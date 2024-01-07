using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Net;

namespace Biblio
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void SignUp_Load(object sender, EventArgs e)
        {
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string username = uname.Text;
            string email = em.Text;
            string password = pw.Text;
            string confirmPassword = cpw.Text;
            string fname_ = fname.Text;
            string lname_ = lname.Text;
            DateTime bdate_ = DateTime.Parse(bdate.Text); // Convert to DateTime
            string addr_ = addr.Text;
            string tel_ = tel.Text;
            DateTime edate_ = DateTime.Parse(edate.Text); // Convert to DateTime

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match. Please re-enter the password.");
                return;
            }

            // Hash the password before insertion
            string hashedPassword = HashPassword(password);

            Employee newEmployee = new Employee()
            {
                Username = username,
                Email = email,
                Password = hashedPassword,
                FirstName = fname_,
                LastName = lname_,
                BirthDate = bdate_,
                Address = addr_,
                PhoneNumber = tel_,
                EmploymentDate = edate_
            };

            // Insert the new employee into the database
            if (InsertEmployeeIntoDatabase(newEmployee))
            {
                MessageBox.Show("User signed in successfully!");
                uname.Text = "";
                em.Text = "";
                pw.Text = "";
                cpw.Text = "";
            }
            else
            {
                MessageBox.Show("Insertion failed. Please try again.");
            }
        }

        private bool InsertEmployeeIntoDatabase(Employee employee)
        {
            string connectionString = "Data Source=MIDNIGHT\\SQLEXPRESS;Initial Catalog=BiblioDB;Integrated Security=True;Encrypt=False"; // Replace with your connection string

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Emp (username, email, password, fname, lname, bdate, addr, tel, edate) " +
                               "VALUES (@Username, @Email, @Password, @Fname, @Lname, @Bdate, @Addr, @Tel, @Edate)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", employee.Username);
                command.Parameters.AddWithValue("@Email", employee.Email);
                command.Parameters.AddWithValue("@Password", employee.Password);
                command.Parameters.AddWithValue("@Fname", employee.FirstName);
                command.Parameters.AddWithValue("@Lname", employee.LastName);
                command.Parameters.AddWithValue("@Bdate", employee.BirthDate);
                command.Parameters.AddWithValue("@Addr", employee.Address);
                command.Parameters.AddWithValue("@Tel", employee.PhoneNumber);
                command.Parameters.AddWithValue("@Edate", employee.EmploymentDate);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return false;
                }
            }
        }

    }
}
