using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace radSaPodacimaKorišćenjemEF_a
{
    public partial class Form2 : Form
    {

        EmployeesDB db = new EmployeesDB();
        Form1 forma1;
        public Form2(Form1 form1)
        {
            forma1 = form1;
            InitializeComponent();
        }

        private void Insert_Click(object sender, EventArgs e)
        {

            if (tb_lastname.Text != "" && tb_lastname.Text != null && tb_firstname.Text != "" && tb_firstname.Text != null)
            {
                string LastName = tb_lastname.Text;
                string FirstName = tb_firstname.Text;
                DateTime BirthDate = dtp.Value;
                db.dodajZaposlenog(LastName, FirstName, BirthDate);
                forma1.ubaciZaposlene();
                this.Close();
               
            }
            else
            {
                MessageBox.Show("Popunite ime i prezime zaposlenog");
            }
        }
    }
}
