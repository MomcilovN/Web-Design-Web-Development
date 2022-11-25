using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace radSaPodacimaKorišćenjemEF_a
{
    class EmployeesDB
    {

        SqlConnection conn = ConnectionDB.Instance;


        public List<Employee> dajZaposlene()
        {
            List<Employee> zaposleni = new List<Employee>();

            conn.Open();

            String upit = @"select *
                            from Employees";

            SqlCommand command = new SqlCommand(upit, conn);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                zaposleni.Add(new Employee(int.Parse(reader["EmployeeID"].ToString()), reader["LastName"].ToString(), reader["FirstName"].ToString(), DateTime.Parse(reader["BirthDate"].ToString())));
            }

            conn.Close();

            return zaposleni;
        }


        public void dodajZaposlenog(string LastName, string FirstName, DateTime BirthDate)
        {
            conn.Open();

            String upit = @"insert into Employees values( @LastName, @FirstName, @BirthDate)";
            string datestring = BirthDate.Year.ToString()  + '-' + BirthDate.Month.ToString() + '-' + BirthDate.Day.ToString();
            SqlCommand command = new SqlCommand(upit, conn);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@BirthDate", datestring);

            int broj = command.ExecuteNonQuery();
            if (broj > 0)
            {
                MessageBox.Show("Zaposleni je uspesno dodat.");
            }
            else
            {
                MessageBox.Show("Zaposleni nije dodat.");
            }

            conn.Close();
        }


        public void izmeniZaposlenog(int EmployeeID, string LastName, string FirstName, DateTime BirthDate)
        {
            conn.Open();

            String upit = @"update Employees set LastName=@last, FirstName=@first, BirthDate=@date where EmployeeID=@id";

            SqlCommand command = new SqlCommand(upit, conn);
            command.Parameters.AddWithValue("@id", EmployeeID);
            command.Parameters.AddWithValue("@last", LastName);
            command.Parameters.AddWithValue("@first", FirstName);
            command.Parameters.AddWithValue("@date", BirthDate);

            int broj = command.ExecuteNonQuery();
            if (broj > 0)
            {
                MessageBox.Show("Zaposleni je uspesno izmenjen.");
            }
            else
            {
                MessageBox.Show("Zaposleni nije izmenjen.");
            }

            conn.Close();
        }


        public void obrisiZaposlenog(int EmployeeID)
        {
            conn.Open();

            String upit = @"delete from Employees where EmployeeID=@id";

            SqlCommand command = new SqlCommand(upit, conn);
            command.Parameters.AddWithValue("@id", EmployeeID);

            int broj = command.ExecuteNonQuery();
            if (broj > 0)
            {
                MessageBox.Show("Zaposleni je uspesno obrisan.");
            }
            else
            {
                MessageBox.Show("Zaposleni nije obrisan.");
            }

            conn.Close();
        }
    }
}

