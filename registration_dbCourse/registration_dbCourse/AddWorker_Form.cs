using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace registration_dbCourse
{
    public partial class AddWorker_Form : Form
    {
        int selectedRow;
        //private Timer timer;


        CloseProgClass close_Class = new CloseProgClass();
        int idWorker_0;
        int id_Worker_now;

        int id_post_0;
        int id_post_now;

        int id_comp_0;
        int id_comp_now;
        int id_depart_0;
        int id_depart_now;

        int quitWorkNO = 0; // не уволен
        int quitWorkYES = 1; // уволен

        bool uvolenNO = false; // не уволен 
        bool uvolenYES = true; // уволен

        string connStr = @"Data Source=IGORSPC;Initial Catalog=businessDB_VS_1;Integrated Security=True";

        DataTable dTable__ = new DataTable();


        public AddWorker_Form()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            RefreshData(); // вызываем метод обновления данных
        }


        private void AddWorker_Form_Load(object sender, EventArgs e)
        {
            //string connecStr = @"Data Source=IGORSPC;Initial Catalog=businessDB_VS_1;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connStr))
            {



                checkBox1.Checked = false;

               // SqlConnection connection = new SqlConnection();
                SqlCommand command = new SqlCommand();
                // connection.ConnectionString = Properties.Settings.Default;


                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT id_worker as [ID], surname as [Фамилия], name_worker as [Имя], middleName as [Отчество], post_name_W as [Должность], " +
                    " department_name_W as [Отдел], company_name_W as [Компания], isDismissed [Уволен ли]  FROM  dbo.Workers";
                /*
                  " (dbo.Workers LEFT JOIN dbo.Posts ON dbo.Workers.id_post_wf = dbo.Posts.id_post) " +
                                        " LEFT JOIN dbo.Departments ON(dbo.Workers.id_department_wf = dbo.Departments.id_department) " +
                                        " LEFT JOIN  dbo.Companies ON dbo.Workers.id_company_wf = dbo.Companies.id_company "
                */
                connection.Open();
                SqlDataReader dreader = command.ExecuteReader();
                ArrayList records = new ArrayList();
                if (dreader.HasRows)
                {
                    foreach (DbDataRecord rec in dreader)
                    {
                        records.Add(rec);
                    }
                }
                connection.Close();
                dataGridView1.DataSource = records;
            }


            string department_fill_q = "SELECT department_name FROM dbo.Departments";
            string company_fill_q = "SELECT company_name FROM dbo.Companies";
            string post_fill_q = "SELECT post_name FROM dbo.Posts ";

            string company_in_q = "SELECT id_company, company_name FROM dbo.Companies";

            using (SqlConnection connection_1 = new SqlConnection(connStr))
            {
                SqlCommand command_department = new SqlCommand(department_fill_q, connection_1);
                // :
                DataTable dTable_department = new DataTable();
                SqlDataAdapter adapter_department = new SqlDataAdapter();
                adapter_department.SelectCommand = command_department;
                adapter_department.Fill(dTable_department);
                depart_CB2.DataSource = dTable_department;
                depart_CB2.DisplayMember = "department_name";

                /*  SqlCommand command_company = new SqlCommand(company_fill_q, connection_1);
                  // :
                  DataTable dTable_command = new DataTable();
                  SqlDataAdapter adapter_command = new SqlDataAdapter();
                  adapter_command.SelectCommand = command_company;
                  adapter_command.Fill(dTable_command);
                  comboBox2.DataSource = dTable_command;
                  comboBox2.DisplayMember = "company_name";
                  */
                SqlCommand command_company_in = new SqlCommand(company_in_q, connection_1);
                // COMPANY     
                DataTable dTable_company2 = new DataTable();
                SqlDataAdapter adapter_company2 = new SqlDataAdapter();
                adapter_company2.SelectCommand = command_company_in;
                adapter_company2.Fill(dTable_company2);
                company_CB3.DataSource = dTable_company2;
                company_CB3.DisplayMember = "company_name";
                company_CB3.ValueMember = "id_company";


                SqlCommand command_post = new SqlCommand(post_fill_q, connection_1);
                // :
                DataTable dTable_post = new DataTable();
                SqlDataAdapter adapter_post = new SqlDataAdapter();
                adapter_post.SelectCommand = command_post;
                adapter_post.Fill(dTable_post);
                post_CB1.DataSource = dTable_post;
                post_CB1.DisplayMember = "post_name";
            }
            company_CB3.SelectedValue = 4;

            ToolTip toolTip_ = new ToolTip();
            toolTip_.SetToolTip(mainWork_BUT4, "Информация о созданных командировочных удостоверениях");
            toolTip_.SetToolTip(search_BUT1, "Поиск осуществляется по совпадению в любых параметрах");

            toolTip_.SetToolTip(depart_CB2, "Вводите первую букву названия отдела для удобного поиска");
            toolTip_.SetToolTip(company_CB3, "Вводите первую букву названия компании для удобного поиска");
            toolTip_.SetToolTip(post_CB1, "Вводите первую букву названия должности для удобного поиска");
        }


        private void exit_BUT8_Click(object sender, EventArgs e)
        {
            close_Class.CloseProg();
        }

        private void add_BUT5_Click(object sender, EventArgs e)
        {
            if (lastName_TB3.Text == "" || name_TB4.Text == "" ) 
            {
                MessageBox.Show("Заполните поля для добавления работника в базу данных", "Внимание!");
            }
            else
            {
                using (SqlConnection connection_2 = new SqlConnection(connStr))
                {
                    connection_2.Open();

                    string id_query = "SELECT MAX(id_worker) FROM dbo.Workers";

                    SqlCommand comandID = new SqlCommand(id_query, connection_2);
                    idWorker_0 = (int)comandID.ExecuteScalar();
                    id_Worker_now = idWorker_0 + 1;



                    // 1
                    /*    string comp_name_bot = comboBox2.Text;

                        MessageBox.Show(comp_name_bot);

                        string id_comp_Q = "SELECT Companies.id_company FROM Companies JOIN Workers " +
                            " ON Companies.company_name = Workers.company_name_W " +
                            " WHERE Workers.company_name_W = @comp_name_bot";
                        SqlCommand comm_comp_ = new SqlCommand(id_comp_Q, connection_2);

                        comm_comp_.Parameters.AddWithValue("@comp_name_bot", comboBox2.Text);
                       // id_comp_0 = (int)comm_comp_.ExecuteScalar();
                       // id_comp_now = id_comp_0;


                        object result = comm_comp_.ExecuteScalar();
                        if (result != null)
                        {
                            id_comp_now = (int)result;
                        }
                        else
                        {
                            MessageBox.Show("NULL возвращает тварь....");
                        }




                        // 2
                        string depart_name_bot = comboBox1.Text;
                        string id_depart_Q = "SELECT Departments.id_department FROM dbo.Departments JOIN Workers " +
                            " ON Departments.department_name = Workers.department_name_W " +
                            " WHERE Workers.department_name_W = @depart_name_bot";
                        SqlCommand comm_depart_ = new SqlCommand(id_depart_Q, connection_2);

                        comm_depart_.Parameters.AddWithValue("@depart_name_bot", depart_name_bot);
                        // id_depart_0 = (int)comm_depart_.ExecuteScalar();
                       // id_depart_now = id_depart_0;

                        object result_2 = comm_comp_.ExecuteScalar();
                        if (result != null)
                        {
                            id_depart_now = (int)result_2;
                        }
                        else
                        {

                            MessageBox.Show("NULL возвращает тварь #2....");
                        }




                        // 3
                        string post_name_bot = comboBox3.Text;
                        string id_posy_query = "SELECT Posts.id_post FROM Posts JOIN Workers " +
                            " ON Posts.post_name = Workers.post_name_W " +
                            " WHERE Workers.post_name_W = @post_name_bot";

                        SqlCommand commandIdPost = new SqlCommand(id_posy_query, connection_2);

                        commandIdPost.Parameters.AddWithValue("@post_name_bot", post_name_bot);
                      //  id_post_0 = (int)commandIdPost.ExecuteScalar();
                       // id_post_now = id_post_0;// + 1;



                        object result_3 = comm_comp_.ExecuteScalar();
                        if (result != null)
                        {
                            id_post_now = (int)result_3;
                        }
                        else
                        {

                            MessageBox.Show("NULL возвращает тварь #3....");
                        }


                        */


                    string id_comp_Q = "SELECT id_company FROM dbo.Companies  JOIN Workers ON Workers.company_name_W = Companies.company_name";
                    SqlCommand comm_comp_ = new SqlCommand(id_comp_Q, connection_2);
                    id_comp_0 = (int)comm_comp_.ExecuteScalar();
                    id_comp_now = id_comp_0;

                    string id_depart_Q = "SELECT id_department FROM dbo.Departments  JOIN Workers ON Workers.department_name_W = Departments.department_name";
                    SqlCommand comm_depart_ = new SqlCommand(id_depart_Q, connection_2);
                    id_depart_0 = (int)comm_depart_.ExecuteScalar();
                    id_depart_now = id_depart_0;



                    /*
                    string post_name_bot = comboBox3.Text;
                    string id_posy_query = "SELECT Posts.id_post FROM Posts JOIN Workers ON Posts.post_name = Workers.post_name_W WHERE Workers.post_name_W = @post_name_bot";

                    SqlCommand commandIdPost = new SqlCommand(id_posy_query, connection_2);

                    commandIdPost.Parameters.AddWithValue("@post_name_bot", post_name_bot);
                    id_post_0 = (int)commandIdPost.ExecuteScalar();
                    id_post_now = id_post_0;// + 1;
                    */


                    string id_posy_query = "SELECT MAX(id_post) FROM dbo.Posts";

                    SqlCommand commandIdPost = new SqlCommand(id_posy_query, connection_2);
                    id_post_0 = (int)commandIdPost.ExecuteScalar();
                    id_post_now = id_post_0;// + 1;





                    // *         // id_company_wf,    id_post_wf,   id_department_wf,
                    SqlCommand command_2 = new SqlCommand("INSERT INTO dbo.Workers (id_worker, surname, name_worker, middleName,  id_company_wf,     company_name_W,  id_post_wf,   post_name_W,   id_department_wf,  department_name_W, isDismissed) " +
                                     " VALUES (@id_worker, @surname, @name_worker, @middleName,  @id_company_wf,    @company_name_W,  @id_post_wf,   @post_name_W,  @id_department_wf,  @department_name_W, @isDismissed)", connection_2);
                    //  @id_company_wf,    @id_post_wf,     @id_department_wf,
                    command_2.Parameters.AddWithValue("id_worker", id_Worker_now);
                    command_2.Parameters.AddWithValue("surname", lastName_TB3.Text);
                    command_2.Parameters.AddWithValue("name_worker", name_TB4.Text);
                    command_2.Parameters.AddWithValue("middleName", middleName_TB5.Text);
                    command_2.Parameters.AddWithValue("id_company_wf", id_comp_now);
                    command_2.Parameters.AddWithValue("company_name_W", company_CB3.Text);
                    command_2.Parameters.AddWithValue("id_post_wf", id_post_now);

                    command_2.Parameters.AddWithValue("post_name_W", post_CB1.Text);
                    // command_2.Parameters.AddWithValue("post_name_W", textBox4.Text);
                    command_2.Parameters.AddWithValue("id_department_wf", id_depart_now);
                    command_2.Parameters.AddWithValue("department_name_W", depart_CB2.Text);
                    command_2.Parameters.AddWithValue("isDismissed", checkBox1.Checked);

                    command_2.ExecuteNonQuery();

                    RefreshData();
                }
            }
            checkBox1.Checked = false;
        }

        // Change and save data-material-information
        private void save_BUT6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connStr);
            con.Open();

            SqlCommand com = new SqlCommand();
            com.Connection = con;


            string id_posy_query = $"SELECT MAX(id_post) FROM dbo.Posts"; // WHERE post_name != \"{textBox4.Text}\" ";

            SqlCommand commandIdPost = new SqlCommand(id_posy_query, con);
            id_post_0 = (int)commandIdPost.ExecuteScalar();
            id_post_now = id_post_0 + 1;
            // string post_qq = $"{id_post_now = id_post_0 + 1} IF EXISTS (SELECT post_name FROM dbo.Posts WHERE post_name = $"{ }") ";


            /*                com.CommandText = "UPDATE Workers SET surname = @surname, name_worker = @name_worker, " +
                                " middleName = @middleName, id_company_wf = @id_company_wf, company_name_W = @company_name_W," +
                                " id_post_wf = @id_post_wf, post_name_W = @post_name_W, id_department_wf = @id_department_wf, " +
                                " department_name_W = @department_name_W, isDismissed = @isDismissed  " +
                                "  WHERE id_worker = @id_worker";
            */
            /*  com.CommandText = "UPDATE Workers " +
                  "SET surname = @surname, name_worker = @name_worker, middleName = @middleName,     company_name_W = @company_name_W,     post_name_W = @post_name_W, " +
                      "     department_name_W = @department_name_W, isDismissed = @isDismissed  " +
                  " FROM Workers JOIN dbo.Companies ON Workers.company_name_W = Companies.company_name    WHERE id_worker = @id_worker";
            */

            com.CommandText = "UPDATE Workers SET  surname = @surname, name_worker = @name_worker, middleName = @middleName, " +
                " id_post_wf = @id_post_wf, post_name_W = @post_name_W, department_name_W = @department_name_W, company_name_W = @company_name_W, " +
                "   isDismissed = @isDismissed  WHERE id_worker = @id_worker";


            com.Parameters.AddWithValue("id_worker", id_TB2.Text);
            com.Parameters.AddWithValue("@surname", lastName_TB3.Text);
            com.Parameters.AddWithValue("@name_worker", name_TB4.Text);
            com.Parameters.AddWithValue("@middleName", middleName_TB5.Text);

            // com.Parameters.AddWithValue("@company_name_W", comboBox2.Text);
            com.Parameters.AddWithValue("@id_post_wf", id_post_now);

            com.Parameters.AddWithValue("@post_name_W", post_CB1.Text);
            //com.Parameters.AddWithValue("@post_name_W", textBox4.Text);

            com.Parameters.AddWithValue("@department_name_W", depart_CB2.Text); //
            com.Parameters.AddWithValue("@company_name_W", company_CB3.Text);    //
            com.Parameters.AddWithValue("@isDismissed", checkBox1.Checked);

            com.ExecuteNonQuery();

            con.Close();

            SaveChanges();
            search_TB1.Text = id_TB2.Text = lastName_TB3.Text = name_TB4.Text = middleName_TB5.Text = "";  // = textBox4.Text 
            //comboBox1.Text = comboBox2.Text = "";


            dataGridView1.CurrentCell = null;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            checkBox1.Checked = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row_now = dataGridView1.Rows[selectedRow];
                id_TB2.Text = row_now.Cells[0].Value.ToString();
                lastName_TB3.Text = row_now.Cells[1].Value.ToString();
                name_TB4.Text = row_now.Cells[2].Value.ToString();
                middleName_TB5.Text = row_now.Cells[3].Value.ToString();

                post_CB1.Text = row_now.Cells[4].Value.ToString();
                //textBox4.Text = row_now.Cells[4].Value.ToString();
                depart_CB2.Text = row_now.Cells[5].Value.ToString();
                company_CB3.Text = row_now.Cells[6].Value.ToString();
                // checkBox1.Checked = row_now.Cells[7].Value.ToString();

            }





            /*

            int r = e.RowIndex;

            DataSet dataSet_ = new DataSet();
            dataSet_.Tables["Workers"].Rows[0]["id_worker"] = dataGridView1.Rows[r].Cells["id_worker"].Value;
            dataSet_.Tables["Workers"].Rows[1]["surname"] = dataGridView1.Rows[r].Cells["surname"].Value;
            dataSet_.Tables["Workers"].Rows[2]["name_worker"] = dataGridView1.Rows[r].Cells["name_worker"].Value;
            dataSet_.Tables["Workers"].Rows[3]["middleName"] = dataGridView1.Rows[r].Cells["middleName"].Value;
            // dataSet_.Tables["Workers"].Rows[4]["id_company_wf"] = dataGridView1.Rows[4].Cells["id_company_wf"].Value;
            dataSet_.Tables["Workers"].Rows[5]["company_name_W"] = dataGridView1.Rows[r].Cells["company_name_W"].Value;
           // dataSet_.Tables["Workers"].Rows[6]["id_post_wf"] = dataGridView1.Rows[r].Cells["id_post_wf"].Value;
            dataSet_.Tables["Workers"].Rows[7]["post_name_W"] = dataGridView1.Rows[r].Cells["post_name_W"].Value;
           // dataSet_.Tables["Workers"].Rows[8]["id_department_wf"] = dataGridView1.Rows[r].Cells["id_department_wf"].Value;
            dataSet_.Tables["Workers"].Rows[9]["department_name_W"] = dataGridView1.Rows[r].Cells["department_name_W"].Value;
            dataSet_.Tables["Workers"].Rows[10]["isDismissed"] = dataGridView1.Rows[r].Cells["isDismissed"].Value;

            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.Update(dataSet_, "Workers");
            // id_worker, surname, name_worker, middleName,  id_company_wf,     company_name_W,  id_post_wf,   post_name_W,   id_department_wf,  department_name_W, isDismissed) " +


            */



        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowIndex = dataGridView1.SelectedCells[0].RowIndex;

                DataGridViewRow editingRow = dataGridView1.Rows[rowIndex];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Командировочные непосредственно: 
        private void mainWork_BUT4_Click(object sender, EventArgs e)
        {
            MainWork_Form main_Form = new MainWork_Form();
            main_Form.Show();
            this.Hide();
        }

        // To find some information: 
        private void search_BUT1_Click(object sender, EventArgs e)
        {
            string searchText = search_TB1.Text;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                bool rowContainsSearchText = false;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString().Contains(searchText))
                    {
                        rowContainsSearchText = true;
                        //SaveChanges();
                        break;
                    }

                }
                if (row.IsNewRow)
                {
                    continue; // Пропускаем новые строки
                }
                dataGridView1.CurrentCell = null;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                row.Visible = rowContainsSearchText;

                /*

                dataGridView1.CurrentCell = null;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                row.Visible = rowContainsSearchText;*/
            }

            dataGridView1.CurrentCell = null;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Visible)
                {
                    dataGridView1.CurrentCell = row.Cells[0];
                    break;
                }
            }
            search_TB1.Text = "";
        }

        // To show all pieces of information (?)
        private void show_BUT2_Click(object sender, EventArgs e)
        {
            search_TB1.Clear();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Visible = true;
            }
            dataGridView1.CurrentCell = null;
            checkBox1.Checked = false;
        }

        // Update: 
        private void update_BUT3_Click(object sender, EventArgs e)
        {
            search_TB1.Enabled = id_TB2.Enabled = lastName_TB3.Enabled = name_TB4.Enabled = middleName_TB5.Enabled = true;
            search_BUT1.Enabled = show_BUT2.Enabled = add_BUT5.Enabled = save_BUT6.Enabled = true;
            //  8, 7, 4, 1
            post_CB1.Enabled = depart_CB2.Enabled = company_CB3.Enabled = true;
            checkBox1.Enabled = true;

            RefreshData();


            string company_in_q = "SELECT id_company, company_name FROM dbo.Companies";
            using (SqlConnection connection_1 = new SqlConnection(connStr))
            {
                SqlCommand command_company_in = new SqlCommand(company_in_q, connection_1);
                // COMPANY     
                DataTable dTable_company2 = new DataTable();
                SqlDataAdapter adapter_company2 = new SqlDataAdapter();
                adapter_company2.SelectCommand = command_company_in;
                adapter_company2.Fill(dTable_company2);
                company_CB3.DataSource = dTable_company2;
                company_CB3.DisplayMember = "company_name";
                company_CB3.ValueMember = "id_company";
            }
            company_CB3.SelectedValue = 4;
            checkBox1.Checked = false;
        }

        // Информация о сформированных командировках
        private void data_BUT7_Click(object sender, EventArgs e)
        {
            search_TB1.Enabled = id_TB2.Enabled = lastName_TB3.Enabled = name_TB4.Enabled = middleName_TB5.Enabled = false;
            search_BUT1.Enabled = show_BUT2.Enabled = add_BUT5.Enabled = save_BUT6.Enabled = false;
            //  8, 7, 4, 1
            post_CB1.Enabled = depart_CB2.Enabled = company_CB3.Enabled = false;
            checkBox1.Enabled = false;

            // Подключаемся к базе данных
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                // Открываем соединение
                connection.Open();

                // Выполняем запрос для получения данных из таблицы
                SqlCommand command = new SqlCommand("SELECT id_inf as [ID], num_ as [Номер], surname_ as [Фамилия], name_ as [Имя], " +
                        " middleName_ as [Отчество], post_ as [Должность], company_ as [Компания работника], " +
                        " date_doc_ as [Дата приказа], days_in_ as [Дней В], date_go_ as [Дата выбытия], " +
                        " place1_from_ as [Место выбытия], place2_in_ as [Место прибытия], " +
                        " place_finish_[Место возвращения], purpose_ as [Цель]  FROM  dbo.Inform", connection);

                // Создаем объект DataTable для хранения данных из запроса
                DataTable dataTable = new DataTable();

                // Заполняем DataTable данными из запроса
                dataTable.Load(command.ExecuteReader());

                // Задаем DataTable в качестве источника данных для DataGridView
                dataGridView1.DataSource = dataTable;

                // Закрываем соединение
                connection.Close();
            }
        }

        //    ****************   methodSSssSs:


        public void RefreshData()
        {
            // Подключаемся к базе данных
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                // Открываем соединение
                connection.Open();

                // Выполняем запрос для получения данных из таблицы
                SqlCommand command = new SqlCommand("SELECT id_worker as [ID], surname as [Фамилия], name_worker as [Имя], middleName as [Отчество], post_name_W as [Должность], " +
                " department_name_W as [Отдел], company_name_W as [Компания], isDismissed [Уволен ли]  FROM  dbo.Workers", connection);

                // Создаем объект DataTable для хранения данных из запроса
                DataTable dataTable = new DataTable();

                // Заполняем DataTable данными из запроса
                dataTable.Load(command.ExecuteReader());

                // Задаем DataTable в качестве источника данных для DataGridView
                dataGridView1.DataSource = dataTable;

                // Закрываем соединение
                connection.Close();
            }
            search_TB1.Text = id_TB2.Text = lastName_TB3.Text = name_TB4.Text = middleName_TB5.Text = ""; // = textBox4.Text
        }

        private void SaveChanges()
        {
            //using (SqlConnection connectS = new SqlConnection(connStr))
            {
                SqlConnection connectS = new SqlConnection(connStr);

                connectS.Open();
                SqlCommand commanS = new SqlCommand("UPDATE Workers SET  surname = @surname, name_worker = @name_worker, middleName = @middleName, " +
                    "  post_name_W = @post_name_W, department_name_W = @department_name_W, company_name_W = @company_name_W,  " +
                    //  " id_company_wf = @id_company_wf, id_post_wf = @id_post_wf, id_department_wf = @id_department_wf, " +
                    "   isDismissed = @isDismissed  WHERE id_worker = @id_worker", connectS);
                // id_post_wf = @id_post_wf,  

                foreach (DataGridViewRow rowS in dataGridView1.Rows)
                {
                    if (rowS.IsNewRow) continue;

                    string id_worker = rowS.Cells["ID"].Value.ToString();
                    string surname = rowS.Cells["Фамилия"].Value.ToString();
                    string name_worker = rowS.Cells["Имя"].Value.ToString();
                    string middleName = rowS.Cells["Отчество"].Value.ToString();
                    string department_name_W = rowS.Cells["Отдел"].Value.ToString();
                    string company_name_W = rowS.Cells["Компания"].Value.ToString();

                    // string id_post_wf = rowS.Cells["id_post_wf"].Value.ToString();
                    string post_name_W = rowS.Cells["Должность"].Value.ToString();
                    string isDismissed = rowS.Cells["Уволен ли"].Value.ToString();


                    commanS.Parameters.Clear();
                    commanS.Parameters.AddWithValue("id_worker", id_worker);
                    commanS.Parameters.AddWithValue("surname", surname);
                    commanS.Parameters.AddWithValue("name_worker", name_worker);
                    commanS.Parameters.AddWithValue("middleName", middleName);
                    commanS.Parameters.AddWithValue("department_name_W", department_name_W);
                    commanS.Parameters.AddWithValue("company_name_W", company_name_W);
                    commanS.Parameters.AddWithValue("post_name_W", post_name_W);
                    commanS.Parameters.AddWithValue("isDismissed", isDismissed);


                    if (connectS.State != ConnectionState.Open)
                    {
                        connectS.Open();
                    }

                    commanS.ExecuteNonQuery();
                    connectS.Close();


                    SqlDataAdapter adaptS = new SqlDataAdapter("SELECT id_worker as [ID], surname as [Фамилия], name_worker as [Имя], middleName as [Отчество], post_name_W as [Должность], " +
                    " department_name_W as [Отдел], company_name_W as [Компания], isDismissed [Уволен ли]  FROM  dbo.Workers", connectS);
                    DataTable tableS = new DataTable();
                    adaptS.Fill(tableS);
                    dataGridView1.DataSource = tableS;
                }
            }
        }




    }
}
