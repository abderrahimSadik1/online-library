using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{
    public class Document
    {
        public int DocumentID { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Category { get; set; }
        public DateTime PublicationDate { get; set; }
        public string? Availability { get; set; }
        public int? BorrowerID { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int? ReservationID { get; set; }
        public Reservation Reservation { get; set; }
        public byte[]? Image { get; set; }

        public Document() { }

        public Document(int id, string title, string author, string category, DateTime publicationDate, string availability, int borrowerID, string description, decimal price, byte[] image)
        {
            DocumentID = id;
            Title = title;
            Author = author;
            Category = category;
            PublicationDate = publicationDate;
            Availability = availability;
            BorrowerID = borrowerID;
            Description = description;
            Price = price;
            Image = image;
        }
    }
}
