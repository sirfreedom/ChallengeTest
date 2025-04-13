using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace WinFormDisegnPattern.RepositoryPattern
{
    public class ContextJson<TEntity> : IRepository<TEntity>
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
            dt = ManagerJson.Instance.Fill(EntityName);
            return BaseEntity.ToList<TEntity>(dt);
        }

        public TEntity Get(int Id)
        {
            DataTable dt;
            DataTable dtResult;
            StringBuilder sbFilter = new StringBuilder();
            sbFilter.Append("Id = ");
            sbFilter.Append("'");
            sbFilter.Append(Id);
            sbFilter.Append("'");
            try
            {
                dt = ManagerJson.Instance.Fill(EntityName);
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
                sbFilter.Append("'");
                sbFilter.Append(p.Value);
                sbFilter.Append("'");
                sbFilter.Append(" ) ");
                sbFilter.AppendLine();
                sbFilter.Append((lParam.Count < i) ? " OR " : "");
            }
            try
            {
                dt = ManagerJson.Instance.Fill(EntityName);
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
                dt = ManagerJson.Instance.Fill(EntityName);

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
                ManagerJson.Instance.ExecuteNonQuery(dt, EntityName);
            }
            catch (Exception)
            {
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
                dt = ManagerJson.Instance.Fill(EntityName);

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
                ManagerJson.Instance.ExecuteNonQuery(dt, EntityName);
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
                dt = ManagerJson.Instance.Fill(EntityName);
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
                ManagerJson.Instance.ExecuteNonQuery(dt, EntityName);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Internal Class

        internal class ManagerJson 
        {

            #region Declaracion

            private string App = AppDomain.CurrentDomain.BaseDirectory.ToString();
            private const string FILENAME = "Data.json";
            private static ManagerJson _instance = null;
            private static object syncRoot = new Object();
 
            #endregion

            #region Singleton 

            public static ManagerJson Instance
            {
                get
                {
                    if (_instance == null)
                    {
                        lock (syncRoot) //Evitamos que ingresen dos procesos consecutivos y concurrentes en el mismo momento.. no se puede importa al mismo tiempo de dos lados.
                        {
                            if (_instance == null)
                            {
                                _instance = new ManagerJson();
                            }
                        }
                    }
                    return _instance;
                }
            }

            private ManagerJson() { }

            #endregion

            public DataTable Fill(string TableName)
            {
                DataTable dt = new DataTable(TableName);
                DataSet ds = new DataSet("ds");
                List<TEntity> lEntity = new List<TEntity>();
                StringBuilder sb = new StringBuilder();
                string sJason = string.Empty;
                try
                {
                    sb.Append(App);
                    sb.Append(FILENAME);

                    if (File.Exists(sb.ToString()))
                    {
                        sJason = File.ReadAllText(sb.ToString());
                        ds = BaseEntity.ToDatatable(sJason);
                        dt = ds.Tables[TableName];
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
                DataSet ds = new DataSet("ds");
                List<TEntity> lEntity = new List<TEntity>();
                StringBuilder sb = new StringBuilder();
                string sJason = string.Empty;
                try
                {
                    sb.Append(App);
                    sb.Append(FILENAME);

                    if (File.Exists(sb.ToString()))
                    {
                        sJason = File.ReadAllText(sb.ToString());
                        ds = BaseEntity.ToDatatable(sJason);
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
                    sJason = BaseEntity.ToJson(ds);

                    File.WriteAllText(sb.ToString(), sJason);
                }
                catch (Exception)
                {
                    throw;
                }
            }
   

        }


        #endregion


    }

}

