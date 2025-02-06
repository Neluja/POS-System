using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pos_Systm
{
    public partial class AdminForm : Form
    {

        
        public AdminForm()
        {
            InitializeComponent();
            StartTimer();


        }
        public void loadform(object Form)
        {


            if (this.mainpanel.Controls.Count > 0)
                this.mainpanel.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Right;
            this.mainpanel.Controls.Add(f);
            this.mainpanel.Tag = f;
            f.Show();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void mainpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            loadform(new Adduser());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            loadform(new AddCategory());
        }

        private void mainpanel_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadform(new AddProduct());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadform(new Model());
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            loadform(new Dashboard());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            loadform(new Stock());
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();

            // Show Form1
            form1.Show();

            // Close AdminForm
            this.Close();
        }

        private void btnAllStock_Click(object sender, EventArgs e)
        {
            loadform(new AllStock());
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            /*int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);*/
        }

        private void button5_Click(object sender, EventArgs e)
        {
            loadform(new AddDiscount());
        }

        private void btnSalesReport_Click(object sender, EventArgs e)
        {
            loadform(new SalesReport());
        }

        private void btnPrediction_Click(object sender, EventArgs e)
        {
            loadform(new Prediction());
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        /*private void AdminForm_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
        }*/

        private void StartTimer()
        {
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // 1 second
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
        }
    }
}
