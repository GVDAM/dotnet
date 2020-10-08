using System;
using Microsoft.EntityFrameworkCore;

namespace primeiromvc.database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
