using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio
{
    public class Document
    {
        [Key]
        public int DocumentID { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Category { get; set; }
        public DateTime PublicationDate { get; set; }
        public string? Availability { get; set; }
        public int? BorrowerID { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        [ForeignKey("Reservation")]
        public int? ReservationID { get; set; }
        public byte[]? Image { get; set; }
        public string? ImageUrl { get; set;}



    }
}
