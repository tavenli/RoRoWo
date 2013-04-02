using RoRoWo.Blog.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using RoRoWo.Blog.Domain;
using RoRoWo.Blog.Domain.Entities;
using RoRoWo.Blog.Infrastructure;
using RoRoWo.Blog.Repository;
using RoRoWo.Blog.Model;

using System.Configuration;
using RoRoWo.Blog.IoC;

namespace RoRoWo.Blog.UnitTest
{


    /// <summary>
    ///这是 ArticleServicesTest 的测试类，旨在
    ///包含所有 ArticleServicesTest 单元测试
    ///</summary>
    [TestClass()]
    public class ArticleServicesTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试特性
        // 
        //编写测试时，还可使用以下特性:
        //
        //使用 ClassInitialize 在运行类中的第一个测试前先运行代码
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //使用 ClassCleanup 在运行完类中的所有测试后再运行代码
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //使用 TestInitialize 在运行每个测试前先运行代码
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //使用 TestCleanup 在运行完每个测试后运行代码
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        [TestInitialize()]
        public void IoCInit()
        {
            //初始化IoC
            IoCHelper.InitializeWith(new DependencyResolverFactory());
        }

        /// <summary>
        ///NewArcitle 的测试
        ///</summary>
        [TestMethod()]
        public void NewArcitleTest()
        {
            IArticleServices article = IoCHelper.Resolve<IArticleServices>("articleServices");
            
            BlogArticle model = new BlogArticle();
            int expected = 0;
            int actual = 0;

            model.Title = "测试标题" + new Random().Next(100000, 999999).ToString();
            model.IsTop = true;

            model.Content = "这里是内容--ArticleServices--NewArcitleTest";
            model.PublishTime = DateTime.Now;
            model.CreateTime = DateTime.Now;
            model.UpdateTime = DateTime.Now;

            actual = article.NewArcitle(model, 2);

            Assert.IsTrue(expected < actual);
        }
    }
}
