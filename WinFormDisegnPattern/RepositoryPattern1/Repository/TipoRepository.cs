
using System.Collections.Generic;

namespace WinFormDisegnPattern.RepositoryPattern
{
    public class TipoRepository : IRepository<Tipo>
    {
        private readonly IRepository<Tipo> _context;


        public TipoRepository(IRepository<Tipo> context)
        {
            _context = context;
        }

        public string EntityName
        {
            get { return _context.EntityName; }
        }

        public Tipo Get(int Id)
        {
            return _context.Get(Id);
        }

        public List<dynamic> Find(Dictionary<string, string> lParam)
        {
            return _context.Find(lParam);
        }

        public List<Tipo> List()
        {
            return _context.List();
        }

        public void Insert(Dictionary<string, string> lParam)
        {
            _context.Insert(lParam);
        }

        public void Delete(int Id)
        {
            _context.Delete(Id);
        }

        public void Update(Dictionary<string, string> lParam)
        {
            _context.Update(lParam);
        }

    }
}
