
using System.Collections.Generic;

namespace WinFormDisegnPattern.RepositoryPattern
{
    public class ClienteRepository : IRepository<Cliente> 
    {

        private readonly IRepository<Cliente> _context;


        public ClienteRepository(IRepository<Cliente> context) 
        {
            _context = context;
        }

        public string EntityName 
        {
            get { return _context.EntityName; }
        }

        public void Delete(int Id)
        {
            _context.Delete(Id);
        }

        public List<dynamic> Find(Dictionary<string, string> lParam)
        {
            return _context.Find(lParam);
        }

        public Cliente Get(int Id)
        {
            return _context.Get(Id);
        }

        public void Insert(Dictionary<string, string> lParam)
        {
            _context.Insert(lParam);
        }

        public List<Cliente> List()
        {
            return _context.List();
        }

        public void Update(Dictionary<string, string> lParam)
        {
            _context.Update(lParam);
        }
    }
}
