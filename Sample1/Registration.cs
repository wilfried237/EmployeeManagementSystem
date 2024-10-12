using EmploymentManagementSystem;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sample1
{
    public partial class Registration : Form
    {
        private SqlConnection mySqlConnection;
        /*private string server;
        private string user;
        private string database;
        private string password;*/
        private string firstname;
        public string dirstname
        {
            get { return firstname; }
            set { firstname = value; }
        }
        string Exception1 = "Error \n fill in all the boxes ";
        public Registration()
        {
            InitializeComponent();
            // First method 
            DashBoard DH = new DashBoard();
            string mysqlconn = DH.mysqlconn; //"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\DMUIC\\LEVEL 1\\Visual Web Develoment\\Projects\\Sample1\\Sample1\\Employee_m_s.mdf;Integrated Security=True"; // collecting all the databse details 
            mySqlConnection = new SqlConnection(mysqlconn); // creating a new object from the class MySqlConnection which takas informations from the variable mysqlconn
            
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

            // Second method 
            /*server = "localhost";
            user = "root";
            database = "employment_m_s";
            password = "";
            string conString;
            conString = $"SERVER={server}; DATABASE={database};USER={user};PASSWORD={password};";*/
            // Set up the MySQL connection

        }

        private void btnmenu_Click(object sender, EventArgs e)
        {
            this.Close();
            Menu menu = new Menu();
            menu.Show();
        }
        public static bool EmailVerification(string a)
        {
            int flag = 0;
            char p= '@';
            for (int i = 0; i < a.Length; i++)
            {
                if( p != a[i])
                {
                    flag += 0;
                }
                else
                {
                    flag += 1;
                }
            }
            if (flag == 1)
            {
                if (a.EndsWith("@gmail.com"))
                {
                    return true;
                }
                else 
                {
                    MessageBox.Show("Enter a Gmail Account ");
                    return false;
                }
                //MessageBox.Show("");
            }
            else if(flag == 0)
            {
                MessageBox.Show("Please Enter a valide Email address since no @ was found ");
                return false;
            }
            else if(flag > 1)
            {
                MessageBox.Show("Error multiple @ was found ");
                return false;
            }
            else
            {
                return false;
            }
        }
        private static bool verification(string a, string b, string c , string d ,string e)
        {
            if(a!="" && b!="" && c!="" && d!="" && e!= ""  )
            {
                if(e == d) 
                {
                   if(EmailVerification(c))
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show(" Email address got a mistake ");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Password doesnot match");
                    return false;
                }
                
            }
            else
            {
                MessageBox.Show(" Fill in all the boxes ");
                return false;
            }
        }

        private void btnrgt_Click(object sender, EventArgs e) { 
            firstname = Firstname.Text;
            string lastname = LastName.Text;
            string email = Email.Text;
            string psw = Psw.Text;
            string psw1 = Psw1.Text;

            if (verification(firstname, lastname, email, psw , psw1))
            {
                if (registrations(firstname, lastname, email, psw))
                {
                    MessageBox.Show($"User {dirstname} has been created ");
                    this.Close();
                    Login login = new Login();
                    login.Show();
                }
                else
                {
                    MessageBox.Show($"User {Firstname} has not been created ");
                }
            }
          /*  else
            {
                
                MessageBox.Show(" Error occured ");
            }*/



            /*  //Add parameter to the SQL query
              command.Parameters.AddWithValue("@firstname",Firstname.Text);
              command.Parameters.AddWithValue("@lastname", LastName.Text);
              command.Parameters.AddWithValue("@email",Email.Text);
              command.Parameters.AddWithValue("@Psw", Psw.Text);
              command.Parameters.AddWithValue("@Psw1", Psw1.Text);

              // Execute the query

              int result = command.ExecuteNonQuery();

              // Close the MySQL connection
              mySqlConnection.Close();
              //MySqlCommand command = new MySqlCommand("SELECT * "); */

        }
        private bool registrations(string firstname, string lastname, string email, string psw)
        {
            // Prepare the SQL query
            string query = $"INSERT INTO users (firstname,lastname,email,Psw) VALUES('{firstname}','{lastname}','{email}','{psw}');";
            try
            {
                if (ConOpen())
                {
                    SqlCommand command = new SqlCommand(query, mySqlConnection);
                    try
                    {
                        command.ExecuteNonQuery();
                        mySqlConnection.Close();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(Text, ex.Message);
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
                MessageBox.Show(Text , ex.Message);
                mySqlConnection.Close();
                return false;
            }

        }


        private bool ConOpen()
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

        private void Registration_Load(object sender, EventArgs e)
        {

        }

        private void Firstname_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Email_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Menu mn = new Menu();
            mn.Show();
            this.Close();
        }

        private void Psw1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
