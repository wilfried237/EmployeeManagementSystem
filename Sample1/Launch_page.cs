using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Diagnostics.Metrics;
using Sample1;

namespace EmploymentManagementSystem
{
    public partial class Launch_page : Form
    {
        private static System.Timers.Timer aTimer;
        public Launch_page()
        {
            InitializeComponent();
            //percentage();
            
        }

        private void Percentage_Click(object sender, EventArgs e)
        {

        }
        private int Counter;


        private void Launch_page_Load(object sender, EventArgs e)
        {
                aTimer = new System.Timers.Timer();
                aTimer.Interval = 100;
                aTimer.Elapsed += OnTimeEvent;
                aTimer.Start();
        }

        private void OnTimeEvent(object sender, ElapsedEventArgs e)
        {
                Invoke(new Action(() => {
                Counter += 1;
                if(Counter == 100)
                {
                    aTimer.Stop();
                    this.Hide();
                    Menu mn = new Menu();
                    mn.Show();
                    
                }
                Percentage.Text=Counter.ToString()+"%";
            
            }));
        }
    }
}
