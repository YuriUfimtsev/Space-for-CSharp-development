using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Clock
{
    public partial class ClockForm : Form
    {
        public ClockForm()
        {
            InitializeComponent();
            graphics = CreateGraphics();
            timer = new Timer();
            circle = new Rectangle(0, 0, 250, 250);
            penForRectangle = new Pen(Color.Black, 2);
            hourHand = new Pen(Color.Black, 3);
            hourHand.CustomEndCap = new AdjustableArrowCap(5, 5);
            minuteHand = new Pen(Color.Black, 3);
            minuteHand.CustomEndCap = new AdjustableArrowCap(4, 4);
            secondHand = new Pen(Color.Black, 4);
            secondHand.CustomEndCap = new AdjustableArrowCap(3, 3);
        }

        Graphics graphics;
        Timer timer;
        Pen hourHand;
        Pen minuteHand;
        Pen secondHand;
        Rectangle circle;
        Pen penForRectangle;

        private void ClockPaint(object sender, PaintEventArgs e)
        {
            graphics.DrawEllipse(penForRectangle, circle);
            graphics.DrawLine(hourHand, 125, 125,
                125 + 90 * (float)Math.Sin((2 * Math.PI / 12 * (DateTime.Now.Hour % 12))),
                125 - 90 * (float)Math.Cos((2 * Math.PI / 12 * (DateTime.Now.Hour % 12))));
            graphics.DrawLine(minuteHand, 125, 125,
                125 + 110 * (float)Math.Sin(2 * Math.PI / 60 * DateTime.Now.Minute),
                125 - 110 * (float)Math.Cos((2 * Math.PI / 60 * DateTime.Now.Minute)));
            graphics.DrawLine(secondHand, 125, 125,
                125 + 125 * (float)Math.Cos(2 * Math.PI / 60 * DateTime.Now.Second),
                125 + 125 * (float)Math.Sin((2 * Math.PI / 60 * DateTime.Now.Second)));
        }

        private void SecondTimerTick(object sender, EventArgs e)
        {
            graphics.Clear(Color.White);
            graphics.DrawEllipse(penForRectangle, circle);
            graphics.DrawLine(hourHand, 125, 125,
                125 + 90 * (float)Math.Sin(2 * Math.PI / 12 * (DateTime.Now.Hour % 12)),
                125 - 90 * (float)Math.Cos((2 * Math.PI / 12 * (DateTime.Now.Hour % 12))));
            graphics.DrawLine(minuteHand, 125, 125,
                125 + 110 * (float)Math.Sin(2 * Math.PI / 60 * DateTime.Now.Minute),
                125 - 110 * (float)Math.Cos((2 * Math.PI / 60 * DateTime.Now.Minute)));
            graphics.DrawLine(secondHand, 125, 125,
                125 + 125 * (float)Math.Sin(2 * Math.PI / 60 * DateTime.Now.Second),
                125 - 125 * (float)Math.Cos((2 * Math.PI / 60 * DateTime.Now.Second)));
        }
    }
}
