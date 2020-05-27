using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;       //需要手动添加引用集System.Runtime.Serialization方可引用该引用

namespace PCClintSoftware.ToolClass      //该引用空间包含各种工具类
{
    /// <summary>
    /// 用于序列化和反序列化json的工具类，静态类
    /// </summary>
    public static  class JSON
    {
        /// <summary>
        /// 静态方法，序列化json并转化为泛型
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="jsonString">json格式的字符串</param>
        /// <returns>返回值为一个泛型的集合</returns>
        public static T parse<T>(string jsonString)
        {
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
            {
                return (T)new DataContractJsonSerializer(typeof(T)).ReadObject(ms);  //json序列化的核心语句
            }
        }
        /// <summary>
        /// 静态方法，将对象（集合）反序列化为json
        /// </summary>
        /// <param name="jsonObject">需要反序列化的对象</param>
        /// <returns>返回值为一个json字符串</returns>
        public static string stringify(object jsonObject)
        {
            using (var ms = new MemoryStream())
            {
                new DataContractJsonSerializer(jsonObject.GetType()).WriteObject(ms, jsonObject);  //json反序列化的核心语句
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }
     }
}
