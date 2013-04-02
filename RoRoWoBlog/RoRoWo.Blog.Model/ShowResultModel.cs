using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoRoWo.Blog.Model
{
    public class ShowResultModel
    {
        /// <summary>
        /// 提示页面名称
        /// </summary>
        public string PageTitle { get; set; }
        /// <summary>
        /// 提示信息内容
        /// </summary>
        public string TipMsg { get; set; }
        /// <summary>
        /// 转向的URL
        /// </summary>
        public string ReDirectUrl { get; set; }
        /// <summary>
        /// 停止时间 超过时间自动跳转
        /// </summary>
        public int Delay { get; set; }


    }
}
