using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SystemProgrammingLesson7
{
    public class BookDBModel : DbContext
    {
        // Your context has been configured to use a 'Model1' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'SystemProgrammingLesson7.Model1' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Model1' 
        // connection string in the application configuration file.
        public BookDBModel()
            : base("name=Model1")
        {
            Database.SetInitializer<BookDBModel>(new ModelDBInitializer());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

         public virtual DbSet<Author> Authors { get; set; }
         public virtual DbSet<Book> Books { get; set; }
    }

    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //NAV
        public virtual ICollection<Book> Books { get; set; } = new HashSet<Book>();
        public override string ToString()
        {
            return $"Author: {Name}";
        }
    }
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }

        //NAV
        public virtual Author Author { get; set; }
        public override string ToString()
        {
            return $"Book: {Name}, {Author}";
        }
    }
}