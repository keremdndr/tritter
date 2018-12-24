using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TP.Data
{
    public static class EFDataReaderExtensions
    {
        /// <Summary>
        /// Map data from DataReader to list of objects
        /// </Summary>
        /// <typeparam name="T">Object</typeparam>
        /// <param name="dr">Data Reader</param>
        /// <returns>List of objects having data from data reader</returns>
        public static List<T> MapToList<T>(this DbDataReader dr) where T : new()
        {
            List<T> RetVal = null;
            var Entity = typeof(T);
            var PropDict = new Dictionary<string, PropertyInfo>();
            try
            {
                if (dr != null && dr.HasRows)
                {
                    RetVal = new List<T>();
                    var Props = Entity.GetProperties(BindingFlags.Instance | BindingFlags.Public);
                    PropDict = Props.ToDictionary(p => p.Name.ToUpper(), p => p);
                    while (dr.Read())
                    {
                        T newObject = new T();
                        for (int Index = 0; Index < dr.FieldCount; Index++)
                        {
                            if (PropDict.ContainsKey(dr.GetName(Index).ToUpper()))
                            {
                                var Info = PropDict[dr.GetName(Index).ToUpper()];
                                if ((Info != null) && Info.CanWrite)
                                {
                                    var Val = dr.GetValue(Index);
                                    Info.SetValue(newObject, (Val == DBNull.Value) ? null : Val, null);
                                }
                            }
                        }
                        RetVal.Add(newObject);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return RetVal;
        }

        /// <Summary>
        /// Map data from DataReader to an object
        /// </Summary>
        /// <typeparam name="T">Object</typeparam>
        /// <param name="dr">Data Reader</param>
        /// <returns>Object having data from Data Reader</returns>
        public static T MapToSingle<T>(this DbDataReader dr) where T : new()
        {
            T RetVal = new T();
            var Entity = typeof(T);
            var PropDict = new Dictionary<string, PropertyInfo>();
            try
            {
                if (dr != null && dr.HasRows)
                {
                    var Props = Entity.GetProperties(BindingFlags.Instance | BindingFlags.Public);
                    PropDict = Props.ToDictionary(p => p.Name.ToUpper(), p => p);
                    dr.Read();
                    for (int Index = 0; Index < dr.FieldCount; Index++)
                    {
                        if (PropDict.ContainsKey(dr.GetName(Index).ToUpper()))
                        {
                            var Info = PropDict[dr.GetName(Index).ToUpper()];
                            if ((Info != null) && Info.CanWrite)
                            {
                                var Val = dr.GetValue(Index);
                                Info.SetValue(RetVal, (Val == DBNull.Value) ? null : Val, null);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return RetVal;
        }

        public static TValue GetValue<TValue>(this DbDataReader reader, string fieldName)
        {
            return InvokeMethodWrapedException(InnerGetValue<TValue>, reader, fieldName);
        }

        private static TValue InnerGetValue<TValue>(this DbDataReader reader, string fieldName)
        {
            int ordinal = reader.GetOrdinal(fieldName);
            return reader.GetFieldValue<TValue>(ordinal);
        }

        public static TValue? GetNullableValue<TValue>(this DbDataReader reader, string fieldName)
            where TValue : struct
        {
            return InvokeMethodWrapedException(InnerGetNullableValue<TValue>, reader, fieldName);
        }

        private static TValue? InnerGetNullableValue<TValue>(this DbDataReader reader, string fieldName)
            where TValue : struct
        {
            int ordinal = reader.GetOrdinal(fieldName);
            if (reader.IsDBNull(ordinal))
            {
                return null;
            }
            else
            {
                return reader.GetFieldValue<TValue>(ordinal);
            }
        }

        public static string GetStringValue(this DbDataReader reader, string fieldName)
        {
            return InvokeMethodWrapedException(InnerGetStringValue, reader, fieldName);
        }

        private static string InnerGetStringValue(this DbDataReader reader, string fieldName)
        {
            int ordinal = reader.GetOrdinal(fieldName);
            if (reader.IsDBNull(ordinal))
            {
                return null;
            }
            else
            {
                return reader.GetFieldValue<string>(ordinal);
            }
        }

        private static TResult InvokeMethodWrapedException<TResult>(Func<DbDataReader, string, TResult> func, DbDataReader reader, string fieldName)
        {
            try
            {
                return func.Invoke(reader, fieldName);
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new IndexOutOfRangeException(fieldName, ex);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(fieldName, ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new TaskCanceledException(fieldName, ex);
            }
            catch (OperationCanceledException ex)
            {
                throw new TaskCanceledException(fieldName, ex);
            }
            catch (InvalidCastException ex)
            {
                throw new InvalidCastException(fieldName, ex);
            }
            catch (Exception ex)
            {
                throw new Exception(fieldName, ex);
            }
        }
    }
}