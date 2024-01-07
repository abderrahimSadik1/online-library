using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblio
{
    public class Reservation
    {
        [Key]
        public int ReservationID { get; set; }

        // Navigation property
        public Subscriber Subscriber { get; set; }

        public DateTime ReservedDate { get; set; }
        public DateTime? ReturnDate { get; set; } // Nullable return date

        public decimal Total { get; set; }

        public ICollection<Document> Documents { get; set; }

        public int SubscriberID { get; set; }

    }
}