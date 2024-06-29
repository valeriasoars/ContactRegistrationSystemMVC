using ContactRegistrationMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactRegistrationMVC.Data
{
    public class BankContext: DbContext
    {
        public BankContext(DbContextOptions<BankContext> options) : base(options)
        {

        }

        public DbSet<ContactModel> Contacts { get; set; }

    }
}
