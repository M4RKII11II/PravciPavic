using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PravciPavic
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			double k1=(double)numericUpDown1.Value;
			double l1=(double)numericUpDown2.Value;
			double k2=(double)numericUpDown3.Value;
			double l2=(double)numericUpDown4.Value;

			double x, y;

			if(RjesiSustav(k1, l1, k2, l2, out x, out y))
			{
				textBox1.Text = $"({x},{y})";
				pbGrafika.Invalidate();
			}
			else
			{
				textBox1.Text = "Pravci su paralelni.";
			}
		}

		static bool RjesiSustav(double k1, double l1, double k2, double l2, out double x, out double y)
		{
			double determinanta = k1 - k2;

			if (determinanta == 0)
			{
				x = 0;
				y = 0;
				return false;
			}
			else
			{
				x = (l2 - l1) / determinanta;
				y = k1 * x + l1;
				x = Math.Round(x,2);
				y = Math.Round(y,2);
				return true;
			}
		}

		private void pbGrafika_Paint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;

			double k1 = (double)numericUpDown1.Value;
			double l1 = (double)numericUpDown2.Value;
			double k2 = (double)numericUpDown3.Value;
			double l2 = (double)numericUpDown4.Value;

			int width = pbGrafika.Width;
			int height = pbGrafika.Height;

			Pen blackPen = new Pen(Color.Black, 2);
			g.DrawLine(blackPen, width / 2, 0, width / 2, height);
			g.DrawLine(blackPen, 0, height / 2, width, height / 2);


			Pen pen1 = new Pen(Color.Blue, 2);
			double x1 = -width / 2;
			double y1 = -k1 * x1 + l1;
			x1 += width / 2;
			y1 = height / 2 - y1;
			double x2 = width / 2;
			double y2 = -k1 * x2 + l1;
			x2 += width / 2;
			y2 = height / 2 - y2;
			g.DrawLine(pen1, (float)x1, (float)y1, (float)x2, (float)y2);

			Pen pen2 = new Pen(Color.Red, 2);
			x1 = -width / 2;
			y1 = -k2 * x1 + l2;
			x1 += width / 2;
			y1 = height / 2 - y1;
			x2 = width / 2;
			y2 = -k2 * x2 + l2;
			x2 += width / 2;
			y2 = height / 2 - y2;
			g.DrawLine(pen2, (float)x1, (float)y1, (float)x2, (float)y2);
		}
	}
}
