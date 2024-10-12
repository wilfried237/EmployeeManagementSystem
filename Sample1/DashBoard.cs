using MySql.Data.MySqlClient;
using Sample1;
using System;
using System.Collections;
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
    public partial class DashBoard : Form
    {

        private SqlConnection mySqlConnection;
        public string mysqlconn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\DMU\\LEVEL 1\\Visual Web Develoment\\Projects\\Sample1\\Sample1\\Employee_m_s.mdf\";Integrated Security=True"; // collecting all the databse details 
        
        private int departmentid;
        private string firstname;
        private string lastname;
        private string email;
        private string phone;
        private string address;
        private DateTime hiredate;
        private double salary;
        private int age;
        private string sex;

        private int mdepartmentid;
        private string mfirstname;
        private string mlastname;
        private string memail;
        private string mphone;
        private string maddress;
        private DateTime mhiredate;
        private double msalary;
        private int mage;
        private string msex;
        private int memployeeid;
      
        private int pmanagerID;
        private string pname;
        private string pbudget;

        private string dname;
        private string daddress;

        public DashBoard()
        {
            //C:\DMUIC\LEVEL 1\Visual Web Develoment\Projects\Sample1\Sample1\Employee_m_s.mdf
            InitializeComponent();
            //string mysqlconn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\DMUIC\\LEVEL 1\\Visual Web Develoment\\Projects\\Sample1\\Sample1\\Employee_m_s.mdf;Integrated Security=True"; // collecting all the databse details 
            mySqlConnection = new SqlConnection(mysqlconn); // creating a new object from the class MySqlConnection which takas informations from the variable mysqlconn
            fillcombo(mysqlconn);
            bindData(mysqlconn);
            fillcomboM(mysqlconn);
            bindDataM(mysqlconn);
            bindDataD(mysqlconn);
            bindDataP(mysqlconn);
            button5.ForeColor = Color.Black;
            Employee_button.ForeColor = Color.SandyBrown;
            Manager_button.ForeColor = Color.SpringGreen;
            Department_button.ForeColor = Color.Indigo;
            Project_button.ForeColor = Color.IndianRed;
            //Remail.Text = Login.bser.ToString();
            //Login lg = new Login();
            // Remail.Text = lg.bser;


        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            menu_dashboard.Hide();
            Project_button.ForeColor = Color.White;
            Employee_button.ForeColor = Color.White;
            Manager_button.ForeColor = Color.White;
            Department_button.ForeColor = Color.White;
            button5.ForeColor = Color.Black;

            if (MessageBox.Show(" Do you want to LogOut ","Exit message", MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.Yes)
            {
                this.Hide();
                Login login = new Login();
                login.Show();

            }
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
        
        private bool createManager()
        {
           mdepartmentid = int.Parse(Mdepartment.Text);
            mfirstname = MFirstname.Text;
            mlastname = Mlastname.Text;
            memail = Memail.Text;
            mphone = Mphone.Text;
            maddress = Maddress.Text;
            msalary = int.Parse(Msalary.Text);
            mage = int.Parse(Mages.Text);
            memployeeid = int.Parse(Employee_combo_box.Text);

            string query = $"INSERT INTO manager (mdepartmentID,mfirstname,mlastname,memail,mphone,maddress,mhireDate,msalary,age,sex,memployeeID) VALUES ('{mdepartmentid}','{mfirstname}','{mlastname}','{memail}','{mphone}','{maddress}','{this.Mhiredate.Value.ToString()}','{msalary}','{mage}','{msex}','{memployeeid}');";
            try
            {
                if (OpenConn())
                {
                    SqlCommand cmd = new SqlCommand(query, mySqlConnection);
                    try
                    {
                        cmd.ExecuteNonQuery();
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
            catch (Exception ex)
            {
                MessageBox.Show(Text, ex.Message);
                mySqlConnection.Close();
                return false;
            }
        }
        
        private bool createEmployee()
        {
            departmentid = int.Parse(Emdescription.Text);
            firstname = emfirstname.Text;
            lastname  = emlastname.Text;
            email     = ememail.Text;
            phone     = emphone.Text;
            address   = emaddress.Text;
            hiredate = DateTime.Parse(emhiredate.Text);
            salary = double.Parse(emsalary.Text);
            age = int.Parse(Emage.Text);

            string query = $"INSERT INTO employee (departmentID,firstname,lastname,email,phone,address,hireDate,salary,age,sex) VALUES ('{departmentid}','{firstname}','{lastname}','{email}','{phone}','{address}','{this.emhiredate.Value.ToString()}','{salary}','{age}','{sex}');";
            try
            {
                if (OpenConn())
                {
                    SqlCommand cmd = new SqlCommand(query, mySqlConnection);
                    try
                    {
                        cmd.ExecuteNonQuery();
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
            catch (Exception ex)
            {
                MessageBox.Show(Text, ex.Message);
                mySqlConnection.Close();
                return false;
            } 
        }
  
        private bool createDepartment()
        {
            dname = Dname.Text;
            daddress = Daddress.Text;
            string query = $"INSERT INTO department (Dname,Dlocation) VALUES ('{dname}','{daddress}');";
            try
            {
                if (OpenConn())
                {
                    SqlCommand cmd = new SqlCommand(query, mySqlConnection);
                    try
                    {
                        cmd.ExecuteNonQuery();
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
            catch (Exception ex)
            {
                MessageBox.Show(Text, ex.Message);
                mySqlConnection.Close();
                return false;
            }
        }

        private bool createProject()
        {
            pmanagerID = int.Parse(PManagerComboBox.Text);
            pname = Pname.Text;
            pbudget = Budget.Text;

            string query = $"INSERT INTO project (managerID,pname,pstartDate,pendDate,budget) VALUES ('{pmanagerID}','{pname}','{this.PstartDate.Value.ToString()}','{this.PendDate.Value.ToString()}','{pbudget}') ;";
            try
            {
                if (OpenConn())
                {
                    SqlCommand cmd = new SqlCommand(query, mySqlConnection);
                    try
                    {
                        cmd.ExecuteNonQuery();
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
            catch (Exception ex)
            {
                MessageBox.Show(Text, ex.Message);
                mySqlConnection.Close();
                return false;
            }
        }

        void fillcombo(string mysqlconn)
        {
            //string mysqlconn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\DMUIC\\LEVEL 1\\Visual Web Develoment\\Projects\\Sample1\\Sample1\\Employee_m_s.mdf;Integrated Security=True"; // collecting all the databse details 
            string query = "select * from department;";
            SqlConnection conn = new SqlConnection(mysqlconn);
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader myReader;
            try
            {
                conn.Open();
                myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    int ID = myReader.GetInt32("DepartmentID");
                    Emdescription.Items.Add(ID);
                }
                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(Text, ex.Message);
                conn.Close();
            }
        }
        
        void fillcomboM(string mysqlconn)
        {
            //string mysqlconn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\DMUIC\\LEVEL 1\\Visual Web Develoment\\Projects\\Sample1\\Sample1\\Employee_m_s.mdf;Integrated Security=True"; // collecting all the databse details 
            string query = "select * from department;";
            string queryE = "select * from employee";
            string queryM = "select * from manager";
            SqlConnection conn = new SqlConnection(mysqlconn);
            SqlConnection connE = new SqlConnection(mysqlconn);
            SqlConnection connM = new SqlConnection(mysqlconn);
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlCommand cmdE = new SqlCommand(queryE, connE);
            SqlCommand cmdM = new SqlCommand(queryM, connM);
            SqlDataReader myReader;
            SqlDataReader myReaderE;
            SqlDataReader myReaderM;
            try
            {
                conn.Open();
                connE.Open();
                connM.Open();
                myReader = cmd.ExecuteReader();
                myReaderE = cmdE.ExecuteReader();
                myReaderM = cmdM.ExecuteReader();
                while (myReader.Read() && myReaderE.Read() && myReaderM.Read())
                {
                    int IDE = myReaderE.GetInt32("employeeId");
                    int ID = myReader.GetInt32("DepartmentID");
                    int IDM = myReaderM.GetInt32("managerID");
                    Mdepartment.Items.Add(ID);
                    Employee_combo_box.Items.Add(IDE);
                    PManagerComboBox.Items.Add(IDM);
                }
                conn.Close();
                connE.Close();
                connM.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Text, ex.Message);
                conn.Close();
                connE.Close();
            }
        }
        
        void bindData(string mysqlconn)
        {
            //string mysqlconn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\DMUIC\\LEVEL 1\\Visual Web Develoment\\Projects\\Sample1\\Sample1\\Employee_m_s.mdf;Integrated Security=True"; // collecting all the databse details 

            SqlConnection conn = new SqlConnection(mysqlconn);
            SqlCommand cmd = new SqlCommand("select * from employee;", conn);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource= dt;
        }
        
        void bindDataM(string mysqlconn)
        {
            //string mysqlconn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\DMUIC\\LEVEL 1\\Visual Web Develoment\\Projects\\Sample1\\Sample1\\Employee_m_s.mdf;Integrated Security=True"; // collecting all the databse details 
            SqlConnection conn = new SqlConnection(mysqlconn);
            SqlCommand cmd = new SqlCommand("select * from manager;", conn);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView_MANAGER.DataSource = dt;
        }
        
        void bindDataD(string mysqlconn)
        {
            //string mysqlconn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\DMUIC\\LEVEL 1\\Visual Web Develoment\\Projects\\Sample1\\Sample1\\Employee_m_s.mdf;Integrated Security=True"; // collecting all the databse details 
            SqlConnection conn = new SqlConnection(mysqlconn);
            SqlCommand cmd = new SqlCommand("select * from department;", conn);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            Department_data.DataSource = dt;
        }
       
        void bindDataP(string mysqlconn)
        {
            //string mysqlconn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\DMUIC\\LEVEL 1\\Visual Web Develoment\\Projects\\Sample1\\Sample1\\Employee_m_s.mdf;Integrated Security=True"; // collecting all the databse details 
            SqlConnection conn = new SqlConnection(mysqlconn);
            SqlCommand cmd = new SqlCommand("select * from project;", conn);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private bool deleteEmployee()
        {

            email = ememail.Text;
            phone = emphone.Text;
            address = emaddress.Text;

            string query = $"DELETE FROM employee WHERE email='{email}' OR phone='{phone}' OR address='{address}';";
            try
            {
                if (OpenConn())
                {
                    SqlCommand cmd = new SqlCommand(query,mySqlConnection);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        mySqlConnection.Close();
                        return true;
                    }
                    catch(Exception ex)
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
                MessageBox.Show(Text, ex.Message);
                mySqlConnection.Close();
                return false;
            }

        }

        private bool deleteManager()
        {
            memail = Memail.Text;
            mphone = Mphone.Text;
            maddress = Maddress.Text;
            string query = $"DELETE FROM manager WHERE memail='{memail}' OR mphone='{mphone}' OR maddress='{maddress}';";
            try
            {
                if (OpenConn())
                {
                    SqlCommand cmd = new SqlCommand(query, mySqlConnection);
                    try
                    {
                        cmd.ExecuteNonQuery();
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
            catch (Exception ex)
            {
                MessageBox.Show(Text, ex.Message);
                mySqlConnection.Close();
                return false;
            }
        }
      
        private bool deleteDepartment()
        {
            dname = Dname.Text;
            string query = $"DELETE FROM department WHERE Dname='{dname}';";
            try
            {
                if (OpenConn())
                {
                    SqlCommand cmd = new SqlCommand(query, mySqlConnection);
                    try
                    {
                        cmd.ExecuteNonQuery();
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
            catch (Exception ex)
            {
                MessageBox.Show(Text, ex.Message);
                mySqlConnection.Close();
                return false;
            }
        }
        
        private bool deleteProject()
        {
            pname=Pname.Text;
            string query = $"DELETE FROM project WHERE pname='{pname}';";

            try
            {
                if (OpenConn())
                {
                    SqlCommand cmd = new SqlCommand(query, mySqlConnection);
                    try
                    {
                        cmd.ExecuteNonQuery();
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
            catch (Exception ex)
            {
                MessageBox.Show(Text, ex.Message);
                mySqlConnection.Close();
                return false;
            }
        }

        private bool searchManager()
        {
            mfirstname = MFirstname.Text;
            mlastname = Mlastname.Text;
            memail = Memail.Text;
            mphone = Mphone.Text;
            maddress = Maddress.Text;


            string query = $"SELECT * FROM manager WHERE  mfirstname='{mfirstname}' OR mlastname='{mlastname}' OR mhireDate='{this.Mhiredate.Value.ToString()}'  OR sex='{msex}' OR memail='{memail}' OR mphone='{mphone}' OR maddress='{maddress}';";

            try
            {
                if (OpenConn())
                {
                    SqlCommand cmd = new SqlCommand(query, mySqlConnection);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView_MANAGER.DataSource = dataTable;
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
            catch (Exception ex)
            {
                MessageBox.Show(Text, ex.Message);
                mySqlConnection.Close();
                return false;
            }
        }
        
        private bool searchEmployee()
        {
      
            firstname = emfirstname.Text;
            lastname = emlastname.Text;
            email = ememail.Text;
            phone = emphone.Text;
            address = emaddress.Text;
            hiredate = DateTime.Parse(emhiredate.Text);
            

            string query = $"SELECT * FROM employee WHERE  firstname='{firstname}' OR lastname='{lastname}' OR hireDate='{hiredate}'  OR sex='{sex}' OR email='{email}' OR phone='{phone}' OR address='{address}'  ;";
            try
            {
                if (OpenConn())
                {
                    SqlCommand cmd = new SqlCommand(query, mySqlConnection);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource=dataTable;
                        mySqlConnection.Close();
                        return true;
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(Text,ex.Message);

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
                MessageBox.Show(Text,ex.Message);
                mySqlConnection.Close();
                return false;
            }
        }
     
        private bool searchDepartment()
        {
            dname = Dname.Text;
            daddress = Daddress.Text;
            string query = $"SELECT * FROM Department WHERE Dname = '{dname}';";
            try
            {
                if (OpenConn())
                {
                    SqlCommand cmd = new SqlCommand(query, mySqlConnection);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        Department_data.DataSource = dataTable;
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
            catch (Exception ex)
            {
                MessageBox.Show(Text, ex.Message);
                mySqlConnection.Close();
                return false;
            }

        }

        private bool searchProject()
        {
            pname = Pname.Text; 
            string query = $"select * from project where pname='{pname}';";
            try
            {
                if (OpenConn())
                {
                    SqlCommand cmd = new SqlCommand(query, mySqlConnection);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView2.DataSource = dataTable;
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
            catch (Exception ex)
            {
                MessageBox.Show(Text, ex.Message);
                mySqlConnection.Close();
                return false;
            }
        }

        private bool updateEmployee()
        {
            departmentid = int.Parse(Emdescription.Text);
            firstname = emfirstname.Text;
            lastname = emlastname.Text;
            email = ememail.Text;
            phone = emphone.Text;
            address = emaddress.Text;
            hiredate = DateTime.Parse(emhiredate.Text);
            salary = double.Parse(emsalary.Text);
            age = int.Parse(Emage.Text);

            string query = $"UPDATE employee SET departmentID='{departmentid}',firstname='{firstname}',lastname='{lastname}',email='{email}',phone='{phone}',address='{address}',hireDate='{hiredate}',salary='{salary}',age='{age}',sex='{sex}' WHERE email='{email}' OR phone='{phone}' OR address='{address}' ;";
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
            catch (Exception ex)
            {
                MessageBox.Show(Text, ex.Message);
                mySqlConnection.Close();
                return false;
            }
        }

        private bool updateManager()
        {
            mdepartmentid = int.Parse(Mdepartment.Text);
            mfirstname = MFirstname.Text;
            mlastname = Mlastname.Text;
            memail = Memail.Text;
            mphone = Mphone.Text;
            maddress = Maddress.Text;
            mhiredate = DateTime.Parse(Mhiredate.Text);
            msalary = double.Parse(Msalary.Text);
            mage = int.Parse(Mages.Text);
            memployeeid = int.Parse(Employee_combo_box.Text);

            string query = $"UPDATE manager SET mdepartmentID='{Mdepartment.Text}',mfirstname='{mfirstname}',mlastname='{mlastname}',memail='{memail}',mphone='{mphone}',maddress='{maddress}',mhireDate='{this.Mhiredate.Value.ToString()}',msalary='{msalary}',age='{mage}',sex='{msex}',memployeeID='{memployeeid}' WHERE memail='{memail}' OR mphone='{mphone}' OR maddress='{maddress}' ;";
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
            catch (Exception ex)
            {
                MessageBox.Show(Text, ex.Message);
                mySqlConnection.Close();
                return false;
            }
        }

        private bool updateDepartment()
        {
            dname = Dname.Text;
            daddress = Daddress.Text;
            string query = $"UPDATE department SET Dname = '{dname}',Dlocation='{daddress}' WHERE Dname='{dname}' ;";
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
            catch (Exception ex)
            {
                MessageBox.Show(Text, ex.Message);
                mySqlConnection.Close();
                return false;
            }
        }

        private bool updateProject()
        {
            pname = Pname.Text;
            pmanagerID = int.Parse(PManagerComboBox.Text);
            pbudget = Budget.Text;

            string query = $"UPDATE project SET managerID = '{pmanagerID}', pstartDate='{this.PstartDate.Value.ToString()}', pendDate='{this.PendDate.Value.ToString()}',budget='{pbudget}' WHERE pname='{pname}' ;";
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
            catch (Exception ex)
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
        
        private bool verificationE(string a, string b,string c,string d, string e,string f,string g)
        {
           
            if (a != "" && b != "" && c != "" && d != "" && e != "" && f!="" && g!="" )
            {
                        if (Registration.EmailVerification(e))
                        {
                                    return true;
                        }
                        else
                        {
                            MessageBox.Show("Enter a valid Email Address");
                            return false;
                        }
             }
            else
            {
                MessageBox.Show("Fill in all the boxes");
                return false;
            }
        }
        
        private void button9_Click(object sender, EventArgs e)
        {
            //int g = int.Parse(ememail.Text);
            if (verificationE(this.emfirstname.Text,this.emlastname.Text,this.emaddress.Text,this.emphone.Text,this.ememail.Text,this.emsalary.Text,this.Emage.Text))
            {
                if (createEmployee())
                {
                    MessageBox.Show("Successfully created employee");
                    bindData(mysqlconn);
                }
            }

            /*else
            {
                MessageBox.Show("Unsuccesfull to create employe");
            }*/
        }

        private void Emmale_CheckedChanged(object sender, EventArgs e)
        {
          string  gender = "MALE";
            sex = gender;
        }

        private void EmFemale_CheckedChanged(object sender, EventArgs e)
        {
            string gender = "FEMALE";
            sex = gender;
        }

        private void DeleteEm_Click(object sender, EventArgs e)
        {
            if (verificationE(this.emfirstname.Text, this.emlastname.Text, this.emaddress.Text, this.emphone.Text, this.ememail.Text, this.emsalary.Text, this.Emage.Text))
            {
                if (deleteEmployee())
                {
                    MessageBox.Show("Employee has been succesfully deleted ");
                    bindData(mysqlconn);
                }
            }
        }

        private void UpdateEm_Click(object sender, EventArgs e)
        {
            if (verificationE(this.emfirstname.Text, this.emlastname.Text, this.emaddress.Text, this.emphone.Text, this.ememail.Text, this.emsalary.Text, this.Emage.Text))
            {
                if (updateEmployee())
                {
                    MessageBox.Show(" Employee successfully updated ");
                    bindData(mysqlconn);
                }
            }
        }

        private void SearchEm_Click(object sender, EventArgs e)
        {
            if (verificationE(this.emfirstname.Text, this.emlastname.Text, this.emaddress.Text, this.emphone.Text, this.ememail.Text, this.emsalary.Text, this.Emage.Text))
            {
                if (searchEmployee())
                {
                    MessageBox.Show(" Employee has been seen ");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Project_Panel.Hide();
            menu_dashboard.Hide();
            Department_panell.Hide();
            Managerpanel.Hide();
            EmployeePanel.Show();
            Project_button.ForeColor = Color.White;
            Employee_button.ForeColor = Color.SandyBrown;
            Manager_button.ForeColor = Color.White;
            Department_button.ForeColor = Color.White;
            button5.ForeColor = Color.White;

        }

        private void Manager_button_Click(object sender, EventArgs e)
        {
            menu_dashboard.Hide();
            Project_Panel.Hide();
            Department_panell.Hide();
            EmployeePanel.Hide();
            Managerpanel.Show();
            Project_button.ForeColor = Color.White;
            Employee_button.ForeColor = Color.White;
            Manager_button.ForeColor = Color.SpringGreen;
            Department_button.ForeColor = Color.White;
            button5.ForeColor = Color.White;
        }

        private void Department_button_Click(object sender, EventArgs e)
        {
            menu_dashboard.Hide();
            EmployeePanel.Hide();
            Managerpanel.Hide();
            Project_Panel.Hide();
            Department_panell.Show();
            Project_button.ForeColor = Color.White;
            Employee_button.ForeColor = Color.White;
            Manager_button.ForeColor = Color.White;
            Department_button.ForeColor = Color.Indigo;
            button5.ForeColor = Color.White;
        }

        private void Project_button_Click(object sender, EventArgs e)
        {
            menu_dashboard.Hide();
            EmployeePanel.Hide();
            Managerpanel.Hide();
            Department_panell.Hide();
            Project_Panel.Show();
            Project_button.ForeColor = Color.IndianRed;
            Employee_button.ForeColor = Color.White;
            Manager_button.ForeColor = Color.White;
            Department_button.ForeColor = Color.White;
            button5.ForeColor = Color.White;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            string mgender = "MALE";
            msex = mgender;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            string mgender = "FEMALE";
            msex = mgender;
        }

        private void Creat_manager_Click(object sender, EventArgs e)
        {
            if (verificationE(this.MFirstname.Text, this.Mlastname.Text, this.Maddress.Text, this.Mphone.Text, this.Memail.Text, this.Msalary.Text, this.Mages.Text))
            {
                if (createManager())
                {
                    MessageBox.Show("manager has been succesfully created ");
                    bindDataM(mysqlconn);
                }
            }
        }

        private void Delete_manager_Click(object sender, EventArgs e)
        {
            if (verificationE(this.MFirstname.Text, this.Mlastname.Text, this.Maddress.Text, this.Mphone.Text, this.Memail.Text, this.Msalary.Text, this.Mages.Text))
            {
                if (deleteManager())
                {
                    MessageBox.Show("manager has been succesfully deleted ");
                    bindDataM(mysqlconn);
                }
            }
        }

        private void Update_manager_Click(object sender, EventArgs e)
        {
            if (verificationE(this.MFirstname.Text, this.Mlastname.Text, this.Maddress.Text, this.Mphone.Text, this.Memail.Text, this.Msalary.Text, this.Mages.Text))
            {
                if (updateManager())
                {
                    MessageBox.Show(" Manager successfully updated ");
                    bindDataM(mysqlconn);
                }
            }
        }

        private void Search_Manager_Click(object sender, EventArgs e)
        {
            if (verificationE(this.MFirstname.Text, this.Mlastname.Text, this.Maddress.Text, this.Mphone.Text, this.Memail.Text, this.Msalary.Text, this.Mages.Text))
            {
                if (searchManager())
            {
                MessageBox.Show("Manager has been found successfully ");
            }

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (createDepartment())
            {
                MessageBox.Show("succesfully created a department ");
                bindDataD(mysqlconn);
            }
            else
            {
                MessageBox.Show("unsuccesfull to create a department ");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void department_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Task_Button_Click(object sender, EventArgs e)
        {

        }

        private void EmployeePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Mhiredate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Msalary_TextChanged(object sender, EventArgs e)
        {

        }

        private void Memail_TextChanged(object sender, EventArgs e)
        {

        }

        private void Mphone_TextChanged(object sender, EventArgs e)
        {

        }

        private void Maddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void Mlastname_TextChanged(object sender, EventArgs e)
        {

        }

        private void MFirstname_TextChanged(object sender, EventArgs e)
        {

        }

        private void Department_data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void delete_department_Click(object sender, EventArgs e)
        {

        }

        private void update_department_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void Employee_combo_box_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView_MANAGER_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Mages_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void Mdepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Emage_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void Emdescription_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void emhiredate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void emsalary_TextChanged(object sender, EventArgs e)
        {

        }

        private void ememail_TextChanged(object sender, EventArgs e)
        {

        }

        private void emphone_TextChanged(object sender, EventArgs e)
        {

        }

        private void emaddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void emlastname_TextChanged(object sender, EventArgs e)
        {

        }

        private bool verificationD(string a ,string b)
        {
            if (a!="" && b!="")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool verificationP(string a , string c,string d ,string e)
        {
            if (a!="" && c!="" && d!=""&& e != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private bool VerificationD(string a , string b)
        {
            if(a!="" && b != "")
            {
                return true;
            }
            else
            {
                MessageBox.Show("Fill in all the boxes ");
                return false;
            }
        }

        private void created_department_Click(object sender, EventArgs e)
        {
            /*dname = Dname.Text;
            daddress = Daddress.Text;*/
            if (VerificationD(this.Dname.Text, this.Daddress.Text))
            {
                if (createDepartment())
                {
                    MessageBox.Show("successfully creted a department ");
                    bindDataD(mysqlconn);
                }
            }

        }

        private void update_department_Click_1(object sender, EventArgs e)
        {
            dname = Dname.Text;
            daddress = Daddress.Text;
            if (verificationD(dname, daddress))
            {
                if (updateDepartment())
                {
                    MessageBox.Show(" Succesfully update department ");
                    bindDataD(mysqlconn);
                }
                else
                {
                    MessageBox.Show(" Error \n no department updated ");
                }
            }
            else
            {
                MessageBox.Show("Fill in all the boxes ");
            }
        }

        private void Dsearch_Click(object sender, EventArgs e)
        {
            dname = Dname.Text;
            daddress = Daddress.Text;
            if (verificationD(dname , daddress))
            {
                if (searchDepartment())
                {
                    MessageBox.Show(" Department has been found ");
                }
                else
                {
                    MessageBox.Show("Error occured \n Department has not been found ");
                }
            }

            else
            {
                MessageBox.Show("Fill in all the boxes");
            }
        }

        private void Ddelete_Click(object sender, EventArgs e)
        {
            dname = Dname.Text; 
            daddress= Daddress.Text;
            if (verificationD(dname, daddress))
            {
                if (deleteDepartment()) 
                {
                    MessageBox.Show("Succesfully delete department ");
                }
                else
                {
                    MessageBox.Show("Error occured \n Unsuccesfull to delete department");
                }
            }
            else
            {
                MessageBox.Show("fill in all the boxes");
            }
        }

        private void CreateProject_Click(object sender, EventArgs e)
        {
            pname = Pname.Text;
            //pmanagerID =int.Parse(PManagerComboBox.Text);
            pbudget = Budget.Text;
            if (verificationP(pname,pbudget,this.PstartDate.Value.ToString(),this.PendDate.Value.ToString()))
            {
                if (createProject())
                {
                    MessageBox.Show("succesfully created project ");
                    bindDataP(mysqlconn);
                }
                else
                {
                    MessageBox.Show("unsuccessfull to create error ");
                }
            }
            else
            {
                MessageBox.Show("Fill in all the boxes ");
            }
        }

        private void Project_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UpdateProject_Click(object sender, EventArgs e)
        {
            pname = Pname.Text;
           // pmanagerID = int.Parse(PManagerComboBox.Text);
            pbudget = Budget.Text;
            if (verificationP(pname, pbudget, this.PstartDate.Value.ToString(), this.PendDate.Value.ToString()))
            {
                if (updateProject())
                {
                    MessageBox.Show(" Successfull to update project ");
                    bindDataP(mysqlconn);
                }
                else
                {
                    MessageBox.Show("unsuccesfull to update project ");
                }
            }
            else
            {
                MessageBox.Show("Fill in all the boxes");
            }
        }

        private void DeleteProject_Click(object sender, EventArgs e)
        {
            pname = Pname.Text;
            //pmanagerID = int.Parse(PManagerComboBox.Text);
            pbudget = Budget.Text;
            if (verificationP(pname,  pbudget, this.PstartDate.Value.ToString(), this.PendDate.Value.ToString()))
            {
                if (deleteProject())
                {
                    MessageBox.Show("succesfully deleted project ");
                    bindDataP(mysqlconn);
                }
                else
                {
                    MessageBox.Show(" Unsuccesfull to delete ");
                }
            }
            else
            {
                MessageBox.Show("fill in all the boxes");
            }
        }

        private void SearchProject_Click(object sender, EventArgs e)
        {
            pname = Pname.Text;
           // pmanagerID = int.Parse(PManagerComboBox.Text);
            pbudget = Budget.Text;
            if (verificationP(pname, pbudget, this.PstartDate.Value.ToString(), this.PendDate.Value.ToString()))
            {
                if (searchProject())
                {
                    MessageBox.Show(" project has been found ");
                    //bindDataP(mysqlconn);
                }
                else
                {
                    MessageBox.Show(" Error Occured ");
                }
            }
            else
            {
                MessageBox.Show("Fill in all the boxes");
            }
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            //Login lg = new Login();
            //Remail.Text = lg.user;
           
        }

        private void Managerpanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

