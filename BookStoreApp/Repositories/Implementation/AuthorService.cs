
using BookStoreApp.Models.Domain;
using BookStoreApp.Repositories.Abstract;

namespace BookStoreApp.Repositories.Implementation
{
    public class AuthorService : IAuthorService
    {
        private readonly DatabaseContext _ctx;

        public AuthorService(DatabaseContext ctx)
        {
            this._ctx = ctx;
        }

        public bool Add(Author name)
        {
            try
            {
                _ctx.Author.Add(name);
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

                _ctx.Author.Remove(data);
                _ctx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public IEnumerable<Author> GetAll()
        {
            return _ctx.Author.ToList();
        }

        public Author FindById(int id)
        {
            return _ctx.Author.Find(id);
        }

        public bool Update(Author data)
        {
            try
            {
                _ctx.Author.Update(data);
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
