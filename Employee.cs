using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace radSaPodacimaKorišćenjemEF_a
{
    class Employee
    {

        public int EmpleyeeID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }

        public Employee(int empleyeeID, string lastName, string firstName, DateTime birthDate)
        {
            EmpleyeeID = empleyeeID;
            LastName = lastName;
            FirstName = firstName;
            BirthDate = birthDate;
        }
    }
}
