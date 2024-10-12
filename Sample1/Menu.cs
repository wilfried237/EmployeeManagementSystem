using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Sample1
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            //string mysqlconn = "server=localhost;user=root;database=employment_m_s;password="; // collecting all the databse details 
            //MySqlConnection mySqlConnection = new MySqlConnection(mysqlconn); // creating a new object from the class MySqlConnection which takas informations from the variable mysqlconn

            //try
            /*{
                mySqlConnection.Open(); // we are opening the connection between visual studio and our data base which is Mysql
                MessageBox.Show("Succesful");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                mySqlConnection.Close(); // we are closing our connection after the process is complete because after openning connection we need to close it 
            }
            */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registration registration = new Registration();
            registration.Show();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
