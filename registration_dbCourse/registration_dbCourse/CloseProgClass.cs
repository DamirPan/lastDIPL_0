using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace registration_dbCourse
{
    class CloseProgClass
    {
        public void CloseProg()
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите выйти из приложения? ", "Внимание", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) Application.Exit(); else { };

        }

        public string HashFun(string pass)//, string passHash_)
        {
            byte[] byteIsh = new UTF8Encoding().GetBytes(pass);
            SHA256 shaMan = new SHA256Managed();
            byte[] byteShaMan = shaMan.ComputeHash(byteIsh);
            string passHash_ = BitConverter.ToString(byteShaMan);
            passHash_ = passHash_.ToLower().Replace("-", string.Empty);
            return passHash_;
        }

        /*
       private Form form_ = new Form(); 
       public void ChangeForm(Form form)
       {

           form_.Show();
       }
       */

    }
}
