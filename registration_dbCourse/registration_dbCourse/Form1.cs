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
using System.Security.Cryptography;

namespace registration_dbCourse
{
    public partial class Start_Form : Form
    {
        MainWork_Form main_Form = new MainWork_Form();
        string connStr = @"Data Source=IGORSPC;Initial Catalog=businessDB_VS_1;Integrated Security=True";

        CloseProgClass close_Class = new CloseProgClass();

        public Start_Form()
        {
            InitializeComponent();
        }

        private void Start_Form_Load(object sender, EventArgs e)
        {

        }

        // Open registration Form: 
        private void registr_BUT2_Click(object sender, EventArgs e)
        {
            AddUserForm addUser_F = new AddUserForm();
            addUser_F.Show();
            this.Hide();
        }

        // Exit from tabPage1: 
        private void exit_BUT3_Click(object sender, EventArgs e)
        {
            close_Class.CloseProg();
        }

        // Exit from tabPage2: 
        private void exit_BUT4_Click(object sender, EventArgs e)
        {
            close_Class.CloseProg();
        }

        // Check in:
        private void entry_BUT1_Click(object sender, EventArgs e)
        {
            string login = log_TB1.Text;
            string password = pass_TB2.Text;

            byte[] byteIsh = new UTF8Encoding().GetBytes(password);
            SHA256 shaMan = new SHA256Managed();
            byte[] byteShaMan = shaMan.ComputeHash(byteIsh);
            string passHash = BitConverter.ToString(byteShaMan);
            passHash = passHash.ToLower().Replace("-", string.Empty);
            // MessageBox.Show(passHash);

            SqlConnection connection_1 = new SqlConnection(connStr);
            connection_1.Open();

            DataTable dTable_1 = new DataTable();
            SqlDataAdapter adapter_1 = new SqlDataAdapter();

            string select_users_Q = "SELECT * FROM dbo.Users WHERE login_user = @login_user AND password_user = @password_user";

            SqlCommand command_1 = new SqlCommand(select_users_Q, connection_1);
            command_1.Parameters.Add("@login_user", SqlDbType.NVarChar).Value = login;
            command_1.Parameters.Add("@password_user", SqlDbType.Char).Value = passHash;
            adapter_1.SelectCommand = command_1;
            adapter_1.Fill(dTable_1);

            if (dTable_1.Rows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Вы хотите добавить работника или изменить информацию о нём?", "Внимание!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    AddWorker_Form worker_F = new AddWorker_Form();
                    worker_F.Show();
                    this.Hide();
                }
                else if (dialogResult == DialogResult.No)
                {
                    main_Form.Show();
                    connection_1.Close();
                    this.Hide();
                }

            }
            else
            {
                log_TB1.Text = pass_TB2.Text = "";
                MessageBox.Show("Проверьте введённый логин или пароль", "Внимание!");
            }
        }

        private void Start_Form_Load_1(object sender, EventArgs e)
        {
            pass_TB2.UseSystemPasswordChar = true;
        }

    }
}
