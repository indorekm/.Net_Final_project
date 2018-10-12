using GymManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace GymManagementSystem.Data
{
    /// <summary>
    /// Database context for Gym Management System
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class GymDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GymDbContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public GymDbContext(DbContextOptions<GymDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the customers.
        /// </summary>
        /// <value>
        /// The customers.
        /// </value>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Gets or sets the trainers.
        /// </summary>
        /// <value>
        /// The trainers.
        /// </value>
        public DbSet<Trainer> Trainers { get; set; }

        /// <summary>
        /// Gets or sets the schedules.
        /// </summary>
        /// <value>
        /// The schedules.
        /// </value>
        public DbSet<Schedule> Schedules { get; set; }

        /// <summary>
        /// Gets or sets the memberships.
        /// </summary>
        /// <value>
        /// The memberships.
        /// </value>
        public DbSet<Membership> Membership { get; set; }
    }
}
