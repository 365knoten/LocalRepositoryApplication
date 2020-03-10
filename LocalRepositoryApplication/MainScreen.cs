using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocalRepositoryApplication
{
    public partial class MainScreen : Form
    {


        public MainScreen()
        {
            InitializeComponent();
            WindowState = FormWindowState.Minimized;
            Hide();
        }
        private delegate void LogDelegate(string message);

        public void log(string message)
        {
            if (this.InvokeRequired)
            {
                // Need for invoke if called from a different thread

                  BeginInvoke(
                      new LogDelegate(log), new object[] { message}                   
                    );


            }
            else
            {
                // add this line at the top of the log
                listBox1.Items.Insert(0, message);

                // keep only a few lines in the log
                while (listBox1.Items.Count > 20)
                {
                    listBox1.Items.RemoveAt(listBox1.Items.Count - 1);
                }
            }
        }


        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

   



        private void MainScreen_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
                Hide();
        }


    }
}
