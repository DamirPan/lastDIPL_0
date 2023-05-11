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
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using System.IO;
using System.Globalization;

namespace registration_dbCourse
{
    public partial class MainWork_Form : Form
    {
        // ХЗ Почему, но лучше объявлять через интерфейсы... 
        Word._Application application;
        Word._Document document;

        // Ок, пусть заранее и обёртки некоторые будут...:
        Object missingObj = System.Reflection.Missing.Value;
        Object trueObj = true;
        Object falseObj = false;




        string newFolder = "Командировочные удостоверения";
        string connStr = @"Data Source=IGORSPC;Initial Catalog=businessDB_VS_1;Integrated Security=True";

        int id_inf_0, id_inf;


        CloseProgClass close_Class = new CloseProgClass();
        AddWorker_Form addWorker_F = new AddWorker_Form();
        // ConnectClass connect_Class = new ConnectClass();


        public MainWork_Form()
        {
            InitializeComponent();

            DateTime now = DateTime.Now;
            dateTimePicker1.Value = dateTimePicker2.Value = dateTimePicker3.Value = now;

            dateTimePicker3.Visible = false;
            post_CB7.Visible = company_CB8.Visible = false;
        }

        private void MainWork_Form_Load(object sender, EventArgs e)
        {
            addWorker_F.RefreshData();

            string fio_q = "SELECT surname, name_worker, middleName, post_name_W, company_name_W FROM dbo.Workers WHERE isDismissed = 0 ";/* +
                 "  JOIN dbo.Posts ON dbo.Workers.id_post_wf = Posts.id_post " +
                 "  JOIN dbo.Companies ON dbo.Workers.id_company_wf = dbo.Companies.id_company ";*/
            string company_in_q = "SELECT id_company, company_name FROM dbo.Companies";

            //  string company_comboBox4 = "SELECT company_name FROM dbo.Companies WHERE id_company = 4";

            using (SqlConnection connection_fill = new SqlConnection(connStr))
            {
                SqlCommand command_fio = new SqlCommand(fio_q, connection_fill);
                SqlCommand command_company_in = new SqlCommand(company_in_q, connection_fill);

                /*
                 SqlCommand command_comp_comb4 = new SqlCommand(company_comboBox4, connection_fill);

                 DataTable dTable_cb4 = new DataTable();
                 SqlDataAdapter adapter_cb4 = new SqlDataAdapter();
                 adapter_cb4.SelectCommand = command_comp_comb4;
                 adapter_cb4.Fill(dTable_cb4);
                 comboBox4.DataSource = dTable_cb4;
                 */

                // ФИО 
                DataTable dTable_fio = new DataTable();
                SqlDataAdapter adapter_fio = new SqlDataAdapter();
                adapter_fio.SelectCommand = command_fio;
                adapter_fio.Fill(dTable_fio);
                surname_CB1.DataSource = dTable_fio;
                surname_CB1.DisplayMember = "surname";
                name_CB2.DataSource = dTable_fio;
                name_CB2.DisplayMember = "name_worker";
                middleName_CB3.DataSource = dTable_fio;
                middleName_CB3.DisplayMember = "middleName";
                post_CB7.DataSource = dTable_fio;
                post_CB7.DisplayMember = "post_name_W";
                company_CB8.DataSource = dTable_fio;
                company_CB8.DisplayMember = "company_name_W";

                // string dolznost_your;
                // string company_your;

                // Должность
                /*   DataTable dTable_post = new DataTable();
                   SqlDataAdapter adapter_post = new SqlDataAdapter();
                   adapter_post.SelectCommand = command_fio;
                   adapter_post.Fill(dTable_post);
                   comboBox8.DataSource = dTable_fio;
                   comboBox8.DisplayMember = "post_name";
                   // КОМПАНИЯ 
                   DataTable dTable_company = new DataTable();
                   SqlDataAdapter adapter_company = new SqlDataAdapter();
                   adapter_company.SelectCommand = command_fio;
                   adapter_company.Fill(dTable_company);
                   comboBox7.DataSource = dTable_fio;
                   comboBox7.DisplayMember = "company_name";
                  */

                // COMPANY     
                DataTable dTable_company2 = new DataTable();
                SqlDataAdapter adapter_company2 = new SqlDataAdapter();
                adapter_company2.SelectCommand = command_company_in;
                adapter_company2.Fill(dTable_company2);
                placeFrom_CB4.DataSource = dTable_company2;
                placeFrom_CB4.DisplayMember = "company_name";
                placeFrom_CB4.ValueMember = "id_company";

                // КОМПАНИЯ В !!!
                DataTable dTable_company_in = new DataTable();
                SqlDataAdapter adapter_company_in = new SqlDataAdapter();
                adapter_company_in.SelectCommand = command_company_in;
                adapter_company_in.Fill(dTable_company_in);
                placeIn_CB5.DataSource = dTable_company_in;
                placeIn_CB5.DisplayMember = "company_name";

                // COMPANY IN 2
                DataTable dTable_company_in2 = new DataTable();
                SqlDataAdapter adapter_company_in2 = new SqlDataAdapter();
                adapter_company_in2.SelectCommand = command_company_in;
                adapter_company_in2.Fill(dTable_company_in2);
                placeFin_CB6.DataSource = dTable_company_in2;
                placeFin_CB6.DisplayMember = "company_name";

            }
            placeFrom_CB4.SelectedValue = 4;
        }

        // Exit
        private void exit_BUT2_Click(object sender, EventArgs e)
        {
            close_Class.CloseProg();
        }

       /* private void post_CB7_SelectedIndexChanged(object sender, EventArgs e)
        {
            placeFrom_CB4.Text = placeIn_CB5.Text = company_CB8.Text;
        }*/


        private void placeFrom_CB4_SelectedIndexChanged(object sender, EventArgs e)
        {
            placeFin_CB6.Text = placeFrom_CB4.Text;
        }

        // Print out button: 
        private void print_BUT1_Click(object sender, EventArgs e)
        {
            int days = (int)numericUpDown1.Value;
            dateTimePicker3.Value = dateTimePicker2.Value.AddDays(days);

            string number_doc;
            // connect_Class.Connection_Prog();


            using (SqlConnection connection_2 = new SqlConnection(connStr))
            {
                connection_2.Open();
                string id_inform_Q = "SELECT MAX(id_inf) FROM dbo.Inform";

                SqlCommand command_2 = new SqlCommand(id_inform_Q, connection_2);
                id_inf_0 = (int)command_2.ExecuteScalar();
                id_inf = id_inf_0 + 1;

                if (dateTimePicker1.Value <= dateTimePicker2.Value)
                {
                    number_doc = "K-" + id_inf.ToString("0000#");
                }
                else
                {
                    number_doc = "K-A-" + id_inf.ToString("0000#");
                }
            }

            // путь к папке (создать и проверить, есть ли она уже (на рабочем столе) 
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), newFolder); // Desktop 
            if (!Directory.Exists(path))
            {
                try
                {
                    Directory.CreateDirectory(path);
                }
                catch (IOException ie)
                {
                    Console.WriteLine("IO Error: " + ie.Message);
                }
            }

            var rus = CultureInfo.GetCultureInfo("ru-RU");

            // 1
            string number_f = "@N";
            string replace_number_f = number_doc;
            // 2
            string surname_f = "_@surname____________________________________________________________________";
            string replace_surname_f = surname_CB1.Text + " " + name_CB2.Text + " " + middleName_CB3.Text;
            // 3
            string company_f = "_@company____________________________________________________________________";
            string replace_company_f = post_CB7.Text + ", " + company_CB8.Text;
            // 4
            string place_in_f = "_@place_in___________________________________________________";
            string replace_place_in_f = placeIn_CB5.Text;
            // 5
            string days_f = "@days__";
            int replace_days_f = (int)numericUpDown1.Value;
            // 6
            string purpose_f = "_@purpose____________________________________________________________________";
            string replace_purpose_f = purpose_TB1.Text;
            // 7
            string baseDate_f = "@baseD";
            string replace_baseDate_f = dateTimePicker1.Value.ToString("dd");
            // 8
            string baseMonth_f = "@baseMonth";
            string replace_baseMonth_f = rus.DateTimeFormat.MonthGenitiveNames[dateTimePicker1.Value.Month - 1];
            // 9 
            string baseYear_f = "@BY"; // B-ase_Y-ear
            string replace_baseYear_f = dateTimePicker1.Value.ToString("yy");
            // 10 
            string dadCompany_f = "_@dadCompany___________"; // company A
            string replaceDadCompany_f = placeFrom_CB4.Text;
            // 11 
            string day1_f = "@D1";
            string replaceDay1_f = dateTimePicker2.Value.ToString("dd");
            // 12 
            string month1_f = "@month1";
            string replaceMonth1_f = rus.DateTimeFormat.MonthGenitiveNames[dateTimePicker2.Value.Month - 1];
            // 13
            string year1_f = "@Y1";
            string replaceYear1_f = dateTimePicker2.Value.ToString("yy");
            // 14 
            string sonCompany_f = "_@sonCompany____________"; // company B
            string replaceSonCompany_f = placeIn_CB5.Text;
            // 15 
            object endCompany_f = "_@endCompany______________";   // here were some prblms
            object replaceEndCompany_f = placeFin_CB6.Text;
            // 16
            object dayEnd_f = "@De";
            object replaceDayEnd_f = dateTimePicker3.Value.ToString("dd");
            // 17
            object monthEnd_f = "@endMonth";
            object replaceMonthEnd_f = rus.DateTimeFormat.MonthGenitiveNames[dateTimePicker3.Value.Month - 1];
            // 18
            object yearEnd_f = "@Ye";
            object replaceYearEnd_f = dateTimePicker3.Value.ToString("yy");


            application = new Word.Application();
            Object templatePathObj = "D:\\4 КУРС\\_Практика_1\\Code\\Course_Project\\registration_dbCourse\\registration_dbCourse\\bin\\Debug\\Komandirovochnoe_udostoverenie.doc";

            // если вылетим нa этом этапе, приложение останется открытым
            try
            {
                document = application.Documents.Add(ref templatePathObj, ref missingObj, ref missingObj, ref missingObj);

            }
            catch (Exception error)
            {
                document.Close(ref falseObj, ref missingObj, ref missingObj);
                document = null;
                application = null;
                throw error;
            }
            application.Visible = true;







            object strToFindObj = number_f;           // 1
            object replaceStrObj = replace_number_f;  // 1
            object strToFindSurnameObj = surname_f;       // 2
            object replaceSurnameObj = replace_surname_f; // 2
            object strToFindCompanyObj = company_f;       // 3
            object replaceCompanyObj = replace_company_f; // 3
            object strToFindPlace_inObj = place_in_f;      // 4
            object replacePlace_inObj = replace_place_in_f;// 4
            object strToFindDaysObj = days_f;              // 5
            object replaceDaysObj = replace_days_f;        // 5
            object strToFindPurposeObj = purpose_f;        // 6
            object replacePurposeObj = replace_purpose_f;  // 6
            object strToFindBaseDateObj = baseDate_f;         // 7
            object replaceBaseDateObj = replace_baseDate_f;   // 7
            object strToFindBaseMonthObj = baseMonth_f;       // 8
            object replaceBaseMonthObj = replace_baseMonth_f; // 8
            object strToFindBaseYearObj = baseYear_f;         // 9
            object replaceBaseYearObj = replace_baseYear_f;   // 9
            object strToFindDadCompanyObj = dadCompany_f;        // 10
            object replaceDadCompanyObj = replaceDadCompany_f;   // 10
            object strToFindDay1Obj = day1_f;                    // 11
            object replaceDay1Obj = replaceDay1_f;               // 11
            object strToFindMonth1Obj = month1_f;                // 12
            object replaceMonth1Obj = replaceMonth1_f;           // 12 
            object strToFindYear1Obj = year1_f;                  // 13
            object replaceYear1Obj = replaceYear1_f;             // 13
            object strToFindSonCompanyObj = sonCompany_f;      // 14
            object replaceSonCompanyObj = replaceSonCompany_f; // 14


            object strToFindEndCompanyObj = endCompany_f;
            object replaceEndCompanyObj = replaceEndCompany_f;
            object strToFindDayEndObj = dayEnd_f;
            object replaceDayEndObj = replaceDayEnd_f;
            object strToFindMonthEndObj = monthEnd_f;
            object replaceMonthEndObj = replaceMonthEnd_f;
            object strToFindYearEndObj = yearEnd_f;
            object replaceYearObj = replaceYearEnd_f;


            // диапазон документа Word
            Word.Range wordRange;

            // Тип поиска и замены
            object replaceTypeObj;
            replaceTypeObj = Word.WdReplace.wdReplaceAll;

            // Обход всех разделов документа 
            for (int i = 1; i <= document.Sections.Count; i++)
            {
                // берем всю секцию диапазоном
                wordRange = document.Sections[i].Range;


                //1
                Word.Find wordFindObj = wordRange.Find;
                FindAndReplace(wordFindObj, strToFindObj, replaceStrObj, missingObj, replaceTypeObj);

                //2
                Word.Find surnameFindObj = wordRange.Find;
                FindAndReplace(surnameFindObj, strToFindSurnameObj, replaceSurnameObj, missingObj, replaceTypeObj);

                //3
                Word.Find companyFindObj = wordRange.Find;
                FindAndReplace(companyFindObj, strToFindCompanyObj, replaceCompanyObj, missingObj, replaceTypeObj);

                //4
                Word.Find place_inFindObj = wordRange.Find;
                FindAndReplace(place_inFindObj, strToFindPlace_inObj, replacePlace_inObj, missingObj, replaceTypeObj);

                //5
                Word.Find daysFindObj = wordRange.Find;
                FindAndReplace(daysFindObj, strToFindDaysObj, replaceDaysObj, missingObj, replaceTypeObj);

                //6
                Word.Find purposeFindObj = wordRange.Find;
                FindAndReplace(purposeFindObj, strToFindPurposeObj, replacePurposeObj, missingObj, replaceTypeObj);

                //7
                Word.Find baseDateFindObj = wordRange.Find;
                FindAndReplace(baseDateFindObj, strToFindBaseDateObj, replaceBaseDateObj, missingObj, replaceTypeObj);

                //8
                Word.Find baseMonthFindObj = wordRange.Find;
                FindAndReplace(baseMonthFindObj, strToFindBaseMonthObj, replaceBaseMonthObj, missingObj, replaceTypeObj);

                //9
                Word.Find baseYearFindObj = wordRange.Find;
                FindAndReplace(baseYearFindObj, strToFindBaseYearObj, replaceBaseYearObj, missingObj, replaceTypeObj);

                //10
                Word.Find dadCompanyFindObj = wordRange.Find;
                FindAndReplace(dadCompanyFindObj, strToFindDadCompanyObj, replaceDadCompanyObj, missingObj, replaceTypeObj);

                //11
                Word.Find day1FindObj = wordRange.Find;
                FindAndReplace(day1FindObj, strToFindDay1Obj, replaceDay1Obj, missingObj, replaceTypeObj);

                //12
                Word.Find month1FindObj = wordRange.Find;
                FindAndReplace(month1FindObj, strToFindMonth1Obj, replaceMonth1Obj, missingObj, replaceTypeObj);

                //13
                Word.Find year1FindObj = wordRange.Find;
                FindAndReplace(year1FindObj, strToFindYear1Obj, replaceYear1Obj, missingObj, replaceTypeObj);

                //14
                Word.Find sonCompanyFindObj = wordRange.Find;
                FindAndReplace(sonCompanyFindObj, strToFindSonCompanyObj, replaceSonCompanyObj, missingObj, replaceTypeObj);

                //18
                Word.Find endCompanyFindObj = wordRange.Find;
                FindAndReplace(endCompanyFindObj, strToFindEndCompanyObj, replaceEndCompanyObj, missingObj, replaceTypeObj);

                //19
                Word.Find dayEndFindObj = wordRange.Find;
                FindAndReplace(dayEndFindObj, strToFindDayEndObj, replaceDayEndObj, missingObj, replaceTypeObj);

                //20
                Word.Find endMonthFindObj = wordRange.Find;
                FindAndReplace(endMonthFindObj, strToFindMonthEndObj, replaceMonthEndObj, missingObj, replaceTypeObj);

                //21
                Word.Find endYearFindObj = wordRange.Find;
                FindAndReplace(endYearFindObj, strToFindYearEndObj, replaceYearObj, missingObj, replaceTypeObj);


                string fileName = replace_number_f;
                string descT = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                document.SaveAs2(@"C:\Users\IgorOK\Desktop\\Командировочные удостоверения\\" + fileName + ".doc");

                // document.SaveAs2(@"C:\Users\IgorOK\Desktop\\Командировочные удостоверения\\" + fileName + ".doc");
            }
            // Конец 1



            using (SqlConnection connect_last = new SqlConnection(connStr))
            {
                connect_last.Open();

                SqlCommand comm_last = new SqlCommand("INSERT INTO dbo.Inform  (id_inf, num_, surname_, name_, middleName_, post_, " +
                    " company_, date_doc_, days_in_, date_go_, place1_from_, place2_in_, place_finish_, purpose_) VALUES " +
                                                                     " (@id_inf, @num_, @surname_, @name_, @middleName_, @post_, " +
                    " @company_, @date_doc_, @days_in_, @date_go_, @place1_from_, @place2_in_, @place_finish_, @purpose_) ", connect_last);

                comm_last.Parameters.AddWithValue("id_inf", id_inf);
                comm_last.Parameters.AddWithValue("num_", replace_number_f);
                comm_last.Parameters.AddWithValue("surname_", surname_CB1.Text);
                comm_last.Parameters.AddWithValue("name_", name_CB2.Text);
                comm_last.Parameters.AddWithValue("middleName_", middleName_CB3.Text);
                comm_last.Parameters.AddWithValue("post_", post_CB7.Text);
                comm_last.Parameters.AddWithValue("company_", company_CB8.Text);
                comm_last.Parameters.AddWithValue("date_doc_", dateTimePicker1.Text);
                comm_last.Parameters.AddWithValue("days_in_", replace_days_f);
                comm_last.Parameters.AddWithValue("date_go_", dateTimePicker2.Text);
                comm_last.Parameters.AddWithValue("place1_from_", replaceDadCompany_f);
                comm_last.Parameters.AddWithValue("place2_in_", replaceSonCompany_f);
                comm_last.Parameters.AddWithValue("place_finish_", replaceEndCompany_f);
                comm_last.Parameters.AddWithValue("purpose_", replace_purpose_f);

                comm_last.ExecuteNonQuery();
            }
        }

        private void company_CB8_SelectedIndexChanged(object sender, EventArgs e)
        {
            placeFrom_CB4.Text = placeIn_CB5.Text = company_CB8.Text;
        }

        private static void FindAndReplace(Word.Find findObj, object strToFindObj, object replaceStrObj, object missingObj, object replaceTypeObj)
        {
            object[] findParameters = new object[15] { strToFindObj,
                                missingObj, missingObj, missingObj, missingObj, missingObj,
                                missingObj, missingObj, missingObj, replaceStrObj,
                                replaceTypeObj, missingObj, missingObj, missingObj,
                                missingObj };
            findObj.GetType().InvokeMember("Execute", BindingFlags.InvokeMethod, null, findObj, findParameters);
        }
    }
}
