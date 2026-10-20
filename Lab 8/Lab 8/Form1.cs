using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Lab_8
{
    public partial class Form1 : Form
    {
        Color currentColor = Color.Black;
        bool isDrawing = false;

        List<DrawItem> listDrawItems = new List<DrawItem>();
        DrawItem currentItem;

        public Form1()
        {
            InitializeComponent();
            cboMode.SelectedIndex = 0; // Mặc định chọn Pen
            CenterTopPanel();
        }

        private void CenterTopPanel()
        {
            functionPanel.Left = (topPanel.Width - functionPanel.Width) / 2;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            CenterTopPanel();
        }

        private void BtnColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog cd = new ColorDialog())
            {
                cd.Color = currentColor;
                if (cd.ShowDialog() == DialogResult.OK)
                {
                    currentColor = cd.Color;
                    btnColor.BackColor = currentColor;
                }
            }
        }

        private void BtnUndo_Click(object sender, EventArgs e)
        {
            if (listDrawItems.Count > 0)
            {
                listDrawItems.RemoveAt(listDrawItems.Count - 1);
                canvas.Invalidate();
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            listDrawItems.Clear();
            canvas.Invalidate();
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrawing = true;
                currentItem = new DrawItem
                {
                    Shape = cboMode.Text,
                    Color = currentColor,
                    Thickness = (float)nudWidth.Value,
                    StartPt = e.Location,
                    EndPt = e.Location
                };

                if (currentItem.Shape == "Pen")
                {
                    currentItem.PathPoints.Add(e.Location);
                }

                listDrawItems.Add(currentItem);
            }
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            lblStatus.Text = $"Tọa độ: X={e.X}, Y={e.Y}";

            if (isDrawing && currentItem != null)
            {
                if (currentItem.Shape == "Pen")
                {
                    currentItem.PathPoints.Add(e.Location);
                }
                else
                {
                    currentItem.EndPt = e.Location;
                }
                canvas.Invalidate();
            }
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false;
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            foreach (var item in listDrawItems)
            {
                using (Pen pen = new Pen(item.Color, item.Thickness))
                {
                    pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                    pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                    pen.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;

                    if (item.Shape == "Pen" && item.PathPoints.Count > 1)
                    {
                        e.Graphics.DrawLines(pen, item.PathPoints.ToArray());
                    }
                    else if (item.Shape == "Line")
                    {
                        e.Graphics.DrawLine(pen, item.StartPt, item.EndPt);
                    }
                    else if (item.Shape == "Rectangle" || item.Shape == "Ellipse")
                    {
                        int x = Math.Min(item.StartPt.X, item.EndPt.X);
                        int y = Math.Min(item.StartPt.Y, item.EndPt.Y);
                        int width = Math.Abs(item.StartPt.X - item.EndPt.X);
                        int height = Math.Abs(item.StartPt.Y - item.EndPt.Y);

                        if (item.Shape == "Rectangle")
                            e.Graphics.DrawRectangle(pen, x, y, width, height);
                        else
                            e.Graphics.DrawEllipse(pen, x, y, width, height);
                    }
                }
            }
        }
    }

    public class DrawItem
    {
        public string Shape { get; set; }
        public Color Color { get; set; }
        public float Thickness { get; set; }
        public Point StartPt { get; set; }
        public Point EndPt { get; set; }
        public List<Point> PathPoints { get; set; } = new List<Point>();
    }

    public class MyCanvas : Panel
    {
        public MyCanvas()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }
    }
}