using System;
using System.Drawing;
using System.Windows.Forms;

namespace _03_VuNgocLinh
{
    /// <summary>
    /// Theme màu sắc chính thức – Green Ocean Shipping
    /// Dựa trên thương hiệu tại go-shipping.vn (Đại Dương Xanh)
    /// Tác giả: Vũ Ngọc Linh – 03_VuNgocLinh
    /// </summary>
    public static class UITheme
    {
        // ═══════════════════════════════════════════════════════════════
        //  BRAND COLORS – Màu thương hiệu Green Ocean Shipping
        // ═══════════════════════════════════════════════════════════════

        /// <summary>Navy đậm – Header, Title bar, DataGrid header, Panel header</summary>
        public static readonly Color Navy = Color.FromArgb(11, 61, 120);   // #0B3D78

        /// <summary>Blue chính – Nút Primary, tab active, accent line</summary>
        public static readonly Color Primary = Color.FromArgb(21, 101, 192);  // #1565C0

        /// <summary>Blue trung – Ribbon bar background, hover nút</summary>
        public static readonly Color PrimaryMid = Color.FromArgb(25, 118, 210); // #1976D2

        /// <summary>Blue nhạt – Selected row DataGrid, selected state</summary>
        public static readonly Color PrimaryLight = Color.FromArgb(187, 222, 251);// #BBDEFB

        /// <summary>Blue rất nhạt – Info panel background, highlight box</summary>
        public static readonly Color PrimaryXLight = Color.FromArgb(227, 242, 253);// #E3F2FD

        /// <summary>Teal accent – Dashboard stats, icon accent</summary>
        public static readonly Color Teal = Color.FromArgb(0, 131, 143);  // #00838F

        // ═══════════════════════════════════════════════════════════════
        //  NEUTRAL – Màu nền & bề mặt
        // ═══════════════════════════════════════════════════════════════

        /// <summary>Background workspace – nền toàn bộ form</summary>
        public static readonly Color Background = Color.FromArgb(238, 242, 247);// #EEF2F7

        /// <summary>Surface – nền card, panel, popup</summary>
        public static readonly Color Surface = Color.White;

        /// <summary>Text chính (ĐÃ DÙNG trong project – giữ nguyên)</summary>
        public static readonly Color TextPrimary = Color.FromArgb(28, 48, 70);   // #1C3046

        /// <summary>Text phụ – Label, thông tin phụ, placeholder</summary>
        public static readonly Color TextSecondary = Color.FromArgb(84, 110, 122); // #546E7A

        /// <summary>Text mờ – Disabled, hint text</summary>
        public static readonly Color TextLight = Color.FromArgb(144, 164, 174);// #90A4AE

        /// <summary>Text màu tối (dùng cho tiêu đề, label đậm)</summary>
        public static readonly Color TextDark = Color.FromArgb(28, 48, 70); // #1C3046 (same as TextPrimary)

        /// <summary>Text mờ (dùng cho label phụ, disabled, hint...)</summary>
        public static readonly Color TextMuted = Color.FromArgb(144, 164, 174); // #90A4AE (same as TextLight)

        /// <summary>Border – Viền panel, textbox, grid cell</summary>
        public static readonly Color Border = Color.FromArgb(207, 216, 220);// #CFD8DC

        /// <summary>Viền nhạt (dùng cho border phụ, textbox, panel...)</summary>
        public static readonly Color BorderLight = Color.FromArgb(224, 224, 224); // #E0E0E0

        /// <summary>Row xen kẽ DataGridView</summary>
        public static readonly Color RowAlternate = Color.FromArgb(240, 247, 255);// #F0F7FF

        /// <summary>Màu chữ trắng – sử dụng cho nút, tiêu đề sáng</summary>
        public static readonly Color TextWhite = Color.White;

        /// <summary>Màu nền xanh da trời nhạt – có thể sử dụng cho các panel thông tin, nền mục</summary>
        public static readonly Color BackgroundBlue = Color.FromArgb(210, 235, 252); // hoặc màu bạn muốn

        /// <summary>Màu nền sáng – sử dụng cho nền form, panel chính</summary>
        public static readonly Color BackgroundLight = Color.FromArgb(235, 245, 251); // hoặc màu bạn muốn

        /// <summary>Xanh đại dương – màu thương hiệu bổ sung, có thể dùng cho các nút hoặc điểm nhấn</summary>
        public static readonly Color OceanBlue = Color.FromArgb(0, 120, 180); // hoặc màu bạn muốn

        // ═══════════════════════════════════════════════════════════════
        //  SEMANTIC – Màu ngữ nghĩa
        // ═══════════════════════════════════════════════════════════════

        public static readonly Color Success = Color.FromArgb(46, 125, 50);  // #2E7D32
        public static readonly Color SuccessLight = Color.FromArgb(232, 245, 233);// #E8F5E9
        public static readonly Color Danger = Color.FromArgb(198, 40, 40);  // #C62828 (thay DarkRed)
        public static readonly Color DangerLight = Color.FromArgb(255, 235, 238);// #FFEBEE
        public static readonly Color Warning = Color.FromArgb(245, 127, 23); // #F57F17

        // ═══════════════════════════════════════════════════════════════
        //  FONTS
        // ═══════════════════════════════════════════════════════════════

        public static readonly Font FontTitle = new Font("Segoe UI", 14f, FontStyle.Bold);
        public static readonly Font FontHeading = new Font("Segoe UI", 11f, FontStyle.Bold);
        public static readonly Font FontBody = new Font("Segoe UI", 10f, FontStyle.Regular);
        public static readonly Font FontSmall = new Font("Segoe UI", 9f, FontStyle.Regular);
        public static readonly Font FontBold = new Font("Segoe UI", 10f, FontStyle.Bold);
        public static readonly Font FontMono = new Font("Consolas", 9.5f, FontStyle.Regular);

        // ═══════════════════════════════════════════════════════════════
        //  BUTTON HELPERS
        // ═══════════════════════════════════════════════════════════════

        /// <summary>Nút Primary – xanh đại dương (dùng cho: Lưu, Thêm, Tạo đơn)</summary>
        public static void ApplyPrimaryButton(Button btn)
        {
            btn.BackColor = Primary;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = PrimaryMid;
            btn.FlatAppearance.MouseDownBackColor = Navy;
            btn.Font = FontBody;
            btn.Cursor = Cursors.Hand;
        }

        /// <summary>Nút Danger – đỏ đậm (dùng cho: Xóa, Hủy)</summary>
        public static void ApplyDangerButton(Button btn)
        {
            btn.BackColor = Danger;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(211, 47, 47);
            btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(183, 28, 28);
            btn.Font = FontBody;
            btn.Cursor = Cursors.Hand;
        }

        /// <summary>Nút Success – xanh lá (dùng cho: Xác nhận, Duyệt, Xuất)</summary>
        public static void ApplySuccessButton(Button btn)
        {
            btn.BackColor = Success;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(56, 142, 60);
            btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(27, 94, 32);
            btn.Font = FontBody;
            btn.Cursor = Cursors.Hand;
        }

        /// <summary>Nút Ghost – trắng viền (dùng cho: nút phụ, Hủy thao tác)</summary>
        public static void ApplyGhostButton(Button btn)
        {
            btn.BackColor = Color.White;
            btn.ForeColor = TextPrimary;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = Border;
            btn.FlatAppearance.MouseOverBackColor = Background;
            btn.FlatAppearance.MouseDownBackColor = PrimaryXLight;
            btn.Font = FontBody;
            btn.Cursor = Cursors.Hand;
        }

        /// <summary>Nút Ribbon (toolbar) – icon button trong ribbon bar</summary>
        public static void ApplyRibbonButton(Button btn, bool isActive = false)
        {
            btn.BackColor = isActive ? PrimaryXLight : Color.White;
            btn.ForeColor = isActive ? Primary : TextPrimary;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = isActive ? Primary : Border;
            btn.FlatAppearance.MouseOverBackColor = PrimaryXLight;
            btn.FlatAppearance.MouseDownBackColor = PrimaryLight;
            btn.Font = FontSmall;
            btn.Cursor = Cursors.Hand;
        }

        // ═══════════════════════════════════════════════════════════════
        //  DATAGRIDVIEW HELPER
        // ═══════════════════════════════════════════════════════════════

        /// <summary>Áp dụng toàn bộ style cho DataGridView</summary>
        public static void ApplyDataGrid(DataGridView dgv)
        {
            // Header row
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Navy;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = FontBold;
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(4, 6, 4, 6);
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.ColumnHeadersHeight = 36;

            // Normal rows
            dgv.DefaultCellStyle.BackColor = Surface;
            dgv.DefaultCellStyle.ForeColor = TextPrimary;
            dgv.DefaultCellStyle.SelectionBackColor = PrimaryLight;
            dgv.DefaultCellStyle.SelectionForeColor = TextPrimary;
            dgv.DefaultCellStyle.Font = FontBody;
            dgv.DefaultCellStyle.Padding = new Padding(2, 5, 2, 5);

            // Alternating rows
            dgv.AlternatingRowsDefaultCellStyle.BackColor = RowAlternate;

            // Grid appearance
            dgv.GridColor = Border;
            dgv.BackgroundColor = Background;
            dgv.BorderStyle = BorderStyle.FixedSingle;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            // Behavior
            dgv.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.RowTemplate.Height = 32;
        }

        // ═══════════════════════════════════════════════════════════════
        //  TEXTBOX / INPUT HELPERS
        // ═══════════════════════════════════════════════════════════════

        public static void ApplyTextBox(TextBox txt)
        {
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.Font = FontBody;
            txt.ForeColor = TextPrimary;
            txt.BackColor = Surface;
        }

        public static void ApplyComboBox(ComboBox cmb)
        {
            cmb.FlatStyle = FlatStyle.Flat;
            cmb.Font = FontBody;
            cmb.ForeColor = TextPrimary;
            cmb.BackColor = Surface;
        }

        // ═══════════════════════════════════════════════════════════════
        //  PANEL / FORM HELPERS
        // ═══════════════════════════════════════════════════════════════

        /// <summary>Áp dụng panel header Navy (trên cùng của section)</summary>
        public static void ApplySectionHeader(Panel pnl, Label lblTitle = null)
        {
            pnl.BackColor = Navy;
            if (lblTitle != null)
            {
                lblTitle.ForeColor = Color.White;
                lblTitle.Font = FontHeading;
            }
        }

        /// <summary>Áp dụng nền workspace cho form/panel chứa</summary>
        public static void ApplyWorkspace(Control ctrl)
        {
            ctrl.BackColor = Background;
        }

        // ═══════════════════════════════════════════════════════════════
        //  TAB CONTROL – FrmMain ribbon
        // ═══════════════════════════════════════════════════════════════

        /// <summary>
        /// Cập nhật màu tab title bar khi người dùng click tab.
        /// Gọi trong mỗi btnXxxTitle_Click handler.
        /// </summary>
        public static void SetActiveTabButton(Button activeBtn, params Button[] allBtns)
        {
            foreach (var btn in allBtns)
            {
                btn.BackColor = PrimaryMid;
                btn.ForeColor = Color.White;
                btn.FlatAppearance.BorderSize = 0;
            }
            activeBtn.BackColor = Surface;
            activeBtn.ForeColor = Primary;
        }

        // ═══════════════════════════════════════════════════════════════
        //  LOGIN FORM – FrmLogin specific
        // ═══════════════════════════════════════════════════════════════

        /// <summary>
        /// Áp dụng style cho panel bên trái FrmLogin (brand panel).
        /// Cần vẽ gradient trong Paint event của panel.
        /// </summary>
        public static void PaintLoginBrandPanel(Panel pnl, System.Windows.Forms.PaintEventArgs e)
        {
            using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                pnl.ClientRectangle,
                Navy,
                Primary,
                System.Drawing.Drawing2D.LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, pnl.ClientRectangle);
            }
        }

        // ═══════════════════════════════════════════════════════════════
        //  APPLY ALL – Áp dụng nhanh toàn bộ form
        // ═══════════════════════════════════════════════════════════════

        /// <summary>
        /// Duyệt đệ quy tất cả controls trong form và áp dụng theme.
        /// Gọi ở cuối Form_Load: UITheme.ApplyAll(this);
        /// </summary>
        public static void ApplyAll(Control root)
        {
            foreach (Control ctrl in root.Controls)
            {
                if (ctrl is DataGridView dgv)
                    ApplyDataGrid(dgv);
                else if (ctrl is TextBox txt)
                    ApplyTextBox(txt);
                else if (ctrl is ComboBox cmb)
                    ApplyComboBox(cmb);
                else if (ctrl is Label lbl && lbl.Tag?.ToString() == "header")
                {
                    lbl.ForeColor = Color.White;
                    lbl.Font = FontHeading;
                }

                // Recurse into panels/groupboxes
                if (ctrl.HasChildren)
                    ApplyAll(ctrl);
            }
        }

        /// <summary>
        /// Áp dụng theme cho control (alias cho ApplyAll)
        /// </summary>
        public static void Apply(Control ctrl) => ApplyAll(ctrl);
    }
}