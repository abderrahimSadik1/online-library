using System;
namespace Biblio
{

    public class Employee
    {
        // Properties representing employee attributes
        public int EmployeeID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? EmploymentDate { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        // Constructors (optional)
        public Employee() { }

        public Employee(int id, string fName, string lName, DateTime bDate, string addr, string phone, DateTime eDate, string username, string email, string password)
        {
            EmployeeID = id;
            FirstName = fName;
            LastName = lName;
            BirthDate = bDate;
            Address = addr;
            PhoneNumber = phone;
            EmploymentDate = eDate;
            Username = username;
            Email = email;
            Password = password;
        }

        // Other methods if needed
    }
}

