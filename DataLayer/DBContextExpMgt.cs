using ExpenseManagement2.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManagement2.DataLayer
{
    public class DBContextExpMgt : DbContext
    {
        public DBContextExpMgt(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ExpenseEntity> Expenses { get; set; }

        public DbSet<ExpenseCategoryEntity> ExpsenseCategories { get; set; }


        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}
