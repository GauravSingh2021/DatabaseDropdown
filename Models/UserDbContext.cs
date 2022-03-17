using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseDropdown.Models
{
    public class UserDbContext:DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options): base(options) { }

        public DbSet<User> users { get; set; }
        public DbSet<Country> countries { get; set; }
        public DbSet<State> states { get; set; }
        public DbSet<City> cities { get; set; }
    }
}
