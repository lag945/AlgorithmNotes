using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Geometry;

namespace LineSegmentIntersection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        List<LineSegment[]> m_Case = new List<LineSegment[]>();
        private void Form1_Shown(object sender, EventArgs e)
        {
            m_Case.Add(new LineSegment[] { new LineSegment(100, 200, 300, 400), new LineSegment(300, 400, 500, 400) });
            m_Case.Add(new LineSegment[] { new LineSegment(100, 200, 300, 400), new LineSegment(300.0000000001, 400, 500, 400) });
            m_Case.Add(new LineSegment[] { new LineSegment(100, 200, 300, 400), new LineSegment(150, 350, 500, 400) });
            m_Case.Add(new LineSegment[] { new LineSegment(100, 200, 300, 400), new LineSegment(280, 350, 500, 400) });
            m_Case.Add(new LineSegment[] { new LineSegment(100, 200, 300, 400), new LineSegment(50, 100, 150, 200) });
            m_Case.Add(new LineSegment[] { new LineSegment(400, 300, 500, 100), new LineSegment(200, 150, 300, 50) });
            m_Case.Add(new LineSegment[] { new LineSegment(100, 100, 200, 100), new LineSegment(300, 100, 400, 100) });
            m_Case.Add(new LineSegment[] { new LineSegment(100, 50, 100, 200), new LineSegment(100, 250, 100, 350) });
            m_Case.Add(new LineSegment[] { new LineSegment(100, 200, 200, 200), new LineSegment(100, 300, 200, 300) });
            m_Case.Add(new LineSegment[] { new LineSegment(100, 100, 100, 200), new LineSegment(300, 100, 300, 300) });
            m_Case.Add(new LineSegment[] { new LineSegment(100, 100, 200, 100), new LineSegment(150, 100, 250, 100) });
            m_Case.Add(new LineSegment[] { new LineSegment(100, 100, 200, 100), new LineSegment(50, 100, 125, 100) });
            m_Case.Add(new LineSegment[] { new LineSegment(100, 200, 300, 400), new LineSegment(100, 200, 300, 400) });
            m_Case.Add(new LineSegment[] { new LineSegment(300, 400, 500, 400), new LineSegment(300, 400, 500, 400) });
            m_Case.Add(new LineSegment[] { new LineSegment(121.15911642918839, 24.968016690356002, 121.15937469481834, 24.967883615161917), new LineSegment(121.15922468211113, 24.967664283474676, 121.15922468211113, 24.968041789545012) });
            m_Case.Add(new LineSegment[] { new LineSegment(121.15, 24.96, 121.15, 24.96), new LineSegment(121.15, 24.96, 121.15, 24.96) });

            comboBox1.Items.AddRange(m_Case.ToArray());
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0)
            {
                LineSegment[] lines = m_Case[comboBox1.SelectedIndex];
                //左下(0,0) 
                double ht = e.ClipRectangle.Height;
                Geometry.Point point = new Geometry.Point();
                IntersectionStatus status = IntersectionStatus.None;
                bool intersective = lines[0].IsIntersect(lines[1], ref point, ref status);
                e.Graphics.DrawString((intersective ? "相交" : "未相交") + status.ToString(), new Font("微軟正黑體", 20), new SolidBrush(Color.Black), 100, 100);
                e.Graphics.DrawLine(new Pen(Color.Red, 2), (float)lines[0].From.X, (float)(ht - lines[0].From.Y), (float)lines[0].To.X, (float)(ht - lines[0].To.Y));
                e.Graphics.DrawLine(new Pen(Color.Blue, 2), (float)lines[1].From.X, (float)(ht - lines[1].From.Y), (float)lines[1].To.X, (float)(ht - lines[1].To.Y));
                if (intersective)
                {
                    e.Graphics.FillEllipse(new SolidBrush(Color.Green),(float) point.X - 5, (float)(ht-(point.Y + 5)), 10, 10);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}
