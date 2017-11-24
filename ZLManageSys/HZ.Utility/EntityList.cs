using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;


namespace HZ.Utility
{
    public class EntityList
    {


        /// <summary>
        /// 解析数据表数据转成模型对象列表
        /// 
        /// 目前支持的基本数据类型都支持转换，注意：数据库“字段名称”要跟模型对象的“属性名称”保持一致
        /// 如果数据库没有的字段，模型没有相对的属性，将不会转换，反之一样不转换
        /// 但不支持自定义模型对象转换
        /// </summary>
        /// <typeparam name="T">返回列表的模型类</typeparam>
        /// <param name="dt">数据表</param>
        /// <returns></returns>
        public static List<T> ToList<T>(DataTable dt)
        {

            //获得数据表列记录
            var columnNames = dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName).ToList();
            //获得列表属性型类型
            var properties = typeof(T).GetProperties();

            //返回  IEnumerable<T> 对象，Select()其元素为对 source 的每个元素调用转换函数的结果。
            return dt.AsEnumerable().Select(row =>
            {
                //创建指定函数类型
                var objT = Activator.CreateInstance<T>();
                //遍历记录属性值，
                foreach (var pro in properties)
                {
                    //    //含有对象属性名称的元素
                    if (columnNames.Contains(pro.Name))
                    {
                        //  Boolean 类型对象转换
                        if (pro.PropertyType.Name == "Boolean" && row[pro.Name] != DBNull.Value)
                        {
                            if (Convert.ToInt32(row[pro.Name]) == 1)
                            {
                                pro.SetValue(objT, true, null);
                            }
                            else
                            {
                                pro.SetValue(objT, false, null);
                            }
                        } //非空类型转换
                        else if (row[pro.Name] != DBNull.Value && pro.PropertyType.Name != "Boolean")
                        {
                            //指定对象的属性值
                            pro.SetValue(objT, row[pro.Name], null);
                        }

                        else
                        { //空对象转换
                            if (pro.PropertyType.Name == "string" || pro.PropertyType.Name == "String")
                            {
                                pro.SetValue(objT, "", null);
                            }
                            else
                            {
                                pro.SetValue(objT, null, null);
                            }
                        }
                    }
                }
                return objT;
            }).ToList();

        }
    }
}
