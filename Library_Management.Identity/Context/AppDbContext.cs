using LibraryManagement.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Infrastucture.Context
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
        public DbSet<Book> books { get; set; }
        public DbSet<Author> authors { get; set; }
        public DbSet<Loan> loans { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<BookCategory> bookCategories { get; set; }
        public DbSet<Payment> payments { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Book>()
               .HasOne(book => book.Author)
               .WithMany(author => author.Books)
               .HasForeignKey(book => book.AuthorId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Loan>()
                .HasOne(loan => loan.Book)
                .WithMany(book => book.Loans)
                .HasForeignKey(loan => loan.BookId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.Entity<Payment>()
                .HasOne(payment => payment.Loan)
                .WithOne(loan => loan.Payment)
                .HasForeignKey<Payment>(payment => payment.LoanId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Payment>()
                .HasOne(payment => payment.User)
                .WithMany(user => user.Payments)
                .HasForeignKey(payment => payment.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Loan>()
                .HasOne(loan => loan.User)
                .WithMany(user => user.Loans)
                .HasForeignKey(loan => loan.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<BookCategory>()
                .HasOne(bookcategory => bookcategory.Book)
                .WithMany(book => book.BookCategories)
                .HasForeignKey(bookCat => bookCat.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<BookCategory>()
                .HasOne(bookCat => bookCat.Category)
                .WithMany(category => category.BookCategories)
                .HasForeignKey(bookCat => bookCat.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);












        }
    }


}
