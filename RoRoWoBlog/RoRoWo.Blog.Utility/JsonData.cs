using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace RoRoWo.Blog.Utility
{
    [DataContract]
    public class JsonData<T>
    {
        /// <summary>
        /// 信息状态    可区分消息的类型或状态 例如： 0为失败信息 1为成功信息
        /// </summary>
        [DataMember]
        public int State { get; set; }

        /// <summary>
        /// 影响的数据条数或总记录数
        /// </summary>
        [DataMember]
        public int Count { get; set; }

        /// <summary>
        /// 所受影响的标识ID
        /// </summary>
        [DataMember]
        public string IDs { get; set; }

        /// <summary>
        /// 消息内容    失败或成功的提示信息
        /// </summary>
        [DataMember]
        public string Msg { get; set; }

        /// <summary>
        /// 消息数组    用户存放其它信息(可以用来存放多个单数据信息)
        /// </summary>
        [DataMember]
        public string[] MsgArray { get; set; }

        /// <summary>
        /// 数据对象    返回的JSON数据对象或对象集合
        /// </summary>
        [DataMember]
        public T Data { get; set; }
    }

}
