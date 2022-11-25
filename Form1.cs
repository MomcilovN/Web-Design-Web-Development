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
    public partial class Form1 : Form
    {

        EmployeesDB db = new EmployeesDB();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ubaciZaposlene();


        }
        public void ubaciZaposlene()
        {
            List<Employee> zap = db.dajZaposlene();
            zaposleni.Rows.Clear();

            foreach (Employee item in zap)
            {

                DataGridViewRow row = (DataGridViewRow)zaposleni.Rows[0].Clone();

                row.Tag = item;

                row.Cells[0].Value = item.EmpleyeeID;
                row.Cells[1].Value = item.LastName;
                row.Cells[2].Value = item.FirstName;
                row.Cells[3].Value = item.BirthDate;

                zaposleni.Rows.Add(row);
            }

        }
       
       

        private void Update_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox1.Text != null)
            {
                int EmployeeID = int.Parse(textBox1.Text);
                string LastName = textBox2.Text;
                string FirstName = textBox3.Text;
                DateTime BirthDate = dateTimePicker1.Value;
                db.izmeniZaposlenog(EmployeeID, LastName, FirstName, BirthDate);
                ubaciZaposlene();
            }
            else
            {
                MessageBox.Show("Popunite zahtevana polja");
            }

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            int id;
            if (zaposleni.SelectedRows.Count > 0)
            {
                id = int.Parse(zaposleni.SelectedRows[0].Cells[0].Value.ToString());
                db.obrisiZaposlenog(id);
                ubaciZaposlene();
            }
            else
            {
                MessageBox.Show("Izaberite ceo red");
            }
            
        }

        private void Insert_Click(object sender, EventArgs e)
        {

            Form2 form = new Form2(this);
            form.Show();
        }

       

        private void zaposleni_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
                if (e.RowIndex >= 0)
                            {
                                DataGridViewRow row = this.zaposleni.Rows[e.RowIndex];
                                textBox1.Text = row.Cells[0].Value.ToString();
                                textBox2.Text = row.Cells[1].Value.ToString();
                                textBox3.Text = row.Cells[2].Value.ToString();
                            }
        }
    }
}
