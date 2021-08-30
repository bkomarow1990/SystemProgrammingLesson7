using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemProgrammingLesson7
{
    class ModelDBInitializer : CreateDatabaseIfNotExists<BookDBModel>
    {
        protected override void Seed(BookDBModel context)
        {
            base.Seed(context);
            Author anatoliy = context.Authors.Add(new Author { Name = "Anatoliy Johnson"});
            Author valeriy = context.Authors.Add(new Author { Name = "Valeriy Albertovich"});
            Author galina = context.Authors.Add(new Author { Name = "Galina Bober"});
            context.SaveChanges();
            Book book1 = context.Books.Add(new Book { Name = "Johnson life 228", Author = anatoliy});
            Book book2 = context.Books.Add(new Book { Name = "Toca Toca", Author = anatoliy});
            Book book3 = context.Books.Add(new Book { Name = "Valeriy zhmih", Author = valeriy});
            Book book4 = context.Books.Add(new Book { Name = "Valeriy zhmih2", Author = valeriy});
            Book book5 = context.Books.Add(new Book { Name = "Kukriku shole", Author = galina});
            Book book6 = context.Books.Add(new Book { Name = "Kukriku shole2", Author = galina});
            Book book7 = context.Books.Add(new Book { Name = "Kukriku shole3", Author = galina});
            Book book8 = context.Books.Add(new Book { Name = "Kukriku shole4", Author = galina});
            context.SaveChanges();
            
        }
    }
}
