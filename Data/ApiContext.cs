using Microsoft.EntityFrameworkCore;
using Drive.Models;

namespace Drive.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<Drive> DriveUsers { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {

        }
    }
}
