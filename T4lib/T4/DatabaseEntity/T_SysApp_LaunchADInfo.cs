using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace T4.DatabaseEntity
{
	///<summary></summary>
	public class T_SysApp_LaunchADInfo : ITableBase<T_SysApp_LaunchADInfo>
	{
		#region  T_SysApp_LaunchADInfo表元信息
		public const string dbName = "BasicUtility";//库名
		public const string tableName = "T_SysApp_LaunchADInfo";//表名
		public const string pkName = "AdID";//主键名
		public const string insertSql = @"Insert Into " + dbName + ".dbo.T_SysApp_LaunchADInfo (AdTitle,AdPicUrl,IntervalTime,SortOrder,IsDeleted,Status,OnlineTime,OfflineTime,CreatedOn,CreatedBy,LastUpdatedBy,LastUpdatedOn)values(@AdTitle,@AdPicUrl,@IntervalTime,@SortOrder,@IsDeleted,@Status,@OnlineTime,@OfflineTime,@CreatedOn,@CreatedBy,@LastUpdatedBy,@LastUpdatedOn);";
		public const string selectSql = @"select AdID,AdTitle,AdPicUrl,IntervalTime,SortOrder,IsDeleted,Status,OnlineTime,OfflineTime,CreatedOn,CreatedBy,LastUpdatedBy,LastUpdatedOn from " + dbName + ".dbo.T_SysApp_LaunchADInfo with(nolock) where 1 = 1 ";
		public const string deleteSql = @"delete from  " + dbName + ".dbo.T_SysApp_LaunchADInfo where AdID = @AdID;";
		public static readonly Dictionary<string,Type> fieldNames;//字段
		public static readonly Dictionary<string, string> fieldNotes;//字备注
		static T_SysApp_LaunchADInfo()
		{
		   fieldNames = new Dictionary<string,Type> {{ "AdID", typeof(int) },{ "AdTitle", typeof(string) },{ "AdPicUrl", typeof(string) },{ "IntervalTime", typeof(int) },{ "SortOrder", typeof(int) },{ "IsDeleted", typeof(int) },{ "Status", typeof(int) },{ "OnlineTime", typeof(DateTime) },{ "OfflineTime", typeof(DateTime) },{ "CreatedOn", typeof(DateTime) },{ "CreatedBy", typeof(string) },{ "LastUpdatedBy", typeof(string) },{ "LastUpdatedOn", typeof(DateTime) }};
		   fieldNotes = new Dictionary<string,string> {{ "AdID", ""},{ "AdTitle", ""},{ "AdPicUrl", ""},{ "IntervalTime", ""},{ "SortOrder", "排列顺序"},{ "IsDeleted", "是否删除"},{ "Status", "充值金额状态"},{ "OnlineTime", ""},{ "OfflineTime", ""},{ "CreatedOn", "创建时间"},{ "CreatedBy", "创建人"},{ "LastUpdatedBy", "最后修改者"},{ "LastUpdatedOn", "最后修改时间"}};
		}
		/// <summary>库名</summary>
		public string GetDbName() { return dbName;}
		/// <summary>表名</summary>
		public string GetTableName() { return tableName;}
		/// <summary>主键名</summary>
		public string GetPkName() { return pkName;}
		/// <summary>插入Sql</summary>
		public string GetInsertSql(){return insertSql;}
		/// <summary>查询Sql</summary>
		public string GetSelectSql(){return selectSql;}
		/// <summary>删除Sql</summary>
		public string GetDeleteSql(){return deleteSql;}
		/// <summary>字段名集合</summary>
		public Dictionary<string,Type> GetFieldNames() { return fieldNames;}
		/// <summary>字段名集合</summary>
		public Dictionary<string,string> GetFieldNotes() { return fieldNotes;}
		#endregion
		#region  T_SysApp_LaunchADInfo默认值
		public T_SysApp_LaunchADInfo()
		{
			SetDefaultValue();
		}
		public void SetDefaultValue()
		{
			if (AdTitle == null)AdTitle = "";
			if (AdPicUrl == null)AdPicUrl = "";
			if (IntervalTime == 0)IntervalTime = 0;
			if (SortOrder == 0)SortOrder = 0;
			if (IsDeleted == 0)IsDeleted = 0;
			if (Status == 0)Status = 0;
			if (OnlineTime.Year<1900)OnlineTime = new DateTime(1900, 1, 1);
			if (OfflineTime.Year<1900)OfflineTime = new DateTime(1900, 1, 1);
			if (CreatedOn.Year<1900)CreatedOn = new DateTime(1900, 1, 1);
			if (CreatedBy == null)CreatedBy = "";
			if (LastUpdatedBy == null)LastUpdatedBy = "";
			if (LastUpdatedOn.Year<1900)LastUpdatedOn = new DateTime(1900, 1, 1);
		}
		#endregion
		#region  T_SysApp_LaunchADInfo属性13
		///<summary>,int4</summary>
		public int AdID{ get; set; }
		///<summary>,string100</summary>
		public string AdTitle{ get; set; }
		///<summary>,string8000</summary>
		public string AdPicUrl{ get; set; }
		///<summary>,int4</summary>
		public int IntervalTime{ get; set; }
		///<summary>排列顺序,int4</summary>
		public int SortOrder{ get; set; }
		///<summary>是否删除；1是，0否,int4</summary>
		public int IsDeleted{ get; set; }
		///<summary>充值金额状态：正常0、删除1…,int4</summary>
		public int Status{ get; set; }
		///<summary>,DateTime8</summary>
		public DateTime OnlineTime{ get; set; }
		///<summary>,DateTime8</summary>
		public DateTime OfflineTime{ get; set; }
		///<summary>创建时间,DateTime8</summary>
		public DateTime CreatedOn{ get; set; }
		///<summary>创建人,string100</summary>
		public string CreatedBy{ get; set; }
		///<summary>最后修改者,string100</summary>
		public string LastUpdatedBy{ get; set; }
		///<summary>最后修改时间,DateTime8</summary>
		public DateTime LastUpdatedOn{ get; set; }
		#endregion
		/// <summary>主键int</summary>
		public object PkValue { get { return AdID; } set { if (value is int)AdID = (int)value; } } 
		/// <summary>得到主键集合</summary>
		public Dictionary<string, object> GetPkValues()
		{
		    Dictionary<string, object> pkValues = new Dictionary<string, object>();
		    pkValues.Add("AdID", AdID);
		    return pkValues;
		}
		///<summary>实体到参数</summary>
		/// <param name="haveDentity">是否包含自增长列</param>
		public List<SqlParameter> ToSqlParameters(bool haveDentity=true)
		{
			List<SqlParameter> parameterList = new List<SqlParameter>();
			if (haveDentity) parameterList.Add(new SqlParameter("@AdID", AdID));
			parameterList.Add(new SqlParameter("@AdTitle", AdTitle));
			parameterList.Add(new SqlParameter("@AdPicUrl", AdPicUrl));
			parameterList.Add(new SqlParameter("@IntervalTime", IntervalTime));
			parameterList.Add(new SqlParameter("@SortOrder", SortOrder));
			parameterList.Add(new SqlParameter("@IsDeleted", IsDeleted));
			parameterList.Add(new SqlParameter("@Status", Status));
			parameterList.Add(new SqlParameter("@OnlineTime", OnlineTime));
			parameterList.Add(new SqlParameter("@OfflineTime", OfflineTime));
			parameterList.Add(new SqlParameter("@CreatedOn", CreatedOn));
			parameterList.Add(new SqlParameter("@CreatedBy", CreatedBy));
			parameterList.Add(new SqlParameter("@LastUpdatedBy", LastUpdatedBy));
			parameterList.Add(new SqlParameter("@LastUpdatedOn", LastUpdatedOn));
			return parameterList;
		}
		///<summary>分析sql添加参数</summary>
		/// <param name="sql">要添加参数的sql</param>
		public List<SqlParameter> ToSqlParameters(string sql)
		{
			List<SqlParameter> parameterList = new List<SqlParameter>();
			List<string> sqlHaveParameters =SqlAid.GetSqlParametersList(sql);
			if (sqlHaveParameters.Contains("AdID")) parameterList.Add(new SqlParameter("@AdID", AdID));
			if (sqlHaveParameters.Contains("AdTitle")) parameterList.Add(new SqlParameter("@AdTitle", AdTitle));
			if (sqlHaveParameters.Contains("AdPicUrl")) parameterList.Add(new SqlParameter("@AdPicUrl", AdPicUrl));
			if (sqlHaveParameters.Contains("IntervalTime")) parameterList.Add(new SqlParameter("@IntervalTime", IntervalTime));
			if (sqlHaveParameters.Contains("SortOrder")) parameterList.Add(new SqlParameter("@SortOrder", SortOrder));
			if (sqlHaveParameters.Contains("IsDeleted")) parameterList.Add(new SqlParameter("@IsDeleted", IsDeleted));
			if (sqlHaveParameters.Contains("Status")) parameterList.Add(new SqlParameter("@Status", Status));
			if (sqlHaveParameters.Contains("OnlineTime")) parameterList.Add(new SqlParameter("@OnlineTime", OnlineTime));
			if (sqlHaveParameters.Contains("OfflineTime")) parameterList.Add(new SqlParameter("@OfflineTime", OfflineTime));
			if (sqlHaveParameters.Contains("CreatedOn")) parameterList.Add(new SqlParameter("@CreatedOn", CreatedOn));
			if (sqlHaveParameters.Contains("CreatedBy")) parameterList.Add(new SqlParameter("@CreatedBy", CreatedBy));
			if (sqlHaveParameters.Contains("LastUpdatedBy")) parameterList.Add(new SqlParameter("@LastUpdatedBy", LastUpdatedBy));
			if (sqlHaveParameters.Contains("LastUpdatedOn")) parameterList.Add(new SqlParameter("@LastUpdatedOn", LastUpdatedOn));
			return parameterList;
		}
		///<summary>IDataRecord填充实体,返回自己</summary>
		///<param name="colName">列名的列次序，可调用GetColNameIndex获得</param>
		public T_SysApp_LaunchADInfo BuildEntity(IDataRecord dataRecord,Dictionary<string,int> colName)
		{
			if (colName.ContainsKey("AdID")&&!dataRecord.IsDBNull(colName["AdID"]))AdID = dataRecord.GetInt32(colName["AdID"]);
			if (colName.ContainsKey("AdTitle")&&!dataRecord.IsDBNull(colName["AdTitle"]))AdTitle = dataRecord.GetString(colName["AdTitle"]);
			if (colName.ContainsKey("AdPicUrl")&&!dataRecord.IsDBNull(colName["AdPicUrl"]))AdPicUrl = dataRecord.GetString(colName["AdPicUrl"]);
			if (colName.ContainsKey("IntervalTime"))IntervalTime =dataRecord.GetInt32(colName["IntervalTime"]);
			if (colName.ContainsKey("SortOrder"))SortOrder =dataRecord.GetInt32(colName["SortOrder"]);
			if (colName.ContainsKey("IsDeleted"))IsDeleted =dataRecord.GetInt32(colName["IsDeleted"]);
			if (colName.ContainsKey("Status"))Status =dataRecord.GetInt32(colName["Status"]);
			if (colName.ContainsKey("OnlineTime")&&!dataRecord.IsDBNull(colName["OnlineTime"]))OnlineTime = dataRecord.GetDateTime(colName["OnlineTime"]);
			if (colName.ContainsKey("OfflineTime")&&!dataRecord.IsDBNull(colName["OfflineTime"]))OfflineTime = dataRecord.GetDateTime(colName["OfflineTime"]);
			if (colName.ContainsKey("CreatedOn")&&!dataRecord.IsDBNull(colName["CreatedOn"]))CreatedOn = dataRecord.GetDateTime(colName["CreatedOn"]);
			if (colName.ContainsKey("CreatedBy")&&!dataRecord.IsDBNull(colName["CreatedBy"]))CreatedBy = dataRecord.GetString(colName["CreatedBy"]);
			if (colName.ContainsKey("LastUpdatedBy")&&!dataRecord.IsDBNull(colName["LastUpdatedBy"]))LastUpdatedBy = dataRecord.GetString(colName["LastUpdatedBy"]);
			if (colName.ContainsKey("LastUpdatedOn")&&!dataRecord.IsDBNull(colName["LastUpdatedOn"]))LastUpdatedOn = dataRecord.GetDateTime(colName["LastUpdatedOn"]);
			return this;
		}
		///<summary>DataRow填充实体,返回自己</summary>
		///<param name="colName">列名的列次序，可调用GetColNameIndex获得</param>
		public T_SysApp_LaunchADInfo BuildEntity(DataRow dr, Dictionary<string, int> colName)
		{
			if (colName.ContainsKey("AdID")&&!dr.IsNull(colName["AdID"]))AdID =  (int)dr[colName["AdID"]];
			if (colName.ContainsKey("AdTitle")&&!dr.IsNull(colName["AdTitle"]))AdTitle =  (string)dr[colName["AdTitle"]];
			if (colName.ContainsKey("AdPicUrl")&&!dr.IsNull(colName["AdPicUrl"]))AdPicUrl =  (string)dr[colName["AdPicUrl"]];
			if (colName.ContainsKey("IntervalTime"))IntervalTime =(Int32)dr[colName["IntervalTime"]];
			if (colName.ContainsKey("SortOrder"))SortOrder =(Int32)dr[colName["SortOrder"]];
			if (colName.ContainsKey("IsDeleted"))IsDeleted =(Int32)dr[colName["IsDeleted"]];
			if (colName.ContainsKey("Status"))Status =(Int32)dr[colName["Status"]];
			if (colName.ContainsKey("OnlineTime")&&!dr.IsNull(colName["OnlineTime"]))OnlineTime =  (DateTime)dr[colName["OnlineTime"]];
			if (colName.ContainsKey("OfflineTime")&&!dr.IsNull(colName["OfflineTime"]))OfflineTime =  (DateTime)dr[colName["OfflineTime"]];
			if (colName.ContainsKey("CreatedOn")&&!dr.IsNull(colName["CreatedOn"]))CreatedOn =  (DateTime)dr[colName["CreatedOn"]];
			if (colName.ContainsKey("CreatedBy")&&!dr.IsNull(colName["CreatedBy"]))CreatedBy =  (string)dr[colName["CreatedBy"]];
			if (colName.ContainsKey("LastUpdatedBy")&&!dr.IsNull(colName["LastUpdatedBy"]))LastUpdatedBy =  (string)dr[colName["LastUpdatedBy"]];
			if (colName.ContainsKey("LastUpdatedOn")&&!dr.IsNull(colName["LastUpdatedOn"]))LastUpdatedOn =  (DateTime)dr[colName["LastUpdatedOn"]];
			return this;
		}
		///<summary>返回对象Josn字串</summary>
		public string ToJosn()
		{
			return "{\"TableName\":\"T_SysApp_LaunchADInfo\""
				+",\"AdID\":\""+AdID+"\""
				+",\"AdTitle\":\""+AdTitle+"\""
				+",\"AdPicUrl\":\""+AdPicUrl+"\""
				+",\"IntervalTime\":\""+IntervalTime+"\""
				+",\"SortOrder\":\""+SortOrder+"\""
				+",\"IsDeleted\":\""+IsDeleted+"\""
				+",\"Status\":\""+Status+"\""
				+",\"OnlineTime\":\""+OnlineTime+"\""
				+",\"OfflineTime\":\""+OfflineTime+"\""
				+",\"CreatedOn\":\""+CreatedOn+"\""
				+",\"CreatedBy\":\""+CreatedBy+"\""
				+",\"LastUpdatedBy\":\""+LastUpdatedBy+"\""
				+",\"LastUpdatedOn\":\""+LastUpdatedOn+"\""
				+"}";
		}
	}
}

