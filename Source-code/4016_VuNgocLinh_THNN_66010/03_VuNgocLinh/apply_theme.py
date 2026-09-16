"""
apply_theme.py — Áp dụng bảng màu Đại Dương Xanh vào toàn bộ project C# WinForms
Chạy: python apply_theme.py
Input : 03_VuNgocLinh.zip (đặt cùng thư mục với script)
Output: 03_VuNgocLinh_themed.zip
"""

import zipfile
import os
import shutil
import re

INPUT_ZIP  = "03_VuNgocLinh.zip"
OUTPUT_ZIP = "03_VuNgocLinh_themed.zip"
TMP_DIR    = "_theme_tmp"

# ─── Bảng màu thương hiệu ───────────────────────────────────────────────────
def argb(r, g, b):
    """Tạo chuỗi System.Drawing.Color.FromArgb(...) theo định dạng Designer.cs"""
    return (
        f"System.Drawing.Color.FromArgb("
        f"((int)(((byte)({r})))), "
        f"((int)(((byte)({g})))), "
        f"((int)(((byte)({b})))))"
    )

NAVY        = argb(28,  54,  100)   # #1C3664 — header, sidebar, status bar
OCEAN_BLUE  = argb(0,  120,  180)   # #0078B4 — ribbon, nút chính
TEAL        = argb(0,  163,  196)   # #00A3C4 — accent
BG_LIGHT    = argb(235, 245, 251)   # #EBF5FB — workspace, nền form
BG_BLUE     = argb(210, 235, 252)   # #D2EBFC — search panel, nút phụ
BORDER_CLR  = argb(200, 221, 237)   # #C8DDED — separator, đường kẻ
GREEN       = argb(39,  174,  96)   # #27AE60 — hoàn thành, thành công
ORANGE      = argb(243, 156,  18)   # #F39C12 — đang xử lý, cảnh báo
RED_CARD    = argb(231,  76,  60)   # #E74C3C — chờ xác nhận, nguy hiểm

# ─── Bảng thay thế màu (tìm → thay) ────────────────────────────────────────
#
# Mỗi entry: (chuỗi CẦN TÌM trong Designer.cs, chuỗi THAY THẾ)
# Thứ tự quan trọng: thay các chuỗi dài/cụ thể trước, tránh partial match.
#
REPLACEMENTS = [
    # ── Các màu hệ thống mặc định ──────────────────────────────────────────
    (
        "System.Drawing.SystemColors.Highlight",
        OCEAN_BLUE
    ),
    (
        "System.Drawing.SystemColors.ActiveCaption",
        OCEAN_BLUE
    ),
    (
        "System.Drawing.SystemColors.GradientInactiveCaption",
        BG_BLUE
    ),
    (
        "System.Drawing.SystemColors.ButtonHighlight",
        BG_LIGHT
    ),
    (
        "System.Drawing.SystemColors.ActiveCaptionText",
        "System.Drawing.Color.White"
    ),

    # ── Màu nền form & panel ───────────────────────────────────────────────
    (
        "System.Drawing.Color.WhiteSmoke",
        BG_LIGHT
    ),
    (
        "System.Drawing.Color.FloralWhite",
        BG_LIGHT
    ),
    (
        "System.Drawing.Color.Ivory",
        "System.Drawing.Color.White"
    ),

    # ── Màu header & status bar ────────────────────────────────────────────
    (
        "System.Drawing.Color.Khaki",          # panel2 (status bar dưới)
        NAVY
    ),
    (
        "System.Drawing.Color.MediumTurquoise", # pnlHeader dashboard
        NAVY
    ),

    # ── Separator ──────────────────────────────────────────────────────────
    (
        "System.Drawing.Color.LightGray",
        BORDER_CLR
    ),

    # ── Search / filter panels ─────────────────────────────────────────────
    (
        "System.Drawing.Color.LightBlue",
        BG_BLUE
    ),

    # ── KPI Cards (Dashboard) ──────────────────────────────────────────────
    (
        "System.Drawing.Color.Plum",           # Card Doanh thu
        OCEAN_BLUE
    ),
    (
        "System.Drawing.Color.PaleTurquoise",  # Card Khách mới
        TEAL
    ),
    (
        "System.Drawing.Color.Honeydew",       # Card Hoàn thành
        GREEN
    ),
    (
        "System.Drawing.Color.Linen",          # Card Đang xử lý
        ORANGE
    ),
    (
        "System.Drawing.Color.MistyRose",      # Card Chờ xác nhận
        RED_CARD
    ),

    # ── Nút báo cáo trong Dashboard ────────────────────────────────────────
    (
        "System.Drawing.Color.PaleGreen",      # Báo cáo NV → Green
        GREEN
    ),
    (
        "System.Drawing.Color.Yellow",         # Báo cáo ĐonDV → Orange
        ORANGE
    ),

    # ── Login form ─────────────────────────────────────────────────────────
    (
        "System.Drawing.Color.DarkRed",        # btnLogin → Ocean Blue
        OCEAN_BLUE
    ),

    # ── Label status màu xanh lá hệ thống → green thương hiệu ─────────────
    (
        "System.Drawing.Color.Green",
        GREEN
    ),
]

# ─── Các file Designer.cs sẽ bị bỏ qua (không phải UI) ─────────────────────
SKIP_PATTERNS = [
    ".vs/",
    "obj/",
    "bin/",
    "DataSet",
    "AssemblyInfo",
    "Resources.Designer",
    "Settings.Designer",
]

def should_skip(path: str) -> bool:
    for pat in SKIP_PATTERNS:
        if pat in path:
            return True
    return False


def apply_replacements(content: str) -> str:
    for old, new in REPLACEMENTS:
        content = content.replace(old, new)
    return content


def process_zip():
    print(f"[1/4] Đọc file: {INPUT_ZIP}")
    if not os.path.exists(INPUT_ZIP):
        print(f"  ✗ Không tìm thấy {INPUT_ZIP}. Đặt file zip cùng thư mục với script.")
        return

    if os.path.exists(TMP_DIR):
        shutil.rmtree(TMP_DIR)
    os.makedirs(TMP_DIR)

    print("[2/4] Giải nén...")
    with zipfile.ZipFile(INPUT_ZIP, 'r') as zin:
        zin.extractall(TMP_DIR)

    print("[3/4] Áp dụng bảng màu...")
    changed_files = []
    all_designer = []

    for root, dirs, files in os.walk(TMP_DIR):
        for fname in files:
            if not fname.endswith("Designer.cs"):
                continue
            full_path = os.path.join(root, fname)
            rel_path  = os.path.relpath(full_path, TMP_DIR)

            if should_skip(rel_path):
                continue

            all_designer.append(rel_path)

            try:
                with open(full_path, 'r', encoding='utf-8-sig') as f:
                    original = f.read()
            except UnicodeDecodeError:
                with open(full_path, 'r', encoding='latin-1') as f:
                    original = f.read()

            modified = apply_replacements(original)

            if modified != original:
                changed_files.append(rel_path)
                with open(full_path, 'w', encoding='utf-8') as f:
                    f.write(modified)

    print(f"  Tổng Designer.cs xử lý: {len(all_designer)}")
    print(f"  File được cập nhật     : {len(changed_files)}")
    for cf in changed_files:
        print(f"    ✓ {cf}")

    print("[4/4] Đóng gói lại...")
    if os.path.exists(OUTPUT_ZIP):
        os.remove(OUTPUT_ZIP)

    with zipfile.ZipFile(OUTPUT_ZIP, 'w', zipfile.ZIP_DEFLATED) as zout:
        for root, dirs, files in os.walk(TMP_DIR):
            for fname in files:
                full_path = os.path.join(root, fname)
                arc_name  = os.path.relpath(full_path, TMP_DIR)
                zout.write(full_path, arc_name)

    shutil.rmtree(TMP_DIR)

    size_kb = os.path.getsize(OUTPUT_ZIP) // 1024
    print(f"\n✅ Hoàn thành! Output: {OUTPUT_ZIP} ({size_kb:,} KB)")
    print("   Mở file trong Visual Studio → Build → chạy để xem kết quả.")


if __name__ == "__main__":
    process_zip()
