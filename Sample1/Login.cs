using EmploymentManagementSystem;
using MySql.Data.MySqlClient;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Sample1
{
    public partial class Login : Form
    {
        private SqlConnection mySqlConnection;
        public string user;
        private string password;
      /*  public string bser
        {
            get { return user; }
            set { user = value; }
        }*/
        public Login()
        {

            InitializeComponent();
            // First method 
            DashBoard DB = new DashBoard();
            string mysqlconn = DB.mysqlconn; //"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\DMUIC\\LEVEL 1\\Visual Web Develoment\\Projects\\Sample1\\Sample1\\Employee_m_s.mdf;Integrated Security=True"; // collecting all the databse details 
            mySqlConnection = new SqlConnection(mysqlconn); // creating a new object from the class MySqlConnection which takas informations from the variable mysqlconn

        }

        private void btnrgt_Click(object sender, EventArgs e)
        {
            this.Hide();// hide the actual page
            Registration registration = new Registration(); // creating an object from the class Registration
            registration.Show(); // new form will be displayed
        }

        private bool loginId(string user,string password)
        {
            string query = $"SELECT * FROM users WHERE  email = '{user}' AND psw = '{password}';";
            try
            {
                if (OpenConn())
                {
                    SqlCommand cmd = new SqlCommand(query, mySqlConnection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        reader.Close();
                        mySqlConnection.Close();
                        return true;
                    }

                    else
                    {
                        reader.Close();
                        mySqlConnection.Close();
                        return false;
                    }
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
            catch(MySqlException ex)
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
        private bool verification(string a,string b)
        {
            if (a!="" && b!="")
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
                MessageBox.Show("Fill in all the boxes ");
                return false;
            }
        }
        private void btnlg_Click(object sender, EventArgs e)
        {
            user = User.Text;
            //bser = User.Text;
            password = psw.Text;
            if (verification(user,password))
            {
            
                if (loginId( user , password))
                {
                    MessageBox.Show($"welcome {user}");
                    this.Close();
                    DashBoard ds = new DashBoard();
                    //ds.ruser = bser;
                    ds.Show();
                }

                else 
                {
                    MessageBox.Show($"{user} doesnot match");
                }

            }         
        }

        private void Firstname_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ResetPassword rs = new ResetPassword();
            rs.Show();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            ResetPassword rs = new ResetPassword();
            rs.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Registration rg = new Registration();
            rg.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Menu mn = new Menu();
            mn.Show();
            this.Hide();
        }
    }
}
