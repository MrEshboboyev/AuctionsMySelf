using Auctions.Models;
using Microsoft.EntityFrameworkCore;

namespace Auctions.Data.Services
{
    public class ListingService : IListingService
    {
        // DI for working database
        private readonly ApplicationDbContext _context;
        public ListingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Listing> GetAll()
        {
            // Include() methodi Database so'rovlarni va yuklamani kamaytiradi
            // ya'ni var applicationDbContext = _context.Listings; ushbu kod LazyLoading
            // var applicationDbContext = _context.Listings.Include(l => l.User); =? Eager loading
            // Biz bog'langan elementlar kerak ekanligini oldindan bilsak, Eager Loading Best Choice
            var applicationDbContext = _context.Listings.Include(l => l.User);
            return applicationDbContext;
        }
    }
}
