using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using RoRoWo.Blog.Utility;

namespace RoRoWo.Blog.Common.IoCResolver.Unity
{
    internal sealed class UnityContainerBuilder
    {
        private string _ContainerName = "ContainerEF"; 

        /// <summary>
        /// 默认方式创建
        /// </summary>
        public IUnityContainer BuilderUnityContainer()
        {
            IUnityContainer container = new UnityContainer();

            var paths = this.GetConfigFilePaths();
            paths.ForEach(path => this.Configure(container, path));

            return container;
        }
              
        /// <summary>
        /// 根据默认 App.config 或 Web.config 配置文件创建
        /// </summary>        
        public IUnityContainer BuilderUnityContainerByDefaultConfig()
        {
            IUnityContainer container = new UnityContainer();

            //App.config 或 Web.config 中加载
            UnityConfigurationSection configuration = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            //旧方法
            //configuration.Containers.Default.Configure(_container);
            //默认
            //configuration.Configure(_container);
            //指定
            configuration.Configure(container, _ContainerName);

            return container;
        }

        /// <summary>
        /// 指定配置文件路径方式创建
        /// </summary>
        /// <param name="paths">多个配置文件路径</param>
        public IUnityContainer BuilderUnityContainerByPaths(IEnumerable<string> paths)
        {
            IUnityContainer container = new UnityContainer();

            paths.ForEach(path => this.Configure(container, path));

            return container;
        }

        #region 私有方法

        /// <summary>
        /// 加载配置文件
        /// </summary>
        /// <param name="container">Unity容器对象</param>
        /// <param name="filePath">配置文件名</param>
        private void Configure(IUnityContainer container, string filePath)
        {
            ExeConfigurationFileMap basicFileMap = new ExeConfigurationFileMap
            {
                ExeConfigFilename = filePath
            };

            UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager
                .OpenMappedExeConfiguration(basicFileMap, ConfigurationUserLevel.None)
                .GetSection("unity");

            // TODO(xuefly):考虑configuredContainerName的可变性
            section.Configure(container, _ContainerName);
        }

        /// <summary>
        /// 获取配置文件列表
        /// </summary>
        /// <returns>字符串集合</returns>
        private IEnumerable<string> GetConfigFilePaths()
        {
            //是否采用配置节的"configSource"属性来指定位置
            //这样就可以避免硬编码为"Config/Unity" ^_^
            // Re:查了一下configSource指定的是文件不是文件夹，
            // 如果我们考虑按模块划分成不同配置文件组织的话就需要约定一个存放Unity配置文件的文件夹了。
            // 希望遵循"约定胜于配置原则"，但这里通过web.config的appSettings节点提供了一个配置文件夹位置的机会：索引键为"UnityConfigPath"。
            string path = AppSettingsHelper.GetString("UnityConfigPath", "Config/Unity");// 默认值为"Config/Unity"
            return Directory.GetFiles(Utility.PathHelper.LocateServerPath(path))
                .Where(fullName => Path.GetExtension(fullName).Equals(".config", StringComparison.CurrentCultureIgnoreCase));
        }

        #endregion
    }
}
