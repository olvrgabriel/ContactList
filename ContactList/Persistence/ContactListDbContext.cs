using ContactList.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactList.Persistence
{
    public class ContactListDbContext : DbContext
    {
        public ContactListDbContext(DbContextOptions<ContactListDbContext> options) : base(options)
        {
        }

        public DbSet<ContactModel> Contatos { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ContactModel>(c =>
            {
                c.HasKey(co => co.Id);

                c.Property(co => co.Name).IsRequired(true);

                c.Property(co => co.Email)
                    .HasMaxLength(200)
                    .HasColumnType("varchar(200)");

                c.Property(co => co.Phone)
                    .HasColumnName("Telefone")
                    .HasColumnType("varchar(14)"); 
            });
        }

    }
}

