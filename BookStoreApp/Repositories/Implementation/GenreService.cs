using BookStoreApp.Models.Domain;
using BookStoreApp.Repositories.Abstract;

namespace BookStoreApp.Repositories.Implementation
{
    public class GenreService : IGenreService
    {
        private readonly DatabaseContext _ctx;

        public GenreService(DatabaseContext ctx)
        {
            this._ctx = ctx;
        }

        public bool Add(Genre model)
        {
            try
            {
                _ctx.Genre.Add(model);
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
                var book = this.FindById(id);

                if (book == null) 
                    return false;

                _ctx.Genre.Remove(book);
                _ctx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public IEnumerable<Genre> GetAll()
        {
            return _ctx.Genre.ToList();
        }

        public Genre FindById(int id)
        {
            return _ctx.Genre.Find(id);
        }

        public bool Update(Genre model)
        {
            try
            {
                _ctx.Genre.Update(model);
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
