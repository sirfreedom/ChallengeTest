using System.Collections.Generic;
using System.Data;
using WinFormDisegnPattern.RepositoryPattern1.Interface;


namespace WinFormDisegnPattern.RepositoryPattern
{
    public class ProductoRepository : IRepository<Producto>, ICommonSQL
    {
        private readonly IRepository<Producto> _context;
        private readonly ICommonSQL _ContextSQL;

        public ProductoRepository(IRepository<Producto> context)
        {
            _context = context;
        }

        public ProductoRepository(ICommonSQL context)
        {
            _ContextSQL = context;
        }

        public string EntityName
        {
            get { return _context.EntityName; }
        }

        public Producto Get(int Id)
        {
            return _context.Get(Id);
        }

        public List<dynamic> Find(Dictionary<string, string> lParam)
        {
            return _context.Find(lParam);
        }

        public List<Producto> List()
        {
            return _context.List();
        }

        public void Insert(Dictionary<string, string> lParam)
        {
            _context.Insert(lParam);
        }

        public  void Delete(int Id)
        {
            _context.Delete(Id);
        }

        public void Update(Dictionary<string, string> lParam)
        {
            _context.Update(lParam);
        }

        public DataSet Fill(string NameSP, Dictionary<string, string> lParam = null)
        {
            return _ContextSQL.Fill(NameSP, lParam);
        }

        public void ExecuteNonQuery(string NameSP, Dictionary<string, string> lParam = null)
        {
            _ContextSQL.ExecuteNonQuery(NameSP, lParam);
        }
    }
}
