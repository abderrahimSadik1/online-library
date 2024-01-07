using System;

namespace Biblio
{
    public class Subscriber
    {
        public int SubscriberID { get; set; }
        public string? Username { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }


        public Subscriber()
        {
        }

        public Subscriber(int subscriberID, string firstName, string lastName, string address, string email, string phoneNumber, string username, DateTime dateOfBirth)
        {
            SubscriberID = subscriberID;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Address = address;
            Email = email;
            PhoneNumber = phoneNumber;
            Username = username;
        }

    }
}
