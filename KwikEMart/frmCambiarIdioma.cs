using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KwikEMart
{
    public partial class frmCambiarIdioma : Form, IObserver
    {


        private Size originalSizePanel4;
        private Point originalLocationPanel4;

        private Size originalSizePanel5;
        private Point originalLocationPanel5;

        private Size originalSizePanel7;
        private Point originalLocationPanel7;

        private Size originalSizePanel8;
        private Point originalLocationPanel8;

        private Size originalSizePanel9;
        private Point originalLocationPanel9;

        private Size originalSizePanel10;
        private Point originalLocationPanel10;

        private Point originalLocationPanel6;

        private Timer animationTimer;
        private int animationSteps;
        private int animationStepCount;

        public frmCambiarIdioma()
        {
            
            InitializeComponent();
            LenguageManager.ObtenerInstancia().Agregar(this);
            LenguageManager.ObtenerInstancia().Notificar();
            panel4.MouseEnter += new EventHandler(panel4_MouseEnter);
            panel4.MouseLeave += new EventHandler(Panel4_MouseLeave);
            panel5.MouseEnter += new EventHandler(panel5_MouseEnter);
            panel5.MouseLeave += new EventHandler(Panel5_MouseLeave);
            panel7.MouseEnter += new EventHandler(panel7_MouseEnter);
            panel7.MouseLeave += new EventHandler(Panel7_MouseLeave);
            panel8.MouseEnter += new EventHandler(panel8_MouseEnter);
            panel8.MouseLeave += new EventHandler(Panel8_MouseLeave);
            panel9.MouseEnter += new EventHandler(panel9_MouseEnter);
            panel9.MouseLeave += new EventHandler(Panel9_MouseLeave);
            panel10.MouseEnter += new EventHandler(panel10_MouseEnter);
            panel10.MouseLeave += new EventHandler(Panel10_MouseLeave);
            panel6.Visible = false;
            
            originalSizePanel4 = panel4.Size;
            originalLocationPanel4 = panel4.Location;

            originalSizePanel5 = panel5.Size;
            originalLocationPanel5 = panel5.Location;

            originalSizePanel7 = panel7.Size;
            originalLocationPanel7 = panel7.Location;

            originalSizePanel8 = panel8.Size;
            originalLocationPanel8 = panel8.Location;

            originalSizePanel9 = panel9.Size;
            originalLocationPanel9 = panel9.Location;

            originalSizePanel10 = panel10.Size;
            originalLocationPanel10 = panel10.Location;

            originalLocationPanel6 = panel6.Location;

            animationTimer = new Timer();
            animationTimer.Interval = 10; 
            animationTimer.Tick += AnimationTimer_Tick;

            panel4.Click += Panel4_Click;
            panel4.Cursor = Cursors.Hand;

            panel5.Click += Panel5_Click;
            panel5.Cursor = Cursors.Hand;

            panel7.Click += Panel7_Click;
            panel7.Cursor = Cursors.Hand;

            panel8.Click += Panel8_Click;
            panel8.Cursor = Cursors.Hand;

            panel9.Click += Panel9_Click;
            panel9.Cursor = Cursors.Hand;

            panel10.Click += Panel10_Click;
            panel10.Cursor = Cursors.Hand;

        }

        private void panel4_MouseEnter(object sender, EventArgs e)
        {
            int newWidth = (int)(originalSizePanel4.Width * 1.1);
            int newHeight = (int)(originalSizePanel4.Height * 1.1);
            panel4.Size = new Size(newWidth, newHeight);
            panel4.Location = new Point(originalLocationPanel4.X - (newWidth - originalSizePanel4.Width) / 2,
                                        originalLocationPanel4.Y - (newHeight - originalSizePanel4.Height) / 2);

            panel6.Visible = true;

            animationSteps = 8; 
            animationStepCount = 0;
            animationTimer.Start();
        }

        private void Panel4_MouseLeave(object sender, EventArgs e)
        {
            panel4.Size = originalSizePanel4;
            panel4.Location = originalLocationPanel4;

            panel6.Visible = false;

            animationTimer.Stop();
            panel6.Location = originalLocationPanel6;
        }

        private void panel5_MouseEnter(object sender, EventArgs e)
        {
            int newWidth = (int)(originalSizePanel5.Width * 1.1);
            int newHeight = (int)(originalSizePanel5.Height * 1.1);
            panel5.Size = new Size(newWidth, newHeight);
            panel5.Location = new Point(originalLocationPanel5.X - (newWidth - originalSizePanel5.Width) / 2,
                                        originalLocationPanel5.Y - (newHeight - originalSizePanel5.Height) / 2);
        }

        private void Panel5_MouseLeave(object sender, EventArgs e)
        {
            panel5.Size = originalSizePanel5;
            panel5.Location = originalLocationPanel5;
        }

        private void panel7_MouseEnter(object sender, EventArgs e)
        {
            int newWidth = (int)(originalSizePanel7.Width * 1.1);
            int newHeight = (int)(originalSizePanel7.Height * 1.1);
            panel7.Size = new Size(newWidth, newHeight);
            panel7.Location = new Point(originalLocationPanel7.X - (newWidth - originalSizePanel7.Width) / 2,
                                        originalLocationPanel7.Y - (newHeight - originalSizePanel7.Height) / 2);
        }
        private void Panel7_MouseLeave(object sender, EventArgs e)
        {
            panel7.Size = originalSizePanel7;
            panel7.Location = originalLocationPanel7;
        }

        private void panel8_MouseEnter(object sender, EventArgs e)
        {
            int newWidth = (int)(originalSizePanel8.Width * 1.1);
            int newHeight = (int)(originalSizePanel8.Height * 1.1);
            panel8.Size = new Size(newWidth, newHeight);
            panel8.Location = new Point(originalLocationPanel8.X - (newWidth - originalSizePanel8.Width) / 2,
                                        originalLocationPanel8.Y - (newHeight - originalSizePanel8.Height) / 2);
        }

        private void panel9_MouseEnter(object sender, EventArgs e)
        {
            int newWidth = (int)(originalSizePanel9.Width * 1.1);
            int newHeight = (int)(originalSizePanel9.Height * 1.1);
            panel9.Size = new Size(newWidth, newHeight);
            panel9.Location = new Point(originalLocationPanel9.X - (newWidth - originalSizePanel9.Width) / 2,
                                        originalLocationPanel9.Y - (newHeight - originalSizePanel9.Height) / 2);
        }
        private void Panel8_MouseLeave(object sender, EventArgs e)
        {
            panel8.Size = originalSizePanel8;
            panel8.Location = originalLocationPanel8;
        }
        private void Panel9_MouseLeave(object sender, EventArgs e)
        {
            panel9.Size = originalSizePanel9;
            panel9.Location = originalLocationPanel9;
        }

        private void panel10_MouseEnter(object sender, EventArgs e)
        {
            int newWidth = (int)(originalSizePanel10.Width * 1.1);
            int newHeight = (int)(originalSizePanel10.Height * 1.1);
            panel10.Size = new Size(newWidth, newHeight);
            panel10.Location = new Point(originalLocationPanel10.X - (newWidth - originalSizePanel10.Width) / 2,
                                        originalLocationPanel10.Y - (newHeight - originalSizePanel10.Height) / 2);
        }
        private void Panel10_MouseLeave(object sender, EventArgs e)
        {
            panel10.Size = originalSizePanel10;
            panel10.Location = originalLocationPanel10;
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            animationStepCount++;

            int deltaY = -5; 
            panel6.Location = new Point(panel6.Location.X, panel6.Location.Y + deltaY);

            if (animationStepCount >= animationSteps)
            {
                animationTimer.Stop();
            }
        }

        private void Panel4_Click(object sender, EventArgs e)
        {

            SessionManager.GetInstance().IdiomaActual = "Español";
            ActualizarIdioma();
        }

        private void Panel5_Click(object sender, EventArgs e)
        {

            SessionManager.GetInstance().IdiomaActual = "Ingles";
            ActualizarIdioma();
        }

        private void Panel7_Click(object sender, EventArgs e)
        {

            SessionManager.GetInstance().IdiomaActual = "Portugues";
            ActualizarIdioma();
        }

        private void Panel8_Click(object sender, EventArgs e)
        {

            SessionManager.GetInstance().IdiomaActual = "Chino";
            ActualizarIdioma();
        }
        private void Panel9_Click(object sender, EventArgs e)
        {

            SessionManager.GetInstance().IdiomaActual = "Japones";
            ActualizarIdioma();
        }

        private void Panel10_Click(object sender, EventArgs e)
        {

            SessionManager.GetInstance().IdiomaActual = "Klingon";
            ActualizarIdioma();
        }

        public void ActualizarIdioma()
        {
            LenguageManager.ObtenerInstancia().CambiarIdiomaControles(this);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            KwikEMart menu = new KwikEMart();
            menu.Show();
            this.Close();
        }

    }
}
