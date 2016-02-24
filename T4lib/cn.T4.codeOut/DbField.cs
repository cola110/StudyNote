using MetaDataV2;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace cn.T4.codeOut
{
    public class DbField : T4Base
    {
        static readonly Regex NotWordRegex = new Regex(@"\W", RegexOptions.Compiled | RegexOptions.IgnoreCase);//非字符分隔
        public DbField(string templateFilePath, string ConnectionName = "MetaDataDB") : base(templateFilePath, ConnectionName) { }
        ///<summary>构建表元信息</summary>
        public void BuildTableAbout(StringBuilder outStr, TableObject table, FieldObject pkField)
        {
            string Identity = "00000000";
            var field = table.Columns.FirstOrDefault(z => z.IsIdentity);
            if (field != null) Identity = field.ColumnName;
            List<string> FieldAll = new List<string>();
            string updateSql = "";
            string fieldAndTypeStr = "";
            string fieldAndNoteStr = "";
            foreach (FieldObject field1 in table.Columns)
            {
                if (!field1.isPK) updateSql += field1.ColumnName + "=@" + field1.ColumnName + ",";
                FieldAll.Add(field1.ColumnName);
                fieldAndTypeStr += "{ \"" + field1.ColumnName + "\", typeof(" + field1.TypeNameCs + ") },";
                fieldAndNoteStr += "{ \"" + field1.ColumnName + "\", \""
                    + NotWordRegex.Split(myDb.GetFieldNote(field1.ColumnName).Trim())[0] + "\"},";
            }
            outStr.AppendLine(_Indent + "#region  " + table.name + "表元信息");
            outStr.AppendLine(_Indent + "public const string dbName = \"" + myDb.DbName + "\";//库名");
            outStr.AppendLine(_Indent + "public const string tableName = \"" + table.name + "\";//表名");
            outStr.AppendLine(_Indent + "public const string pkName = \"" + pkField.ColumnName + "\";//主键名");

            if (table.type.Trim() == "V") //如果是视图
            {
                string viewSql = "";
                DataSet ds = ExeSqlDataSet("sp_helptext  " + table.name);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 2)
                    for (int i = 2; i < ds.Tables[0].Rows.Count; i++)
                        viewSql += " " + ds.Tables[0].Rows[i][0].ToString().Trim().Replace("  ", " ");
                outStr.AppendLine(_Indent + "public const string insertSql = @\"\";");
                outStr.AppendLine(_Indent + "public const string selectSql = @\"" + viewSql.Trim() + " where 1 = 1 \";");
                outStr.AppendLine(_Indent + "public const string deleteSql = @\"\";");
            }
            else
            {
                outStr.AppendLine(_Indent + "public const string insertSql = @\"Insert Into \" + dbName + \".dbo." + table.name + " ("
                + (" " + string.Join(",", FieldAll.ToArray())).Replace(" " + Identity + ",", "").Trim() + ")values(@"
                + (" " + string.Join(",@", FieldAll.ToArray())).Replace(" " + Identity + ",@", "").Trim() + ");\";");
                outStr.AppendLine(_Indent + "public const string selectSql = @\"select " +
                                  string.Join(",", FieldAll.ToArray())
                                  + " from \" + dbName + \".dbo." + table.name + " with(nolock) where 1 = 1 \";");
                outStr.AppendLine(_Indent + "public const string deleteSql = @\"delete from  \" + dbName + \".dbo."
                + table.name + " where " + pkField.ColumnName + " = @" + pkField.ColumnName + ";\";");
            }
            //outStr.AppendLine(_Indent + "public const string updateSQL = @\"update  \" + dbName + \".dbo." + table.name + " set " +
            //     updateSql.TrimEnd(',') + "where " + pkField.ColumnName + " = @" + pkField.ColumnName + ";\";");
            //outStr.AppendLine(_Indent + "");
            outStr.AppendLine(_Indent + "public static readonly Dictionary<string,Type> fieldNames;//字段");
            outStr.AppendLine(_Indent + "public static readonly Dictionary<string, string> fieldNotes;//字备注");
            outStr.AppendLine(_Indent + "static " + table.name + "()");
            outStr.AppendLine(_Indent + "{");
            outStr.AppendLine(_Indent + "   fieldNames = new Dictionary<string,Type> {" + fieldAndTypeStr.TrimEnd(',') + "};");
            outStr.AppendLine(_Indent + "   fieldNotes = new Dictionary<string,string> {" + fieldAndNoteStr.TrimEnd(',') + "};");
            outStr.AppendLine(_Indent + "}");
            outStr.AppendLine(_Indent + "/// <summary>库名</summary>");
            outStr.AppendLine(_Indent + "public string GetDbName() { return dbName;}");
            outStr.AppendLine(_Indent + "/// <summary>表名</summary>");
            outStr.AppendLine(_Indent + "public string GetTableName() { return tableName;}");
            outStr.AppendLine(_Indent + "/// <summary>主键名</summary>");
            outStr.AppendLine(_Indent + "public string GetPkName() { return pkName;}");
            outStr.AppendLine(_Indent + "/// <summary>插入Sql</summary>");
            outStr.AppendLine(_Indent + "public string GetInsertSql(){return insertSql;}");
            outStr.AppendLine(_Indent + "/// <summary>查询Sql</summary>");
            outStr.AppendLine(_Indent + "public string GetSelectSql(){return selectSql;}");
            //outStr.AppendLine(_Indent + "/// <summary>修改Sql</summary>");
            //outStr.AppendLine(_Indent + "public string GetUpdateSQL { get { return updateSQL; } }");
            outStr.AppendLine(_Indent + "/// <summary>删除Sql</summary>");
            outStr.AppendLine(_Indent + "public string GetDeleteSql(){return deleteSql;}");
            outStr.AppendLine(_Indent + "/// <summary>字段名集合</summary>");
            outStr.AppendLine(_Indent + "public Dictionary<string,Type> GetFieldNames() { return fieldNames;}");
            outStr.AppendLine(_Indent + "/// <summary>字段名集合</summary>");
            outStr.AppendLine(_Indent + "public Dictionary<string,string> GetFieldNotes() { return fieldNotes;}");
            outStr.AppendLine(_Indent + "#endregion");
        }

        ///<summary>构建默认值</summary>
        public void BuildDefaultValue(StringBuilder outStr, TableObject table, FieldObject pkField)
        {
            outStr.AppendLine(_Indent + "#region  " + table.name + "默认值");
            outStr.AppendLine(_Indent + "public " + table.name + "()");
            outStr.AppendLine(_Indent + "{");
            outStr.AppendLine(_Indent + "\tSetDefaultValue();");
            outStr.AppendLine(_Indent + "}");
            outStr.AppendLine(_Indent + "public void SetDefaultValue()");
            outStr.AppendLine(_Indent + "{");
            PushIndent("\t");
            foreach (FieldObject field1 in table.Columns)
            {
                string dVal = field1.defaultVal.Replace("(", "").Replace(")", "").Trim('\'');
                switch (field1.TypeNameCs)
                {
                    case "string":
                        outStr.AppendLine(_Indent + "if (" + field1.ColumnName + " == null)"
                            + field1.ColumnName + " = \"" + dVal + "\";");
                        break;
                    case "byte":
                    case "decimal":
                    case "int":
                    case "short":
                        {
                            decimal val;
                            decimal.TryParse(dVal, out val);
                            if (val > 0)
                            {
                                outStr.AppendLine(_Indent + "if (" + field1.ColumnName + " == 0)"
                                                           + field1.ColumnName + " = " + dVal + ";");
                            }
                            else if ((dVal == "" || dVal == "0" || dVal == null) && !field1.isPK)
                            {
                                outStr.AppendLine(_Indent + "if (" + field1.ColumnName + " == 0)"
                                                           + field1.ColumnName + " = " + 0 + ";");
                            }
                        }
                        break;
                    case "DateTime":
                        {
                            if (dVal.Contains("getdate"))
                            {
                                outStr.AppendLine(_Indent + "if (" + field1.ColumnName + ".Year<1900)"
                                                  + field1.ColumnName + " = DateTime.Now;");
                                continue;
                            }
                            DateTime datetime;
                            DateTime.TryParse(dVal, out datetime);
                            if (datetime.Year >= 1900)
                            {
                                outStr.AppendLine(_Indent + "if (" + field1.ColumnName + ".Year<1900)" +
                                    field1.ColumnName + " = new DateTime(" + datetime.Year + "," +
                                    datetime.Month + "," + datetime.Day + ");");
                            }
                            else if (dVal == "")
                            {
                                outStr.AppendLine(_Indent + "if (" + field1.ColumnName + ".Year<1900)" +
                                field1.ColumnName + " = new DateTime(1900, 1, 1);");
                            }
                        }
                        break;
                    case "bool":
                        break;
                    default:
                        if (dVal.Length > 0)
                            outStr.AppendLine(_Indent + "if (" + field1.ColumnName + " == null)" + field1.ColumnName + " = " + dVal + ";");
                        break;
                }
            }
            PopIndent();
            outStr.AppendLine(_Indent + "}");
            outStr.AppendLine(_Indent + "#endregion");
        }

        ///<summary>构建属性</summary>
        public void BuildProperty(StringBuilder outStr, TableObject table, FieldObject pkField)
        {
            outStr.AppendLine(_Indent + "#region  " + table.name + "属性" + table.Columns.Count());
            foreach (FieldObject field1 in table.Columns)
            {
                field1.deText = field1.deText.Replace("\r", "").Replace("\n", "");
                if (field1.deText.Trim().Length > 0)
                    outStr.AppendLine(_Indent + "///<summary>" + field1.deText.Trim() + "," + field1.TypeNameCs + field1.Length + "</summary>");
                else
                    outStr.AppendLine(_Indent + "///<summary>" + myDb.GetFieldNote(field1.ColumnName).Trim() + ","
                     + field1.TypeNameCs + field1.Length + "</summary>");
                outStr.AppendLine(_Indent + "public " + field1.TypeNameCs + " " + field1.ColumnName + "{ get; set; }");
            }
            outStr.AppendLine(_Indent + "#endregion");
        }
        ///<summary>构建SqlParameters</summary>
        public void BuildSqlParameters(StringBuilder outStr, TableObject table, FieldObject pkField)
        {
            //outStr.AppendLine(_Indent + "");
            outStr.AppendLine(_Indent + "/// <summary>主键" + pkField.TypeNameCs + "</summary>");
            outStr.AppendLine(_Indent + "public object PkValue { get { return " + pkField.ColumnName + "; } set { if (value is "
                + pkField.TypeNameCs + ")" + pkField.ColumnName + " = (" + pkField.TypeNameCs + ")value; } } ");
            //主键集合
            outStr.AppendLine(_Indent + "/// <summary>得到主键集合</summary>");
            outStr.AppendLine(_Indent + "public Dictionary<string, object> GetPkValues()");
            outStr.AppendLine(_Indent + "{");
            outStr.AppendLine(_Indent + "    Dictionary<string, object> pkValues = new Dictionary<string, object>();");
            foreach (FieldObject field in table.Columns)
                if (field.isPK)
                {
                    outStr.AppendLine(_Indent + "    pkValues.Add(\"" + field.ColumnName + "\", " + field.ColumnName + ");");
                }
            outStr.AppendLine(_Indent + "    return pkValues;");
            outStr.AppendLine(_Indent + "}");
            //实体到参数
            outStr.AppendLine(_Indent + "///<summary>实体到参数</summary>");
            outStr.AppendLine(_Indent + "/// <param name=\"haveDentity\">是否包含自增长列</param>");
            outStr.AppendLine(_Indent + "public List<SqlParameter> ToSqlParameters(bool haveDentity=true)");
            outStr.AppendLine(_Indent + "{");
            PushIndent("\t");
            outStr.AppendLine(_Indent + "List<SqlParameter> parameterList = new List<SqlParameter>();");
            foreach (FieldObject field in table.Columns)
            {
                outStr.Append(_Indent);
                if (field.IsIdentity) outStr.Append("if (haveDentity) ");
                outStr.AppendLine("parameterList.Add(new SqlParameter(\"@" + field.ColumnName + "\", " + field.ColumnName + "));");
            }
            outStr.AppendLine(_Indent + "return parameterList;");
            PopIndent();
            outStr.AppendLine(_Indent + "}");
            //分析sql添加参数
            outStr.AppendLine(_Indent + "///<summary>分析sql添加参数</summary>");
            outStr.AppendLine(_Indent + "/// <param name=\"sql\">要添加参数的sql</param>");
            outStr.AppendLine(_Indent + "public List<SqlParameter> ToSqlParameters(string sql)");
            outStr.AppendLine(_Indent + "{");
            PushIndent("\t");
            outStr.AppendLine(_Indent + "List<SqlParameter> parameterList = new List<SqlParameter>();");
            outStr.AppendLine(_Indent + "List<string> sqlHaveParameters =SqlAid.GetSqlParametersList(sql);");
            foreach (FieldObject field in table.Columns)
            {
                outStr.AppendLine(_Indent + "if (sqlHaveParameters.Contains(\"" + field.ColumnName
                    + "\")) parameterList.Add(new SqlParameter(\"@" + field.ColumnName + "\", " + field.ColumnName + "));");
            }
            outStr.AppendLine(_Indent + "return parameterList;");
            PopIndent();
            outStr.AppendLine(_Indent + "}");
        }
        ///<summary>构建ToJosn</summary>
        public void BuildToJosn(StringBuilder outStr, TableObject table)
        {
            outStr.AppendLine(_Indent + "///<summary>返回对象Josn字串</summary>");
            outStr.AppendLine(_Indent + "public string ToJosn()");
            outStr.AppendLine(_Indent + "{");
            outStr.AppendLine(_Indent + "	return \"{\\\"TableName\\\":\\\"" + table.name + "\\\"\"");
            foreach (FieldObject field in table.Columns)
                outStr.AppendLine(_Indent + "		+\",\\\"" + field.ColumnName + "\\\":\\\"\"+" + field.ColumnName + "+\"\\\"\"");
            outStr.AppendLine(_Indent + "		+\"}\";");
            outStr.AppendLine(_Indent + "}");
        }
        ///<summary>构建IDataRecord填充实体</summary>
        public void BuildDataRecord(StringBuilder outStr, TableObject table)
        {
            outStr.AppendLine(_Indent + "///<summary>IDataRecord填充实体,返回自己</summary>");
            outStr.AppendLine(_Indent + "///<param name=\"colName\">列名的列次序，可调用GetColNameIndex获得</param>");
            outStr.AppendLine(_Indent + "public " + table.name + " BuildEntity(IDataRecord dataRecord,Dictionary<string,int> colName)");// override
            outStr.AppendLine(_Indent + "{");
            foreach (FieldObject field in table.Columns)
            {
                if (field.isNull || field.defaultVal.Length == 0)
                    outStr.AppendLine(_Indent + "	if (colName.ContainsKey(\"" + field.ColumnName + "\")&&!dataRecord.IsDBNull(colName[\""
                    + field.ColumnName + "\"]))" + field.ColumnName
                    + " = dataRecord.Get" + field.DbTypeNameStr + "(colName[\"" + field.ColumnName + "\"]);");
                else
                    outStr.AppendLine(_Indent + "	if (colName.ContainsKey(\"" + field.ColumnName + "\"))"
                        + field.ColumnName + " =dataRecord.Get" + field.DbTypeNameStr + "(colName[\"" + field.ColumnName + "\"]);");
            }
            outStr.AppendLine(_Indent + "	return this;");
            outStr.AppendLine(_Indent + "}");
        }
        ///<summary>构建DataRow填充实体</summary>
        public void BuildDataRow(StringBuilder outStr, TableObject table)
        {
            outStr.AppendLine(_Indent + "///<summary>DataRow填充实体,返回自己</summary>");
            outStr.AppendLine(_Indent + "///<param name=\"colName\">列名的列次序，可调用GetColNameIndex获得</param>");
            outStr.AppendLine(_Indent + "public " + table.name + " BuildEntity(DataRow dr, Dictionary<string, int> colName)");
            outStr.AppendLine(_Indent + "{");
            foreach (FieldObject field in table.Columns)
            {
                if (field.isNull || field.defaultVal.Length == 0)
                    outStr.AppendLine(_Indent + "	if (colName.ContainsKey(\"" + field.ColumnName + "\")&&!dr.IsNull(colName[\""
                    + field.ColumnName + "\"]))" + field.ColumnName
                    + " =  (" + field.TypeNameCs + ")dr[colName[\"" + field.ColumnName + "\"]];");
                else
                    outStr.AppendLine(_Indent + "	if (colName.ContainsKey(\"" + field.ColumnName + "\"))"
                        + field.ColumnName + " =(" + field.DbTypeNameStr + ")dr[colName[\"" + field.ColumnName + "\"]];");
            }
            outStr.AppendLine(_Indent + "	return this;");
            outStr.AppendLine(_Indent + "}");
        }
        public string Render()
        {
            StringBuilder outStr = new StringBuilder();
            outStr.AppendLine(_Indent + "using System;");
            outStr.AppendLine(_Indent + "using System.Collections.Generic;");
            outStr.AppendLine(_Indent + "using System.Data;");
            outStr.AppendLine(_Indent + "using System.Data.SqlClient;");
            outStr.Append("\n");
            outStr.AppendLine(_Indent + "namespace " + NamespaceStr);
            outStr.AppendLine(_Indent + "{");
            foreach (TableObject table in myDb.GetTableView())//只要的表和不要的表
            {
                if ((OnlyTable.Count == 0 || OnlyTable.Contains(table.name)) && !NoTable.Contains(table.name))
                {
                    table.comments = table.comments.Replace("\r", "").Replace("\n", "");
                    FieldObject pkField = new FieldObject();

                    //FieldObject tempFlie=new FieldObject();
                    List<FieldObject> lsttempFlie = new List<FieldObject>();
                    foreach (FieldObject field1 in table.Columns)
                    {
                        if (field1.isPK)
                        {
                            pkField = field1;
                        }
                        if (field1.ColumnName == table.name)
                        {
                            lsttempFlie.Add(field1);
                        }
                    }

                    foreach (FieldObject field1 in lsttempFlie)
                    {
                        table.Columns.Remove(field1);
                    }

                    if (pkField.ColumnName == null) pkField = table.Columns.First();
                    PushIndent("\t");
                    //outStr.AppendLine(_Indent + "#region  " + table.name + table.comments);
                    outStr.AppendLine(_Indent + "///<summary>" + table.comments + "</summary>");
                    //if (table.type.Trim() == "V") outStr.AppendLine(_Indent + "[NotMapped]");
                    outStr.AppendLine(_Indent + "public class " + table.name + " : ITableBase<" + table.name + ">");
                    outStr.AppendLine(_Indent + "{");
                    PushIndent("\t");
                    BuildTableAbout(outStr, table, pkField);//构建表名相关
                    BuildDefaultValue(outStr, table, pkField);//构建默认值
                    BuildProperty(outStr, table, pkField);//构建属性
                    BuildSqlParameters(outStr, table, pkField);//构建值相关方法
                    BuildDataRecord(outStr, table);
                    BuildDataRow(outStr, table);
                    BuildToJosn(outStr, table);//ToJosn
                    PopIndent();
                    outStr.AppendLine(_Indent + "}");
                    //outStr.AppendLine(_Indent + "#endregion");
                    PopIndent();
                }
            }
            outStr.AppendLine(_Indent + "}");
            return outStr.ToString();
        }
    }
}
