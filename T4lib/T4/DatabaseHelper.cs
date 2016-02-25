using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Data.Common;

namespace T4
{
    /// <summary>
    /// 数据库帮助类
    /// </summary>
    public class DataBaseHelper
    {
        //#region 开启事务(事务所用的库属性都为写库)
        ///// <summary>
        ///// 开启事务(事务所用的库属性都为写库)
        ///// </summary>
        ///// <param name="dbName"></param>
        ///// <returns></returns>
        //public static DbTransaction GetDbTransaction(DbConfig dbName)
        //{
        //    Database dataBase = GetDb(dbName);
        //    if (dataBase == null)
        //    {
        //        return null;
        //    }
        //    return new DataBaseTransaction(dataBase).DbTransaction;
        //}
        //#endregion

        //#region ExecuteDataSet

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sql"></param>
        ///// <param name="dbName"></param>
        ///// <param name="isWriteDb"></param>
        ///// <param name="handler"></param>
        ///// <returns></returns>
        //public static DataSet ExecuteDataSet(string sql, DbConfig dbName, bool isWriteDb, string handler = "")
        //{
        //    sql += GetSqlNote(handler, new StackTrace());//sql追加sql注释
        //    Database dataBase = GetDb(dbName, isWriteDb);
        //    if (dataBase == null)
        //    {
        //        return null;
        //    }
        //    return SqlHelper.ExecuteDataSet(dataBase, sql);
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sql"></param>
        ///// <param name="parameterList"></param>
        ///// <param name="dbName"></param>
        ///// <param name="isWriteDb"></param>
        ///// <param name="handler"></param>
        ///// <returns></returns>
        //public static DataSet ExecuteDataSet(string sql, List<SqlParameter> parameterList,
        //    DbConfig dbName, bool isWriteDb, string handler = "")
        //{
        //    sql += GetSqlNote(handler, new StackTrace());//sql追加sql注释
        //    Database dataBase = GetDb(dbName, isWriteDb);
        //    if (dataBase == null)
        //    {
        //        return null;
        //    }
        //    SqlParameterWrapperCollection paramCollection = GetWrapperCollection(parameterList);
        //    return SqlHelper.ExecuteDataSet(dataBase, sql, paramCollection);
        //}
        //#endregion

        //#region ExecuteDataTable
        ///// <summary>
        ///// ExecuteDataTable
        ///// </summary>
        ///// <param name="sql"></param>
        ///// <param name="dbName"></param>
        ///// <param name="isWriteDb"></param>
        ///// <param name="handler"></param>
        ///// <returns></returns>
        //public static DataTable ExecuteDataTable(string sql, DbConfig dbName, bool isWriteDb = true, string handler = "")
        //{
        //    sql += GetSqlNote(handler, new StackTrace());//sql追加sql注释
        //    Database dataBase = GetDb(dbName, isWriteDb);
        //    if (dataBase == null)
        //    {
        //        return null;
        //    }
        //    try
        //    {
        //        return SqlHelper.ExecuteDataTable(dataBase, sql);
        //    }
        //    catch (Exception ex)
        //    {
        //        string errStr = "执行ExecuteDataTable报错:\r\n" + sql;
        //        throw new Exception(errStr, ex);
        //    }
        //}
        ///// <summary>
        ///// ExecuteDataTable
        ///// </summary>
        ///// <param name="sql"></param>
        ///// <param name="parameterList"></param>
        ///// <param name="dbName"></param>
        ///// <param name="isWriteDb"></param>
        ///// <param name="handler"></param>
        ///// <returns></returns>
        //public static DataTable ExecuteDataTable(string sql, List<SqlParameter> parameterList, DbConfig dbName,
        //    bool isWriteDb = true, string handler = "")
        //{
        //    sql += GetSqlNote(handler, new StackTrace());//sql追加sql注释
        //    Database dataBase = GetDb(dbName, isWriteDb);
        //    if (dataBase == null)
        //    {
        //        return null;
        //    }
        //    SqlParameterWrapperCollection paramCollection = GetWrapperCollection(parameterList);
        //    try
        //    {
        //        return SqlHelper.ExecuteDataTable(dataBase, sql, paramCollection);
        //    }
        //    catch (Exception ex)
        //    {
        //        string errStr = "执行ExecuteDataTable报错:\r\n"
        //            + SqlAid.SqlParameterWrapperToString(parameterList)
        //            + "\r\n"
        //            + sql;
        //        throw new Exception(errStr, ex);
        //    }
        //}
        //#endregion

        //#region ExecuteNonQuery

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sql"></param>
        ///// <param name="dbName"></param>
        ///// <param name="handler"></param>
        ///// <returns></returns>
        ///// <exception cref="Exception"></exception>
        //public static int ExecuteNonQuery(string sql, DbConfig dbName, string handler = "")
        //{
        //    try
        //    {
        //        sql += GetSqlNote(handler, new StackTrace());//sql追加sql注释
        //        Database dataBase = GetDb(dbName);
        //        return SqlHelper.ExecuteNonQuery(dataBase, sql);
        //    }
        //    catch (Exception ex)
        //    {
        //        string errStr = "执行ExecuteNonQuery报错:\r\n" + sql;
        //        throw new Exception(errStr, ex);
        //    }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sql"></param>
        ///// <param name="parameterList"></param>
        ///// <param name="dbName"></param>
        ///// <param name="handler"></param>
        ///// <returns></returns>
        ///// <exception cref="Exception"></exception>
        //public static int ExecuteNonQuery(string sql, List<SqlParameter> parameterList, DbConfig dbName, string handler = "")
        //{
        //    try
        //    {
        //        sql += GetSqlNote(handler, new StackTrace());//sql追加sql注释
        //        Database dataBase = GetDb(dbName);
        //        SqlParameterWrapperCollection paramCollection = GetWrapperCollection(parameterList);
        //        return SqlHelper.ExecuteNonQuery(dataBase, sql, paramCollection);
        //    }
        //    catch (Exception ex)
        //    {
        //        string errStr = "执行ExecuteNonQuery报错:\r\n"
        //            + SqlAid.SqlParameterWrapperToString(parameterList)
        //            + "\r\n"
        //            + sql;
        //        throw new Exception(errStr, ex);
        //    }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sql"></param>
        ///// <param name="tran"></param>
        ///// <param name="dbName"></param>
        ///// <param name="handler"></param>
        ///// <returns></returns>
        ///// <exception cref="Exception"></exception>
        //public static int ExecuteNonQuery(string sql, DbTransaction tran, DbConfig dbName, string handler = "")
        //{
        //    try
        //    {
        //        sql += GetSqlNote(handler, new StackTrace());//sql追加sql注释
        //        Database dataBase = GetDb(dbName);
        //        return SqlHelper.ExecuteNonQuery(dataBase, sql, tran);
        //    }
        //    catch (Exception ex)
        //    {
        //        string errStr = "执行ExecuteNonQuery报错:\r\n"
        //            + sql;
        //        throw new Exception(errStr, ex);
        //    }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sql"></param>
        ///// <param name="parameterList"></param>
        ///// <param name="tran"></param>
        ///// <param name="dbName"></param>
        ///// <param name="handler"></param>
        ///// <returns></returns>
        ///// <exception cref="Exception"></exception>
        //public static int ExecuteNonQuery(string sql, List<SqlParameter> parameterList,
        //    DbTransaction tran, DbConfig dbName, string handler = "")
        //{
        //    try
        //    {
        //        sql += GetSqlNote(handler, new StackTrace());//sql追加sql注释
        //        Database dataBase = GetDb(dbName);
        //        SqlParameterWrapperCollection paramCollection = GetWrapperCollection(parameterList);
        //        return SqlHelper.ExecuteNonQuery(dataBase, sql, paramCollection, tran);
        //    }
        //    catch (Exception ex)
        //    {
        //        string errStr = "执行ExecuteNonQuery报错:\r\n"
        //            + SqlAid.SqlParameterWrapperToString(parameterList)
        //            + "\r\n"
        //            + sql;
        //        throw new Exception(errStr, ex);
        //    }
        //}
        //#endregion

        //#region ExecuteIdentity

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sql"></param>
        ///// <param name="dbName"></param>
        ///// <param name="handler"></param>
        ///// <returns></returns>
        ///// <exception cref="Exception"></exception>
        //public static int ExecuteIdentity(string sql, DbConfig dbName, string handler = "")
        //{
        //    try
        //    {
        //        sql += GetSqlNote(handler, new StackTrace());//sql追加sql注释
        //        Database dataBase = GetDb(dbName);
        //        return SqlHelper.ExecuteIdentity(dataBase, sql);
        //    }
        //    catch (Exception ex)
        //    {
        //        string errStr = "执行ExecuteIdentity报错:\r\n" + sql;
        //        throw new Exception(errStr, ex);
        //    }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sql"></param>
        ///// <param name="parameterList"></param>
        ///// <param name="dbName"></param>
        ///// <param name="handler"></param>
        ///// <returns></returns>
        ///// <exception cref="Exception"></exception>
        //public static int ExecuteIdentity(string sql, List<SqlParameter> parameterList, DbConfig dbName,
        //    string handler = "")
        //{
        //    try
        //    {
        //        sql += GetSqlNote(handler, new StackTrace());//sql追加sql注释
        //        Database dataBase = GetDb(dbName);
        //        SqlParameterWrapperCollection paramCollection = GetWrapperCollection(parameterList);
        //        return SqlHelper.ExecuteIdentity(dataBase, sql, paramCollection);
        //    }
        //    catch (Exception ex)
        //    {
        //        string errStr = "执行ExecuteIdentity报错:\r\n"
        //             + SqlAid.SqlParameterWrapperToString(parameterList)
        //             + "\r\n"
        //             + sql;
        //        throw new Exception(errStr, ex);
        //    }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sql"></param>
        ///// <param name="tran"></param>
        ///// <param name="dbName"></param>
        ///// <param name="handler"></param>
        ///// <returns></returns>
        ///// <exception cref="Exception"></exception>
        //public static int ExecuteIdentity(string sql, DbTransaction tran, DbConfig dbName, string handler = "")
        //{
        //    try
        //    {
        //        sql += GetSqlNote(handler, new StackTrace());//sql追加sql注释
        //        Database dataBase = GetDb(dbName);
        //        return SqlHelper.ExecuteIdentity(dataBase, sql, tran);
        //    }
        //    catch (Exception ex)
        //    {
        //        string errStr = "执行ExecuteIdentity报错:\r\n"
        //             + sql;
        //        throw new Exception(errStr, ex);
        //    }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sql"></param>
        ///// <param name="parameterList"></param>
        ///// <param name="tran"></param>
        ///// <param name="dbName"></param>
        ///// <param name="handler"></param>
        ///// <returns></returns>
        ///// <exception cref="Exception"></exception>
        //public static int ExecuteIdentity(string sql, List<SqlParameter> parameterList,
        //    DbTransaction tran, DbConfig dbName, string handler = "")
        //{
        //    try
        //    {
        //        sql += GetSqlNote(handler, new StackTrace());//sql追加sql注释
        //        Database dataBase = GetDb(dbName);
        //        SqlParameterWrapperCollection paramCollection = GetWrapperCollection(parameterList);
        //        return SqlHelper.ExecuteIdentity(dataBase, sql, paramCollection, tran);
        //    }
        //    catch (Exception ex)
        //    {
        //        string errStr = "执行ExecuteIdentity报错:\r\n"
        //             + SqlAid.SqlParameterWrapperToString(parameterList)
        //             + "\r\n"
        //             + sql;
        //        throw new Exception(errStr, ex);
        //    }
        //}

        //#endregion

        //#region ExecuteIdentityByBigInt
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sql"></param>
        ///// <param name="dbName"></param>
        ///// <param name="handler"></param>
        ///// <returns></returns>
        //public static long ExecuteIdentityByBigInt(string sql, DbConfig dbName, string handler = "")
        //{
        //    try
        //    {
        //        sql += GetSqlNote(handler, new StackTrace());//sql追加sql注释
        //        Database dataBase = GetDb(dbName);
        //        return SqlHelper.ExecuteIdentityByBigInt(dataBase, sql);
        //    }
        //    catch (Exception ex)
        //    {
        //        string errStr = "执行ExecuteIdentityByBigInt报错:\r\n" + sql;
        //        throw new Exception(errStr, ex);
        //    }
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sql"></param>
        ///// <param name="parameterList"></param>
        ///// <param name="dbName"></param>
        ///// <param name="handler"></param>
        ///// <returns></returns>
        //public static long ExecuteIdentityByBigInt(string sql, List<SqlParameter> parameterList, DbConfig dbName,
        //    string handler = "")
        //{
        //    try
        //    {
        //        sql += GetSqlNote(handler, new StackTrace());//sql追加sql注释
        //        Database dataBase = GetDb(dbName);
        //        SqlParameterWrapperCollection paramCollection = GetWrapperCollection(parameterList);
        //        return SqlHelper.ExecuteIdentityByBigInt(dataBase, sql, paramCollection);
        //    }
        //    catch (Exception ex)
        //    {
        //        string errStr = "执行ExecuteIdentityByBigInt报错:\r\n" + sql;
        //        throw new Exception(errStr, ex);
        //    }
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sql"></param>
        ///// <param name="tran"></param>
        ///// <param name="dbName"></param>
        ///// <param name="handler"></param>
        ///// <returns></returns>
        //public static long ExecuteIdentityByBigInt(string sql, DbTransaction tran, DbConfig dbName, string handler = "")
        //{
        //    try
        //    {
        //        sql += GetSqlNote(handler, new StackTrace());//sql追加sql注释
        //        Database dataBase = GetDb(dbName);
        //        return SqlHelper.ExecuteIdentityByBigInt(dataBase, sql, tran);
        //    }
        //    catch (Exception ex)
        //    {
        //        string errStr = "执行ExecuteIdentityByBigInt报错:\r\n" + sql;
        //        throw new Exception(errStr, ex);
        //    }
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sql"></param>
        ///// <param name="parameterList"></param>
        ///// <param name="tran"></param>
        ///// <param name="dbName"></param>
        ///// <param name="handler"></param>
        ///// <returns></returns>
        //public static long ExecuteIdentityByBigInt(string sql, List<SqlParameter> parameterList,
        //    DbTransaction tran, DbConfig dbName, string handler = "")
        //{
        //    try
        //    {
        //        sql += GetSqlNote(handler, new StackTrace());//sql追加sql注释
        //        Database dataBase = GetDb(dbName);
        //        SqlParameterWrapperCollection paramCollection = GetWrapperCollection(parameterList);
        //        return SqlHelper.ExecuteIdentityByBigInt(dataBase, sql, paramCollection, tran);
        //    }
        //    catch (Exception ex)
        //    {
        //        string errStr = "执行ExecuteIdentityByBigInt报错:\r\n" + sql;
        //        throw new Exception(errStr, ex);
        //    }
        //}

        //#endregion

        //#region ExecuteReader
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sql"></param>
        ///// <param name="dbName"></param>
        ///// <param name="isWriteDb"></param>
        ///// <param name="handler"></param>
        ///// <returns></returns>
        //public static IDataReader ExecuteReader(string sql, DbConfig dbName, bool isWriteDb, string handler = "")
        //{
        //    sql += GetSqlNote(handler, new StackTrace());//sql追加sql注释
        //    Database dataBase = GetDb(dbName, isWriteDb);
        //    if (dataBase == null)
        //    {
        //        return null;
        //    }
        //    return SqlHelper.ExecuteReader(dataBase, sql);
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sql"></param>
        ///// <param name="parameterList"></param>
        ///// <param name="dbName"></param>
        ///// <param name="isWriteDb"></param>
        ///// <param name="handler"></param>
        ///// <returns></returns>
        //public static IDataReader ExecuteReader(string sql, List<SqlParameter> parameterList, DbConfig dbName,
        //    bool isWriteDb = true, string handler = "")
        //{
        //    sql += GetSqlNote(handler, new StackTrace());//sql追加sql注释
        //    Database dataBase = GetDb(dbName, isWriteDb);
        //    if (dataBase == null)
        //    {
        //        return null;
        //    }
        //    SqlParameterWrapperCollection paramCollection = GetWrapperCollection(parameterList);
        //    return SqlHelper.ExecuteReader(dataBase, sql, paramCollection);
        //}
        //#endregion

        //#region ExecuteScalar
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sql"></param>
        ///// <param name="dbName"></param>
        ///// <param name="isWriteDb"></param>
        ///// <param name="handler"></param>
        ///// <returns></returns>
        //public static object ExecuteScalar(string sql, DbConfig dbName, bool isWriteDb, string handler = "")
        //{
        //    sql += GetSqlNote(handler, new StackTrace());//sql追加sql注释
        //    Database dataBase = GetDb(dbName, isWriteDb);
        //    return SqlHelper.ExecuteScalar(dataBase, sql);
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sql"></param>
        ///// <param name="parameterList"></param>
        ///// <param name="dbName"></param>
        ///// <param name="isWriteDb"></param>
        ///// <param name="handler"></param>
        ///// <returns></returns>
        //public static object ExecuteScalar(string sql, List<SqlParameter> parameterList, DbConfig dbName,
        //    bool isWriteDb = true, string handler = "")
        //{
        //    sql += GetSqlNote(handler, new StackTrace());//sql追加sql注释
        //    Database dataBase = GetDb(dbName, isWriteDb);
        //    SqlParameterWrapperCollection paramCollection = GetWrapperCollection(parameterList);
        //    return SqlHelper.ExecuteScalar(dataBase, sql, paramCollection);
        //}

        //#endregion

        #region SelectModel
        /// <summary>
        /// 以主键查询一个实体(方法内部捕获异常，存在异常返回异常信息)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keyVlaue"></param>
        /// <param name="errorMsg"></param>
        /// <param name="isWriteDb"></param>
        /// <returns></returns>
        public static T SelectModel<T>(long keyVlaue, out string errorMsg, bool isWriteDb = true)
            where T : class,ITableBase<T>, new()
        {
            errorMsg = string.Empty;
            try
            {
                return SelectModel<T>(keyVlaue, isWriteDb);
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                // ExceptionService.Instance.RecordException(ex, "查询实体异常");
            }
            return null;
        }
        /// <summary>
        /// 以主键查询一个实体(方法内部捕获异常，存在异常返回异常信息)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="nameValues"></param>
        /// <param name="errorMsg"></param>
        /// <param name="isWriteDb"></param>
        /// <returns></returns>
        public static T SelectModel<T>(NameValueCollection nameValues, out string errorMsg, bool isWriteDb = true)
            where T : class,ITableBase<T>, new()
        {
            errorMsg = string.Empty;
            try
            {
                return SelectModel<T>(nameValues, isWriteDb);
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                // ExceptionService.Instance.RecordException(ex, "查询实体异常");
            }
            return null;
        }
        /// <summary>
        /// 以主键查询一个实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keyVlaue"></param>
        /// <param name="isWriteDb"></param>
        /// <returns></returns>
        public static T SelectModel<T>(long keyVlaue, bool isWriteDb = true) where T : class,ITableBase<T>, new()
        {
            T tempT = new T();
            // Database dbTcFly = GetDb(tempT.GetDbName(), isWriteDb);
            //var dbTcFly = null;
            //if (dbTcFly == null)
            //{
            //    throw new Exception("DB Is Null");
            //}
            //DbCommand cmd = dbTcFly.GetSqlStringCommand(tempT.GetSelectSql() + " and " + tempT.GetPkName() + "=" + keyVlaue);
            try
            {
                //using (IDataReader dr = dbTcFly.ExecuteReader(cmd))
                //{
                //    Dictionary<string, int> colName = SqlAid.GetColNameIndex(dr);
                //    if (dr.Read())
                //    {
                //        tempT = new T().BuildEntity(dr, colName);
                //    }
                //    else
                //    {
                //        tempT = null;
                //    }
                //    dr.Close();
                //    return tempT;
                //}
                return tempT; // for rest
            }
            catch (Exception ex)
            {
                // string errStr = "SelectModel<T>报错:\r\n" + cmd.CommandText;
                // throw new Exception(errStr, ex);
                throw ex;
            }
        }
        /// <summary>
        /// (根据指定的字段)查询实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="nameValues"></param>
        /// <param name="isWriteDb"></param>
        /// <returns></returns>
        public static T SelectModel<T>(NameValueCollection nameValues, bool isWriteDb = true) where T : class,ITableBase<T>, new()
        {
            T tempT = new T();
            Tuple<string, List<SqlParameter>> whereSql = SqlAid.GetWhereSql<T>(nameValues);
            return SelectModel<T>(tempT.GetSelectSql() + whereSql.Item1, whereSql.Item2, isWriteDb);
        }

        /// <summary>
        /// (根据sql)查询实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameterList"></param>
        /// <param name="isWriteDb"></param>
        /// <returns></returns>
        public static T SelectModel<T>(string sql, List<SqlParameter> parameterList,
            bool isWriteDb = true) where T : class,ITableBase<T>, new()
        {
            T tempT = new T();
            // Database dbTcFly = GetDb(tempT.GetDbName(), isWriteDb);
            //if (dbTcFly == null)
            //{
            //    throw new Exception("DB Is Null");
            //}
            // DbCommand cmd = dbTcFly.GetSqlStringCommand(sql);
            foreach (SqlParameter par in parameterList)
            {
                // cmd.Parameters.Add(par);
            }
            try
            {
                //using (IDataReader dr = dbTcFly.ExecuteReader(cmd))
                //{
                //    Dictionary<string, int> colName = SqlAid.GetColNameIndex(dr);
                //    if (dr.Read())
                //    {
                //        tempT = new T().BuildEntity(dr, colName);
                //    }
                //    else
                //    {
                //        tempT = null;
                //    }
                //    dr.Close();
                //    return tempT;
                //}
                return tempT;
            }
            catch (Exception ex)
            {
                // string errStr = "SelectModel<T>报错:\r\n" + cmd.CommandText;
                string errStr = string.Empty;
                throw new Exception(errStr, ex);
            }
        }

        #region (根据指定的字段)查询实体 key-value
        /// <summary>
        /// (根据指定的字段)查询实体 key-value
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="paramArrary">二维数组,key-value（格式为new string[,] { { "param1", "1" }, { "param2", "2" } }）</param>
        /// <param name="isWriteDb"></param>
        /// <returns></returns>
        public static T SelectModel<T>(string[,] paramArrary, bool isWriteDb = true) where T : class,ITableBase<T>, new()
        {
            T tempT = new T();
            NameValueCollection nameValues = new NameValueCollection();
            if (paramArrary == null || paramArrary.GetLength(1) != 2)
            {
                return null;
            }
            for (int i = 0; i < paramArrary.GetLength(0); i++)
            {
                string key = string.Empty;
                string value = string.Empty;
                for (int j = 0; j < paramArrary.GetLength(1); j++)
                {
                    if (j == 0)
                    {
                        key = paramArrary[i, j];
                    }
                    else if (j == 1)
                    {
                        value = paramArrary[i, j];
                    }
                }
                nameValues.Add(key, value);
            }
            Tuple<string, List<SqlParameter>> whereSql = SqlAid.GetWhereSql<T>(nameValues);
            return SelectModel<T>(tempT.GetSelectSql() + whereSql.Item1, whereSql.Item2, isWriteDb);
        }


        #endregion

        #endregion

        #region SelectList
        /// <summary>生成查询sql并执行得到对象集合</summary>
        /// <typeparam name="T">对象</typeparam>
        /// <param name="nameValues">参数集合</param>
        /// <param name="isWriteDb">默认为写库</param>
        /// <param name="dp">分页</param>
        public static List<T> SelectList<T>(NameValueCollection nameValues, DataPage dp = null
            , bool isWriteDb = true) where T : class,ITableBase<T>, new()
        {
            T tempT = new T();
            if (dp != null && dp.OrderField == null)
            {
                dp.OrderField = tempT.GetPkName() + " desc";
            }
            Tuple<string, List<SqlParameter>> whereSql = SqlAid.GetWhereSql<T>(nameValues);
            return SelectList<T>(tempT.GetSelectSql() + whereSql.Item1, whereSql.Item2, dp, isWriteDb);
        }

        /// <summary>生成查询sql并执行得到对象集合</summary>
        /// <typeparam name="T">对象</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="isWriteDb">默认为写库</param>
        /// <param name="dp">分页</param>
        public static List<T> SelectList<T>(string sql, DataPage dp = null
                                            , bool isWriteDb = true) where T : class, ITableBase<T>, new()
        {
            DateTime dNow = DateTime.Now;
            T tempT = new T();
            List<T> list = new List<T>();
            Tuple<string, List<SqlParameter>> pageSql = SqlAid.GetPageSql(sql, dp);
            //Database dbTcFly = GetDb(tempT.GetDbName(), isWriteDb);
            //if (dbTcFly == null)
            //{
            //    throw new Exception("DB Is Null");
            //}
            //DbCommand cmd = dbTcFly.GetSqlStringCommand(pageSql.Item1);
            //foreach (var par in pageSql.Item2)
            //{
            //    cmd.Parameters.Add(par);
            //}
            try
            {
                //using (IDataReader dr = dbTcFly.ExecuteReader(cmd))
                //{
                //    Dictionary<string, int> colName = SqlAid.GetColNameIndex(dr);
                //    while (dr.Read())
                //    {
                //        list.Add(new T().BuildEntity(dr, colName));
                //    }
                //    if (dp != null && dp.PageSize > 0)
                //    {
                //        dr.NextResult();
                //        dr.Read();
                //        dp.RowCount = dr.GetInt32(0);
                //        dp.ExeTime = (DateTime.Now - dNow).TotalMilliseconds;
                //    }
                //    dr.Close();
                //}
                throw new Exception();
            }
            catch (Exception ex)
            {
                string errStr = "";//  "SelectList<T>报错:\r\n" + SqlAid.SqlParameterWrapperToString(cmd.Parameters) + "\r\n" +cmd.CommandText;
                throw new Exception(errStr, ex);
            }
            return list;
        }

        /// <summary>生成查询sql并执行得到对象集合</summary>
        /// <typeparam name="T">对象</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="parameterList">参数</param>
        /// <param name="isWriteDb">默认为写库</param>
        /// <param name="dp">分页</param>
        public static List<T> SelectList<T>(string sql, List<SqlParameter> parameterList, DataPage dp = null
                                            , bool isWriteDb = true) where T : class, ITableBase<T>, new()
        {
            DateTime dNow = DateTime.Now;
            T tempT = new T();
            List<T> list = new List<T>();
            Tuple<string, List<SqlParameter>> pageSql = SqlAid.GetPageSql(sql, dp);
            //Database dbTcFly = GetDb(tempT.GetDbName(), isWriteDb);
            //if (dbTcFly == null)
            //{
            //    throw new Exception("DB Is Null");
            //}
            //DbCommand cmd = dbTcFly.GetSqlStringCommand(pageSql.Item1);
            //foreach (SqlParameter par in parameterList)
            //{
            //    cmd.Parameters.Add(par);
            //}
            //foreach (var par in pageSql.Item2)
            //{
            //    cmd.Parameters.Add(par);
            //}
            try
            {
                //using (IDataReader dr = dbTcFly.ExecuteReader(cmd))
                //{
                //    Dictionary<string, int> colName = SqlAid.GetColNameIndex(dr);
                //    while (dr.Read())
                //    {
                //        list.Add(new T().BuildEntity(dr, colName));
                //    }
                //    if (dp != null && dp.PageSize > 0)
                //    {
                //        dr.NextResult();
                //        dr.Read();
                //        dp.RowCount = dr.GetInt32(0);
                //        dp.ExeTime = (DateTime.Now - dNow).TotalMilliseconds;
                //    }
                //    dr.Close();
                //}
            }
            catch (Exception ex)
            {
                //string errStr = "SelectList<T>报错:\r\n" + SqlAid.SqlParameterWrapperToString(cmd.Parameters) + "\r\n"
                //    + cmd.CommandText;
                //throw new Exception(errStr, ex);
                throw new Exception();
            }
            return list;
        }

        #region (根据指定的字段)查询实体列表 key-value
        /// <summary>(根据指定的字段)查询实体列表 key-value</summary>
        /// <typeparam name="T">对象</typeparam>
        /// <param name="paramArrary">参数集合</param>
        /// <param name="isWriteDb">默认为写库</param>
        /// <param name="dp">分页</param>
        public static List<T> SelectList<T>(object[,] paramArrary, DataPage dp = null
            , bool isWriteDb = true) where T : class,ITableBase<T>, new()
        {
            T tempT = new T();
            if (dp != null && dp.OrderField == null)
            {
                dp.OrderField = tempT.GetPkName() + " desc";
            }

            NameValueCollection nameValues = new NameValueCollection();
            if (paramArrary == null || paramArrary.GetLength(1) != 2)
            {
                return null;
            }
            for (int i = 0; i < paramArrary.GetLength(0); i++)
            {
                string key = string.Empty;
                string value = string.Empty;
                for (int j = 0; j < paramArrary.GetLength(1); j++)
                {
                    if (j == 0)
                    {
                        key = paramArrary[i, j].ToString();
                    }
                    else if (j == 1)
                    {
                        value = paramArrary[i, j].ToString();
                    }
                }
                nameValues.Add(key, value);
            }

            Tuple<string, List<SqlParameter>> whereSql = SqlAid.GetWhereSql<T>(nameValues);
            return SelectList<T>(tempT.GetSelectSql() + whereSql.Item1, whereSql.Item2, dp, isWriteDb);
        }
        #endregion
        #endregion

        #region SelectDataTable
        /// <summary>生成查询sql并执行得到对象集合</summary>
        /// <typeparam name="T">对象</typeparam>
        /// <param name="nameValues">参数集合</param>
        /// <param name="isWriteDb">默认为写库</param>
        /// <param name="dp">分页</param>
        public static DataTable SelectDataTable<T>(NameValueCollection nameValues, DataPage dp = null
            , bool isWriteDb = true) where T : class,ITableBase<T>, new()
        {
            T tempT = new T();
            if (dp != null && dp.OrderField == null) dp.OrderField = tempT.GetPkName() + " desc";
            Tuple<string, List<SqlParameter>> whereSql = SqlAid.GetWhereSql<T>(nameValues);
            return SelectDataTable(tempT.GetSelectSql() + whereSql.Item1, whereSql.Item2, tempT.GetDbName(), dp, isWriteDb);
        }
        /// <summary>生成查询sql并执行得到对象集合</summary>
        /// <param name="sql">sql语句</param>
        /// <param name="parameterList">参数</param>
        /// <param name="isWriteDb">默认为写库</param>
        /// <param name="dbName">库名</param>
        /// <param name="dp">分页</param>
        public static DataTable SelectDataTable(string sql, List<SqlParameter> parameterList, string dbName
            , DataPage dp = null, bool isWriteDb = true)
        {
            DateTime dNow = DateTime.Now;
            DataTable dt = new DataTable();
            Tuple<string, List<SqlParameter>> pageSql = SqlAid.GetPageSql(sql, dp);
            //Database dbTcFly = isWriteDb ? DatabaseFactory.GetWriteDatabase(dbName) : DatabaseFactory.GetReadDatabase(dbName);
            //DbCommand cmd = dbTcFly.GetSqlStringCommand(pageSql.Item1);
            //foreach (var par in parameterList)
            //    cmd.Parameters.Add(par);
            //foreach (var par in pageSql.Item2)
            //    cmd.Parameters.Add(par);
            try
            {
                //DataSet ds = dbTcFly.ExecuteDataSet(cmd);
                //if (ds.Tables.Count == 1)
                //{
                //    dt = ds.Tables[0];
                //}
                //else if (dp != null && ds.Tables.Count > 1)
                //{
                //    dt = ds.Tables[1];
                //    dp.RowCount = (int)ds.Tables[0].Rows[0][0];
                //    dp.ExeTime = (DateTime.Now - dNow).TotalMilliseconds;
                //}

                throw new Exception();
            }
            catch (Exception ex)
            {
                //string errStr = "SelectDataTable<T>报错:\r\n" + SqlAid.SqlParameterWrapperToString(cmd.Parameters) + "\r\n"
                // + cmd.CommandText;
                //throw new Exception(errStr, ex);
                throw new Exception();
            }
            return dt;
        }
        #endregion

        //#region Add
        ///// <summary>实体数据插入到数据库</summary>
        ///// <param name="model">实体</param>
        ///// <returns>主键</returns>
        //public static int Add<T>(ITableBase<T> model) where T : class,new()
        //{
        //    string dbName = model.GetDbName();
        //    string sql = model.GetInsertSql() + "select isnull(@@identity,0)";
        //    List<SqlParameter> parList = model.ToSqlParameters(false);
        //    try
        //    {
        //        Database dataBase = GetDb(dbName);
        //        SqlParameterWrapperCollection paramCollection = GetWrapperCollection(parList);
        //        return SqlHelper.ExecuteIdentity(dataBase, sql, paramCollection);
        //    }
        //    catch (Exception ex)
        //    {
        //        string errStr = "执行Add<T>报错:\r\n" + SqlAid.SqlParameterWrapperToString(parList) + "\r\n" + sql;
        //        throw new Exception(errStr, ex);
        //    }
        //}
        ///// <summary>
        ///// 实体数据插入到数据库
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="model"></param>
        ///// <param name="tran"></param>
        ///// <returns></returns>
        //public static int Add<T>(ITableBase<T> model, DbTransaction tran) where T : class,new()
        //{
        //    string dbName = model.GetDbName();
        //    string sql = model.GetInsertSql() + "select isnull(@@identity,0)";
        //    List<SqlParameter> parList = model.ToSqlParameters(false);
        //    try
        //    {
        //        Database dataBase = GetDb(dbName);
        //        SqlParameterWrapperCollection paramCollection = GetWrapperCollection(parList);
        //        return SqlHelper.ExecuteIdentity(dataBase, sql, paramCollection, tran);
        //    }
        //    catch (Exception ex)
        //    {
        //        string errStr = "执行Add<T>报错:\r\n" + SqlAid.SqlParameterWrapperToString(parList) + "\r\n" + sql;
        //        throw new Exception(errStr, ex);
        //    }
        //}
        //#endregion

        #region update
        ///// <summary>
        ///// 以主键为条件,更新整个实体
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //public static int Update<T>(T model) where T : class, ITableBase<T>, new()
        //{
        //    int result;
        //    T tempT = new T();
        //    Tuple<string, List<SqlParameter>> updateSql = SqlAid.GetUpdateSql(model);
        //    try
        //    {
        //        Database dbTcFly = GetDb(tempT.GetDbName());
        //        string sql = updateSql.Item1;
        //        SqlParameterWrapperCollection paramCollection = GetWrapperCollection(updateSql.Item2);
        //        result = SqlHelper.ExecuteNonQuery(dbTcFly, sql, paramCollection);
        //    }
        //    catch (Exception ex)
        //    {
        //        string errStr = "Update<T>报错:\r\n" + SqlAid.SqlParameterWrapperToString(updateSql.Item2) + "\r\n"
        //            + updateSql.Item1;
        //        throw new Exception(errStr, ex);
        //    }
        //    return result;
        //}
        ///// <summary>
        ///// 以主键为条件,更新整个实体
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="model"></param>
        ///// <param name="tran"></param>
        ///// <returns></returns>
        //public static int Update<T>(T model, DbTransaction tran) where T : class, ITableBase<T>, new()
        //{
        //    int result;
        //    T tempT = new T();
        //    Tuple<string, List<SqlParameter>> updateSql = SqlAid.GetUpdateSql(model);
        //    try
        //    {
        //        Database dbTcFly = GetDb(tempT.GetDbName());
        //        string sql = updateSql.Item1;
        //        SqlParameterWrapperCollection paramCollection = GetWrapperCollection(updateSql.Item2);
        //        result = SqlHelper.ExecuteNonQuery(dbTcFly, sql, paramCollection, tran);
        //    }
        //    catch (Exception ex)
        //    {
        //        string errStr = "Update<T>报错:\r\n" + SqlAid.SqlParameterWrapperToString(updateSql.Item2) + "\r\n"
        //            + updateSql.Item1;
        //        throw new Exception(errStr, ex);
        //    }
        //    return result;
        //}

        ///// <summary>
        ///// 以主键为条件,更新指定字段
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="keyValue"></param>
        ///// <param name="updateColumns"></param>
        ///// <returns></returns>
        //public static int Update<T>(long keyValue, NameValueCollection updateColumns) where T : class, ITableBase<T>, new()
        //{
        //    T tempT = new T();
        //    if (updateColumns == null)
        //    {
        //        updateColumns = new NameValueCollection();
        //    }
        //    updateColumns.Add(tempT.GetPkName(), keyValue.ToString());
        //    return Update<T>(updateColumns);
        //}
        /// <summary>
        /// 以主键为条件,更新指定字段
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keyValue"></param>
        /// <param name="updateColumns"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        public static int Update<T>(long keyValue, NameValueCollection updateColumns,
            DbTransaction tran) where T : class, ITableBase<T>, new()
        {
            T tempT = new T();
            if (updateColumns == null)
            {
                updateColumns = new NameValueCollection();
            }
            updateColumns.Add(tempT.GetPkName(), keyValue.ToString());
            return Update<T>(updateColumns, tran);
        }

        ///// <summary>
        ///// 以主键为条件,更新指定列
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="nameValues"></param>
        ///// <returns></returns>
        //private static int Update<T>(NameValueCollection nameValues) where T : class,ITableBase<T>, new()
        //{
        //    int result;
        //    T tempT = new T();
        //    Tuple<string, List<SqlParameter>> updateSql = SqlAid.GetUpdateSql<T>(nameValues);
        //    try
        //    {
        //        Database dbTcFly = GetDb(tempT.GetDbName());
        //        string sql = updateSql.Item1;
        //        SqlParameterWrapperCollection paramCollection = GetWrapperCollection(updateSql.Item2);
        //        result = SqlHelper.ExecuteNonQuery(dbTcFly, sql, paramCollection);
        //    }
        //    catch (Exception ex)
        //    {
        //        string errStr = "Update<T>报错:\r\n" + SqlAid.SqlParameterWrapperToString(updateSql.Item2) + "\r\n"
        //            + updateSql.Item1;
        //        throw new Exception(errStr, ex);
        //    }
        //    return result;
        //}
        /// <summary>
        /// 以主键为条件,更新指定列
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="nameValues"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        private static int Update<T>(NameValueCollection nameValues, DbTransaction tran) where T : class,ITableBase<T>, new()
        {
            int result = 0;
            T tempT = new T();
            Tuple<string, List<SqlParameter>> updateSql = SqlAid.GetUpdateSql<T>(nameValues);
            try
            {
                //Database dbTcFly = GetDb(tempT.GetDbName());
                //string sql = updateSql.Item1;
                //SqlParameterWrapperCollection paramCollection = GetWrapperCollection(updateSql.Item2);
                //result = SqlHelper.ExecuteNonQuery(dbTcFly, sql, paramCollection, tran);
                throw new Exception();
            }
            catch (Exception ex)
            {
                //string errStr = "Update<T>报错:\r\n" + SqlAid.SqlParameterWrapperToString(updateSql.Item2) + "\r\n"
                //    + updateSql.Item1;
                //throw new Exception(errStr, ex);
            }
            return result;
        }
        #endregion

        #region delete
        /// <summary>
        /// 删除(根据主键删除)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public static int Del<T>(long keyValue) where T : class,ITableBase<T>, new()
        {
            T tempT = new T();
            string sql = tempT.GetDeleteSql();
            // SqlParameterWrapper par = new SqlParameterWrapper("@" + tempT.GetPkName(), tempT.PkValue);
            try
            {
                //Database dbTcFly = GetDb(tempT.GetDbName());
                //return SqlHelper.ExecuteNonQuery(dbTcFly, sql, par);
            }
            catch (Exception ex)
            {
                //string errStr = "执行Del<T>报错:\r\n"
                //    + SqlAid.SqlParameterWrapperToString(new SqlParameterWrapperCollection { par })
                //    + "\r\n" + sql;
                //throw new Exception(errStr, ex);
            }
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="tran"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static int Del<T>(long keyValue, DbTransaction tran) where T : class,ITableBase<T>, new()
        {
            T tempT = new T();
            string sql = tempT.GetDeleteSql();
            //SqlParameterWrapper par = new SqlParameterWrapper("@" + tempT.GetPkName(), tempT.PkValue);
            //try
            //{
            //    Database dbTcFly = GetDb(tempT.GetDbName());
            //    return SqlHelper.ExecuteNonQuery(dbTcFly, sql, par, tran);
            //}
            //catch (Exception ex)
            //{
            //    string errStr = "执行Del<T>报错:\r\n"
            //        + SqlAid.SqlParameterWrapperToString(new SqlParameterWrapperCollection { par })
            //        + "\r\n" + sql;
            //    throw new Exception(errStr, ex);
            //}
            return 0;
        }

        #endregion

        #region 获取数据库

        ///// <summary>
        ///// 获取数据库
        ///// </summary>
        ///// <param name="isWriteDb"></param>
        ///// <param name="dbName"></param>
        ///// <returns></returns>
        //private static Database GetDb(DbConfig dbName, bool isWriteDb = true)
        //{
        //    return GetDb(dbName.ToString(), isWriteDb);
        //}

        ///// <summary>
        ///// 获取数据库
        ///// </summary>
        ///// <param name="isWriteDb"></param>
        ///// <param name="dbName"></param>
        ///// <returns></returns>
        //private static Database GetDb(string dbName, bool isWriteDb = true)
        //{
        //    if (isWriteDb)
        //    {
        //        return DatabaseFactory.GetWriteDatabase(dbName);
        //    }
        //    return DatabaseFactory.GetReadDatabase(dbName);
        //}

        #endregion

        #region 获取sql注释

        /// <summary>
        /// 获取sql注释
        /// </summary>
        /// <param name="author">作者</param>
        /// <param name="st"></param>
        /// <returns></returns>
        private static string GetSqlNote(string author, StackTrace st)
        {
            string sqlNote = string.Empty;
            try
            {
                string methodName = st.GetFrame(1).GetMethod().Name;
                string className = st.GetFrame(1).GetMethod().ReflectedType.Name;
                //方法详细描述：类名+方法名
                string methodDesc = string.Format("{0}_{1}", className, methodName);
                sqlNote = string.Format(" --Flat:{0}/Author:{1}/For:{2}/File:{3}/Fun:{4}",
                "TCFlightBook", author, methodDesc, className, methodName);
            }
            catch (Exception ex)
            {
                // ExceptionService.Instance.RecordException(ex, "获取sql注释异常");
            }
            return sqlNote;
        }

        #endregion

        //#region SqlParameterCollection转化为SqlParameterWrapperCollection
        ///// <summary>
        ///// SqlParameterCollection转化为SqlParameterWrapperCollection
        ///// </summary>
        ///// <param name="parameterList"></param>
        ///// <returns></returns>
        //private static SqlParameterWrapperCollection GetWrapperCollection(List<SqlParameter> parameterList)
        //{
        //    SqlParameterWrapperCollection sqlWrapperCollection = new SqlParameterWrapperCollection();
        //    if (parameterList == null || parameterList.Count <= 0)
        //    {
        //        return sqlWrapperCollection;
        //    }
        //    foreach (SqlParameter key in parameterList)
        //    {
        //        /* 以后出了问题再改这边的代码
        //        //Start: Added by zhijie on 2014-04-10 for datetime convert error
        //        if (key.DbType == DbType.DateTime && key.Value != null && DateTime.Parse(key.Value.ToString()).Year < 1900)
        //        {
        //            key.Value = new DateTime(1900, 1, 1);
        //        }
        //        //End: Added by zhijie on 2014-04-10 for datetime convert error
        //         * */
        //        sqlWrapperCollection.Add(new SqlParameterWrapper(key.ParameterName, key.Value));
        //    }
        //    return sqlWrapperCollection;
        //}
        //#endregion

        //#region 采用SqlDataAdapter批量更新
        ///// <summary>
        ///// 采用SqlDataAdapter批量更新
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="modelList"></param>
        ///// <param name="updateColumns"></param>
        ///// <returns></returns>
        //public static bool UpdateList<T>(List<T> modelList, List<TableColumn> updateColumns) where T : class,ITableBase<T>, new()
        //{
        //    T tempT = new T();
        //    try
        //    {
        //        Database dbTcFly = GetDb(tempT.GetDbName());
        //        if (dbTcFly == null)
        //        {
        //            throw new Exception("DB Is Null");
        //        }
        //        Dictionary<string, object> pkValues = tempT.GetPkValues();
        //        string selectSql = string.Format("SELECT ");
        //        string updateSql = string.Format("UPDATE {0}.dbo.{1} SET ", tempT.GetDbName(), tempT.GetTableName());
        //        List<SqlParameter> paramList = new List<SqlParameter>();
        //        List<string> columnNameList = new List<string>();
        //        foreach (TableColumn column in updateColumns)
        //        {
        //            if (pkValues.ContainsKey(column.ColumnName))
        //            {
        //                //更新列包含主键不更新
        //                continue;
        //            }
        //            columnNameList.Add(column.ColumnName);
        //            selectSql += string.Format(" {0},", column.ColumnName);
        //            updateSql += string.Format(" {0}=@{0},", column.ColumnName);
        //            paramList.Add(new SqlParameter("@" + column.ColumnName, column.DbType, column.ColumnSize, column.ColumnName));
        //        }
        //        updateSql = updateSql.TrimEnd(',') + " where 1=1 ";
        //        foreach (var pkValue in pkValues)
        //        {
        //            columnNameList.Add(pkValue.Key);
        //            selectSql += string.Format(" {0},", pkValue.Key);
        //            updateSql += " and " + pkValue.Key + "=@" + pkValue.Key;
        //            paramList.Add(new SqlParameter("@" + pkValue.Key, SqlDbType.Int, 8, pkValue.Key));
        //        }
        //        selectSql = selectSql.TrimEnd(',') + string.Format(" FROM {0}.dbo.{1} WITH(NOLOCK) WHERE 0=1 ",
        //            tempT.GetDbName(), tempT.GetTableName());
        //        DataTable dt = TableHelper.ToDataTable(modelList, columnNameList);
        //        if (dt == null || dt.Rows.Count <= 0)
        //        {
        //            throw new Exception("ToDataTable Error");
        //        }
        //        using (SqlConnection conn = new SqlConnection(dbTcFly.ConnectionString))
        //        {
        //            conn.Open();
        //            SqlDataAdapter sd = new SqlDataAdapter();
        //            sd.SelectCommand = new SqlCommand(selectSql, conn);
        //            sd.UpdateCommand = new SqlCommand(updateSql, conn);
        //            sd.UpdateCommand.Parameters.AddRange(paramList.ToArray());
        //            sd.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;
        //            sd.UpdateBatchSize = 0;
        //            DataSet dataset = new DataSet();
        //            sd.Fill(dataset);
        //            dataset.Tables[0].Clear();
        //            foreach (DataRow row in dt.Rows)
        //            {
        //                dataset.Tables[0].ImportRow(row);
        //            }
        //            sd.Update(dataset.Tables[0]);
        //            dataset.Tables[0].Clear();
        //            sd.Dispose();
        //            dataset.Dispose();
        //            conn.Close();
        //        }
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("UpdateList<T>异常", ex);
        //    }
        //}
        //#endregion

        //#region 采用SqlBulkCopy批量插入
        ///// <summary>
        ///// 采用SqlBulkCopy批量插入
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="modelList"></param>
        ///// <returns></returns>
        //public static bool AddList<T>(List<T> modelList) where T : class,ITableBase<T>, new()
        //{
        //    T tempT = new T();
        //    try
        //    {
        //        Database dbTcFly = GetDb(tempT.GetDbName());
        //        if (dbTcFly == null)
        //        {
        //            throw new Exception("DB Is Null");
        //        }
        //        DataTable dt = TableHelper.ToDataTable(modelList);
        //        SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(dbTcFly.ConnectionString);
        //        sqlBulkCopy.DestinationTableName = tempT.GetTableName();
        //        sqlBulkCopy.WriteToServer(dt);
        //        sqlBulkCopy.Close();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("AddList<T>异常", ex);
        //    }
        //}
        //#endregion
    }
}
