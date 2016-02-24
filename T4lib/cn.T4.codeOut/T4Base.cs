using MetaDataV2;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace cn.T4.codeOut
{
    /// <summary>T4的帮助 http://msdn.microsoft.com/zh-cn/library/bb126478</summary>
    public class T4Base
    {
        /// <summary> 不要生成的表</summary>
        public string NamespaceStr = "";
        /// <summary> 不要生成的表</summary>
        public List<string> NoTable = new List<string>();
        /// <summary> 只要生成的表</summary>
        public List<string> OnlyTable = new List<string>();
        /// <summary> DB</summary>
        public static Database myDb;
        /// <summary>数据库的备注</summary>
        public static Dictionary<string, FieldObject> Decs = new Dictionary<string, FieldObject>();
        public static Dictionary<string, TableObject> TableDecs = new Dictionary<string, TableObject>();
        public string _Indent = "";
        public void PushIndent(string str)
        {
            _Indent += str;
        }
        public void PopIndent()
        {
            _Indent = _Indent.Remove(_Indent.Length - 1);
        }
        public T4Base(string TemplateFilePath, string ConnectionName = "MetaDataDB")
        {
            string pathStr = Path.GetDirectoryName(TemplateFilePath);
            string configPath = Directory.GetFiles(pathStr, "*.config").FirstOrDefault() ??
                                Directory.GetParent(pathStr).GetFiles("*.config").FirstOrDefault().FullName;
            Configuration _Configuration = ConfigurationManager.OpenMappedExeConfiguration(
                new ExeConfigurationFileMap() { ExeConfigFilename = configPath }, ConfigurationUserLevel.None);
            AppSettingsSection appSett = (AppSettingsSection)_Configuration.GetSection("appSettings");
            ConnectionStringsSection appCon = (ConnectionStringsSection)_Configuration.GetSection("connectionStrings");
            MdFactory.SetConnectionStr(appCon.ConnectionStrings[ConnectionName].ConnectionString);
            myDb = MdFactory.SetCurrentDbName(appSett.Settings[ConnectionName + "_CurrentDbName"].Value, true);
            foreach (TableObject table in myDb.GetTableView())
            {
                if (!TableDecs.ContainsKey(table.name)) TableDecs.Add(table.name, table);
                foreach (FieldObject field in table.Columns)
                    if (!Decs.ContainsKey(field.ColumnName)) Decs.Add(field.ColumnName, field);
            }
        }
        public T4Base() { }
        /// <summary>设置当前数据库</summary>
        public void SetDB(string dbName, bool refresh = false)
        {
            myDb = MdFactory.SetCurrentDbName(dbName, refresh);
            //return myDb;//有返回值且是对象的时候,tt里也要知道这个对象,要引用的相应的dll
        }
        public SqlConnection DB;
        public DataSet ExeSqlDataSet(string sqlStr)
        {
            if (DB == null || DB.Database != myDb.DbName) DB = new SqlConnection(myDb.ConnectionString);
            SqlCommand cmd = new SqlCommand(sqlStr, DB);
            cmd.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
            new SqlDataAdapter(cmd).Fill(ds);
            return ds;
        }
        #region
        /// <summary>取数据例子</summary>
        public void TablesAndViews(StringBuilder str)
        {
            foreach (TableObject table in myDb.GetTableView())//只要的表和不要的表
                if ((OnlyTable.Count == 0 || OnlyTable.Contains(table.name)) && !NoTable.Contains(table.name))
                {
                    foreach (FieldObject field1 in table.Columns)
                    { }
                    IEnumerable<ProObject> myPro = myDb.Procedures.Where(z => z.text.IndexOf(table.name) >= 0);
                    foreach (ProObject item in myPro)
                    { }
                }
        }
        public string GetTbDes(string tbName)
        {
            int dIndex = tbName.LastIndexOf('.');
            if (dIndex > -1) tbName = tbName.Substring(dIndex + 1);
            if (TableDecs.ContainsKey(tbName))
            {
                var tb = TableDecs[tbName];
                return tb.comments + tb.dates;
            }
            return "";
        }
        public string GetDes(string fieldName)
        {
            if (Decs.ContainsKey(fieldName))
            {
                var field = Decs[fieldName];
                return field.deText.Trim() + field.TypeNameCs + field.Length;
            }
            return "";
        }
        #endregion
    }
}
