using Biblio;
using Library.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
 
    public class DisplayController : Controller
    {
        private readonly ApplicationDbContext _dbContext; // Update with your DbContext
        private readonly IHttpContextAccessor _httpContext;
        public DisplayController(ApplicationDbContext dbContext, IHttpContextAccessor httpContext)
        {
            _dbContext = dbContext;
            _httpContext = httpContext;
        }

        public IActionResult Index(string filter, string categoryFilter)
        {
            var booksQuery = _dbContext.Documents.AsQueryable();

            // Filter by title or author
            if (!string.IsNullOrEmpty(filter))
            {
                booksQuery = booksQuery.Where(b => b.Title.Contains(filter) || b.Author.Contains(filter));
            }

            // Filter by category
            if (!string.IsNullOrEmpty(categoryFilter))
            {
                booksQuery = booksQuery.Where(b => b.Category == categoryFilter);
            }

            var books = booksQuery.ToList();
            return View(books);
        }

        public IActionResult Details(int id)
        {
             
            
                Document document = _dbContext.Documents.FirstOrDefault(d => d.DocumentID == id);
                if (document == null)
                {
                    return NotFound(); // or handle the case where the document is not found
                }
                return View(document);
          
        }
        [HttpPost]
        public IActionResult Reserve(int documentId, int reservationDays)
        {
            // Retrieve the Document from the database
            var document = _dbContext.Documents.FirstOrDefault(d => d.DocumentID == documentId);

            if (document == null)
            {
                // Handle the case where the document is not found
                return NotFound();
            }

            // Check if the document is available
            if (document.Availability.ToLower() == "yes")
            {

                decimal total = document.Price ?? 0; // Assuming Price is nullable
                                                     // You can add more logic here to calculate the total based on your requirements

                var subscriberId = _httpContext.HttpContext.Session.GetInt32("UserId");

                // Create a Reservation object
                var reservation = new Reservation
                {
                    SubscriberID = subscriberId.Value,
                    ReservedDate = DateTime.Now,
                    Total = (total * reservationDays),
                };

                // Calculate ReturnDate based on the ReservedDate and the user-provided reservation period
                reservation.ReturnDate = reservation.ReservedDate.AddDays(reservationDays);


                // Save the Reservation to the database
                _dbContext.Reservations.Add(reservation);
                _dbContext.SaveChanges();

                // Update the Document with the Reservation information
                document.ReservationID = reservation.ReservationID;
                document.Availability = "No"; // Assuming "No" means not available after reservation
                document.BorrowerID = reservation.SubscriberID;

                _dbContext.SaveChanges();
                return RedirectToAction("Index"); // Redirect to the appropriate action after reservation
            }

            // Handle the case where the document is not available
            return RedirectToAction("Details", new { id = documentId }); // Redirect back to the Details view
        }
    }
}
