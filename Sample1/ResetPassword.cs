using MySql.Data.MySqlClient;
using Sample1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmploymentManagementSystem
{
    public partial class ResetPassword : Form
    {
        private SqlConnection mySqlConnection;
        private string userEmail;
        private string newpassword;

        public ResetPassword()
        {
            InitializeComponent();
            DashBoard DH = new DashBoard();
            string mysqlconn = DH.mysqlconn; //"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\DMUIC\\LEVEL 1\\Visual Web Develoment\\Projects\\Sample1\\Sample1\\Employee_m_s.mdf;Integrated Security=True"; // collecting all the databse details 
            mySqlConnection = new SqlConnection(mysqlconn); // creating a new object from the class MySqlConnection which takas informations from the variable mysqlconn
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu();
            menu.Show();
        }
        private bool updatepassword (string user, string nwpass)
        {
            string query = $"UPDATE users SET Psw = '{nwpass}' WHERE email = '{user}';";
            try
            {
                if (OpenConn())
                {
                    SqlCommand cmd = new SqlCommand(query, mySqlConnection);
                    cmd.ExecuteNonQuery();
                    mySqlConnection.Close();
                    return true;
                    

                }
                else
                {
                    mySqlConnection.Close();
                    return false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(Text, ex.Message);
                mySqlConnection.Close();
                return false;
            }
        }
        private bool OpenConn()
        {
            try
            {
                mySqlConnection.Open();
                return true;
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Connection to the server failed");
                        break;
                    case 1024:
                        MessageBox.Show("Server username or password is incorrect");
                        break;
                }
                return false;
            }
        }
        private bool verification(string a, string b)
        {
            //Registration rg = new Registration();
            //Registration.EmailVerification
            if (a != "" && b != "")
            {
                if (Registration.EmailVerification(a))
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            else
            {
                MessageBox.Show("you need to fill all the Boxes ");
                return false;
            }
        }
        private void btnreset_Click(object sender, EventArgs e)
        {
            userEmail = Username.Text;
            newpassword = NewPassword.Text;
            if(verification(userEmail, newpassword))
            {
                if (updatepassword(userEmail, newpassword))
                {
                    MessageBox.Show($"Password succesfully changed ");
                }
                else
                {
                    MessageBox.Show($"Password unsuccesfully changed ");
                }
            }

        }

        private void ResetPassword_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Menu mn = new Menu();
            mn.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
