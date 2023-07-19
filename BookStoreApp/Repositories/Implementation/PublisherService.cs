
using BookStoreApp.Models.Domain;
using BookStoreApp.Repositories.Abstract;

namespace BookStoreApp.Repositories.Implementation
{
    public class PublisherService : IPublisherService
    {
        private readonly DatabaseContext _ctx;

        public PublisherService(DatabaseContext ctx)
        {
            this._ctx = ctx;
        }

        public bool Add(Publisher name)
        {
            try
            {
                _ctx.Publisher.Add(name);
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

                _ctx.Publisher.Remove(data);
                _ctx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public IEnumerable<Publisher> GetAll()
        {
            return _ctx.Publisher.ToList();
        }

        public Publisher FindById(int id)
        {
            return _ctx.Publisher.Find(id);
        }

        public bool Update(Publisher data)
        {
            try
            {
                _ctx.Publisher.Update(data);
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
