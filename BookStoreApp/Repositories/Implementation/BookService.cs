
using BookStoreApp.Models.Domain;
using BookStoreApp.Repositories.Abstract;

namespace BookStoreApp.Repositories.Implementation
{
    public class BookService : IBookService
    {
        private readonly DatabaseContext _ctx;

        public BookService(DatabaseContext ctx)
        {
            this._ctx = ctx;
        }

        public bool Add(Book name)
        {
            try
            {
                _ctx.Book.Add(name);
                _ctx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var data = this.FindById(id);

                if (data == null)
                    return false;

                _ctx.Book.Remove(data);
                _ctx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public IEnumerable<Book> GetAll()
        {
            var data = (from book in _ctx.Book join author in _ctx.Author
                        on book.AuthorId equals author.Id
                        join publisher in _ctx.Publisher on book.PublisherId equals publisher.Id
                        join genre in _ctx.Genre on book.GenreId equals genre.Id
                        select new Book 
                        { 
                            Id = book.Id, 
                            AuthorId = book.AuthorId, 
                            PublisherId = book.PublisherId,
                            GenreId = book.GenreId, 
                            Isbn = book.Isbn, 
                            Title = book.Title, 
                            TotalPages = book.TotalPages,
                            GenreName = genre.Name, 
                            AuthorName = author.AuthorName, 
                            PublisherName = publisher.PublisherName
                        }
                        ).ToList();

            return data;
        }

        public Book FindById(int id)
        {
            return _ctx.Book.Find(id);
        }

        public bool Update(Book data)
        {
            try
            {
                _ctx.Book.Update(data);
                _ctx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
