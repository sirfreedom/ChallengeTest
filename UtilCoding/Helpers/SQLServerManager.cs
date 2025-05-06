/*
Hecho por Alejandro Millan 
OpenSource 
Finalidad: 
poder generar sentencias SQL INSERT basicas para poder implemetar algun sistema.

*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;


namespace UtilCoding
{

    public class SQLServerManager
    {

        #region Declaration

        private string DbConectionString = string.Empty;

        private const string COMILLADOBLE = "\"";
        private const string SPACE = " ";
        private const string TAB = "\t";
        private const string PUNTOCOMA = ";";
        private const string COMA = ",";

        private LenguajePuntoComa _Lenguaje;

        public enum TipoMotor
        {
            Oracle = 1,
            SqlServer2000 = 2,
            SoloInsert = 4,
            SqlServer2005 = 6,
            SqlServer2008 = 6
        }


        public enum LenguajePuntoComa
        {
            Punto = 1,
            Coma = 2
        }

        public LenguajePuntoComa Lenguaje
        {
            set
            {
                _Lenguaje = value;
            }
        }

        #endregion

        #region Constructor / Destructor / Dispose

        public SQLServerManager(string BaseName, string ServerName, string User, string Pass, bool IntegrateSecurity)
        {
            this.DbConectionString = this.ConectionStringManagerSql(BaseName, ServerName, User, Pass, IntegrateSecurity);
        }

        #endregion

        #region Conection String

        private string ConectionStringManagerSql(string BaseName, string ServerName, string User, string Pass, bool IntegrateSegurity)
        {
            StringBuilder sb = new StringBuilder();
                        
            if (User.Length != 0 && Pass.Length != 0)
            {
                sb.Append("Password=");
                sb.Append(Pass);
                sb.Append(";Persist Security Info=True");
                sb.Append(";User ID=");
                sb.Append(User);
            }
            sb.Append(";Initial Catalog=");
            sb.Append(BaseName);
            sb.Append(";Data Source=");
            sb.Append(ServerName);

            if (IntegrateSegurity)
            {
                sb.Append(";Integrated Security=SSPI;");
            }
            return sb.ToString();
        }

        #endregion

        #region Method Get Data

        public List<TableRelation> GetTables()
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            StringBuilder sbConsultas = new StringBuilder();
            List<TableRelation> lTableRelation;
            try
            {
                sbConsultas.AppendLine("select so.Id as TableId, so.[name] as TableName, count(*) Relation");
                sbConsultas.AppendLine("from [sysobjects] so");
                sbConsultas.AppendLine("left join [sysforeignkeys] sfk on so.id = sfk.rkeyid");
                sbConsultas.AppendLine("WHERE[TYPE] = 'U' AND[NAME] != 'dtproperties' AND[NAME] != 'sysdiagrams' ");
                sbConsultas.AppendLine("group by");
                sbConsultas.AppendLine("so.id,so.[name] order by Relation desc");
                da.SelectCommand = cmd;
                cmd.CommandText = sbConsultas.ToString();

                using (SqlConnection connection = new SqlConnection()) 
                {
                    connection.ConnectionString = this.DbConectionString;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connection;
                    connection.Open();
                    da.Fill(ds);
                    connection.Close();
                }

                lTableRelation = ToList<TableRelation>(ds.Tables[0]);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lTableRelation;
        }

        public PackTableInfo GetTablesInfo(List<string> SelectTables)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            StringBuilder sbConsultas = new StringBuilder();
            StringBuilder sbTablasFilter = new StringBuilder();
            DataSet dsTablesInfo = new DataSet();
            PackTableInfo oPack = new PackTableInfo();

            int iFinal = 0;
            try
            {
                while (iFinal < SelectTables.Count)
                {
                    sbTablasFilter.Append("'");
                    sbTablasFilter.Append(SelectTables[iFinal]);
                    sbTablasFilter.Append("'");
                    if ((SelectTables.Count - 1) != iFinal)
                    {
                        sbTablasFilter.Append(",");
                    }
                    iFinal++;
                }

                //Consulta de Tablas y la cantidad de relaciones
                sbConsultas.AppendLine("select so.Id as TableId, so.[name] as TableName, count(*) Relation");
                sbConsultas.AppendLine("from [sysobjects] so");
                sbConsultas.AppendLine("left join [sysforeignkeys] sfk on so.id = sfk.rkeyid");
                sbConsultas.AppendLine("WHERE[TYPE] = 'U' AND[NAME] != 'dtproperties' AND[NAME] != 'sysdiagrams' ");
                sbConsultas.AppendLine("and so.name in ( ");
                sbConsultas.AppendLine(sbTablasFilter.ToString());
                sbConsultas.AppendLine(" )");
                sbConsultas.AppendLine("group by");
                sbConsultas.AppendLine("so.id,so.[name] order by Relation desc");
                sbConsultas.AppendLine();

                //Consulta de Columnas
                sbConsultas.AppendLine("select ");
                sbConsultas.AppendLine("so.Id TableId,");
                sbConsultas.AppendLine("sc.[name] ColumnName,");
                sbConsultas.AppendLine("st.[name] ColumType,  ");
                sbConsultas.AppendLine("sc.[length] ColumnLen, ");
                sbConsultas.AppendLine("(SELECT c.name AS column_name FROM sys.columns c ");
                sbConsultas.AppendLine("INNER JOIN sys.index_columns ic ON c.object_id = ic.object_id");
                sbConsultas.AppendLine("AND c.column_id = ic.column_id");
                sbConsultas.AppendLine("INNER JOIN sys.indexes i ON ic.object_id = i.object_id");
                sbConsultas.AppendLine("AND ic.index_id = i.index_id ");
                sbConsultas.AppendLine("INNER JOIN sys.tables t ON i.object_id = t.object_id");
                sbConsultas.AppendLine("WHERE t.name = so.[name] AND i.is_primary_key = 1) as NameColumnPK,");
                sbConsultas.AppendLine("sc.isnullable as AllowNull ");
                sbConsultas.AppendLine("from [syscolumns] sc ");
                sbConsultas.AppendLine("inner join [systypes] st");
                sbConsultas.AppendLine("on st.xtype = sc.xtype ");
                sbConsultas.AppendLine("inner join [SYSOBJECTS] so");
                sbConsultas.AppendLine("on sc.id = so.id ");
                sbConsultas.AppendLine("left join sys.[identity_columns] ic");
                sbConsultas.AppendLine("on so.id = ic.[object_id] ");
                sbConsultas.AppendLine("WHERE so.[TYPE] = 'U' ");
                sbConsultas.AppendLine("and so.[name] != 'dtproperties'");
                sbConsultas.AppendLine("and st.[name] != 'sysname' ");
                sbConsultas.AppendLine("and so.[name] in ( ");
                sbConsultas.AppendLine(sbTablasFilter.ToString());
                sbConsultas.AppendLine(")");
                sbConsultas.AppendLine("order by TableId");
                sbConsultas.AppendLine();

                //Consulta de tablas relacionadas consigo mismas, para obtener un ordenamiento por su PrimaryKey y que no de error de insercion.
                sbConsultas.AppendLine("SELECT");
                sbConsultas.AppendLine("f.[parent_object_id] as TableId,");
                sbConsultas.AppendLine("f.[object_id] as ObjectId,");
                sbConsultas.AppendLine("f.[referenced_object_id] as TableForeingId,");
                sbConsultas.AppendLine("f.[type_desc] as TypeDescription,");
                sbConsultas.AppendLine("OBJECT_NAME(f.parent_object_id) AS TableName,");
                sbConsultas.AppendLine("COL_NAME(fc.parent_object_id, fc.parent_column_id) AS ColumnName,");
                sbConsultas.AppendLine("OBJECT_NAME (f.referenced_object_id) AS ReferenceTableName,");
                sbConsultas.AppendLine("COL_NAME(fc.referenced_object_id, fc.referenced_column_id) AS ReferenceColumnName");
                sbConsultas.AppendLine("FROM sys.foreign_keys AS f");
                sbConsultas.AppendLine("INNER JOIN sys.foreign_key_columns AS fc");
                sbConsultas.AppendLine("ON f.[OBJECT_ID] = fc.constraint_object_id");
                sbConsultas.AppendLine("where");
                sbConsultas.AppendLine("OBJECT_NAME(f.parent_object_id) in (");
                sbConsultas.AppendLine(sbTablasFilter.ToString());
                sbConsultas.AppendLine(")");
                sbConsultas.AppendLine();

                cmd.CommandType = CommandType.Text;
                da.SelectCommand = cmd;
                cmd.CommandText = sbConsultas.ToString();

                using (SqlConnection connection = new SqlConnection()) 
                {
                    connection.ConnectionString = this.DbConectionString;
                    cmd.Connection = connection;
                    connection.Open();
                    da.Fill(dsTablesInfo);
                    connection.Close();
                }

                oPack.TableRelations = ToList<TableRelation>(dsTablesInfo.Tables[0]);
                oPack.TableColumns = ToList<TableColumn>(dsTablesInfo.Tables[1]);
                oPack.TableConstrainRelations = ToList<TableConstrainRelation>(dsTablesInfo.Tables[2]);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oPack;
        }

        public DataTable GetAllData(string ActiveTable, string Schema, int PageSecuence, int PageLen, string ColumnaId)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            StringBuilder sbConsultaIni = new StringBuilder();
            try
            {
                sbConsultaIni.AppendLine("SELECT * FROM ( ");
                sbConsultaIni.AppendLine("SELECT *, ROW_NUMBER() Over(Order By ");
                sbConsultaIni.Append(ColumnaId);
                sbConsultaIni.Append(" desc ");
                sbConsultaIni.Append(") As RowNum ");
                sbConsultaIni.AppendLine("FROM ");
                sbConsultaIni.Append(ActiveTable);
                sbConsultaIni.AppendLine(") AS TABLEROWNUMBER ");
                sbConsultaIni.AppendLine("WHERE RowNum BETWEEN ( ");
                sbConsultaIni.Append(PageSecuence.ToString());
                sbConsultaIni.Append(" - 1 ) * ");
                sbConsultaIni.Append(PageLen.ToString());
                sbConsultaIni.Append("+ 1 AND ");
                sbConsultaIni.Append(PageSecuence.ToString());
                sbConsultaIni.Append(" * ");
                sbConsultaIni.Append(PageLen.ToString());
                cmd.CommandType = CommandType.Text;
                da.SelectCommand = cmd;
                cmd.CommandText = sbConsultaIni.ToString();

                using (SqlConnection connection = new SqlConnection())
                {
                    connection.ConnectionString = this.DbConectionString;
                    cmd.Connection = connection;
                    connection.Open();
                    da.Fill(dt);
                    connection.Close();
                }
            }
            catch (SqlException sse)
            {
                throw sse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        private List<T> ToList<T>(DataTable dt)
        {
            var properties = typeof(T).GetProperties();
            List<string> columnNames = new List<string>();
            try
            {
                columnNames = dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName).ToList();
                return dt.AsEnumerable().Select(dr =>
                {
                    var objT = Activator.CreateInstance<T>();

                    foreach (var p in properties)
                    {
                        if (columnNames.Contains(p.Name))
                        {
                            if (dr[p.Name] != DBNull.Value && p.PropertyType.Name != "Nullable")
                            {
                                switch (p.PropertyType.Name)
                                {
                                    case "String":
                                        p.SetValue(objT, dr[p.Name].ToString(), null); ;
                                        break;
                                    case "Int64":
                                        p.SetValue(objT, long.Parse(dr[p.Name].ToString()), null);
                                        break;
                                    case "Int16":
                                        p.SetValue(objT, short.Parse(dr[p.Name].ToString()), null);
                                        break;
                                    case "Int32":
                                        p.SetValue(objT, int.Parse(dr[p.Name].ToString()), null);
                                        break;
                                    case "Byte":
                                        p.SetValue(objT, byte.Parse(dr[p.Name].ToString()), null);
                                        break;
                                    case "Short":
                                        p.SetValue(objT, short.Parse(dr[p.Name].ToString()), null);
                                        break;
                                    case "Boolean":
                                        p.SetValue(objT, bool.Parse((dr[p.Name].ToString() == "1") ? "true" : "false"), null);
                                        break;
                                    case "Single":
                                        p.SetValue(objT, Single.Parse(dr[p.Name].ToString()), null);
                                        break;
                                    case "DateTime":
                                        p.SetValue(objT, DateTime.Parse(dr[p.Name].ToString()), null);
                                        break;
                                    default:
                                        p.SetValue(objT, dr[p.Name], null);
                                        break;
                                }
                            }
                            if (dr[p.Name] == DBNull.Value)
                            {
                                switch (p.PropertyType.Name)
                                {
                                    case "String":
                                        p.SetValue(objT, string.Empty, null);
                                        break;
                                    case "Int64":
                                    case "Int32":
                                    case "Int16":
                                    case "Byte":
                                    case "Short":
                                    case "Single":
                                        p.SetValue(objT, 0, null);
                                        break;
                                    case "Boolean":
                                        p.SetValue(objT, false, null);
                                        break;
                                    case "DateTime":
                                        p.SetValue(objT, DateTime.MinValue, null);
                                        break;
                                    default:
                                        break;
                                }
                            }

                        }
                    }
                    return objT;
                }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Convert

        private string ConvertSQL_Datetime(string fecha)
        {
            StringBuilder sbFecha = new StringBuilder();

            if (fecha.IndexOf("a.m.") != 0 || fecha.IndexOf("AM") != 0)
            {
                fecha = fecha.Replace("a.m.", "");
                fecha = fecha.Replace("AM", "");
                fecha = fecha.Replace("12:", "00:");
            }
            if (fecha.IndexOf("p.m.") != 0 || fecha.IndexOf("PM") != 0)
            {
                fecha = fecha.Replace("p.m.", "");
                fecha = fecha.Replace("PM", "");
                fecha = fecha.Replace(" 1:", "13:");
                fecha = fecha.Replace(" 2:", "14:");
                fecha = fecha.Replace(" 3:", "15:");
                fecha = fecha.Replace(" 4:", "16:");
                fecha = fecha.Replace(" 5:", "17:");
                fecha = fecha.Replace(" 6:", "18:");
                fecha = fecha.Replace(" 7:", "19:");
                fecha = fecha.Replace(" 8:", "20:");
                fecha = fecha.Replace(" 9:", "21:");
                fecha = fecha.Replace("10:", "22:");
                fecha = fecha.Replace("11:", "23:");
            }


            sbFecha.Append("convert(datetime,(substring(");
            sbFecha.Append("'");
            sbFecha.Append(fecha);
            sbFecha.Append("'");
            sbFecha.Append(", 7, 4) + '/' + substring(");
            sbFecha.Append("'");
            sbFecha.Append(fecha);
            sbFecha.Append("'");
            sbFecha.Append(", 4, 2) + '/' + substring(");
            sbFecha.Append("'");
            sbFecha.Append(fecha);
            sbFecha.Append("'");
            sbFecha.Append(", 1, 2) + ' ' + substring(");
            sbFecha.Append("'");
            sbFecha.Append(fecha);
            sbFecha.Append("'");
            sbFecha.Append(", 11, 16)))");

            return sbFecha.ToString();
        }

        private string ConvertORACLE_Datetime(string fecha)
        {
            StringBuilder sbReturn = new StringBuilder();
            sbReturn.Append("to_date('");
            sbReturn.Append(fecha);
            sbReturn.Append("'");
            sbReturn.Append(",'DD/MM/YYYY HH24:MI:SS')");
            return sbReturn.ToString();
        }

        private string ConvertORACLE_Boolean(string value)
        {
            StringBuilder sbReturn = new StringBuilder();
            value.ToLower().Replace("true", "1");
            value.ToLower().Replace("false", "0");
            return sbReturn.ToString();
        }

        private string ConvertSQL_Boolean(string value)
        {
            StringBuilder sbReturn = new StringBuilder();
            sbReturn.Append("convert(bit,");
            sbReturn.Append("'");
            sbReturn.Append(value);
            sbReturn.Append("'");
            sbReturn.Append(")");
            return sbReturn.ToString();
        }

        private string ConvertSQL_Int(string value)
        {
            StringBuilder sbReturn = new StringBuilder();

            if (value.Length == 0)
            {
                sbReturn.Append("null");
            }
            else
            {
                sbReturn.Append(value);
            }

            return sbReturn.ToString();
        }

        private string ConvertSQL_Decimal(string value)
        {
            StringBuilder sbReturn = new StringBuilder();

            if (_Lenguaje == LenguajePuntoComa.Punto)
            {
                value = value.Replace(",", ".");
            }
            if (_Lenguaje == LenguajePuntoComa.Coma)
            {
                value = value.Replace(".", ",");
            }
            sbReturn.Append("convert(decimal,'");
            sbReturn.Append(value);
            sbReturn.Append("')");
            return sbReturn.ToString();
        }

        #endregion

        #region Method Export 


        private string CommonCreateQueries(string ActiveTable, string Schema, TipoMotor MotorBaseDeDatos, DataTable dtActiveTable, DataSet dsTablesInfo, PackTableInfo oPack)
        {
            string sActiveIdTable = string.Empty;
            StringBuilder sbConsulta = new StringBuilder();
            StringBuilder sbColumns = new StringBuilder();
            StringBuilder sbConsultaIni = new StringBuilder();
            bool NeedIdentity = false;
            try
            {
                if (Schema.Length != 0)
                {
                    Schema = "[" + Schema + "].";
                }

                if (oPack.TableConstrainRelations.Select(x => x.TableName == ActiveTable).Count() > 0 && (MotorBaseDeDatos == TipoMotor.SqlServer2000 || MotorBaseDeDatos == TipoMotor.SqlServer2005))
                {
                    NeedIdentity = true;
                }

                sbConsulta.AppendLine();
                sbConsulta.AppendLine();
                sbConsulta.AppendLine();
                sbConsulta.Append("---************************************** ");
                sbConsulta.Append(ActiveTable);
                sbConsulta.Append("***********************************");
                sbConsulta.AppendLine();
                sbConsulta.AppendLine();
                sbConsulta.AppendLine();
                sbConsulta.AppendLine();
                sbConsulta.AppendLine();

                if (MotorBaseDeDatos == TipoMotor.SqlServer2000 || MotorBaseDeDatos == TipoMotor.SqlServer2005 || MotorBaseDeDatos == TipoMotor.SqlServer2008)
                {
                    sbConsulta.AppendLine("SET QUOTED_IDENTIFIER ON ");
                    sbConsulta.AppendLine("SET TRANSACTION ISOLATION LEVEL SERIALIZABLE ");
                    sbConsulta.AppendLine("SET ARITHABORT ON ");
                    sbConsulta.AppendLine("SET NUMERIC_ROUNDABORT OFF ");
                    sbConsulta.AppendLine("SET CONCAT_NULL_YIELDS_NULL ON ");
                    sbConsulta.AppendLine("SET ANSI_NULLS ON ");
                    sbConsulta.AppendLine("SET ANSI_PADDING ON ");
                    sbConsulta.AppendLine("SET ANSI_WARNINGS ON ");
                    sbConsulta.AppendLine();
                    sbConsulta.AppendLine("GO ");
                    sbConsulta.AppendLine();
                    sbConsulta.AppendLine();
                    sbConsulta.Append("BEGIN TRANSACTION ");
                    sbConsulta.AppendLine();
                    sbConsulta.AppendLine();
                }


                if (MotorBaseDeDatos == TipoMotor.Oracle)
                {
                    sbConsulta.AppendLine("SET SERVEROUTPUT ON");
                    sbConsulta.AppendLine();
                    sbConsulta.AppendLine();
                    sbConsulta.Append("BEGIN ");
                    sbConsulta.AppendLine();
                    sbConsulta.AppendLine();
                }

                if (NeedIdentity)
                {
                    sbConsulta.AppendLine();
                    sbConsulta.Append("SET IDENTITY_INSERT ");
                    sbConsulta.Append(Schema);
                    sbConsulta.Append(ActiveTable);
                    sbConsulta.Append(" ON");
                }

                sbConsulta.AppendLine();

                int iFinalColumna = 0;

                for (int i = 0; i < oPack.TableColumns.Count; i++)
                {
                    sbColumns.Append(oPack.TableColumns[i].ColumnName);

                    if (i < oPack.TableColumns.Count)
                    {
                        sbColumns.Append(",");
                    }
                }

                sbConsultaIni.Append("INSERT INTO ");
                sbConsultaIni.Append(Schema);
                sbConsultaIni.Append("");
                sbConsultaIni.Append(ActiveTable);
                sbConsultaIni.Append("");
                sbConsultaIni.Append(" ( ");
                sbConsultaIni.Append(sbColumns.ToString());
                sbConsultaIni.Append(" ) VALUES ( ");

                foreach (DataRow drdato in dtActiveTable.Rows)
                {
                    iFinalColumna = 0;
                    StringBuilder sbValores = new StringBuilder();

                    foreach (TableColumn oTableColumn in oPack.TableColumns)
                    {
                        string stipo = oTableColumn.ColumType;
                        string scolumna = oTableColumn.ColumnName;

                        switch (stipo)
                        {
                            case "char":
                            case "text":
                            case "varchar":
                            case "nchar":
                            case "nvarchar":
                                sbValores.Append("'");
                                sbValores.Append(drdato[scolumna].ToString().Trim());
                                sbValores.Append("'");
                                break;
                            case "tinyint":
                            case "int":
                            case "smallint":
                            case "bigint":
                                sbValores.Append(ConvertSQL_Int(drdato[scolumna].ToString().Trim()));
                                break;
                            case "numeric":
                            case "decimal":
                            case "money":
                            case "smallmoney":
                            case "real":
                            case "float":
                                sbValores.Append(ConvertSQL_Decimal(drdato[scolumna].ToString().Trim()));
                                break;
                            case "bit":
                                if (MotorBaseDeDatos == TipoMotor.SqlServer2000 || MotorBaseDeDatos == TipoMotor.SqlServer2005 || MotorBaseDeDatos == TipoMotor.SqlServer2008)
                                {
                                    sbValores.Append(ConvertSQL_Boolean(drdato[scolumna].ToString().Trim()));
                                }
                                if (MotorBaseDeDatos == TipoMotor.Oracle)
                                {
                                    sbValores.Append(ConvertORACLE_Boolean(drdato[scolumna].ToString().Trim()));
                                }
                                if (MotorBaseDeDatos == TipoMotor.SoloInsert)
                                {
                                    sbValores.Append("'");
                                    sbValores.Append(drdato[scolumna].ToString().Trim());
                                    sbValores.Append("'");
                                }
                                break;
                            case "datetime":
                            case "date":
                            case "time":
                            case "smalldatetime":
                                if (MotorBaseDeDatos == TipoMotor.Oracle)
                                {
                                    sbValores.Append(ConvertORACLE_Datetime(drdato[scolumna].ToString().Trim()));
                                }
                                if (MotorBaseDeDatos == TipoMotor.SqlServer2000 || MotorBaseDeDatos == TipoMotor.SqlServer2005 || MotorBaseDeDatos == TipoMotor.SqlServer2008)
                                {
                                    sbValores.Append(ConvertSQL_Datetime(drdato[scolumna].ToString().Trim()));
                                }
                                if (MotorBaseDeDatos == TipoMotor.SoloInsert)
                                {
                                    sbValores.Append("'");
                                    sbValores.Append(drdato[scolumna].ToString().Trim());
                                    sbValores.Append("'");
                                }
                                break;
                            default:
                                sbValores.Append("null");
                                break;
                        }

                        if ((dtActiveTable.Rows.Count - 1) != iFinalColumna)
                        {
                            sbValores.Append(",");
                        }
                        iFinalColumna++;
                    }
                    sbValores.Append(")");

                    sbConsulta.AppendLine();
                    sbConsulta.Append(sbConsultaIni.ToString());
                    sbConsulta.Append(sbValores.ToString());
                }

                if (NeedIdentity)
                {
                    sbConsulta.AppendLine();
                    sbConsulta.AppendLine();
                    sbConsulta.AppendLine();
                    sbConsulta.Append("SET IDENTITY_INSERT ");
                    sbConsulta.Append(Schema);
                    sbConsulta.Append(ActiveTable);
                    sbConsulta.Append(" OFF");
                }

                if (MotorBaseDeDatos == TipoMotor.SqlServer2000 || MotorBaseDeDatos == TipoMotor.SqlServer2005 || MotorBaseDeDatos == TipoMotor.SqlServer2008)
                {
                    sbConsulta.AppendLine();
                    sbConsulta.AppendLine();
                    sbConsulta.AppendLine("COMMIT TRANSACTION  ");
                    sbConsulta.AppendLine();
                    sbConsulta.AppendLine("--**************************  Fin de Query - Generated by SqlToScript ********************************** ");
                    sbConsulta.AppendLine();
                    sbConsulta.AppendLine();
                }

                if (MotorBaseDeDatos == TipoMotor.Oracle)
                {
                    sbConsulta.AppendLine("--**************************  Fin Transaccion ********************************** ");
                    sbConsulta.AppendLine();
                    sbConsulta.AppendLine();
                    sbConsulta.AppendLine("COMMIT;");
                    sbConsulta.AppendLine("EXCEPTION WHEN OTHERS THEN ");
                    sbConsulta.AppendLine("dbms_output.put_line( SQLCODE || '   ********    ' || SQLERRM ); ");
                    sbConsulta.AppendLine();
                    sbConsulta.AppendLine("dbms_output.put_line('*************************************************************************' ); ");
                    sbConsulta.AppendLine("dbms_output.put_line('OCURRIO UN ERROR EN EL PROCESAMIENTO DE LOS DATOS, NO SE HA INSERTADO NADA'); ");
                    sbConsulta.AppendLine("dbms_output.put_line('*************************************************************************'); ");
                    sbConsulta.AppendLine("ROLLBACK;");
                    sbConsulta.AppendLine("END;");
                    sbConsulta.AppendLine("--**************************  Fin de Query - Generated by SqlToScript ********************************** ");
                    sbConsulta.AppendLine();
                    sbConsulta.AppendLine();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return sbConsulta.ToString();
        }

        public void SaveOutputScript(List<string> SelectTables, TipoMotor tipoMotor, string PathScript, string Schema, int RowPerPage)
        {
            DataSet dsTablesInfo = new DataSet();
            DataTable dt = new DataTable();
            string s = string.Empty;
            string sColumnaId = string.Empty;
            PackTableInfo oPackTableInfo = new PackTableInfo();
            try
            {
                foreach (string sTableName in SelectTables)
                {
                    List<string> lTable = new List<string>();
                    lTable.Add(sTableName);
                    int i = 1;
                    oPackTableInfo = GetTablesInfo(lTable);

                    sColumnaId = oPackTableInfo.TableColumns[0].NameColumnPK;
                    do
                    {
                        dt = GetAllData(sTableName, Schema, i, RowPerPage, sColumnaId);
                        s = CommonCreateQueries(sTableName, Schema, tipoMotor, dt, dsTablesInfo, oPackTableInfo);
                        StringBuilder sbFile = new StringBuilder();
                        sbFile.Append(PathScript);
                        sbFile.Append("_");
                        sbFile.Append(sTableName.ToString());
                        sbFile.Append("_");
                        sbFile.Append(i.ToString());
                        sbFile.Append(".sql");
                        File.AppendAllText(sbFile.ToString(), s, Encoding.UTF8);
                    }
                    while (dt.Rows.Count != 0);

                    System.Threading.Thread.Sleep(1000);
                    i++;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Entities

        public class PackTableInfo
        {
            public List<TableRelation> TableRelations { get; set; } = new List<TableRelation>();
            public List<TableColumn> TableColumns { get; set; } = new List<TableColumn>();
            public List<TableConstrainRelation> TableConstrainRelations { get; set; } = new List<TableConstrainRelation>();
        }

        
        public class TableRelation
        {
            public int TableId { get; set; }
            public string TableName { get; set; }
            public int Relation { get; set; }
        }

        public class TableColumn 
        {
            public int TableId { get; set; }
            public string ColumnName { get; set; }
            public string ColumType { get; set; }
            public string NameColumnPK { get; set; }
            public int ColumnLen { get; set; }
            public bool AllowNull { get; set; }
        }

        public class TableConstrainRelation 
        {
            public int TableId { get; set;}
            public int ObjectId { get; set; }
            public int TableForeingId { get; set; }
            public string TypeDescription { get; set; }
            public string TableName { get; set; }
            public string ColumnName { get; set; }
            public string  ReferenceTableName { get; set; }
            public string ReferenceColumnName { get; set; }
        }

        public class ParameterExport
        {
            public List<string> lTables { get; set; }
            public TipoMotor TipoMotorExport { get; set; }
            public LenguajePuntoComa PuntoComa { get; set; }
            public string PathInicial { get; set; }
            public string Schema { get; set; }
            public string Base { get; set; }
            public string Server { get; set; }
            public string UserBase { get; set; }
            public string PassBase { get; set; }
            public bool IntegratedSecurity { get; set; }
            public int RowPerPage { get; set; }
        }


        #endregion

        public void CreateSP(List<string> Tables, string PathFile, bool List, bool Get = false, bool Find = false, bool Insert = false, bool Update = false, bool Delete = false) 
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder sbPreHeader = new StringBuilder();
            StringBuilder sbHeader = new StringBuilder();
            StringBuilder sbFooter = new StringBuilder();
            PackTableInfo oPack = new PackTableInfo();
            StringBuilder sbFile = new StringBuilder();

            sbHeader.AppendLine();
            sbHeader.AppendLine("AS");
            sbHeader.AppendLine("BEGIN");
            sbHeader.AppendLine("declare @MsgError varchar(100)");
            sbHeader.AppendLine();

            sbPreHeader.AppendLine("SET ANSI_NULLS ON");
            sbPreHeader.AppendLine("GO");
            sbPreHeader.AppendLine("SET QUOTED_IDENTIFIER ON");
            sbPreHeader.AppendLine("GO");
            sbPreHeader.AppendLine();

            sbHeader.AppendLine("BEGIN TRY");
            sbHeader.AppendLine("SET NOCOUNT ON; --No necesitamos pedirle al motor que cuente los registos.");
            sbHeader.AppendLine("SET ANSI_NULLS ON; --Habilitamos que interprete los NULLS ");
            sbHeader.AppendLine("SET QUOTED_IDENTIFIER ON; --Habilitamos Interpretacion de Comillas y comillas dobles validas");
            sbHeader.AppendLine("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED; --Necesitamos acceder a la info sin que este comiteada");
            sbHeader.AppendLine("SET ANSI_WARNINGS OFF; --no necesitamos que nos avice los warning, variables sin usar, etc...");
            sbHeader.AppendLine("SET Language Spanish --Seteamos la lengua independiente del server, asi aparece en espanol.");

            sbFooter.AppendLine();
            sbFooter.AppendLine("END try");
            sbFooter.AppendLine();

            sbFooter.AppendLine("BEGIN CATCH");
            sbFooter.AppendLine("set @MsgError = ERROR_NUMBER() + ERROR_MESSAGE() + ERROR_SEVERITY() + ERROR_STATE() + ERROR_PROCEDURE() + ERROR_LINE()");
            sbFooter.AppendLine("RAISERROR(@MsgError, 16, 1);");
            sbFooter.AppendLine("END CATCH;");
            sbFooter.AppendLine("END");
            
            oPack = GetTablesInfo(Tables);

            foreach (string sTable in Tables) 
            {
                int TableId = 0;
                string sColumPK = string.Empty;
                string sTypeColumPk = string.Empty;
                TableRelation oTableRelation = oPack.TableRelations.FirstOrDefault(x => x.TableName == sTable);
                TableId = oTableRelation.TableId;
                List<TableConstrainRelation> lTableConstrain = oPack.TableConstrainRelations.Where(x => x.TableId == TableId).ToList();
                List<TableColumn> lColumn = new List<TableColumn>();
                List<string> lTypeColumnWhere = new List<string>() { "nvarchar", "ntext", "varchar", "text", "char", "bit" };
                StringBuilder sbColums = new StringBuilder();
                StringBuilder sbColumAntiNull = new StringBuilder();

                StringBuilder sbJoin = new StringBuilder();
                StringBuilder sbColumsWithoutId = new StringBuilder();
                StringBuilder sbParam = new StringBuilder();
                StringBuilder sbParamFindWithoutId = new StringBuilder();
                StringBuilder sbParamInsertWithoutId = new StringBuilder();
                StringBuilder sbUpdate = new StringBuilder();
                StringBuilder sbFindWhere = new StringBuilder();
                StringBuilder sbInsert = new StringBuilder();
                bool isNeedNewLine = false;
                int iColumnWhereInsertedFind = 1;
                int iColumnWhereTotalFind = 0;

                string sCapitalLetter = string.Empty;
                lColumn = oPack.TableColumns.Where(x => x.TableId == TableId).ToList();
                sCapitalLetter = sTable.Substring(0, 1).ToLower();

                sbFindWhere.Append("( ");
                sbFindWhere.AppendLine();

                //intentamos obtener la cantidad de columnas del where
                var resultado = from p in oPack.TableColumns.Where(x => x.TableId == TableId)
                                join c in lTypeColumnWhere on p.ColumType equals c
                                select new { p.ColumnName, p.ColumType };
                iColumnWhereTotalFind = resultado.Distinct().ToList().Count();

                for (int i=0;i<lColumn.Count;i++)
                {
                       
                    if (lColumn[i].ColumnName == lColumn[i].NameColumnPK) 
                    {
                        sbColums.Append(sCapitalLetter);
                        sbColums.Append(".");
                        sbColums.Append("[");
                        sbColums.Append(lColumn[i].ColumnName);
                        sbColums.Append("]");

                        sbColumAntiNull.Append(sCapitalLetter);
                        sbColumAntiNull.Append(".");
                        sbColumAntiNull.Append("[");
                        sbColumAntiNull.Append(lColumn[i].ColumnName);
                        sbColumAntiNull.Append("]");

                        sbParam.Append("@");
                        sbParam.Append(lColumn[i].ColumnName);
                        sbParam.Append(" ");
                        sbParam.Append(lColumn[i].ColumType);

                        sColumPK = lColumn[i].ColumnName;
                        sTypeColumPk = lColumn[i].ColumType;
                        
                        if (i < lColumn.Count-1) 
                        {
                            sbColums.Append(",");
                            sbParam.Append(",");
                            sbColumAntiNull.Append(",");
                        }
                    }

                    if (lColumn[i].ColumnName != lColumn[i].NameColumnPK)
                    {
                        sbColums.Append(sCapitalLetter);
                        sbColums.Append(".");
                        sbColums.Append("[");
                        sbColums.Append(lColumn[i].ColumnName);
                        sbColums.Append("] ");

                        sbColumsWithoutId.Append(lColumn[i].ColumnName);

                        sbUpdate.Append(lColumn[i].ColumnName);
                        sbUpdate.Append(" = ");
                        sbUpdate.Append("@");
                        sbUpdate.Append(lColumn[i].ColumnName);

                        sbParam.Append("@");
                        sbParam.Append(lColumn[i].ColumnName);
                        sbParam.Append(" ");
                        sbParam.Append(lColumn[i].ColumType);

                        sbInsert.Append("@");
                        sbInsert.Append(lColumn[i].ColumnName);

                        switch (lColumn[i].ColumType)
                        {
                            case "nvarchar":
                            case "ntext":
                            case "varchar":
                            case "char":
                                iColumnWhereInsertedFind++;

                                sbFindWhere.Append("( ");

                                if (lColumn[i].AllowNull)
                                {
                                    sbFindWhere.Append("ISNULL(");
                                }

                                sbFindWhere.Append(sCapitalLetter);
                                sbFindWhere.Append(".");
                                sbFindWhere.Append("[");
                                sbFindWhere.Append(lColumn[i].ColumnName);
                                sbFindWhere.Append("] ");

                                if (lColumn[i].AllowNull)
                                {
                                    sbFindWhere.Append(",'') ");
                                }

                                sbFindWhere.Append("like '%' + ");
                                sbFindWhere.Append("@");
                                sbFindWhere.Append(lColumn[i].ColumnName);
                                sbFindWhere.Append(" + '%' ");
                                sbFindWhere.Append(" or ");
                                sbFindWhere.Append("@");
                                sbFindWhere.Append(lColumn[i].ColumnName);
                                sbFindWhere.Append(" = ");
                                sbFindWhere.Append(" '' ");
                                sbFindWhere.Append(" ) ");

                                sbParamFindWithoutId.Append("@");
                                sbParamFindWithoutId.Append(lColumn[i].ColumnName);
                                sbParamFindWithoutId.Append(" ");
                                sbParamFindWithoutId.Append(lColumn[i].ColumType);

                                sbParamInsertWithoutId.Append("@");
                                sbParamInsertWithoutId.Append(lColumn[i].ColumnName);
                                sbParamInsertWithoutId.Append(" ");
                                sbParamInsertWithoutId.Append(lColumn[i].ColumType);

                                sbParamInsertWithoutId.Append("(");
                                sbParamInsertWithoutId.Append(lColumn[i].ColumnLen);
                                sbParamInsertWithoutId.Append(")");

                                sbParamFindWithoutId.Append("(");
                                sbParamFindWithoutId.Append(lColumn[i].ColumnLen);
                                sbParamFindWithoutId.Append(")");
                                sbParamFindWithoutId.AppendLine();

                                sbParam.Append("(");
                                sbParam.Append(lColumn[i].ColumnLen);
                                sbParam.Append(")");

                                if (lColumn[i].AllowNull)
                                {
                                    sbColumAntiNull.Append("ISNULL(");
                                }

                                sbColumAntiNull.Append(sCapitalLetter);
                                sbColumAntiNull.Append(".");
                                sbColumAntiNull.Append("[");
                                sbColumAntiNull.Append(lColumn[i].ColumnName);
                                sbColumAntiNull.Append("] ");

                                if (lColumn[i].AllowNull)
                                {
                                    sbColumAntiNull.Append(",'') AS ");
                                    sbColumAntiNull.Append(lColumn[i].ColumnName);
                                    sbColumAntiNull.Append(SPACE);
                                }

                                break;
                            case "text":
                                iColumnWhereInsertedFind++;

                                sbFindWhere.Append("( ");

                                if (lColumn[i].AllowNull)
                                {
                                    sbFindWhere.Append("ISNULL(");
                                } 

                                sbFindWhere.Append(sCapitalLetter);
                                sbFindWhere.Append(".");
                                sbFindWhere.Append("[");
                                sbFindWhere.Append(lColumn[i].ColumnName);
                                sbFindWhere.Append("] ");
                                
                                if (lColumn[i].AllowNull)
                                {
                                    sbFindWhere.Append(",'') ");
                                }

                                sbFindWhere.Append("like '%' + ");
                                sbFindWhere.Append("@");
                                sbFindWhere.Append(lColumn[i].ColumnName);
                                sbFindWhere.Append(" + '%' ");
                                sbFindWhere.Append(" or ");
                                sbFindWhere.Append("@");
                                sbFindWhere.Append(lColumn[i].ColumnName);
                                sbFindWhere.Append(" = ");
                                sbFindWhere.Append(" '' ");
                                sbFindWhere.Append(" ) ");

                                sbParamFindWithoutId.Append("@");
                                sbParamFindWithoutId.Append(lColumn[i].ColumnName);
                                sbParamFindWithoutId.Append(" ");
                                sbParamFindWithoutId.Append(lColumn[i].ColumType);

                                sbParamInsertWithoutId.Append("@");
                                sbParamInsertWithoutId.Append(lColumn[i].ColumnName);
                                sbParamInsertWithoutId.Append(" ");
                                sbParamInsertWithoutId.Append(lColumn[i].ColumType);

                                sbParamFindWithoutId.AppendLine();

                                if (lColumn[i].AllowNull)
                                {
                                    sbColumAntiNull.Append("ISNULL(");
                                }

                                sbColumAntiNull.Append(sCapitalLetter);
                                sbColumAntiNull.Append(".");
                                sbColumAntiNull.Append("[");
                                sbColumAntiNull.Append(lColumn[i].ColumnName);
                                sbColumAntiNull.Append("] ");

                                if (lColumn[i].AllowNull)
                                {
                                    sbColumAntiNull.Append(",'') AS ");
                                    sbColumAntiNull.Append(lColumn[i].ColumnName);
                                    sbColumAntiNull.Append(SPACE);
                                }

                                break;
                            case "bigint":  
                            case "smallint":
                            case "int":
                            case "tinyint":
                                sbParamInsertWithoutId.Append("@");
                                sbParamInsertWithoutId.Append(lColumn[i].ColumnName);
                                sbParamInsertWithoutId.Append(" ");
                                sbParamInsertWithoutId.Append(lColumn[i].ColumType);

                                if (lColumn[i].AllowNull)
                                {
                                    sbColumAntiNull.Append("ISNULL(");
                                }

                                sbColumAntiNull.Append(sCapitalLetter);
                                sbColumAntiNull.Append(".");
                                sbColumAntiNull.Append("[");
                                sbColumAntiNull.Append(lColumn[i].ColumnName);
                                sbColumAntiNull.Append("] ");

                                if (lColumn[i].AllowNull)
                                {
                                    sbColumAntiNull.Append(",0) AS ");
                                    sbColumAntiNull.Append(lColumn[i].ColumnName);
                                    sbColumAntiNull.Append(SPACE);
                                }

                                break;
                            case "decimal":
                            case "smallmoney":
                            case "money":
                            case "numeric":
                            case "float":
                                sbParamInsertWithoutId.Append("@");
                                sbParamInsertWithoutId.Append(lColumn[i].ColumnName);
                                sbParamInsertWithoutId.Append(" ");
                                sbParamInsertWithoutId.Append(lColumn[i].ColumType);

                                sbColumAntiNull.Append(sCapitalLetter);
                                sbColumAntiNull.Append(".");
                                sbColumAntiNull.Append("[");
                                sbColumAntiNull.Append(lColumn[i].ColumnName);
                                sbColumAntiNull.Append("] ");

                                if (lColumn[i].AllowNull)
                                {
                                    sbColumAntiNull.Append("ISNULL(");
                                }

                                sbColumAntiNull.Append(sCapitalLetter);
                                sbColumAntiNull.Append(".");
                                sbColumAntiNull.Append("[");
                                sbColumAntiNull.Append(lColumn[i].ColumnName);
                                sbColumAntiNull.Append("] ");

                                if (lColumn[i].AllowNull)
                                {
                                    sbColumAntiNull.Append(",0) AS ");
                                    sbColumAntiNull.Append(lColumn[i].ColumnName);
                                    sbColumAntiNull.Append(SPACE);
                                }

                                break;
                            case "bit":
                                iColumnWhereInsertedFind++;
                                sbParamInsertWithoutId.Append("@");
                                sbParamInsertWithoutId.Append(lColumn[i].ColumnName);
                                sbParamInsertWithoutId.Append(" ");
                                sbParamInsertWithoutId.Append(lColumn[i].ColumType);
                                sbParamInsertWithoutId.Append(" = 0");

                                sbParamFindWithoutId.Append("@");
                                sbParamFindWithoutId.Append(lColumn[i].ColumnName);
                                sbParamFindWithoutId.Append(" ");
                                sbParamFindWithoutId.Append(lColumn[i].ColumType);
                                sbParamFindWithoutId.AppendLine();


                                sbFindWhere.Append("( ");

                                if (lColumn[i].AllowNull)
                                {
                                    sbFindWhere.Append("ISNULL(");
                                }

                                sbFindWhere.Append(sCapitalLetter);
                                sbFindWhere.Append(".");
                                sbFindWhere.Append("[");
                                sbFindWhere.Append(lColumn[i].ColumnName);
                                sbFindWhere.Append("] ");

                                if (lColumn[i].AllowNull)
                                {
                                    sbFindWhere.Append(",0) ");
                                }

                                sbFindWhere.Append(" = ");
                                sbFindWhere.Append("@");
                                sbFindWhere.Append(lColumn[i].ColumnName);
                                sbFindWhere.Append(" or ");
                                sbFindWhere.Append("@");
                                sbFindWhere.Append(lColumn[i].ColumnName);
                                sbFindWhere.Append(" = ");
                                sbFindWhere.Append(" 0 ");
                                sbFindWhere.Append(" ) ");

                                if (lColumn[i].AllowNull)
                                {
                                    sbColumAntiNull.Append("ISNULL(");
                                }

                                sbColumAntiNull.Append(sCapitalLetter);
                                sbColumAntiNull.Append(".");
                                sbColumAntiNull.Append("[");
                                sbColumAntiNull.Append(lColumn[i].ColumnName);
                                sbColumAntiNull.Append("] ");

                                if (lColumn[i].AllowNull)
                                {
                                    sbColumAntiNull.Append(",0) AS ");
                                    sbColumAntiNull.Append(lColumn[i].ColumnName);
                                    sbColumAntiNull.Append(SPACE);
                                }

                                break;
                            case "date":
                            case "datetimeoffset":
                            case "datetime2":
                            case "smalldatetime":
                            case "datetime":
                            case "time":
                                sbParamInsertWithoutId.Append("@");
                                sbParamInsertWithoutId.Append(lColumn[i].ColumnName);
                                sbParamInsertWithoutId.Append(" ");
                                sbParamInsertWithoutId.Append(lColumn[i].ColumType);

                                sbColumAntiNull.Append(sCapitalLetter);
                                sbColumAntiNull.Append(".");
                                sbColumAntiNull.Append("[");
                                sbColumAntiNull.Append(lColumn[i].ColumnName);
                                sbColumAntiNull.Append("] ");

                                break;
                            case "binary":
                            case "varbinary":
                            case "image":
                                break;
                        }

                        if (i < lColumn.Count -1 )
                        {
                            sbColums.Append(",");
                            sbColumAntiNull.Append(",");
                            sbColumsWithoutId.Append(",");
                            sbParam.Append(",");
                            sbUpdate.Append(",");
                            sbInsert.Append(",");
                            sbParamInsertWithoutId.Append(",");
                            isNeedNewLine = true;
                        }

                        if (iColumnWhereInsertedFind <= iColumnWhereTotalFind && lTypeColumnWhere.Where(x => x == lColumn[i].ColumType).ToList().Count > 0)
                        {
                            sbParamFindWithoutId.Append(',');
                            sbFindWhere.Append(" AND ");
                            sbFindWhere.AppendLine();
                        }
                    }

                    if (isNeedNewLine)
                    {
                        sbColums.AppendLine();
                        sbColumAntiNull.AppendLine();
                        sbParam.AppendLine();
                        sbUpdate.AppendLine();
                        sbParamInsertWithoutId.AppendLine();
                        isNeedNewLine = false;
                    }

                    if (i % 3 == 0) 
                    {
                        sbColumsWithoutId.AppendLine();
                        sbInsert.AppendLine();
                    }
                }

                sbFindWhere.AppendLine();
                sbFindWhere.Append(") ");

               if (List) 
                {
                    sb.Append(sbPreHeader.ToString());
                    
                    sb.Append("CREATE PROCEDURE [dbo].[");
                    sb.Append(sTable);
                    sb.Append("_List]");
                    sb.AppendLine(sbHeader.ToString());

                    sb.Append("Select");
                    sb.AppendLine();
                    sb.Append(sbColumAntiNull.ToString());
                    sb.AppendLine();
                    sb.Append(" FROM ");
                    sb.Append(sTable);
                    sb.Append(" ");
                    sb.Append(sCapitalLetter);
                    sb.Append(" (nolock)");
                    sb.AppendLine();
                    sb.Append(sbFooter.ToString());
                    sb.AppendLine();
                    sb.AppendLine();
                }

                if (Get)
                {
                    sb.Append(sbPreHeader.ToString());

                    sb.Append("CREATE PROCEDURE [dbo].[");
                    sb.Append(sTable);
                    sb.Append("_Get]");
                    sb.AppendLine();
                    sb.Append("@");
                    sb.Append(sColumPK);
                    sb.Append(" ");
                    sb.Append(sTypeColumPk);
                    sb.AppendLine();
                    sb.AppendLine(sbHeader.ToString());

                    sb.Append("SELECT TOP 1");
                    sb.AppendLine();
                    sb.Append(sbColumAntiNull.ToString());
                    sb.Append("FROM ");
                    sb.Append(sTable);
                    sb.Append(" ");
                    sb.Append(sCapitalLetter);
                    sb.AppendLine();
                    sb.Append("WHERE ");
                    sb.AppendLine();
                    sb.Append(sCapitalLetter);
                    sb.Append(".");
                    sb.Append(sColumPK);
                    sb.Append(" = ");
                    sb.Append("@");
                    sb.Append(sColumPK);
                    sb.AppendLine();

                    sb.Append(sbFooter.ToString());
                    sb.AppendLine();
                    sb.AppendLine();
                }

                if (Find && iColumnWhereTotalFind > 0) 
                {
                    sb.Append(sbPreHeader.ToString());
                    sb.Append("CREATE PROCEDURE [dbo].[");
                    sb.Append(sTable);
                    sb.Append("_Find]");
                    sb.AppendLine();
                    sb.Append(sbParamFindWithoutId.ToString());
                    sb.AppendLine(sbHeader.ToString());

                    sb.Append("SELECT");
                    sb.AppendLine();
                    sb.Append(sbColumAntiNull.ToString());
                    sb.Append(" FROM ");
                    sb.Append(sTable);
                    sb.Append(SPACE);
                    sb.Append(sCapitalLetter);
                    sb.Append(SPACE);
                    sb.AppendLine();
                    sb.AppendLine("WHERE ");
                    sb.Append(sbFindWhere.ToString());
                    sb.AppendLine();
                    sb.Append(sbFooter.ToString());
                    sb.AppendLine();
                }

                if (Insert)
                {
                    sb.Append(sbPreHeader.ToString());
                    sb.Append("CREATE PROCEDURE [dbo].[");
                    sb.Append(sTable);
                    sb.Append("_Insert]");
                    sb.AppendLine();
                    sb.Append(sbParamInsertWithoutId.ToString());
                    sb.AppendLine(sbHeader.ToString());

                    sb.Append("INSERT INTO ");
                    sb.Append(sTable);
                    sb.Append(" (");
                    sb.Append(sbColumsWithoutId.ToString());
                    sb.Append(")");
                    sb.Append(" VALUES");
                    sb.Append(" ( ");
                    sb.Append(sbInsert.ToString());
                    sb.Append(" ) ");
                    sb.AppendLine();
                    sb.Append(sbFooter.ToString());
                    sb.AppendLine();
                }

                if (Update) 
                {
                    sb.Append(sbPreHeader.ToString());
                    sb.Append("CREATE PROCEDURE [dbo].[");
                    sb.Append(sTable);
                    sb.Append("_Update] ");
                    sb.AppendLine();
                    sb.Append(sbParam.ToString());
                    sb.AppendLine(sbHeader.ToString());

                    sb.Append("UPDATE ");
                    sb.Append(sTable);
                    sb.Append(" SET");
                    sb.AppendLine();
                    sb.Append(sbUpdate.ToString());
                    sb.AppendLine();
                    sb.Append("WHERE ");
                    sb.AppendLine();
                    sb.Append(sColumPK);
                    sb.Append(" = ");
                    sb.Append("@");
                    sb.Append(sColumPK);
                    sb.AppendLine();

                    sb.Append(sbFooter.ToString());
                    sb.AppendLine();
                }

                if (Delete) 
                {
                    sb.Append(sbPreHeader.ToString());

                    sb.Append("CREATE PROCEDURE [dbo].[");
                    sb.Append(sTable);
                    sb.Append("_Delete]");
                    sb.AppendLine();
                    sb.Append("@");
                    sb.Append(sColumPK);
                    sb.Append(" ");
                    sb.Append(sTypeColumPk);
                    sb.AppendLine();
                    sb.AppendLine(sbHeader.ToString());

                    sb.Append("delete");
                    sb.Append(" from ");
                    sb.Append(sTable);
                    sb.Append(" ");
                    sb.AppendLine();
                    sb.Append("where ");
                    sb.AppendLine();
                    sb.Append(sColumPK);
                    sb.Append(" = ");
                    sb.Append("@");
                    sb.Append(sColumPK);
                    sb.AppendLine();

                    sb.Append(sbFooter.ToString());
                    sb.AppendLine();
                }
            }

            sbFile.Append(PathFile);
            sbFile.Append("sp_");
            sbFile.Append(DateTime.Now.Ticks.ToString());
            sbFile.Append(".sql");
            File.AppendAllText(sbFile.ToString(), sb.ToString(), Encoding.UTF8);
        }

        public void CreateClass(List<string> Tables, string PathFile, bool IncludePK , string NameSpace = "", string BaseClass = "")
        {
            PackTableInfo oPack = new PackTableInfo();
            StringBuilder sbNewPath = new StringBuilder();
            int TableId = 0;

            sbNewPath.Append(PathFile);
            sbNewPath.Append("Class_");
            sbNewPath.Append(DateTime.Now.Ticks.ToString());
            sbNewPath.Append(@"\");

            Directory.CreateDirectory(sbNewPath.ToString());
            
            oPack = GetTablesInfo(Tables);

            foreach (string sTable in Tables)
            {
                StringBuilder sb = new StringBuilder();
                StringBuilder sbFile = new StringBuilder();
                TableRelation oTableRelation = oPack.TableRelations.FirstOrDefault(x => x.TableName == sTable);
                TableId = oTableRelation.TableId;
                List<TableColumn> lColumn = new List<TableColumn>();
                lColumn = oPack.TableColumns.Where(x => x.TableId == TableId).ToList();

                sb.AppendLine();

                if (NameSpace.Length > 3) 
                {
                    sb.Append("namespace ");
                    sb.Append(NameSpace);
                    sb.Append(".Entity");
                    sb.AppendLine();
                    sb.Append("{");
                    sb.AppendLine();
                }

                sb.Append(TAB);
                sb.Append("public class ");
                sb.Append(sTable);

                if (BaseClass.Length > 0) 
                {
                    sb.Append(" : ");
                    sb.Append(BaseClass);
                }

                sb.AppendLine();
                sb.Append(TAB);
                sb.Append("{");
                sb.AppendLine();

                foreach (TableColumn oTableColum in lColumn)
                {
                    bool IsValidNull = false;

                    if (oTableColum.NameColumnPK == oTableColum.ColumnName && IncludePK == false ) 
                    {
                        continue;
                    }

                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("public ");

                    switch (oTableColum.ColumType) 
                    {
                        case "nvarchar":
                        case "ntext":
                        case "varchar":
                        case "text":
                        case "char":
                        case "xml":
                            sb.Append("string");
                            break;
                        case "bigint":
                        case "smallint":
                        case "int":
                        case "tinyint":
                            IsValidNull = true;
                            sb.Append("int");
                            break;
                        case "decimal":
                        case "smallmoney":
                        case "money":
                        case "numeric":
                        case "float":
                        case "geography":
                        case "geometry":
                        case "real":
                            IsValidNull = true;
                            sb.Append("decimal");
                            break;
                        case "bit":
                            IsValidNull = true;
                            sb.Append("bool");
                            break;
                        case "date":
                        case "datetimeoffset":
                        case "datetime2":
                        case "smalldatetime":
                        case "datetime":
                        case "time":
                            IsValidNull = true;
                            sb.Append("System.DateTime");
                            break;
                        case "binary":
                        case "varbinary":
                        case "image":
                            sb.Append("byte[]");
                            break;
                        default:
                            sb.Append("object");
                        break;
                    }

                    if (oTableColum.AllowNull && IsValidNull) 
                    {
                        sb.Append("?");
                    }

                    sb.Append(SPACE);
                    sb.Append(oTableColum.ColumnName);
                    sb.Append(SPACE);
                    sb.Append("{ get; set; }");
                    sb.AppendLine();
                }

                sb.Append(TAB);
                sb.Append("}");
                sb.AppendLine();

                if (NameSpace.Length > 3)
                {
                    sb.AppendLine();
                    sb.Append("}");
                }

                sbFile.Append(sbNewPath.ToString());
                sbFile.Append(sTable);
                sbFile.Append(".cs");
                File.AppendAllText(sbFile.ToString(), sb.ToString(), Encoding.UTF8);

            }
        }

        public void CreateDataLayerClass(List<string> Tables, string PathFile, string NameSpace = "", string BaseClass = "", bool List = false, bool Get = false, bool Find = false, bool Insert = false, bool Update = false, bool Delete = false) 
        {
            PackTableInfo oPack = new PackTableInfo();
            StringBuilder sbNewPath = new StringBuilder();
            int TableId = 0;

            sbNewPath.Append(PathFile);
            sbNewPath.Append("DataLayerClass_");
            sbNewPath.Append(DateTime.Now.Ticks.ToString());
            sbNewPath.Append(@"\");

            Directory.CreateDirectory(sbNewPath.ToString());

            oPack = GetTablesInfo(Tables);

            foreach (string sTable in Tables)
            {
                StringBuilder sb = new StringBuilder();
                StringBuilder sbTryCatch = new StringBuilder();
                StringBuilder sbFile = new StringBuilder();
                TableRelation oTableRelation = oPack.TableRelations.FirstOrDefault(x => x.TableName == sTable);
                TableId = oTableRelation.TableId;
                List<TableColumn> lColumn = new List<TableColumn>();
                lColumn = oPack.TableColumns.Where(x => x.TableId == TableId).ToList();

                sbTryCatch.Append(TAB);
                sbTryCatch.Append(TAB);
                sbTryCatch.Append("catch (Exception) ");
                sbTryCatch.AppendLine();
                sbTryCatch.Append(TAB);
                sbTryCatch.Append(TAB);
                sbTryCatch.Append("{");
                sbTryCatch.AppendLine();
                sbTryCatch.Append(TAB);
                sbTryCatch.Append(TAB);
                sbTryCatch.Append(TAB);
                sbTryCatch.Append("throw;");
                sbTryCatch.AppendLine();
                sbTryCatch.Append(TAB);
                sbTryCatch.Append(TAB);
                sbTryCatch.Append("}");
                sbTryCatch.AppendLine();

                sb.Append("using System.Collections.Generic;");
                sb.AppendLine();
                sb.Append("using System;");
                sb.AppendLine();
                sb.Append("using ");
                sb.Append(NameSpace);
                sb.Append(".Entity;");
                sb.AppendLine();

                if (NameSpace.Length > 3)
                {
                    sb.AppendLine();
                    sb.Append("namespace ");
                    sb.Append(NameSpace);
                    sb.Append(".Data");
                    sb.AppendLine();
                    sb.Append("{");
                    sb.AppendLine();
                }

                sb.AppendLine();
                sb.Append(TAB);
                sb.Append("public class ");
                sb.Append(sTable);
                sb.Append("Data");
                sb.AppendLine();
                sb.Append(TAB);
                sb.Append("{");
                sb.AppendLine();
                sb.AppendLine();
                sb.Append(TAB);
                sb.Append(TAB);
                sb.Append("private readonly string _ConnectionString = string.Empty;");
                sb.AppendLine();
                sb.AppendLine();
                sb.AppendLine();
                sb.Append(TAB);
                sb.Append(TAB);
                sb.Append("public ");
                sb.Append(sTable);
                sb.Append("Data ");
                sb.Append("(string ConnectionString)");
                sb.AppendLine();
                sb.Append(TAB);
                sb.Append(TAB);
                sb.Append("{");
                sb.AppendLine();
                sb.Append(TAB);
                sb.Append(TAB);
                sb.Append(TAB);
                sb.Append("_ConnectionString = ConnectionString;");
                sb.AppendLine();
                sb.Append(TAB);
                sb.Append(TAB);
                sb.Append("}");
                sb.AppendLine();
                sb.AppendLine();

                if (List)
                {
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("public List<");
                    sb.Append(sTable);
                    sb.Append("> ");
                    sb.Append("List() ");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("{");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("IRepository<");
                    sb.Append(sTable);
                    sb.Append("> ");
                    sb.Append(sTable);
                    sb.Append("Repository; ");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("List<");
                    sb.Append(sTable);
                    sb.Append(">");
                    sb.Append(SPACE);
                    sb.Append("l");
                    sb.Append(sTable);
                    sb.Append(";");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("try ");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("{");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append(sTable);
                    sb.Append("Repository ");
                    sb.Append(" = new ContextSQL<");
                    sb.Append(sTable);
                    sb.Append(">(_ConnectionString);");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("l");
                    sb.Append(sTable);
                    sb.Append(" = ");
                    sb.Append(sTable);
                    sb.Append("Repository.List(); ");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("}");
                    sb.AppendLine();
                    sb.Append(sbTryCatch.ToString());
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("return ");
                    sb.Append("l");
                    sb.Append(sTable);
                    sb.Append(";");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("}");
                    sb.AppendLine();
                    sb.AppendLine();
                    sb.AppendLine();
                }

                if (Find)
                {
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("public List<dynamic> Find (");
                    sb.Append(sTable);
                    sb.Append(SPACE);
                    sb.Append(sTable.ToLower());
                    sb.Append(")");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("{");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("List<dynamic> ldynamic;");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("IRepository<");
                    sb.Append(sTable);
                    sb.Append("> ");
                    sb.Append(sTable);
                    sb.Append("Repository; ");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("try");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("{");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append(sTable);
                    sb.Append("Repository ");
                    sb.Append("= new ContextSQL<");
                    sb.Append(sTable);
                    sb.Append(">(_ConnectionString);");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("ldynamic");
                    sb.Append(" = ");
                    sb.Append(sTable);
                    sb.Append("Repository.Find(");
                    sb.Append(sTable.ToLower());
                    sb.Append(");");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("}");
                    sb.AppendLine();
                    sb.Append(sbTryCatch.ToString());
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("return ldynamic;");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("}");
                    sb.AppendLine();
                    sb.AppendLine();
                    sb.AppendLine();
                }

                if (Get)
                {
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("public ");
                    sb.Append(sTable);
                    sb.Append(" Get(int Id) ");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("{");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("IRepository<");
                    sb.Append(sTable);
                    sb.Append("> ");
                    sb.Append(sTable);
                    sb.Append("Repository;");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append(sTable);
                    sb.Append(SPACE);
                    sb.Append("o");
                    sb.Append(sTable);
                    sb.Append(";");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("try");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("{");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append(sTable);
                    sb.Append("Repository = new ContextSQL<");
                    sb.Append(sTable);
                    sb.Append(">(_ConnectionString);");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("o");
                    sb.Append(sTable);
                    sb.Append(" = ");
                    sb.Append(sTable);
                    sb.Append("Repository.Get(Id);");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("}");
                    sb.AppendLine();
                    sb.Append(sbTryCatch.ToString());
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("return ");
                    sb.Append("o");
                    sb.Append(sTable);
                    sb.Append(";");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("}");
                    sb.AppendLine();
                    sb.AppendLine();
                    sb.AppendLine();
                }

                if (Update)
                {
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("public void Update(");
                    sb.Append(sTable);
                    sb.Append(SPACE);
                    sb.Append(sTable.ToLower());
                    sb.Append(")");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("{");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("IRepository<");
                    sb.Append(sTable);
                    sb.Append("> ");
                    sb.Append(sTable);
                    sb.Append("Repository;");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("try");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("{");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append(sTable);
                    sb.Append("Repository = new ContextSQL<");
                    sb.Append(sTable);
                    sb.Append(">(_ConnectionString);");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append(sTable);
                    sb.Append("Repository.Update(");
                    sb.Append(sTable.ToLower());
                    sb.Append("); ");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("}");
                    sb.AppendLine();
                    sb.Append(sbTryCatch.ToString());
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("}");
                    sb.AppendLine();
                    sb.AppendLine();
                    sb.AppendLine();
                }

                if (Insert)
                {
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("public void Insert(");
                    sb.Append(sTable);
                    sb.Append(SPACE);
                    sb.Append(sTable.ToLower());
                    sb.Append(")");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("{");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("IRepository<");
                    sb.Append(sTable);
                    sb.Append("> ");
                    sb.Append(sTable);
                    sb.Append("Repository;");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("try");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("{");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append(sTable);
                    sb.Append("Repository = new ContextSQL<");
                    sb.Append(sTable);
                    sb.Append(">(_ConnectionString);");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append(sTable);
                    sb.Append("Repository.Insert(");
                    sb.Append(sTable.ToLower());
                    sb.Append(");");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("}");
                    sb.AppendLine();
                    sb.Append(sbTryCatch.ToString());
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("}");
                    sb.AppendLine();
                    sb.AppendLine();
                    sb.AppendLine();
                }

                if (Delete)
                {
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("public void Delete(int Id)");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("{");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("IRepository<");
                    sb.Append(sTable);
                    sb.Append("> ");
                    sb.Append(sTable);
                    sb.Append("Repository;");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("try");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("{");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append(sTable);
                    sb.Append("Repository = new ContextSQL<");
                    sb.Append(sTable);
                    sb.Append(">(_ConnectionString);");
                    sb.Append(sTable);
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append(sTable);
                    sb.Append("Repository.Delete(Id);");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("}");
                    sb.AppendLine();
                    sb.Append(sbTryCatch.ToString());
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("}");
                    sb.AppendLine();
                    sb.AppendLine();
                    sb.AppendLine();
                }

                sb.Append(TAB);
                sb.Append("}");
                sb.AppendLine();

                if (NameSpace.Length > 3)
                {
                    sb.AppendLine();
                    sb.Append("}");
                }

                sbFile.Append(sbNewPath.ToString());
                sbFile.Append(sTable);
                sbFile.Append("Data");
                sbFile.Append(".cs");
                File.AppendAllText(sbFile.ToString(), sb.ToString(), Encoding.UTF8);
            }
            MessageBox.Show("Se creo la capa de datos correctamente ", "");
        }

        public void CreateBizLayerClass(List<string> Tables, string PathFile, string NameSpace = "", string BaseClass = "", bool List = false, bool Get = false, bool Find = false, bool Insert = false, bool Update = false, bool Delete = false)
        {
            PackTableInfo oPack = new PackTableInfo();
            StringBuilder sbNewPath = new StringBuilder();
            int TableId = 0;

            sbNewPath.Append(PathFile);
            sbNewPath.Append("BizLayerClass_");
            sbNewPath.Append(DateTime.Now.Ticks.ToString());
            sbNewPath.Append(@"\");

            Directory.CreateDirectory(sbNewPath.ToString());

            oPack = GetTablesInfo(Tables);

            foreach (string sTable in Tables)
            {
                StringBuilder sb = new StringBuilder();
                StringBuilder sbTryCatch = new StringBuilder();
                StringBuilder sbDeclaracionData = new StringBuilder();

                StringBuilder sbFile = new StringBuilder();
                TableRelation oTableRelation = oPack.TableRelations.FirstOrDefault(x => x.TableName == sTable);
                TableId = oTableRelation.TableId;
                List<TableColumn> lColumn = new List<TableColumn>();
                lColumn = oPack.TableColumns.Where(x => x.TableId == TableId).ToList();

                sbTryCatch.Append(TAB);
                sbTryCatch.Append(TAB);
                sbTryCatch.Append("catch (Exception) ");
                sbTryCatch.AppendLine();
                sbTryCatch.Append(TAB);
                sbTryCatch.Append(TAB);
                sbTryCatch.Append("{");
                sbTryCatch.AppendLine();
                sbTryCatch.Append(TAB);
                sbTryCatch.Append(TAB);
                sbTryCatch.Append(TAB);
                sbTryCatch.Append("throw;");
                sbTryCatch.AppendLine();
                sbTryCatch.Append(TAB);
                sbTryCatch.Append(TAB);
                sbTryCatch.Append("}");
                sbTryCatch.AppendLine();

                sbDeclaracionData.Append(TAB);
                sbDeclaracionData.Append(TAB);
                sbDeclaracionData.Append(sTable);
                sbDeclaracionData.Append("Data ");
                sbDeclaracionData.Append("o");
                sbDeclaracionData.Append(sTable);
                sbDeclaracionData.Append("Data");
                sbDeclaracionData.Append(" = new ");
                sbDeclaracionData.Append(sTable);
                sbDeclaracionData.Append("Data(_ConnectionString); ");
                sbDeclaracionData.AppendLine();

                sb.Append("using System.Collections.Generic;");
                sb.AppendLine();
                sb.Append("using System;");
                
                sb.AppendLine();
                sb.Append("using ");
                sb.Append(NameSpace);
                sb.Append(".Entity;");
                
                sb.AppendLine();
                sb.Append("using ");
                sb.Append(NameSpace);
                sb.Append(".Data;");
                sb.AppendLine();

                if (NameSpace.Length > 3)
                {
                    sb.AppendLine();
                    sb.Append("namespace ");
                    sb.Append(NameSpace);
                    sb.Append(".Biz");
                    sb.AppendLine();
                    sb.Append("{");
                    sb.AppendLine();
                }

                sb.AppendLine();
                sb.Append(TAB);
                sb.Append("public class ");
                sb.Append(sTable);
                sb.Append("Biz");
                sb.AppendLine();
                sb.Append(TAB);
                sb.Append("{");
                sb.AppendLine();
                sb.AppendLine();
                sb.Append(TAB);
                sb.Append(TAB);
                sb.Append("private readonly string _ConnectionString = string.Empty;");
                sb.AppendLine();
                sb.AppendLine();
                sb.AppendLine();
                sb.Append(TAB);
                sb.Append(TAB);
                sb.Append("public ");
                sb.Append(sTable);
                sb.Append("Biz ");
                sb.Append("(string ConnectionString)");
                sb.AppendLine();
                sb.Append(TAB);
                sb.Append(TAB);
                sb.Append("{");
                sb.AppendLine();
                sb.Append(TAB);
                sb.Append(TAB);
                sb.Append(TAB);
                sb.Append("_ConnectionString = ConnectionString;");
                sb.AppendLine();
                sb.Append(TAB);
                sb.Append(TAB);
                sb.Append("}");
                sb.AppendLine();
                sb.AppendLine();

                if (List)
                {
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("public List<");
                    sb.Append(sTable);
                    sb.Append("> ");
                    sb.Append("List() ");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("{");
                    sb.AppendLine();
                    sb.Append(sbDeclaracionData.ToString());
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("List<");
                    sb.Append(sTable);
                    sb.Append("> l");
                    sb.Append(sTable);
                    sb.Append(";");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("try ");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("{");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("l");
                    sb.Append(sTable);
                    sb.Append(" = ");
                    sb.Append("o");
                    sb.Append(sTable);
                    sb.Append("Data.List();");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("}");
                    sb.AppendLine();
                    sb.Append(sbTryCatch.ToString());
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("return ");
                    sb.Append("l");
                    sb.Append(sTable);
                    sb.Append(";");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("}");
                    sb.AppendLine();
                    sb.AppendLine();
                    sb.AppendLine();
                }

                if (Find)
                {
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("public List<dynamic> Find (");
                    sb.Append(sTable);
                    sb.Append(SPACE);
                    sb.Append(sTable.ToLower());
                    sb.Append(")");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("{");
                    sb.AppendLine();
                    sb.Append(sbDeclaracionData.ToString());
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("List<dynamic> ldynamic;");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("try");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("{");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("ldynamic");
                    sb.Append(" = ");
                    sb.Append("o");
                    sb.Append(sTable);
                    sb.Append("Data.Find(");
                    sb.Append(sTable.ToLower());
                    sb.Append(");");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("}");
                    sb.AppendLine();
                    sb.Append(sbTryCatch.ToString());
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("return ldynamic;");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("}");
                    sb.AppendLine();
                    sb.AppendLine();
                    sb.AppendLine();
                }

                if (Get)
                {
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("public ");
                    sb.Append(sTable);
                    sb.Append(" Get(int Id) ");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("{");
                    sb.AppendLine();
                    sb.Append(sbDeclaracionData.ToString());
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append(sTable);
                    sb.Append(" o");
                    sb.Append(sTable);
                    sb.Append(";");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("try");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("{");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("o");
                    sb.Append(sTable);
                    sb.Append(" = ");
                    sb.Append("o");
                    sb.Append(sTable);
                    sb.Append("Data.Get(Id);");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("}");
                    sb.AppendLine();
                    sb.Append(sbTryCatch.ToString());
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("return ");
                    sb.Append("o");
                    sb.Append(sTable);
                    sb.Append(";");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("}");
                    sb.AppendLine();
                    sb.AppendLine();
                    sb.AppendLine();
                }

                if (Update)
                {
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("public void Update(");
                    sb.Append(sTable);
                    sb.Append(SPACE);
                    sb.Append(sTable.ToLower());
                    sb.Append(")");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("{");
                    sb.AppendLine();
                    sb.Append(sbDeclaracionData.ToString());
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("try");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("{");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("o");
                    sb.Append(sTable);
                    sb.Append("Data.Update(");
                    sb.Append(sTable.ToLower());
                    sb.Append("); ");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("}");
                    sb.AppendLine();
                    sb.Append(sbTryCatch.ToString());
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("}");
                    sb.AppendLine();
                    sb.AppendLine();
                    sb.AppendLine();
                }

                if (Insert)
                {
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("public void Insert(");
                    sb.Append(sTable);
                    sb.Append(SPACE);
                    sb.Append(sTable.ToLower());
                    sb.Append(")");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("{");
                    sb.AppendLine();
                    sb.Append(sbDeclaracionData.ToString());
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("try");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("{");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("o");
                    sb.Append(sTable);
                    sb.Append("Data.Insert(");
                    sb.Append(sTable.ToLower());
                    sb.Append(");");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("}");
                    sb.AppendLine();
                    sb.Append(sbTryCatch.ToString());
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("}");
                    sb.AppendLine();
                    sb.AppendLine();
                    sb.AppendLine();
                }

                if (Delete)
                {
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("public void Delete(int Id)");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("{");
                    sb.AppendLine();
                    sb.Append(sbDeclaracionData.ToString());
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("try");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("{");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("o");
                    sb.Append(sTable);
                    sb.Append("Data.Delete(Id);");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("}");
                    sb.AppendLine();
                    sb.Append(sbTryCatch.ToString());
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("}");
                    sb.AppendLine();
                    sb.AppendLine();
                    sb.AppendLine();
                }

                sb.Append(TAB);
                sb.Append("}");
                sb.AppendLine();

                if (NameSpace.Length > 3)
                {
                    sb.AppendLine();
                    sb.Append("}");
                }

                sbFile.Append(sbNewPath.ToString());
                sbFile.Append(sTable);
                sbFile.Append("Biz");
                sbFile.Append(".cs");
                File.AppendAllText(sbFile.ToString(), sb.ToString(), Encoding.UTF8);
            }
            MessageBox.Show("Se creo la capa de Biz correctamente ", "");

        }

        public void CreateControllerClass(List<string> Tables, string PathFile, string NameSpace = "", string BaseClass = "", bool List = false, bool Get = false, bool Find = false, bool Insert = false, bool Update = false, bool Delete = false)
        {
            PackTableInfo oPack = new PackTableInfo();
            StringBuilder sbNewPath = new StringBuilder();
            StringBuilder sbTryCatch = new StringBuilder();

            int TableId = 0;

            sbNewPath.Append(PathFile);
            sbNewPath.Append("ControllerClass_");
            sbNewPath.Append(DateTime.Now.Ticks.ToString());
            sbNewPath.Append(@"\");

            Directory.CreateDirectory(sbNewPath.ToString());

            oPack = GetTablesInfo(Tables);

            sbTryCatch.Append(TAB);
            sbTryCatch.Append(TAB);
            sbTryCatch.Append("catch (WebException ex) ");
            sbTryCatch.AppendLine();
            sbTryCatch.Append(TAB);
            sbTryCatch.Append(TAB);
            sbTryCatch.Append("{");
            sbTryCatch.AppendLine();
            sbTryCatch.Append(TAB);
            sbTryCatch.Append(TAB);
            sbTryCatch.Append(TAB);
            sbTryCatch.Append("_logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);");
            sbTryCatch.AppendLine();
            sbTryCatch.Append(TAB);
            sbTryCatch.Append(TAB);
            sbTryCatch.Append(TAB);
            sbTryCatch.Append("return ValidationProblem(");
            sbTryCatch.Append(COMILLADOBLE);
            sbTryCatch.Append("Error");
            sbTryCatch.Append(COMILLADOBLE);
            sbTryCatch.Append(", ");
            sbTryCatch.Append(COMILLADOBLE);
            sbTryCatch.Append("Get");
            sbTryCatch.Append(COMILLADOBLE);
            sbTryCatch.Append(", 500, ex.Message);");
            sbTryCatch.AppendLine();
            sbTryCatch.Append(TAB);
            sbTryCatch.Append(TAB);
            sbTryCatch.Append("}");
            sbTryCatch.AppendLine();
            sbTryCatch.Append(TAB);
            sbTryCatch.Append(TAB);
            sbTryCatch.Append("catch (Exception ex)");
            sbTryCatch.AppendLine();
            sbTryCatch.Append(TAB);
            sbTryCatch.Append(TAB);
            sbTryCatch.Append("{");
            sbTryCatch.AppendLine();
            sbTryCatch.Append(TAB);
            sbTryCatch.Append(TAB);
            sbTryCatch.Append(TAB);
            sbTryCatch.Append("_logger.LogError(ex.Message, ex.InnerException, ex.StackTrace);");
            sbTryCatch.AppendLine();
            sbTryCatch.Append(TAB);
            sbTryCatch.Append(TAB);
            sbTryCatch.Append(TAB);
            sbTryCatch.Append("return ValidationProblem(");
            sbTryCatch.Append(COMILLADOBLE);
            sbTryCatch.Append("Error");
            sbTryCatch.Append(COMILLADOBLE);
            sbTryCatch.Append(", ");
            sbTryCatch.Append(COMILLADOBLE);
            sbTryCatch.Append("Get ");
            sbTryCatch.Append(COMILLADOBLE);
            sbTryCatch.Append(", 500, ex.Message);");
            sbTryCatch.AppendLine();
            sbTryCatch.Append(TAB);
            sbTryCatch.Append(TAB);
            sbTryCatch.Append("}");
            sbTryCatch.AppendLine();


            foreach (string sTable in Tables)
            {
                StringBuilder sb = new StringBuilder();
                StringBuilder sbDeclaracionBiz = new StringBuilder();
                StringBuilder sbFile = new StringBuilder();
                TableRelation oTableRelation = oPack.TableRelations.FirstOrDefault(x => x.TableName == sTable);
                TableId = oTableRelation.TableId;
                List<TableColumn> lColumn = new List<TableColumn>();

                lColumn = oPack.TableColumns.Where(x => x.TableId == TableId).ToList();

                sbDeclaracionBiz.Append(TAB);
                sbDeclaracionBiz.Append(TAB);
                sbDeclaracionBiz.Append(sTable);
                sbDeclaracionBiz.Append("Biz ");
                sbDeclaracionBiz.Append("o");
                sbDeclaracionBiz.Append(sTable);
                sbDeclaracionBiz.Append("Biz");
                sbDeclaracionBiz.Append(" = new ");
                sbDeclaracionBiz.Append(sTable);
                sbDeclaracionBiz.Append("Biz(_ConectionString); ");
                sbDeclaracionBiz.AppendLine();


                sb.Append("using System.Collections.Generic;");
                sb.AppendLine();
                sb.Append("using Microsoft.AspNetCore.Authorization;");
                sb.AppendLine();
                sb.Append("using Microsoft.AspNetCore.Mvc;");
                sb.AppendLine();
                sb.Append("using System.Net;");
                sb.AppendLine();
                sb.Append("using Microsoft.Extensions.Configuration;");
                sb.AppendLine();
                sb.Append("using Microsoft.Extensions.Logging;");
                sb.AppendLine();
                sb.Append("using System;");

                sb.AppendLine();
                sb.Append("using ");
                sb.Append(NameSpace);
                sb.Append(".Entity;");

                sb.AppendLine();
                sb.Append("using ");
                sb.Append(NameSpace);
                sb.Append(".Biz;");
                sb.AppendLine();

                if (NameSpace.Length > 3)
                {
                    sb.AppendLine();
                    sb.Append("namespace ");
                    sb.Append(NameSpace);
                    sb.Append(".Controllers");
                    sb.AppendLine();
                    sb.Append("{");
                    sb.AppendLine();
                }

                sb.Append(TAB);
                sb.Append("[ApiController]");
                sb.AppendLine();
                sb.Append(TAB);
                sb.Append("[Route(");
                sb.Append(COMILLADOBLE);
                sb.Append("api/[controller]");
                sb.Append(COMILLADOBLE);
                sb.Append(")]");
                sb.AppendLine();
                sb.Append(TAB);
                sb.Append("public class ");
                sb.Append(sTable);
                sb.Append("Controller");
                sb.Append(" : Controller ");
                sb.AppendLine();
                sb.Append(TAB);
                sb.Append("{");
                sb.AppendLine();
                sb.Append(TAB);
                sb.Append(TAB);
                sb.Append("private readonly ILogger<");
                sb.Append(sTable);
                sb.Append("Controller");
                sb.Append("> _logger;");
                sb.AppendLine();

                sb.Append(TAB);
                sb.Append(TAB);
                sb.Append("private readonly IConfiguration _configuration;");
                sb.AppendLine();

                sb.Append(TAB);
                sb.Append(TAB);
                sb.Append("private readonly string _ConectionString;");
                sb.AppendLine();

                sb.AppendLine();
                sb.AppendLine();
                sb.Append(TAB);
                sb.Append(TAB);
                sb.Append("public ");
                sb.Append(sTable);
                sb.Append("Controller(ILogger<");
                sb.Append(sTable);
                sb.Append("Controller");
                sb.Append("> logger, IConfiguration configuration)");
                sb.AppendLine();
                sb.Append(TAB);
                sb.Append(TAB);
                sb.Append("{");
                sb.AppendLine();

                sb.Append(TAB);
                sb.Append(TAB);
                sb.Append(TAB);
                sb.Append("_logger = logger;");
                sb.AppendLine();

                sb.Append(TAB);
                sb.Append(TAB);
                sb.Append(TAB);
                sb.Append("_configuration = configuration;");
                sb.AppendLine();

                sb.Append(TAB);
                sb.Append(TAB);
                sb.Append(TAB);
                sb.Append("_ConectionString = _configuration.GetConnectionString(");
                sb.Append(COMILLADOBLE);
                sb.Append("DefaultConnection");
                sb.Append(COMILLADOBLE);
                sb.Append(");");
                sb.AppendLine();

                sb.Append(TAB);
                sb.Append(TAB);
                sb.Append("}");
                sb.AppendLine();
                sb.AppendLine();

                if (List)
                {
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("/// <summary>");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("/// Lista ");
                    sb.Append(sTable);
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("/// </summary>");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("/// <returns>");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("/// devuelve la lista de ");
                    sb.Append(sTable);
                    sb.Append(". generalmente usado para combos y lugares donde no necesitarias un filtro");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("/// </returns>");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("[HttpGet(");
                    sb.Append(COMILLADOBLE);
                    sb.Append("List");
                    sb.Append(COMILLADOBLE);
                    sb.Append(")]");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("[AllowAnonymous]");
                    sb.AppendLine();

                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("public ActionResult List()");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("{");
                    sb.AppendLine();
                    sb.Append(sbDeclaracionBiz.ToString());
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("List<");
                    sb.Append(sTable);
                    sb.Append("> l");
                    sb.Append(sTable);
                    sb.Append(";");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("try ");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("{");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("l");
                    sb.Append(sTable);
                    sb.Append(" = ");
                    sb.Append("o");
                    sb.Append(sTable);
                    sb.Append("Biz.List();");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("}");
                    sb.AppendLine();
                    sb.Append(sbTryCatch.ToString());
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("return Ok(new {  ");
                    sb.Append("list");
                    sb.Append(sTable.ToLower() );
                    sb.Append(" = ");
                    sb.Append("l");
                    sb.Append(sTable);
                    sb.Append(" }); //OK 200);");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("}");
                    sb.AppendLine();
                    sb.AppendLine();
                    sb.AppendLine();
                }

                if (Find)
                {
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("/// <summary>");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("/// Busca un ");
                    sb.Append(sTable);
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("/// </summary>");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("/// <param name=");
                    sb.Append(COMILLADOBLE);
                    sb.Append(sTable.ToLower());
                    sb.Append(COMILLADOBLE);
                    sb.Append(">");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("/// ");
                    sb.Append("Esta entidad permite filtrar de manera sensilla por todos los campos que contiene");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("/// ");
                    sb.Append("Los valores que son filtrables son de tipo string, ");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("/// </param>");
                    sb.AppendLine();

                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("/// <returns>");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("/// devuelve una lista dinamica de los valores obtenidos en la base de datos, puede alterar los valores sin problemas");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("/// o bien crear una entidad que sea exactamente igual a los valores que desea devolver y convertir la lista dinamica por lista de DTOs");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("/// </returns>");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("[HttpGet(");
                    sb.Append(COMILLADOBLE);
                    sb.Append("Find");
                    sb.Append(COMILLADOBLE);
                    sb.Append(")]");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("[AllowAnonymous]");
                    sb.AppendLine();

                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("public ActionResult Find (");
                    sb.Append("[FromBody] ");
                    sb.Append(sTable);
                    sb.Append(SPACE);
                    sb.Append(sTable.ToLower());
                    sb.Append(")");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("{");
                    sb.AppendLine();
                    sb.Append(sbDeclaracionBiz.ToString());
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("List<dynamic> ldynamic;");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("try");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("{");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("ldynamic");
                    sb.Append(" = ");
                    sb.Append("o");
                    sb.Append(sTable);
                    sb.Append("Biz.Find(");
                    sb.Append(sTable.ToLower());
                    sb.Append(");");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("}");
                    sb.AppendLine();
                    sb.Append(sbTryCatch.ToString());
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("return Ok(new {  list");
                    sb.Append(sTable.ToLower());
                    sb.Append(" = ldynamic");
                    sb.Append("}); //OK 200);"); 
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("}");
                    sb.AppendLine();
                    sb.AppendLine();
                    sb.AppendLine();
                }

                if (Get)
                {
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("/// <summary>");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("/// Devuelve un ");
                    sb.Append(sTable);
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("/// </summary>");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("/// <param name=");
                    sb.Append(COMILLADOBLE);
                    sb.Append("Id");
                    sb.Append(COMILLADOBLE);
                    sb.Append(">");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("/// ");
                    sb.Append("El Id es la clave unica PK de la entidad ");
                    sb.Append(sTable);
                    sb.Append(".");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("/// </param>");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("/// <returns>");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("/// devuelve un objeto unico del tipo ");
                    sb.Append(sTable);
                    sb.Append(" .");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("/// </returns>");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("[HttpGet(");
                    sb.Append(COMILLADOBLE);
                    sb.Append("Get");
                    sb.Append(COMILLADOBLE);
                    sb.Append(")]");
                    sb.AppendLine();

                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("[AllowAnonymous]");
                    sb.AppendLine();

                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("public ActionResult");
                    sb.Append(" Get(int Id) ");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("{");
                    sb.AppendLine();
                    sb.Append(sbDeclaracionBiz.ToString());
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append(sTable);
                    sb.Append(" o");
                    sb.Append(sTable);
                    sb.Append(" = new ");
                    sb.Append(sTable);
                    sb.Append("();");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("try");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("{");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("o");
                    sb.Append(sTable);
                    sb.Append(" = ");
                    sb.Append("o");
                    sb.Append(sTable);
                    sb.Append("Biz.Get(Id);");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("}");
                    sb.AppendLine();
                    sb.Append(sbTryCatch.ToString());
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("return Ok(new {  ");
                    sb.Append(sTable.ToLower());
                    sb.Append(" = o");
                    sb.Append(sTable);
                    sb.Append("}); //OK 200);");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("}");
                    sb.AppendLine();
                    sb.AppendLine();
                    sb.AppendLine();
                }

                if (Update)
                {
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("/// <summary>");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("/// Actualiza ");
                    sb.Append(sTable);
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("/// </summary>");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("/// <param name=");
                    sb.Append(COMILLADOBLE);
                    sb.Append(sTable.ToLower());
                    sb.Append(COMILLADOBLE);
                    sb.Append(">");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("/// ");
                    sb.Append("Esta entidad permite actualizar todos los valores de la tabla ");
                    sb.Append(sTable);
                    sb.Append(".");

                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("/// </param>");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("/// <returns>");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("/// devuelve Status: 200 en caso de haber actualizado correctamente ");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("/// </returns>");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("[HttpPut(");
                    sb.Append(COMILLADOBLE);
                    sb.Append("Update");
                    sb.Append(COMILLADOBLE);
                    sb.Append(")]");
                    sb.AppendLine();

                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("[AllowAnonymous]");
                    sb.AppendLine();

                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("public ActionResult Update(");
                    sb.Append("[FromBody] ");
                    sb.Append(sTable);
                    sb.Append(SPACE);
                    sb.Append(sTable.ToLower());
                    sb.Append(")");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("{");
                    sb.AppendLine();
                    sb.Append(sbDeclaracionBiz.ToString());
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("try");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("{");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("o");
                    sb.Append(sTable);
                    sb.Append("Biz.Update(");
                    sb.Append(sTable.ToLower());
                    sb.Append("); ");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("}");
                    sb.AppendLine();
                    sb.Append(sbTryCatch.ToString());

                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("return Ok(); //OK 200");
                    sb.AppendLine();

                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("}");
                    sb.AppendLine();
                    sb.AppendLine();
                    sb.AppendLine();
                }

                if (Insert)
                {
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("/// <summary>");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("/// Inserta ");
                    sb.Append(sTable);
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("/// </summary>");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("/// <param name=");
                    sb.Append(COMILLADOBLE);
                    sb.Append(sTable.ToLower());
                    sb.Append(COMILLADOBLE);
                    sb.Append(">");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("/// ");
                    sb.Append("Inserta todos los campos de la entidad ");
                    sb.Append(sTable);
                    sb.Append(".");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("/// </param>");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("/// <returns>");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("/// devuelve un status: 201 si inserto correctamente ");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("/// </returns>");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("[HttpPost(");
                    sb.Append(COMILLADOBLE);
                    sb.Append("Insert");
                    sb.Append(COMILLADOBLE);
                    sb.Append(")]");
                    sb.AppendLine();

                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("[AllowAnonymous]");
                    sb.AppendLine();

                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("public ActionResult Insert(");
                    sb.Append("[FromBody] ");
                    sb.Append(sTable);
                    sb.Append(SPACE);
                    sb.Append(sTable.ToLower());
                    sb.Append(")");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("{");
                    sb.AppendLine();
                    sb.Append(sbDeclaracionBiz.ToString());
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("try");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("{");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("o");
                    sb.Append(sTable);
                    sb.Append("Biz.Insert(");
                    sb.Append(sTable.ToLower());
                    sb.Append(");");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("}");
                    sb.AppendLine();
                    sb.Append(sbTryCatch.ToString());
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("return Created(); //OK 201");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("}");
                    sb.AppendLine();
                    sb.AppendLine();
                    sb.AppendLine();
                }

                if (Delete)
                {
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("/// <summary>");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("/// Insert  ");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("/// </summary>");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("/// <param name=");
                    sb.Append(COMILLADOBLE);
                    sb.Append("Id");
                    sb.Append(COMILLADOBLE);
                    sb.Append(">");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("/// ");
                    sb.Append("El Id es la clave unica PK de la entidad ");
                    sb.Append(sTable);
                    sb.Append(".");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("/// </param>");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("/// <returns>");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("/// devuelve Status: 200 en caso de haber eliminado correctamente ");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("/// </returns>");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("[HttpDelete(");
                    sb.Append(COMILLADOBLE);
                    sb.Append("Delete");
                    sb.Append(COMILLADOBLE);
                    sb.Append(")]");
                    sb.AppendLine();

                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("[AllowAnonymous]");
                    sb.AppendLine();

                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("public ActionResult Delete(int Id)");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("{");
                    sb.AppendLine();
                    sb.Append(sbDeclaracionBiz.ToString());
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("try");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("{");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("o");
                    sb.Append(sTable);
                    sb.Append("Biz.Delete(Id);");
                    sb.AppendLine();
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("}");
                    sb.AppendLine();
                    sb.Append(sbTryCatch.ToString());
                    
                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("return Ok(); //OK 200");
                    sb.AppendLine();

                    sb.Append(TAB);
                    sb.Append(TAB);
                    sb.Append("}");
                    sb.AppendLine();
                    sb.AppendLine();
                    sb.AppendLine();
                }

                sb.Append(TAB);
                sb.Append("}");
                sb.AppendLine();

                if (NameSpace.Length > 3)
                {
                    sb.AppendLine();
                    sb.Append("}");
                }

                sbFile.Append(sbNewPath.ToString());
                sbFile.Append(sTable);
                sbFile.Append("Controller");
                sbFile.Append(".cs");
                File.AppendAllText(sbFile.ToString(), sb.ToString(), Encoding.UTF8);
            }
            MessageBox.Show("Se creo la capa de Controller correctamente ", "");

        }















    }
}


