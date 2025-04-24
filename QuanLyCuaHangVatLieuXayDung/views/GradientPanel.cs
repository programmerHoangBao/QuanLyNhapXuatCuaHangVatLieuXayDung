using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangVatLieuXayDung.views
{
    public class GradientPanel : Panel
    {
        public Color TopColor { get; set; } = Color.FromArgb(44, 62, 80); // Màu trên
        public Color BottomColor { get; set; } = Color.FromArgb(22, 160, 133); // Màu dưới
        public float Angle { get; set; } = 90F; // Góc gradient

        protected override void OnPaint(PaintEventArgs e)
        {
            LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, TopColor, BottomColor, Angle);
            e.Graphics.FillRectangle(brush, this.ClientRectangle);
            base.OnPaint(e);
        }
    }
}
