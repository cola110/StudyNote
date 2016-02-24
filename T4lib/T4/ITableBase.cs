using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace T4
{
    public interface ITableBase<T> where T : class,new()
    {
        /// <summary>库名</summary>
        string GetDbName();

        /// <summary>表名</summary>
        string GetTableName();

        /// <summary>主键名称</summary>
        string GetPkName();
        /// <summary>主键</summary>
        object PkValue { get; set; }

        /// <summary>得到主键集合</summary>
        Dictionary<string, object> GetPkValues();
        /// <summary>插入Sql</summary>
        string GetInsertSql();
        /// <summary>查询Sql</summary>
        string GetSelectSql();
        /// <summary>删除Sql</summary>
        string GetDeleteSql();

        /// <summary>字段集合</summary>
        Dictionary<string, Type> GetFieldNames();
        /// <summary>字段备注</summary>
        Dictionary<string, string> GetFieldNotes();
        ///<summary>实体到参数</summary>
        /// <param name="haveDentity">是否包含自增长列</param>
        List<SqlParameter> ToSqlParameters(bool haveDentity = true);
        ///<summary>分析sql添加参数</summary>
        /// <param name="sql">要添加参数的sql</param>
        List<SqlParameter> ToSqlParameters(string sql);
        /// <summary>转换为josn值</summary>
        string ToJosn();
        /// <summary>设置默认值</summary>
        void SetDefaultValue();
        /// <summary>DataRecord填充实体 </summary>
        T BuildEntity(IDataRecord dataRecord, Dictionary<string, int> colName);
        /// <summary>DataRow填充实体 </summary>
        T BuildEntity(DataRow dr, Dictionary<string, int> colName);
    }
}
