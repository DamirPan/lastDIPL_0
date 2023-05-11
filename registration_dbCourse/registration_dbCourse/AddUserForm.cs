using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
//using MongoDB.Driver.Core.Configuration;

namespace registration_dbCourse
{
    public partial class AddUserForm : Form
    {
        string passHash = "";
        CloseProgClass close_Class = new CloseProgClass();
        string connStr = @"Data Source=IGORSPC;Initial Catalog=businessDB_VS_1;Integrated Security=True";

        public AddUserForm()
        {
            InitializeComponent();
        }

        // Exit:
        private void exit_BUT3_Click(object sender, EventArgs e)
        {
            close_Class.CloseProg();
        }

        // Registration button:
        private void registr_BUT2_Click(object sender, EventArgs e)
        {
            if (log_TB1.Text == "" || pass_TB2.Text == "")
            {
                MessageBox.Show("Необходимо заполнить все поля", "Внимание!");
                log_TB1.Text = pass_TB2.Text = "";
            }
            else
            {

                string password = pass_TB2.Text;
                /*
               close_Class.HashFun(password);//, passHash);
               MessageBox.Show(passHash);*/
                // хэширование пароля: 

                byte[] byteIsh = new UTF8Encoding().GetBytes(password);
                SHA256 shaMan = new SHA256Managed();
                byte[] byteShaMan = shaMan.ComputeHash(byteIsh);
                string passHash = BitConverter.ToString(byteShaMan);
                passHash = passHash.ToLower().Replace("-", string.Empty);
                // MessageBox.Show(passHash);



                string query = "SELECT COUNT(*) FROM dbo.Users WHERE login_user = @login_user AND password_user = @password_user";

                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@login_user", log_TB1.Text);
                    command.Parameters.AddWithValue("@password_user", passHash);

                    connection.Open();

                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Данный пользователь уже существует", "Внимание!");
                        log_TB1.Text = pass_TB2.Text = "";
                        return; // выходим из метода, чтобы не добавлять дублирующиеся данные
                    }
                    else
                    {

                        using (SqlConnection connection_0 = new SqlConnection(connStr))
                        {
                            connection_0.Open();
                            string idUser_Q = "SELECT MAX(id_user) FROM dbo.Users";
                            SqlCommand commID = new SqlCommand(idUser_Q, connection_0);
                            int idUser = (int)commID.ExecuteScalar();
                            int idUser_now = idUser + 1;

                            string addUser_Q = string.Format("INSERT INTO dbo.Users (id_user, login_user, password_user) VALUES (@id_user, '{0}', '{1}') OPTION (QUERYTRACEON 460)", log_TB1.Text, passHash);

                            using (SqlCommand command_0 = new SqlCommand(addUser_Q, connection_0))
                            {
                                command_0.Parameters.AddWithValue("id_user", idUser_now);

                                //Как это классом сделать ??!?
                                SqlParameter parameter_0 = new SqlParameter();
                                parameter_0.ParameterName = @"login_user";
                                parameter_0.Value = log_TB1.Text;
                                parameter_0.SqlDbType = SqlDbType.NVarChar;
                                parameter_0.Size = 50;
                                command_0.Parameters.Add(parameter_0);

                                parameter_0 = new SqlParameter();
                                parameter_0.ParameterName = "password_user";
                                parameter_0.Value = passHash;
                                parameter_0.SqlDbType = SqlDbType.Char;
                                parameter_0.Size = 300;
                                command_0.Parameters.Add(parameter_0);

                                command_0.ExecuteNonQuery();


                            }
                            connection_0.Close();
                        }
                        MessageBox.Show("Регистрация прошла успешно", "Внимание!");
                        Start_Form form1 = new Start_Form();
                        form1.Show();
                        this.Close();

                    }
                    log_TB1.Text = pass_TB2.Text = "";
                }
            }
        }

        private void back_BUT1_Click(object sender, EventArgs e)
        {
            Start_Form form1 = new Start_Form();
            form1.Show();
            this.Close();
        }
    }
}
