using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System;
using System.Text;



namespace UtilCoding.Helpers
{
    public class JsonHelper
    {

        #region Singleton

        private static JsonHelper _instance = null;
        private static object syncRoot = new Object();

        private JsonHelper()
        { }

        public static JsonHelper Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncRoot)  // lock is used because as we are using files it needs to block the other instances
                    {
                        if (_instance == null)
                        {
                            _instance = new JsonHelper();
                        }
                    }
                }
                return _instance;
            }
        }

        #endregion

        public class JsonEntity 
        {
            public string SubTableName { get; set; }
            public string TableName { get; set; }
            public string Key { get; set; }
            public string Value { get; set; }

            public JsonEntity() { }

            public JsonEntity(string subtablename,string tablename, string key, string value) 
            { 
                SubTableName = subtablename;
                TableName = tablename;
                Key = key;
                Value = value;
            }
        }  


      public List<JsonEntity> JsonToEntity(string Json)
        {
            JObject jsonObject;
            const string COMILLADOBLE = "\"";
            List<JsonEntity> lJsonEntity = new List<JsonEntity>();
            List<JsonEntity> lJsonEntityChild = new List<JsonEntity>();
            try
            {
                jsonObject = JObject.Parse(Json);

                foreach (JProperty jTable in jsonObject.Children<JProperty>())
                {
                    var jTableChild = jTable.Descendants().First();
                    DataSet dsChild = new DataSet();
                    JArray jArrayResult = new JArray();

                    foreach (JObject jRow in jTableChild.Children<JObject>())
                    {
                        JObject jTableRowResult = new JObject();

                        foreach (JProperty jColumn in jRow.Properties())
                        {
                            if (jColumn.Value is JValue) 
                            {
                                lJsonEntity.Add(new JsonEntity(jTable.Name, jTable.Name, jColumn.Name, jColumn.Value.ToString()));
                            }
                            else
                            {
                                StringBuilder sbChildren = new StringBuilder();
                                sbChildren.Append("{");
                                sbChildren.Append(COMILLADOBLE);
                                sbChildren.Append(jColumn.Name);
                                sbChildren.Append(COMILLADOBLE);
                                sbChildren.Append(":");
                                sbChildren.Append(jColumn.Value.ToString());
                                sbChildren.Append("}");

                                lJsonEntityChild = JsonChild(sbChildren.ToString());

                                foreach (JsonEntity oJsonChild in lJsonEntityChild)
                                {
                                   lJsonEntity.Add(new JsonEntity(jTable.Name,oJsonChild.TableName, oJsonChild.Key, oJsonChild.Value ));
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            { 
                string sss = ex.Message;
            }
            return lJsonEntity;
        }


        private List<JsonEntity> JsonChild(string Json)
        {
            JObject jsonObject;
            List<JsonEntity> lJsonEntity = new List<JsonEntity>();
            List<JsonEntity> lJsonEntityChild = new List<JsonEntity>();
            try
            {
                jsonObject = JObject.Parse(Json);

                foreach (JProperty jTable in jsonObject.Children<JProperty>())
                {
                    var jTableChild = jTable.Descendants().First();
                    DataSet dsChild = new DataSet();
                    JArray jArrayResult = new JArray();

                    foreach (JObject jRow in jTableChild.Children<JObject>())
                    {
                        JObject jTableRowResult = new JObject();

                        foreach (JProperty jColumn in jRow.Properties())
                        {
                            if (jColumn.Value is JValue)
                            {
                                lJsonEntity.Add(new JsonEntity( jTable.Name, jTable.Name, jColumn.Name, jColumn.Value.ToString()));
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                string sss = ex.Message;
            }
            return lJsonEntity;
        }


        public DataSet JsonEntityToDataset(List<JsonEntity> lJsonEntity)
        {
            DataSet ds = new DataSet("ds");
            int iRowSimpleTable = 0;
            DataRow dr = null;
            try
            {
                var lSimpleTable = lJsonEntity.Where(x => x.SubTableName == x.TableName).ToList().Select(t => t.SubTableName).ToList().Distinct();
                var lComplexTable = lJsonEntity.Where(x => x.SubTableName != x.TableName).GroupBy(x => new { x.SubTableName, x.TableName }).Select(t => t.First()).ToList();


                foreach (string sSimpleTable in lSimpleTable)
                {
                    List<string> lSimpleColumn = lJsonEntity.GroupBy(x => new { x.SubTableName, x.TableName, x.Key }).Select(t => t.First()).ToList().Where(z => z.SubTableName == sSimpleTable).Select(t => t.Key).ToList();

                    DataTable dt = new DataTable(sSimpleTable);

                    foreach (string sSimpleColumn in lSimpleColumn) 
                    { 
                        DataColumn dc = new DataColumn(sSimpleColumn,typeof(string));
                        dt.Columns.Add(dc);
                    }

                    ds.Tables.Add(dt);
                }

                foreach (var oComplexTable in lComplexTable)
                {
                    List<string> lComplexColumn = lJsonEntity.GroupBy(x => new { x.SubTableName, x.TableName, x.Key }).Select(t => t.First()).ToList().Where(z => z.SubTableName == oComplexTable.SubTableName).Select(t => t.Key).ToList();

                    DataTable dt = new DataTable(oComplexTable.SubTableName);
                    DataColumn dcCode = new DataColumn("TableName", typeof(string));
                    dt.Columns.Add(dcCode);

                    foreach (string sComplexColumn in lComplexColumn) 
                    {
                        DataColumn dc = new DataColumn(sComplexColumn, typeof(string));
                        dt.Columns.Add(dc);
                    }
                    ds.Tables.Add(dt);
                }

                foreach (JsonEntity oJson in lJsonEntity)
                {
                    StringBuilder sbComplexTable = new StringBuilder();
                    sbComplexTable.Append(oJson.SubTableName);
                    sbComplexTable.Append(oJson.TableName);

                    //new row table simple
                    if (iRowSimpleTable == 0 && oJson.SubTableName == oJson.TableName)
                    {
                        dr = ds.Tables[oJson.SubTableName].NewRow();
                    }

                    //Tabla Simple
                    if (oJson.SubTableName == oJson.TableName)
                    {
                        dr[oJson.Key] = oJson.Value.ToString(); // registro actual
                        iRowSimpleTable = iRowSimpleTable + 1;
                    }

                    // Si se cumplen la cantidad de rows comparadas con las columnas completo un row completo
                    if (ds.Tables[oJson.SubTableName].Columns.Count == iRowSimpleTable && oJson.SubTableName == oJson.TableName)
                    {
                        ds.Tables[oJson.SubTableName].Rows.Add(dr);
                        iRowSimpleTable = 0;
                    }

                    // nuevo row en complex.
                    if (oJson.SubTableName != oJson.TableName && ds.Tables[oJson.SubTableName].Columns.Contains(oJson.Key) )
                    {
                        dr = ds.Tables[oJson.SubTableName].NewRow();
                    }

                    if (oJson.SubTableName != oJson.TableName)
                    {
                        dr[oJson.Key] = oJson.Value.ToString();
                        iRowSimpleTable = iRowSimpleTable + 1;
                    }

                    if (
                        (oJson.SubTableName != oJson.TableName) ) 
                    {
                        ds.Tables[oJson.SubTableName].Rows.Add(dr);
                    }

                }
            }
            catch (Exception ex) 
            {
                throw ex;
            }
            return ds;
        }






    }
}
