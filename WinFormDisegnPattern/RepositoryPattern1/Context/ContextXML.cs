using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace WinFormDisegnPattern.RepositoryPattern
{
    public class ContextXML<TEntity> : IRepository<TEntity>
    {

        #region Properties

        public string EntityName
        {
            get
            {
                Type type = typeof(TEntity);
                return type.Name;
            }
        }

        public string MessageError
        {
            get; private set;
        }

        #endregion

        #region Interface Method

        public List<TEntity> List()
        {
            DataTable dt;
            dt = ManagerXml.Instance.Fill(EntityName);
            return BaseEntity.ToList<TEntity>(dt);
        }

        public TEntity Get(int Id)
        {
            DataTable dt;
            DataTable dtResult;
            StringBuilder sbFilter = new StringBuilder();
            sbFilter.Append("Id = ");
            sbFilter.Append(ManagerXml.COMILLA);
            sbFilter.Append(Id);
            sbFilter.Append(ManagerXml.COMILLA);
            try
            {
                dt = ManagerXml.Instance.Fill(EntityName);
                dtResult = BaseEntity.ToDataTable(dt, sbFilter.ToString());
            }
            catch (Exception) 
            {
                throw;
            }
            return BaseEntity.ToList<TEntity>(dtResult).SingleOrDefault();
        }

        public List<dynamic> Find(Dictionary<string, string> lParam)
        {
            DataTable dt;
            DataTable dtResult;
            StringBuilder sbFilter = new StringBuilder();

            for (int i = 0; i < lParam.Count; i++)
            {
                KeyValuePair<string, string> p = lParam.ElementAt(i);
                sbFilter.Append("(");
                sbFilter.Append(p.Key);
                sbFilter.Append(" = ");
                sbFilter.Append(ManagerXml.COMILLA);
                sbFilter.Append(p.Value);
                sbFilter.Append(ManagerXml.COMILLA);
                sbFilter.Append(" ) ");
                sbFilter.AppendLine();
                sbFilter.Append((lParam.Count < i) ? " OR " : "");
            }
            try
            {
                dt = ManagerXml.Instance.Fill(EntityName);
                dtResult = BaseEntity.ToDataTable(dt, sbFilter.ToString());
            }
            catch (Exception) 
            {
                throw;
            }
            return BaseEntity.ToDynamic(dtResult);
        }

        public void Delete(int Id)
        {
            DataTable dt;
            try
            {

                dt = ManagerXml.Instance.Fill(EntityName);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["Id"].ToString() == Id.ToString())
                    {
                        dt.BeginInit();
                        dt.Rows.RemoveAt(i);
                        dt.EndInit();
                        break;
                    }
                }
                ManagerXml.Instance.ExecuteNonQuery(dt, EntityName);
            }
            catch (Exception) {
                throw;
            }
        }

        public void Insert(Dictionary<string, string> lParam)
        {
            DataTable dt;
            DataRow dr;
            Random oRandom = new Random(DateTime.Now.Millisecond);
            try
            {

                dt = ManagerXml.Instance.Fill(EntityName);

                if (dt.Columns.Count == 0)
                {
                    for (int i = 0; i < lParam.Count; i++)
                    {
                        KeyValuePair<string, string> p = lParam.ElementAt(i);
                        DataColumn dc = new DataColumn(p.Key, typeof(string));
                        dt.Columns.Add(dc);
                    }
                    DataColumn dcId = new DataColumn("Id", typeof(string));
                    dt.Columns.Add(dcId);
                }

                dr = dt.NewRow();

                for (int i = 0; i < lParam.Count; i++)
                {
                    KeyValuePair<string, string> p = lParam.ElementAt(i);
                    dr[p.Key] = p.Value;
                }
                dr["Id"] = oRandom.Next(1, int.MaxValue);
                dt.Rows.Add(dr);
                ManagerXml.Instance.ExecuteNonQuery(dt, EntityName);
            }
            catch (Exception) 
            {
                throw;
            }
        }

        public void Update(Dictionary<string, string> lParam)
        {
            DataTable dt;
            string sId;
            try
            {
                dt = ManagerXml.Instance.Fill(EntityName);
                sId = lParam["Id"].ToString();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["Id"].ToString() == sId.ToString())
                    {
                        dt.BeginInit();
                        for (int j = 0; j < lParam.Count; j++)
                        {
                            KeyValuePair<string, string> p = lParam.ElementAt(j);
                            dt.Rows[i][p.Key] = p.Value;
                        }
                        dt.EndInit();
                        break;
                    }
                }
                ManagerXml.Instance.ExecuteNonQuery(dt, EntityName);
            }
            catch (Exception) {
                throw;
            }
        }

        #endregion

        #region Internal Class

        internal class ManagerXml
        {
            private string App = AppDomain.CurrentDomain.BaseDirectory.ToString();
            private const string FILENAME = "dsXml.xml";
            private static ManagerXml _instance = null;
            private static object syncRoot = new Object();
            public const string COMILLADOBLE = "\"";
            public const string SPACE = " ";
            public const string TAB = "\t";
            public const string PUNTOCOMA = ";";
            public const string COMA = ",";
            public const string COMILLA = "'";

            #region Singleton 

            public static ManagerXml Instance
            {
                get
                {
                    if (_instance == null)
                    {
                        lock (syncRoot) //Evitamos que ingresen dos procesos consecutivos y concurrentes en el mismo momento.. no se puede importa al mismo tiempo de dos lados.
                        {
                            if (_instance == null)
                            {
                                _instance = new ManagerXml();
                            }
                        }
                    }
                    return _instance;
                }
            }

            private ManagerXml() { }

            #endregion

            #region Common Xml

            public DataTable Fill(string TableName)
            {
                StringBuilder sb = new StringBuilder();
                DataSet ds = new DataSet("ds");
                DataTable dt = new DataTable(TableName);
                try
                {
                    sb.Append(App);
                    sb.Append(FILENAME);

                    if (File.Exists(sb.ToString()))
                    {
                        ds.ReadXml(sb.ToString());
                    }

                    if (!File.Exists(sb.ToString()))
                    {
                        ds.Tables.Add(new DataTable(TableName));
                        dt = ds.Tables[TableName];
                    }

                    if (ds.Tables.Count > 0 && ds.Tables.Contains(TableName))
                    {
                        dt = ds.Tables[TableName].Copy();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                return dt;
            }

            public void ExecuteNonQuery(DataTable dt, string TableName)
            {
                StringBuilder sb = new StringBuilder();
                DataSet ds = new DataSet("ds");
                try
                {
                    sb.Append(App);
                    sb.Append(FILENAME);

                    dt.TableName = TableName;

                    if (File.Exists(sb.ToString()))
                    {
                        ds.ReadXml(sb.ToString());
                    }

                    if (ds.Tables.Contains(TableName))
                    {
                        ds.Tables.Remove(TableName);
                        ds.Tables.Add(dt);
                    }
                    else
                    {
                        ds.Tables.Add(dt);
                    }

                    ds.WriteXml(sb.ToString());
                }
                catch (Exception)
                {
                    throw;
                }
            }

            #endregion

        }

        #endregion


    }
}
