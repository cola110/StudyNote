using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace T4
{
    public class SqlAid
    {
        #region 参数转换成sql
        /// <summary>参数转换成sql变量申明,主要是调试和记录日志用</summary>
        //public static string SqlParameterWrapperToString(SqlParameterWrapperCollection pars)
        //{
        //    StringBuilder declare = new StringBuilder();
        //    foreach (var par in pars)
        //    {
        //        string suffix = "";
        //        if (par.Parameter.SqlDbType == SqlDbType.NVarChar || par.Parameter.SqlDbType == SqlDbType.VarChar)
        //            suffix = "(" + par.Parameter.Value.ToString().Length * 2 + ")";
        //        declare.AppendLine("declare @" + par.Parameter.ParameterName.TrimStart('@') + " " +
        //                           par.Parameter.SqlDbType + suffix + " ='"
        //                           + par.Parameter.Value + "';");
        //    }
        //    return declare.ToString();
        //}
        ///// <summary>参数转换成sql变量申明,主要是调试和记录日志用</summary>
        //public static string SqlParameterWrapperToString(DbParameterCollection pars)
        //{
        //    StringBuilder declare = new StringBuilder();
        //    foreach (SqlParameter par in pars)
        //    {
        //        string suffix = "";
        //        if (par.SqlDbType == SqlDbType.NVarChar || par.SqlDbType == SqlDbType.VarChar)
        //            suffix = "(" + par.Value.ToString().Length * 2 + ")";
        //        declare.AppendLine("declare @" + par.ParameterName.TrimStart('@') + " " + par.SqlDbType + suffix + " ='"
        //                           + par.Value + "';");
        //    }
        //    return declare.ToString();
        //}

        /// <summary>参数转换成sql变量申明,主要是调试和记录日志用</summary>
        public static string SqlParameterWrapperToString(List<SqlParameter> parList)
        {
            StringBuilder declare = new StringBuilder();
            foreach (SqlParameter par in parList)
            {
                string suffix = "";
                if (par.SqlDbType == SqlDbType.NVarChar || par.SqlDbType == SqlDbType.VarChar)
                    suffix = "(" + par.Value.ToString().Length * 2 + ")";
                declare.AppendLine("declare @" + par.ParameterName.TrimStart('@') + " " + par.SqlDbType + suffix + " ='"
                                   + par.Value + "';");
            }
            return declare.ToString();
        }
        #endregion

        #region GetWhereSql

        /// <summary>根据页面传值生成查询语句的where部分及需要的参数</summary>
        /// <param name="nameValues">页面请求参数集合</param>
        public static Tuple<string, List<SqlParameter>>
            GetWhereSql<T>(NameValueCollection nameValues) where T : class,ITableBase<T>, new()
        {
            T tempT = new T();
            string whereSql = "";
            List<SqlParameter> pars = new List<SqlParameter>();
            foreach (string key in nameValues.Keys)
            {
                if (string.IsNullOrEmpty(key)) continue;
                string keyValue = nameValues[key];
                if (keyValue.Length <= 0) continue;
                WhereField fieldOb = new WhereField(key);
                Type valueType;
                tempT.GetFieldNames().TryGetValue(fieldOb.Field, out valueType);
                if (valueType == null) continue;
                object parValue;
                string inValue = "";
                try
                {
                    if (valueType == typeof(string))
                        parValue = keyValue;
                    else if (valueType == typeof(bool) && keyValue.Length == 1)
                        parValue = keyValue == "1";
                    else if (keyValue.IndexOf(",") > 0)
                    {
                        parValue = true;
                        foreach (var splitValue in keyValue.Split(','))
                            inValue += ",'" + Convert.ChangeType(splitValue, valueType) + "'";
                    }
                    else
                        parValue = Convert.ChangeType(keyValue, valueType);
                }
                catch
                {
                    continue;
                }
                if (parValue == null) continue;
                if (valueType != typeof(string))
                {
                    if (keyValue.IndexOf(",") > 0)
                        whereSql += " and " + fieldOb.Prefix + fieldOb.Field + " in(" + inValue.TrimStart(',') + ")";
                    else
                    {
                        whereSql += " and " + fieldOb.Prefix + fieldOb.Field + " " + fieldOb.Operators + "@" + fieldOb.Field + fieldOb.Suffix;
                        pars.Add(new SqlParameter(fieldOb.Field + fieldOb.Suffix, parValue));
                    }
                }
                else if (keyValue.IndexOf("%") >= 0)
                {
                    whereSql += " and " + fieldOb.Prefix + fieldOb.Field + " like @" + fieldOb.Field;
                    pars.Add(new SqlParameter(fieldOb.Field + fieldOb.Suffix, parValue));
                }
                else
                {
                    whereSql += " and " + fieldOb.Prefix + fieldOb.Field + "=@" + fieldOb.Field;
                    pars.Add(new SqlParameter(fieldOb.Field + fieldOb.Suffix, parValue));
                }
            }
            return new Tuple<string, List<SqlParameter>>(whereSql, pars);
        }
        #endregion

        #region GetUpdateSql
        /// <summary>生成update语句,与默认值不同的进行更新</summary>
        public static Tuple<string, List<SqlParameter>>
            GetUpdateSql<T>(T model) where T : class, ITableBase<T>, new()
        {
            T tempT = new T();
            var newPars = model.ToSqlParameters(false);
            StringBuilder sqlStr = new StringBuilder("UPDATE " + tempT.GetTableName() + " set ");
            List<SqlParameter> parList = new List<SqlParameter>();
            foreach (var newpar in newPars)
            {
                sqlStr.Append(newpar.ParameterName.TrimStart('@') + "=" + newpar.ParameterName + ",");
                parList.Add(newpar);
            }
            Dictionary<string, object> pkValues = model.GetPkValues();
            string whereSql = "";
            foreach (var pkValue in pkValues)
            {
                whereSql += " and " + pkValue.Key + "=@" + pkValue.Key;
                parList.Add(new SqlParameter("@" + pkValue.Key, pkValue.Value));
            }
            return new Tuple<string, List<SqlParameter>>(sqlStr.ToString().TrimEnd(',')
                + " where 1=1 " + whereSql, parList);
        }
        /// <summary>生成update语句,与默认值不同的进行更新</summary>
        public static Tuple<string, List<SqlParameter>>
            GetUpdateSqlFromDefault<T>(T model, List<string> mustUpdate) where T : class, ITableBase<T>, new()
        {
            T tempT = new T();
            var oldPars = tempT.ToSqlParameters(false).ToDictionary(z => z.ParameterName);
            var newPars = model.ToSqlParameters(false);
            StringBuilder sqlStr = new StringBuilder("UPDATE " + tempT.GetDbName() + ".dbo." + tempT.GetTableName() + " set ");
            List<SqlParameter> parList = new List<SqlParameter>();
            Dictionary<string, object> pkValues = model.GetPkValues();
            foreach (var newpar in newPars)
            {
                SqlParameter oldpar;
                string colName = newpar.ParameterName.TrimStart('@');
                if (!oldPars.TryGetValue(newpar.ParameterName, out oldpar) || newpar.Value == null
                    || pkValues.ContainsKey(colName))
                    continue;
                if (mustUpdate.Contains(colName)
                    || oldpar.Value.ToString() != newpar.Value.ToString()
                    || oldpar.Value is bool
                    || (newpar.Value is DateTime && ((DateTime)newpar.Value).Year > 1900))
                {
                    sqlStr.Append(colName + "=" + newpar.ParameterName + ",");
                    parList.Add(newpar);
                }
            }
            string whereSql = "";
            foreach (var pkValue in pkValues)
            {
                whereSql += " and " + pkValue.Key + "=@" + pkValue.Key;
                parList.Add(new SqlParameter("@" + pkValue.Key, pkValue.Value));
            }
            return new Tuple<string, List<SqlParameter>>(sqlStr.ToString().TrimEnd(',')
                + " where 1=1 " + whereSql, parList);
        }
        /// <summary>生成update语句,不更新指定字段</summary>
        public static Tuple<string, List<SqlParameter>>
            GetUpdateSql<T>(T model, List<string> notUpdate) where T : class, ITableBase<T>, new()
        {
            var newPars = model.ToSqlParameters(false);
            Dictionary<string, object> pkValues = model.GetPkValues();
            StringBuilder sqlStr = new StringBuilder("UPDATE " + model.GetDbName() + ".dbo." + model.GetTableName() + " set ");
            List<SqlParameter> parList = new List<SqlParameter>();
            foreach (var newpar in newPars)
            {
                string colName = newpar.ParameterName.TrimStart('@');
                if (notUpdate.Contains(colName) || pkValues.ContainsKey(colName)) continue;
                sqlStr.Append(colName + "=" + newpar.ParameterName + ",");
                parList.Add(newpar);
            }
            string whereSql = "";
            foreach (var pkValue in pkValues)
            {
                whereSql += " and " + pkValue.Key + "=@" + pkValue.Key;
                parList.Add(new SqlParameter("@" + pkValue.Key, pkValue.Value));
            }
            return new Tuple<string, List<SqlParameter>>(sqlStr.ToString().TrimEnd(',')
                + " where 1=1 " + whereSql, parList);
        }
        /// <summary>生成update语句,根据集合</summary>
        public static Tuple<string, List<SqlParameter>>
            GetUpdateSql<T>(NameValueCollection nameValues) where T : class, ITableBase<T>, new()
        {
            T tempT = new T();
            Dictionary<string, object> pkValues = tempT.GetPkValues();
            StringBuilder sqlStr = new StringBuilder("UPDATE " + tempT.GetDbName() + ".dbo." + tempT.GetTableName() + " set ");
            List<SqlParameter> parList = new List<SqlParameter>();
            foreach (string key in nameValues.Keys)
            {
                if (key.Length <= 0) continue;
                string keyValue = nameValues[key];
                if (keyValue == null) continue;
                Type valueType;
                if (!tempT.GetFieldNames().TryGetValue(key, out valueType)
                    || pkValues.ContainsKey(key)) continue;
                if (valueType != typeof(string) && keyValue.Length <= 0) continue;//非字符型,为空时,不更新
                object parValue = Convert.ChangeType(keyValue, valueType);
                if (parValue == null) continue;
                if (key != tempT.GetPkName())
                    sqlStr.Append(key + "=@" + key + ",");
                parList.Add(new SqlParameter(key, parValue));
            }
            string whereSql = "";
            foreach (var pkValue in pkValues)
            {
                whereSql += " and " + pkValue.Key + "=@" + pkValue.Key;
                Type valueType;
                tempT.GetFieldNames().TryGetValue(pkValue.Key, out valueType);
                object parValue = Convert.ChangeType(nameValues[pkValue.Key], valueType);
                if (parValue == null) throw new Exception("没有找到主键" + pkValue.Key + "对应的值");
                parList.Add(new SqlParameter("@" + pkValue.Key, parValue));
            }
            return new Tuple<string, List<SqlParameter>>(sqlStr.ToString().TrimEnd(',')
                + " where 1=1 " + whereSql, parList);
        }
        #endregion

        #region GetPageSql
        /// <summary>
        /// 根据sql语句,生成分页语句
        /// </summary>
        /// <param name="mailSql"></param>
        /// <param name="dp"></param>
        /// <returns></returns>
        public static Tuple<string, List<SqlParameter>> GetPageSql(string mailSql, DataPage dp = null)
        {
            string pageSql = "";
            List<SqlParameter> parList = new List<SqlParameter>();
            if (dp == null || dp.PageSize == 0) return new Tuple<string, List<SqlParameter>>(mailSql, parList);
            int fromIndex = mailSql.IndexOf(" from ", StringComparison.CurrentCultureIgnoreCase);
            if (fromIndex > 0)
            {
                string fieldSql = mailSql.Substring(0, fromIndex + 5);
                string whereSql = mailSql.Substring(fromIndex + 5);
                pageSql = fieldSql + "(select ROW_NUMBER() over(order by " + dp.OrderField + ") as RowID,"
                    + fieldSql.Substring(6) + whereSql
                    + ") tempT where RowID BETWEEN (@PageIndex - 1) * @PageSize+1 AND @PageIndex * @PageSize ;"
                    + "select count(1) from " + whereSql;
            }
            parList.Add(new SqlParameter("@" + DataPage.PageSizeField, dp.PageSize));
            parList.Add(new SqlParameter("@" + DataPage.PageIndexField, dp.PageIndex));
            return new Tuple<string, List<SqlParameter>>(pageSql, parList);
        }
        #endregion

        static readonly Regex SqlParameterRegex = new Regex(@"@\w+", RegexOptions.Compiled);//sql语句里的参数
        /// <summary>获取sql里的参数列表</summary>
        /// <param name="sql">是分析的sql</param>
        public static List<string> GetSqlParametersList(string sql)
        {
            List<string> sqlHaveParameters = new List<string>();
            MatchCollection sqlParameters = SqlParameterRegex.Matches(sql);
            foreach (Match par in sqlParameters)
            {
                sqlHaveParameters.Add(par.Value.TrimStart('@'));
            }
            return sqlHaveParameters;
        }
        public static Dictionary<string, int> GetColNameIndex(IDataRecord dataRecord)
        {
            Dictionary<string, int> colName = new Dictionary<string, int>();
            for (int i = 0; i < dataRecord.FieldCount; i++)
                colName.Add(dataRecord.GetName(i), i);
            return colName;
        }
        public static Dictionary<string, int> GetColNameIndex(DataRow dr)
        {
            Dictionary<string, int> colName = new Dictionary<string, int>();
            for (int i = 0; i < dr.Table.Columns.Count; i++)
                colName.Add(dr.Table.Columns[i].ColumnName, i);
            return colName;
        }
    }


    /// <summary>对where里的字段名进行处理</summary>
    public class WhereField
    {
        /// <summary>输入值:如ct.CityType></summary>
        public WhereField(string field)
        {
            _field = field;
            string[] fields = field.Split('.');
            if (fields.Length > 1)
            {
                _prefix = fields[0] + ".";
                _field = fields[1];
            }
            if (_field[_field.Length - 2] < 'A')
            {
                _Operators = _field.Substring(_field.Length - 2);
                _field = _field.Substring(0, _field.Length - 2);
                _Suffix = ((int)_Operators[0]).ToString();
            }
            else if (_field[_field.Length - 1] < 'A')
            {
                _Operators = _field.Substring(_field.Length - 1);
                _field = _field.Substring(0, _field.Length - 1);
                _Suffix = ((int)_Operators[0]).ToString();
            }
        }

        private string _prefix = "";
        /// <summary>前缀ct.</summary>
        public string Prefix
        {
            get { return _prefix; }
        }
        private string _field;
        /// <summary>字段名CityType</summary>
        public string Field
        {
            get { return _field; }
        }
        private string _Operators = "=";
        /// <summary>操作符></summary>
        public string Operators
        {
            get { return _Operators; }
        }

        private string _Suffix = "";
        /// <summary>后缀转换成Char,解决同参数不同条件问题</summary>
        public string Suffix
        {
            get { return _Suffix; }
        }
    }
}
