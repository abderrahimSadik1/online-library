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


namespace Biblio
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SignUp signUpForm = new SignUp();

            signUpForm.ShowDialog();
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

        private void button1_Click(object sender, EventArgs e)
        {
            string username = uname.Text;
            string enteredPassword = pw.Text;

            string connectionString = "Data Source=MIDNIGHT\\SQLEXPRESS;Initial Catalog=BiblioDB;Integrated Security=True;Encrypt=False"; // Replace with your connection string

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT password FROM Emp WHERE username = @Username";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);

                try
                {
                    connection.Open();
                    string hashedStoredPassword = command.ExecuteScalar()?.ToString();

                    if (hashedStoredPassword != null)
                    {
                        // Hash the entered password for comparison
                        string hashedEnteredPassword = HashPassword(enteredPassword);

                        // Compare the hashed entered password with the hashed stored password
                        if (hashedStoredPassword.Equals(hashedEnteredPassword))
                        {
                            MessageBox.Show("Login Successful!");
                            Manager managerForm = new Manager();
                            managerForm.Show();

                            this.Hide(); // Hide the Login form
                        }
                        else
                        {
                            MessageBox.Show("Invalid credentials. Please try again.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid credentials. Please try again.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

    }
}
