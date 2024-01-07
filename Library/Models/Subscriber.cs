using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Biblio
{
    public class Subscriber
    {
        [Key]
        public int SubscriberID { get; set; }
 
        public string? UserName { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

 
        public DateTime? DateOfBirth { get; set; }

        public string? Address { get; set; }


        public string? Email { get; set; }


        public string? PhoneNumber { get; set; }

        public string? Password { get; set; }

    }
}
