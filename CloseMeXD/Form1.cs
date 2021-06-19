using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CloseMeXD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            GlobalMouseHandler gmh = new GlobalMouseHandler();
            gmh.TheMouseMoved += new MouseMovedEvent(gmh_TheMouseMoved);
            Application.AddMessageFilter(gmh);
            this.FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
        }

        private void btnFunct1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("YU AR IDIOT AH AH AH AHAHAHAAAHAHAHAAA!");
            Form1 frm = new Form1();
            frm.Show();
        }

        void gmh_TheMouseMoved()
        {
            Point cur_pos = System.Windows.Forms.Cursor.Position;
            progressBar1.Increment(1);
            //1366 - X
            //768 - Y
            int countX = cur_pos.X - this.Location.X;
            if(countX <=100)
                this.Location = new Point(this.Location.X+100, this.Location.Y);
            else
                this.Location = new Point(this.Location.X - 100, this.Location.Y);

            int countY = cur_pos.Y - this.Location.Y;
            if (countY <= 100)
                this.Location = new Point(this.Location.X, this.Location.Y + 100);
            else
                this.Location = new Point(this.Location.X , this.Location.Y - 100);
            if (this.Location.X <= 0 || this.Location.X >= 1366)
            {
                if (this.Location.X >= 1366)
                    this.Location = new Point(this.Location.X - 500, this.Location.Y + 100);
                if (this.Location.X <= 0)
                    this.Location = new Point(this.Location.X + 500, this.Location.Y + 100);
            }
            if (this.Location.Y <= 0 || this.Location.Y >= 768)
            {
                if(this.Location.Y >= 768)
                    this.Location = new Point(this.Location.X, this.Location.Y - 400);
                if (this.Location.Y <= 0)
                    this.Location = new Point(this.Location.X, this.Location.Y + 400);
            }

            //MessageBox.Show(this.Location.ToString());
        }
    }
    public delegate void MouseMovedEvent();

    public class GlobalMouseHandler : IMessageFilter
    {
        private const int WM_MOUSEMOVE = 0x0200;

        public event MouseMovedEvent TheMouseMoved;

        #region IMessageFilter Members

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == WM_MOUSEMOVE)
            {
                if (TheMouseMoved != null)
                {
                    TheMouseMoved();
                }
            }
            // Always allow message to continue to the next filter control
            return false;
        }

        #endregion
    }
}
