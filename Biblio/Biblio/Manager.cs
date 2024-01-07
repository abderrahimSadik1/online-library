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
using System.Drawing;
using System.IO;
using OfficeOpenXml;
using Microsoft.VisualBasic.FileIO;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;


namespace Biblio
{
    public partial class Manager : Form
    {
        private string connectionString = "Data Source=MIDNIGHT\\SQLEXPRESS;Initial Catalog=BiblioDB;Integrated Security=True;Encrypt=False"; // Replace with your connection string

        public Manager()
        {
            InitializeComponent();
            DisplayEmployees();
            DisplaySubscriber();
            DisplayDocuments();
            DisplayExpSub();
            DisplayReservations();
            Emp.SelectionChanged += Emp_SelectionChanged;
            Sub.SelectionChanged += Sub_SelectionChanged;
            Doc.SelectionChanged += Doc_SelectionChanged;
            Res.SelectionChanged += Res_SelectionChanged;
            e_search.TextChanged += e_search_TextChanged;
            s_search.TextChanged += s_search_TextChanged;
            d_search.TextChanged += d_search_TextChanged;
            r_search.TextChanged += r_search_TextChanged;
            List<string> categories = new List<string>
            {
                "Roman",
                "Science-fiction",
                "Fantasy",
                "Mystère",
                "Biographie",
                "Histoire",
                "Art",
                "Cuisine",
                "Voyage",
                "Science"
            };
            cat.Items.AddRange(categories.ToArray());
            List<Subscriber> subscribers = FetchSubscribersFromDatabase();
            adh.DataSource = subscribers;
            adh.DisplayMember = "Username"; // Assuming Username is the property to display
            adh.ValueMember = "SubscriberID"; // Assuming SubscriberID is the unique identifier
            List<Document> documents = FetchDocumentsFromDatabase();
            // Assuming checkedListBox1 is the name of your CheckedListBox control
            doc_.DataSource = documents;
            doc_.DisplayMember = "Title";
            doc_.ValueMember = "DocumentID";
        }

        private void DisplayEmployees()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Emp";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable employeesTable = new DataTable();
                adapter.Fill(employeesTable);

                Emp.DataSource = employeesTable;
                Emp.Columns["password"].Visible = false;
                Emp.Columns["fname"].HeaderText = "Prénom";
                Emp.Columns["lname"].HeaderText = "Nom";
                Emp.Columns["bdate"].HeaderText = "Date de naissance";
                Emp.Columns["edate"].HeaderText = "Date d'emploiment";
                Emp.Columns["addr"].HeaderText = "Addresse";
                Emp.Columns["tel"].HeaderText = "Numéro de téléphone";
                Emp.Columns["username"].HeaderText = "Username";
                Emp.Columns["email"].HeaderText = "Email";
            }
        }

        private void Emp_SelectionChanged(object sender, EventArgs e)
        {
            if (Emp.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = Emp.SelectedRows[0];

                // Assuming the column indices match the order in which they're displayed in the DataGridView
                uname.Text = selectedRow.Cells[1].Value?.ToString();
                fname.Text = selectedRow.Cells[4].Value?.ToString();
                lname.Text = selectedRow.Cells[5].Value?.ToString();
                if (DateTime.TryParse(selectedRow.Cells[6].Value?.ToString(), out DateTime bDate))
                {
                    bdate.Value = bDate;
                }
                else
                {

                    bdate.Value = DateTime.Today;
                }
                em.Text = selectedRow.Cells[2].Value?.ToString();
                addr.Text = selectedRow.Cells[7].Value?.ToString();
                tel.Text = selectedRow.Cells[8].Value?.ToString();
                if (DateTime.TryParse(selectedRow.Cells[9].Value?.ToString(), out DateTime eDate))
                {
                    edate.Value = eDate;
                }
                else
                {
                    edate.Value = DateTime.Today;
                }
            }
        }

        private void del_Click(object sender, EventArgs e)
        {
            if (Emp.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to delete this row?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DataGridViewRow selectedRow = Emp.SelectedRows[0];

                    // Assuming EmployeeID is stored in the first column (adjust the index as needed)
                    int employeeID = Convert.ToInt32(selectedRow.Cells[0].Value);

                    string connectionString = "Data Source=MIDNIGHT\\SQLEXPRESS;Initial Catalog=BiblioDB;Integrated Security=True;Encrypt=False"; // Replace with your connection string

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "DELETE FROM Emp WHERE ID = @EmployeeID";

                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@EmployeeID", employeeID);

                        try
                        {
                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Row deleted successfully!");
                                // Refresh DataGridView after deletion
                                DisplayEmployees(); // Custom method to reload data
                            }
                            else
                            {
                                MessageBox.Show("No rows deleted. Please try again.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }

        private void mod_Click(object sender, EventArgs e)
        {
            if (Emp.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to modify this row?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DataGridViewRow selectedRow = Emp.SelectedRows[0];

                    // Assuming EmployeeID is stored in the first column (adjust the index as needed)
                    int employeeID = Convert.ToInt32(selectedRow.Cells[0].Value);

                    string uname_ = uname.Text;
                    string email = em.Text;
                    string fname_ = fname.Text; // Get data from text boxes
                    string lname_ = lname.Text;
                    string bdate_ = bdate.Value.ToString("yyyy-MM-dd"); // Convert DateTime to string
                    string addr_ = addr.Text;
                    string tel_ = tel.Text;
                    string edate_ = edate.Value.ToString("yyyy-MM-dd"); // Convert DateTime to string

                    string connectionString = "Data Source=MIDNIGHT\\SQLEXPRESS;Initial Catalog=BiblioDB;Integrated Security=True;Encrypt=False"; // Replace with your connection string

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "UPDATE Emp SET username = @Uname, email = @Email, fname = @FName, lname = @LName, bdate = @BDate, addr = @Addr, tel = @Tel, edate = @EDate WHERE ID = @EmployeeID";

                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Uname", uname_);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@FName", fname_);
                        command.Parameters.AddWithValue("@LName", lname_);
                        command.Parameters.AddWithValue("@BDate", bdate_);
                        command.Parameters.AddWithValue("@Addr", addr_);
                        command.Parameters.AddWithValue("@Tel", tel_);
                        command.Parameters.AddWithValue("@EDate", edate_);
                        command.Parameters.AddWithValue("@EmployeeID", employeeID);

                        try
                        {
                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Row modified successfully!");
                                DisplayEmployees();
                            }
                            else
                            {
                                MessageBox.Show("No rows modified. Please try again.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row to modify.");
            }
        }


        //sub--------------------------------------------------------------------------------

        private void DisplaySubscriber()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Subscribers";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable employeesTable = new DataTable();
                adapter.Fill(employeesTable);

                Sub.DataSource = employeesTable;
                Sub.Columns["Password"].Visible = false;
                Sub.Columns["Username"].DisplayIndex = 1;
                Sub.Columns["Email"].DisplayIndex = 2;
                Sub.Columns["FirstName"].DisplayIndex = 3;
                Sub.Columns["LastName"].DisplayIndex = 4;
                Sub.Columns["DateOfBirth"].DisplayIndex = 5;
                Sub.Columns["Address"].DisplayIndex = 6;
                Sub.Columns["PhoneNumber"].DisplayIndex = 7;

                Sub.Columns["SubscriberID"].HeaderText = "ID";
                Sub.Columns["FirstName"].HeaderText = "Prénom";
                Sub.Columns["LastName"].HeaderText = "Nom";
                Sub.Columns["DateOfBirth"].HeaderText = "Date de naissance";
                Sub.Columns["Address"].HeaderText = "Addresse";
                Sub.Columns["PhoneNumber"].HeaderText = "Numéro de téléphone";
                Sub.Columns["Username"].HeaderText = "Username";
                Sub.Columns["Email"].HeaderText = "Email";
            }
        }

        private void Sub_SelectionChanged(object sender, EventArgs e)
        {
            if (Sub.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = Sub.SelectedRows[0];

                // Assuming the column indices match the order in which they're displayed in the DataGridView
                s_uname.Text = selectedRow.Cells[6].Value?.ToString();
                s_fname.Text = selectedRow.Cells[1].Value?.ToString();
                s_lname.Text = selectedRow.Cells[2].Value?.ToString();
                if (DateTime.TryParse(selectedRow.Cells[7].Value?.ToString(), out DateTime bDate))
                {
                    s_bdate.Value = bDate;
                }
                else
                {
                    s_bdate.Value = DateTime.Today;
                }
                s_em.Text = selectedRow.Cells[4].Value?.ToString();
                s_addr.Text = selectedRow.Cells[3].Value?.ToString();
                s_tel.Text = selectedRow.Cells[5].Value?.ToString();
            }
        }

        private void s_mod_Click(object sender, EventArgs e)
        {
            if (Sub.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to modify this row?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DataGridViewRow selectedRow = Sub.SelectedRows[0];

                    // Assuming SubscriberID is stored in the first column (adjust the index as needed)
                    int subscriberID = Convert.ToInt32(selectedRow.Cells[0].Value);

                    string uname_ = s_uname.Text;
                    string email = s_em.Text;
                    string fname_ = s_fname.Text; // Get data from text boxes
                    string lname_ = s_lname.Text;
                    string bdate_ = s_bdate.Value.ToString("yyyy-MM-dd"); // Convert DateTime to string
                    string addr_ = s_addr.Text;
                    string tel_ = s_tel.Text;

                    string connectionString = "Data Source=MIDNIGHT\\SQLEXPRESS;Initial Catalog=BiblioDB;Integrated Security=True;Encrypt=False"; // Replace with your connection string

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "UPDATE Subscribers SET Username = @Uname, Email = @Email, FirstName = @FName, LastName = @LName, DateOfBirth = @BDate, Address = @Addr, PhoneNumber = @Tel WHERE SubscriberID = @SubscriberID";

                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Uname", uname_);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@FName", fname_);
                        command.Parameters.AddWithValue("@LName", lname_);
                        command.Parameters.AddWithValue("@BDate", bdate_);
                        command.Parameters.AddWithValue("@Addr", addr_);
                        command.Parameters.AddWithValue("@Tel", tel_);
                        command.Parameters.AddWithValue("@SubscriberID", subscriberID);

                        try
                        {
                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Row modified successfully!");
                                DisplaySubscriber();
                            }
                            else
                            {
                                MessageBox.Show("No rows modified. Please try again.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row to modify.");
            }
        }

        private void s_del_Click(object sender, EventArgs e)
        {
            if (Sub.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to delete this row?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DataGridViewRow selectedRow = Sub.SelectedRows[0];

                    // Assuming SubscriberID is stored in the first column (adjust the index as needed)
                    int subscriberID = Convert.ToInt32(selectedRow.Cells[0].Value);

                    string connectionString = "Data Source=MIDNIGHT\\SQLEXPRESS;Initial Catalog=BiblioDB;Integrated Security=True;Encrypt=False"; // Replace with your connection string

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "DELETE FROM Subscribers WHERE SubscriberID = @SubscriberID";

                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@SubscriberID", subscriberID);

                        try
                        {
                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Row deleted successfully!");
                                // Refresh DataGridView after deletion
                                DisplaySubscriber(); // Custom method to reload data
                            }
                            else
                            {
                                MessageBox.Show("No rows deleted. Please try again.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }


        //doc---------------------------------------------------------------------------------------------------------------------

        private void add_Click(object sender, EventArgs e)
        {
            string title_ = tit.Text;
            string auth_ = auth.Text;
            string cat_ = cat.SelectedItem.ToString();
            DateTime pdate_ = pdate.Value;
            string desc_ = desc.Text;
            decimal price_ = Convert.ToDecimal(pr.Text);
            byte[] imageData; // This will store the image as bytes

            // Check if an image is present in the PictureBox
            if (pic.Image != null)
            {
                try
                {
                    // Convert the PictureBox image to bytes
                    using (MemoryStream ms = new MemoryStream())
                    {
                        pic.Image.Save(ms, pic.Image.RawFormat);
                        imageData = ms.ToArray();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error converting image: " + ex.Message);
                    return;
                }
            }
            else
            {
                MessageBox.Show("No image selected.");
                return;
            }

            string connectionString = "Data Source=MIDNIGHT\\SQLEXPRESS;Initial Catalog=BiblioDB;Integrated Security=True;Encrypt=False"; // Replace with your actual connection string

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Documents (Title, Author, Category, PublicationDate, Description, Availability, Price, Image) " +
                    "VALUES (@Title, @Author, @Category, @PublicationDate, @Description, @Availability, @Price, @ImageData)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Title", title_);
                command.Parameters.AddWithValue("@Author", auth_);
                command.Parameters.AddWithValue("@Category", cat_);
                command.Parameters.AddWithValue("@PublicationDate", pdate_);
                command.Parameters.AddWithValue("@Description", desc_);
                command.Parameters.AddWithValue("@Availability", "Disponible"); // Default value
                command.Parameters.AddWithValue("@Price", price_);
                command.Parameters.AddWithValue("@ImageData", imageData);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Document added successfully!");
                        DisplayDocuments();
                    }
                    else
                    {
                        MessageBox.Show("Failed to add document. Please try again.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }



        private void DisplayDocuments()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Documents";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable documentsTable = new DataTable();
                adapter.Fill(documentsTable);

                Doc.DataSource = documentsTable;
                Doc.Columns["DocumentID"].HeaderText = "ID";
                Doc.Columns["Title"].HeaderText = "Titre";
                Doc.Columns["Author"].HeaderText = "Auteur";
                Doc.Columns["Category"].HeaderText = "Catégorie";
                Doc.Columns["PublicationDate"].HeaderText = "Date de publication";
                Doc.Columns["Description"].HeaderText = "Description";
                Doc.Columns["Price"].HeaderText = "Prix"; // Added Price column
                Doc.Columns["Availability"].HeaderText = "Disponibilité";
                Doc.Columns["BorrowerID"].HeaderText = "Réservé par";

                // Set the display index for columns as needed
                Doc.Columns["Title"].DisplayIndex = 1;
                Doc.Columns["Author"].DisplayIndex = 2;
                Doc.Columns["Category"].DisplayIndex = 3;
                Doc.Columns["PublicationDate"].DisplayIndex = 4;
                Doc.Columns["Description"].DisplayIndex = 5;
                Doc.Columns["Price"].DisplayIndex = 6; // Display Price after Description
                Doc.Columns["Availability"].DisplayIndex = 7;
                Doc.Columns["BorrowerID"].DisplayIndex = 8;
            }
        }


        private void Doc_SelectionChanged(object sender, EventArgs e)
        {
            if (Doc.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = Doc.SelectedRows[0];

                tit.Text = selectedRow.Cells["Title"].Value?.ToString();
                auth.Text = selectedRow.Cells["Author"].Value?.ToString();
                cat.Text = selectedRow.Cells["Category"].Value?.ToString();
                if (DateTime.TryParse(selectedRow.Cells["PublicationDate"].Value?.ToString(), out DateTime pDate))
                {
                    pdate.Value = pDate;
                }
                else
                {
                    pdate.Value = DateTime.Today;
                }
                desc.Text = selectedRow.Cells["Description"].Value?.ToString();
                pr.Text = selectedRow.Cells["Price"].Value?.ToString();

                // Fetch the image bytes from the selected row
                byte[] imageData = selectedRow.Cells["Image"].Value as byte[];

                // Convert bytes to Image and display in PictureBox
                if (imageData != null && imageData.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        Image imgFromBytes = Image.FromStream(ms);
                        pic.Image = imgFromBytes;
                    }
                }
                else
                {
                    pic.Image = null; // Set PictureBox to display nothing
                }
            }
        }



        private void d_mod_Click(object sender, EventArgs e)
        {
            if (Doc.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to modify this document?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DataGridViewRow selectedRow = Doc.SelectedRows[0];
                    int documentID = Convert.ToInt32(selectedRow.Cells["DocumentID"].Value);

                    string title_ = tit.Text;
                    string auth_ = auth.Text;
                    string cat_ = cat.Text;
                    string pdate_ = pdate.Value.ToString("yyyy-MM-dd");
                    string desc_ = desc.Text;
                    decimal price_ = Convert.ToDecimal(pr.Text);

                    // Convert PictureBox image to bytes
                    byte[] imageData = null;
                    if (pic.Image != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            pic.Image.Save(ms, pic.Image.RawFormat);
                            imageData = ms.ToArray();
                        }
                    }

                    string connectionString = "Data Source=MIDNIGHT\\SQLEXPRESS;Initial Catalog=BiblioDB;Integrated Security=True;Encrypt=False";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "UPDATE Documents SET Title = @Title, Author = @Author, Category = @Category, PublicationDate = @PublicationDate, Description = @Description, Price = @Price, Image = @ImageData WHERE DocumentID = @DocumentID";

                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Title", title_);
                        command.Parameters.AddWithValue("@Author", auth_);
                        command.Parameters.AddWithValue("@Category", cat_);
                        command.Parameters.AddWithValue("@PublicationDate", pdate_);
                        command.Parameters.AddWithValue("@Description", desc_);
                        command.Parameters.AddWithValue("@Price", price_);
                        command.Parameters.AddWithValue("@ImageData", (object)imageData ?? DBNull.Value); // Handle null image
                        command.Parameters.AddWithValue("@DocumentID", documentID);

                        try
                        {
                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Document modified successfully!");
                                DisplayDocuments(); // Custom method to reload data
                            }
                            else
                            {
                                MessageBox.Show("No documents modified. Please try again.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a document to modify.");
            }
        }



        private void d_del_Click(object sender, EventArgs e)
        {
            if (Doc.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to delete this document?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DataGridViewRow selectedRow = Doc.SelectedRows[0];

                    // Assuming DocumentID is stored in the first column (adjust the index as needed)
                    int documentID = Convert.ToInt32(selectedRow.Cells["DocumentID"].Value);

                    string connectionString = "Data Source=MIDNIGHT\\SQLEXPRESS;Initial Catalog=BiblioDB;Integrated Security=True;Encrypt=False";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "DELETE FROM Documents WHERE DocumentID = @DocumentID";

                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@DocumentID", documentID);

                        try
                        {
                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Document deleted successfully!");
                                DisplayDocuments(); // Custom method to reload data
                            }
                            else
                            {
                                MessageBox.Show("No documents deleted. Please try again.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a document to delete.");
            }
        }

        private void browse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg;*.png;*.gif)|*.BMP;*.JPG;*.JPEG;*.PNG;*.GIF";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Load the selected image into the PictureBox
                        pic.Image = Image.FromFile(openFileDialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading the image: " + ex.Message);
                    }
                }
            }
        }

        private void e_search_TextChanged(object sender, EventArgs e)
        {
            string searchUsername = e_search.Text.Trim();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Emp WHERE Username LIKE @Username";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@Username", $"%{searchUsername}%");

                DataTable employeesTable = new DataTable();
                adapter.Fill(employeesTable);

                Emp.DataSource = employeesTable;
            }
        }

        private void s_search_TextChanged(object sender, EventArgs e)
        {
            string searchValue = s_search.Text.Trim();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Subscribers WHERE Username LIKE @SearchValue OR FirstName LIKE @SearchValue OR LastName LIKE @SearchValue";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@SearchValue", $"%{searchValue}%");
                DataTable subscribersTable = new DataTable();

                adapter.Fill(subscribersTable);
                Sub.DataSource = subscribersTable;
            }
        }

        private void d_search_TextChanged(object sender, EventArgs e)
        {
            string searchUsername = d_search.Text.Trim();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Documents WHERE Title LIKE @Username";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@Username", $"%{searchUsername}%");

                DataTable employeesTable = new DataTable();
                adapter.Fill(employeesTable);

                Doc.DataSource = employeesTable;
            }
        }

        private void r_search_TextChanged(object sender, EventArgs e)
        {
            int reservationID;
            if (int.TryParse(r_search.Text.Trim(), out reservationID))
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT Reservations.ReservationID, Reservations.SubscriberID, " +
                                   "STRING_AGG(Documents.Title, '-') AS DocumentTitles, " +
                                   "Reservations.ReservedDate, Reservations.ReturnDate, Reservations.Total " +
                                   "FROM Reservations " +
                                   "INNER JOIN Documents ON Reservations.ReservationID = Documents.ReservationID " +
                                   "WHERE Reservations.ReservationID = @ReservationID " +
                                   "GROUP BY Reservations.ReservationID, Reservations.SubscriberID, " +
                                   "Reservations.ReservedDate, Reservations.ReturnDate, Reservations.Total";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@ReservationID", reservationID);

                    DataTable reservationsTable = new DataTable();
                    adapter.Fill(reservationsTable);

                    Res.DataSource = reservationsTable;

                    // Set column headers
                    Res.Columns["ReservationID"].HeaderText = "Reservation ID";
                    Res.Columns["SubscriberID"].HeaderText = "Subscriber ID";
                    Res.Columns["DocumentTitles"].HeaderText = "Document Titles";
                    Res.Columns["ReservedDate"].HeaderText = "Reservation Date";
                    Res.Columns["ReturnDate"].HeaderText = "Return Date";
                    Res.Columns["Total"].HeaderText = "Total";

                    // Set the display index for columns as needed
                    Res.Columns["SubscriberID"].DisplayIndex = 1;
                    Res.Columns["DocumentTitles"].DisplayIndex = 2;
                    Res.Columns["ReservedDate"].DisplayIndex = 3;
                    Res.Columns["ReturnDate"].DisplayIndex = 4;
                    Res.Columns["Total"].DisplayIndex = 5;
                }
            }
            else
            {
                // Handle the case where the input is not a valid integer (display a message, clear the grid, etc.)
            }
        }


        //exp_imp------------------------------------------------------------------------------------------------------------------

        private void DisplayExpSub()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Subscribers";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable employeesTable = new DataTable();
                adapter.Fill(employeesTable);

                Sub_.DataSource = employeesTable;
                Sub_.Columns["Password"].Visible = false;
                Sub_.Columns["Username"].DisplayIndex = 1;
                Sub_.Columns["Email"].DisplayIndex = 2;
                Sub_.Columns["FirstName"].DisplayIndex = 3;
                Sub_.Columns["LastName"].DisplayIndex = 4;
                Sub_.Columns["DateOfBirth"].DisplayIndex = 5;
                Sub_.Columns["Address"].DisplayIndex = 6;
                Sub_.Columns["PhoneNumber"].DisplayIndex = 7;

                Sub_.Columns["SubscriberID"].HeaderText = "ID";
                Sub_.Columns["FirstName"].HeaderText = "Prénom";
                Sub_.Columns["LastName"].HeaderText = "Nom";
                Sub_.Columns["DateOfBirth"].HeaderText = "Date de naissance";
                Sub_.Columns["Address"].HeaderText = "Addresse";
                Sub_.Columns["PhoneNumber"].HeaderText = "Numéro de téléphone";
                Sub_.Columns["Username"].HeaderText = "Username";
                Sub_.Columns["Email"].HeaderText = "Email";
            }
        }

        private void exp_csv_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV (*.csv)|*.csv";
                sfd.FileName = "Subscribers.csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string filePath = sfd.FileName;
                    string delimiter = ",";

                    StringBuilder sb = new StringBuilder();

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "SELECT SubscriberID, Username, Email, FirstName, LastName, DateOfBirth, Address, PhoneNumber FROM Subscribers";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            connection.Open();
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                // Write headers
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    sb.Append(reader.GetName(i));
                                    sb.Append(delimiter);
                                }
                                sb.AppendLine();

                                // Write data
                                while (reader.Read())
                                {
                                    for (int i = 0; i < reader.FieldCount; i++)
                                    {
                                        sb.Append(reader[i].ToString());
                                        sb.Append(delimiter);
                                    }
                                    sb.AppendLine();
                                }
                            }
                        }
                    }

                    File.WriteAllText(filePath, sb.ToString());
                    MessageBox.Show("Data exported successfully!");
                }
            }
        }

        private void exp_exc_Click(object sender, EventArgs e)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel (*.xlsx)|*.xlsx";
                sfd.FileName = "Subscribers.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string filePath = sfd.FileName;

                    using (ExcelPackage excelPackage = new ExcelPackage())
                    {
                        ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Subscribers");

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            string query = "SELECT SubscriberID, Username, Email, FirstName, LastName, DateOfBirth, Address, PhoneNumber FROM Subscribers";

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                connection.Open();
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    // Write headers
                                    for (int i = 0; i < reader.FieldCount; i++)
                                    {
                                        worksheet.Cells[1, i + 1].Value = reader.GetName(i);
                                    }

                                    // Write data
                                    int row = 2;
                                    while (reader.Read())
                                    {
                                        for (int i = 0; i < reader.FieldCount; i++)
                                        {
                                            worksheet.Cells[row, i + 1].Value = reader[i].ToString();
                                        }
                                        row++;
                                    }
                                }
                            }
                        }

                        FileInfo excelFile = new FileInfo(filePath);
                        excelPackage.SaveAs(excelFile);
                        MessageBox.Show("Data exported successfully!");
                    }
                }
            }
        }

        private void imp_csv_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "CSV (*.csv)|*.csv";
                ofd.Title = "Select CSV file";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string filePath = ofd.FileName;

                    try
                    {
                        using (TextFieldParser parser = new TextFieldParser(filePath))
                        {
                            parser.TextFieldType = FieldType.Delimited;
                            parser.SetDelimiters(",");

                            // Skip the header row
                            if (!parser.EndOfData)
                            {
                                parser.ReadLine();
                            }

                            while (!parser.EndOfData)
                            {
                                string[] fields = parser.ReadFields();

                                // Assuming the order of columns: Username, Password, Email, FirstName, LastName, DateOfBirth, Address, PhoneNumber
                                string username = fields[1];
                                string password = HashPassword(fields[8]); // Assuming fields[1] contains the password
                                string email = fields[2];
                                string firstName = fields[3];
                                string lastName = fields[4];
                                DateTime dateOfBirth = DateTime.Parse(fields[5]); // Parse DateOfBirth
                                string address = fields[6];
                                string phoneNumber = fields[7];

                                // Insert into database
                                InsertSubscriber(username, password, email, firstName, lastName, dateOfBirth, address, phoneNumber);
                            }
                        }

                        MessageBox.Show("Subscribers imported successfully!");
                        DisplayExpSub();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    builder.Append(hashedBytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void InsertSubscriber(string username, string password, string email, string firstName, string lastName, DateTime dateOfBirth, string address, string phoneNumber)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Subscribers (Username, Password, Email, FirstName, LastName, DateOfBirth, Address, PhoneNumber) " +
                                "VALUES (@Username, @Password, @Email, @FirstName, @LastName, @DateOfBirth, @Address, @PhoneNumber)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                command.Parameters.AddWithValue("@Address", address);
                command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    // Handle success or failure...
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
                ofd.Title = "Select Excel file";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string filePath = ofd.FileName;

                    try
                    {
                        using (ExcelPackage package = new ExcelPackage(new FileInfo(filePath)))
                        {
                            ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();

                            if (worksheet != null)
                            {
                                int rowCount = worksheet.Dimension.Rows;
                                int columnCount = worksheet.Dimension.Columns;

                                for (int row = 2; row <= rowCount; row++) // Assuming the header is in the first row
                                {
                                    // Assuming the order of columns: Username, Password, Email, FirstName, LastName, DateOfBirth, Address, PhoneNumber
                                    string username = worksheet.Cells[row, 2].Value?.ToString();
                                    string password = HashPassword(worksheet.Cells[row, 9].Value?.ToString()); // Assuming the password is in the second column
                                    string email = worksheet.Cells[row, 3].Value?.ToString();
                                    string firstName = worksheet.Cells[row, 4].Value?.ToString();
                                    string lastName = worksheet.Cells[row, 5].Value?.ToString();
                                    DateTime dateOfBirth = DateTime.Parse(worksheet.Cells[row, 6].Value?.ToString()); // Parse DateOfBirth
                                    string address = worksheet.Cells[row, 7].Value?.ToString();
                                    string phoneNumber = worksheet.Cells[row, 8].Value?.ToString();

                                    // Insert into database
                                    InsertSubscriber(username, password, email, firstName, lastName, dateOfBirth, address, phoneNumber);
                                }
                            }
                        }

                        MessageBox.Show("Subscribers imported successfully!");
                        DisplayExpSub();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        //res---------------------------------------------------------------------------------------------------------------------------------

        public List<Subscriber> FetchSubscribersFromDatabase()
        {
            List<Subscriber> subscribers = new List<Subscriber>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT SubscriberID, Username FROM Subscribers"; // Adjust query as needed

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Subscriber subscriber = new Subscriber
                        {
                            SubscriberID = Convert.ToInt32(reader["SubscriberID"]),
                            Username = reader["Username"].ToString(),
                            // Map other properties here if needed
                        };

                        subscribers.Add(subscriber);
                    }
                }
            }

            return subscribers;
        }

        public List<Document> FetchDocumentsFromDatabase()
        {
            List<Document> documents = new List<Document>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT DocumentID, Title FROM Documents where Availability = 'Disponible'"; // Adjust query as needed

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Document document = new Document
                        {
                            DocumentID = Convert.ToInt32(reader["DocumentID"]),
                            Title = reader["Title"].ToString(),
                            // Map other properties here if needed
                        };

                        documents.Add(document);
                    }
                }
            }

            return documents;
        }

        private void r_add_Click(object sender, EventArgs e)
        {
            using (var context = new BiblioDbContext()) // Replace with your DbContext
            {
                // Fetch the selected subscriber
                var selectedSubscriber = (int)adh.SelectedValue;

                // Fetch selected documents
                var selectedDocuments = new List<Document>();
                foreach (var selectedItem in doc_.CheckedItems)
                {
                    var selectedDocument = context.Documents.FirstOrDefault(d => d.DocumentID == ((Document)selectedItem).DocumentID);
                    if (selectedDocument != null)
                    {
                        selectedDocuments.Add(selectedDocument);
                    }
                }

                if (selectedSubscriber != null && selectedDocuments.Any())
                {
                    DateTime reservationDate = res_date.Value;
                    DateTime returnDate = ret_date.Value;

                    // Calculate total price based on the selected documents and the duration of the reservation
                    int days = (int)(returnDate - reservationDate).TotalDays + 1;
                    decimal totalPrice = selectedDocuments.Sum(doc => doc.Price ?? 0) * days;

                    // Create a new reservation object
                    Reservation newReservation = new Reservation
                    {
                        SubscriberID = selectedSubscriber,
                        Documents = selectedDocuments,
                        ReservedDate = reservationDate,
                        ReturnDate = returnDate,
                        Total = totalPrice
                    };

                    context.Reservations.Add(newReservation);

                    // Update availability of associated documents
                    foreach (var document in selectedDocuments)
                    {
                        document.Availability = "Réservé";
                    }

                    try
                    {
                        context.SaveChanges();

                        MessageBox.Show("Reservation added successfully!");
                        DisplayReservations();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a subscriber and at least one document for the reservation.");
                }
            }
        }


        private void DisplayReservations()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Reservations.ReservationID, Reservations.SubscriberID, " +
                               "ISNULL(STRING_AGG(Documents.Title, '-'), '') AS DocumentTitles, " +
                               "Reservations.ReservedDate, Reservations.ReturnDate, Reservations.Total " +
                               "FROM Reservations " +
                               "LEFT JOIN Documents ON Reservations.ReservationID = Documents.ReservationID " +
                               "GROUP BY Reservations.ReservationID, Reservations.SubscriberID, " +
                               "Reservations.ReservedDate, Reservations.ReturnDate, Reservations.Total";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable reservationsTable = new DataTable();
                adapter.Fill(reservationsTable);

                Res.DataSource = reservationsTable;
                Res.Columns["ReservationID"].HeaderText = "Reservation ID";
                Res.Columns["SubscriberID"].HeaderText = "Subscriber ID";
                Res.Columns["DocumentTitles"].HeaderText = "Document Titles";
                Res.Columns["ReservedDate"].HeaderText = "Reservation Date";
                Res.Columns["ReturnDate"].HeaderText = "Return Date";
                Res.Columns["Total"].HeaderText = "Total";

                // Set the display index for columns as needed
                Res.Columns["SubscriberID"].DisplayIndex = 1;
                Res.Columns["DocumentTitles"].DisplayIndex = 2;
                Res.Columns["ReservedDate"].DisplayIndex = 3;
                Res.Columns["ReturnDate"].DisplayIndex = 4;
                Res.Columns["Total"].DisplayIndex = 5;
            }
        }





        private void Res_SelectionChanged(object sender, EventArgs e)
        {
            if (Res.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = Res.SelectedRows[0];

                int reservationID = Convert.ToInt32(selectedRow.Cells["ReservationID"].Value);
                int subscriberID = Convert.ToInt32(selectedRow.Cells["SubscriberID"].Value);
                DateTime reservationDate = Convert.ToDateTime(selectedRow.Cells["ReservedDate"].Value);
                DateTime returnDate = Convert.ToDateTime(selectedRow.Cells["ReturnDate"].Value);
                decimal total = Convert.ToDecimal(selectedRow.Cells["Total"].Value);

                string totalcost = total.ToString();

                // Set the reservation date and return date
                res_date.Value = reservationDate;
                ret_date.Value = returnDate;

                // Fetch and display subscriber's username in the ComboBox
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string subscriberQuery = "SELECT Username FROM Subscribers WHERE SubscriberID = @SubscriberID";
                    SqlCommand subscriberCommand = new SqlCommand(subscriberQuery, connection);
                    subscriberCommand.Parameters.AddWithValue("@SubscriberID", subscriberID);

                    connection.Open();
                    object username = subscriberCommand.ExecuteScalar();

                    if (username != null)
                    {
                        adh.Text = username.ToString();
                    }
                }
                // Fetch documents associated with the reservation
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string documentQuery = "SELECT Title, Price FROM Documents WHERE ReservationID = @ReservationID";
                    SqlCommand documentCommand = new SqlCommand(documentQuery, connection);
                    documentCommand.Parameters.AddWithValue("@ReservationID", reservationID);

                    connection.Open();

                    // Load all documents into the CheckedListBox
                    LoadDocumentsIntoCheckedListBox();

                    SqlDataReader documentReader = documentCommand.ExecuteReader();

                    List<string> checkedDocuments = new List<string>();

                    if (documentReader.HasRows)
                    {
                        while (documentReader.Read())
                        {
                            checkedDocuments.Add(documentReader["Title"].ToString());

                            string title = documentReader["Title"].ToString();

                            doc_.Items.Add(title, false);
                        }
                    }

                    documentReader.Close();

                    // Check documents associated with the reservation
                    for (int i = 0; i < doc_.Items.Count; i++)
                    {
                        string displayedTitle = doc_.Items[i].ToString();

                        if (checkedDocuments.Contains(displayedTitle))
                        {
                            doc_.SetItemChecked(i, true);
                        }
                    }

                    // Display the calculated total
                    price.Text = totalcost;
                }

            }
        }

        private void LoadDocumentsIntoCheckedListBox()
        {

            // Ensure DataSource is null before adding items
            doc_.DataSource = null;

            doc_.Items.Clear(); // Clear existing items if needed

            // Fetch documents from the database and add them to the CheckedListBox
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string documentQuery = "SELECT DocumentID, Title FROM Documents where Availability = 'Disponible'";
                SqlCommand documentCommand = new SqlCommand(documentQuery, connection);

                connection.Open();
                SqlDataReader documentReader = documentCommand.ExecuteReader();

                if (documentReader.HasRows)
                {
                    while (documentReader.Read())
                    {
                        string title = documentReader["Title"].ToString();

                        doc_.Items.Add(title, false);
                    }
                }

                documentReader.Close();
            }
        }

        private void r_del_Click(object sender, EventArgs e)
        {
            if (Res.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = Res.SelectedRows[0];
                int reservationID = Convert.ToInt32(selectedRow.Cells["ReservationID"].Value);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        // Update associated documents to set ReservationID to NULL
                        string updateQuery = "UPDATE dbo.Documents SET ReservationID = NULL, Availability = 'Disponible' WHERE ReservationID = @ReservationIDToDelete";
                        SqlCommand updateCommand = new SqlCommand(updateQuery, connection, transaction);
                        updateCommand.Parameters.AddWithValue("@ReservationIDToDelete", reservationID);
                        updateCommand.ExecuteNonQuery();

                        // Delete the reservation after modifying associated documents
                        string deleteQuery = "DELETE FROM dbo.Reservations WHERE ReservationID = @ReservationIDToDelete";
                        SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection, transaction);
                        deleteCommand.Parameters.AddWithValue("@ReservationIDToDelete", reservationID);
                        deleteCommand.ExecuteNonQuery();

                        transaction.Commit();
                        MessageBox.Show("Reservation deleted successfully!");

                        // Refresh the displayed reservations after deletion
                        DisplayReservations(); // Your method to refresh the reservations in the DataGridView
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a reservation to delete.");
            }
        }

        private void r_mod_Click(object sender, EventArgs e)
        {
            if (Res.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = Res.SelectedRows[0];
                int reservationID = Convert.ToInt32(selectedRow.Cells["ReservationID"].Value);

                DateTime reservationDate = res_date.Value;
                DateTime returnDate = ret_date.Value;
                string priceValueString = price.Text;
                decimal priceValue = Convert.ToDecimal(priceValueString);

                // Fetch subscriberID based on the username in the ComboBox (if needed)
                int subscriberID = FetchSubscriberID(adh.Text); // Implement this method

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Fetch existing documents associated with the reservation
                    List<string> existingDocuments = new List<string>();
                    string existingDocumentQuery = "SELECT DocumentID, Title FROM Documents WHERE ReservationID = @ReservationID";
                    SqlCommand existingDocumentCommand = new SqlCommand(existingDocumentQuery, connection);
                    existingDocumentCommand.Parameters.AddWithValue("@ReservationID", reservationID);

                    SqlDataReader existingDocumentReader = existingDocumentCommand.ExecuteReader();
                    while (existingDocumentReader.Read())
                    {
                        existingDocuments.Add(existingDocumentReader["Title"].ToString());
                    }
                    existingDocumentReader.Close();

                    foreach (var checkedItem in doc_.Items)
                    {
                        string documentTitle = checkedItem.ToString();

                        // Implement method to fetch documentID based on the title
                        int documentID = FetchDocumentID(documentTitle);

                        // Update the ReservationID in Documents based on the checkbox status
                        if (doc_.CheckedItems.Contains(documentTitle))
                        {
                            string updateQuery = "UPDATE Documents SET ReservationID = @ReservationID, Availability = 'Réservé' WHERE DocumentID = @DocumentID";
                            SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                            updateCommand.Parameters.AddWithValue("@ReservationID", reservationID);
                            updateCommand.Parameters.AddWithValue("@DocumentID", documentID);
                            updateCommand.ExecuteNonQuery();
                        }
                        else if (existingDocuments.Contains(documentTitle))
                        {
                            string nullifyQuery = "UPDATE Documents SET ReservationID = NULL, Availability = 'Disponible' WHERE DocumentID = @DocumentID";
                            SqlCommand nullifyCommand = new SqlCommand(nullifyQuery, connection);
                            nullifyCommand.Parameters.AddWithValue("@DocumentID", documentID);
                            nullifyCommand.ExecuteNonQuery();
                        }
                    }

                    // Update reservation information in the database
                    string updateReservationQuery = "UPDATE dbo.Reservations SET SubscriberID = @SubscriberID, ReservedDate = @ReservedDate, ReturnDate = @ReturnDate, Total = @Total WHERE ReservationID = @ReservationID";
                    SqlCommand updateReservationCommand = new SqlCommand(updateReservationQuery, connection);
                    updateReservationCommand.Parameters.AddWithValue("@SubscriberID", subscriberID);
                    updateReservationCommand.Parameters.AddWithValue("@ReservedDate", reservationDate);
                    updateReservationCommand.Parameters.AddWithValue("@ReturnDate", returnDate);
                    updateReservationCommand.Parameters.AddWithValue("@Total", priceValue); // Assign price value to Total
                    updateReservationCommand.Parameters.AddWithValue("@ReservationID", reservationID);

                    try
                    {
                        int rowsAffected = updateReservationCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Reservation updated successfully!");
                            DisplayReservations();
                        }
                        else
                        {
                            MessageBox.Show("No reservations were updated.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a reservation to modify.");
            }
        }


        private int FetchDocumentID(string title)
        {
            int documentID = -1; // Set a default value if document is not found

            // Fetch DocumentID based on the provided title
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT DocumentID FROM Documents WHERE Title = @Title";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Title", title);

                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    documentID = Convert.ToInt32(result);
                }
            }

            return documentID;
        }



        private int FetchSubscriberID(string username)
        {
            int subscriberID = -1; // Default value if not found

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT SubscriberID FROM Subscribers WHERE Username = @Username";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);

                try
                {
                    connection.Open();
                    var result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        subscriberID = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching subscriber ID: " + ex.Message);
                }
            }

            return subscriberID;
        }

    }
}
