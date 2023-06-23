using Microsoft.EntityFrameworkCore;
using Nomad.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomad.DataAccess.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<PrivacyType> PrivacyTypes { get; set; }
        public DbSet<ListingType> ListingTypes { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Listing> Listings { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<UserReviews> UsersReviews { get; set; }
        public DbSet<ListingReviews> ListingReviews { get; set; }
        public DbSet<ListingPhoto> ListingPhotos { get; set;}
        public DbSet<ProfilePhoto> ProfilePhoto { get; set; }
    }
}
