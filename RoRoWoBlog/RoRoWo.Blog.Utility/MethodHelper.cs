using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Reflection;

namespace RoRoWo.Blog.Utility
{
    public class MethodHelper
    {
        /// <summary>
        /// 执行当前类的方法
        /// </summary>
        /// <param name="o">this</param>
        /// <param name="funcName">方法名</param>
        public static void DoMethod(object o, string funcName)
        {
            BindingFlags flags = BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.InvokeMethod | BindingFlags.IgnoreCase;

            if (o.GetType().BaseType.GetMethod(funcName, flags) != null)
            {
                o.GetType().BaseType.InvokeMember(funcName, flags, null, o, null);
            }
        }

        /// <summary>
        /// 执行指定程序集中的方法
        /// </summary>
        /// <param name="funcName"></param>
        /// <param name="className"></param>
        /// <param name="dllName"></param>
        public static void DoMethod(string funcName, string className, string dllName)
        {
            BindingFlags flags = BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase;
            Type type;
            Assembly ass = Assembly.Load(dllName);
            if (ass != null)
            {
                type = ass.GetType(className);
                if (type != null)
                {
                    object obj = ass.CreateInstance(className);
                    try
                    {
                        MethodInfo method = type.GetMethod(funcName, flags);//方法的名称
                        if (method != null)
                        {
                            method.Invoke(obj, null);
                        }
                    }
                    catch (Exception ex)
                    {
                        //System.Web.HttpContext.Current.Response.Write(ex.ToString());
                    }
                    finally
                    {
                        type = null;
                        obj = null;
                        ass = null;
                    }
                }//if type
            }//if ass
        }


    }
}
