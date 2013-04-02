
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq.Expressions;
using RoRoWo.Blog.Domain;
using RoRoWo.Blog.Domain.Entities;
using RoRoWo.Blog.Repository;
using RoRoWo.Blog.Infrastructure;
using System.Collections.Generic;
using RoRoWo.Blog.Services;
using RoRoWo.Blog.Model;

using System.Configuration;
using RoRoWo.Blog.IoC;
using RoRoWo.Blog.Utility;
using RoRoWo.Blog.Domain.Specification;

using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace RoRoWo.Blog.UnitTest
{


    /// <summary>
    ///这是 ArticleRepositoryTest 的测试类，旨在
    ///包含所有 ArticleRepositoryTest 单元测试
    ///</summary>
    [TestClass()]
    public class ArticleRepositoryTest
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


        /// <summary>
        ///FindAll 的测试
        ///</summary>
        public void FindAllTestHelper<S>()
        {

        }

        [TestInitialize()]
        public void IoCInit()
        {
            //初始化IoC
            IoCHelper.InitializeWith(new DependencyResolverFactory());
        }
        
        /// <summary>
        ///GetList 的测试
        ///</summary>
        [TestMethod()]
        public void GetListTest()
        {
            //使用IoC测试
            //IUnityContainer container = new UnityContainer();
            //UnityConfigurationSection section = ConfigurationManager.GetSection("unity") as UnityConfigurationSection;
            //section.Configure(container, "ContainerEF");
            //IArticleRepository target = container.Resolve<IArticleRepository>("articleRepository"); 

            //固定代码测试
            //RoRoWoDBEntities context = new RoRoWoDBEntities();            
            //ArticleRepository target = new ArticleRepository(context);

            //使用 IoCHelper 测试            
            IArticleRepository target = IoCHelper.Resolve<IArticleRepository>("articleRepository");

            IEnumerable<BlogArticle> list = target.GetList();

            Assert.IsTrue(list != null);
        }

        [TestMethod()]
        public void GetListTest1()
        {

            //固定代码测试
            RoRoWoDBEntities context = new RoRoWoDBEntities();
            RoRoWo.Blog.Infrastructure.Repository.ArticleRepository target = new RoRoWo.Blog.Infrastructure.Repository.ArticleRepository(context);

            IEnumerable<BlogArticle> list = target.GetList();

            Assert.IsTrue(list != null);
        }

        [TestMethod()]
        public void GetListTest2()
        {

            //使用 IoCHelper 测试 （不指定 Name 注入） 
            IArticleRepository target = IoCHelper.Resolve<IArticleRepository>();

            IEnumerable<BlogArticle> list = target.GetList();

            //测试序列化成JSON数据
            string json = SerializeHelper.JsonSerialize(list);

            Assert.IsTrue(list != null);
        }

        [TestMethod()]
        public void GetListTest3()
        {

            //使用IoC测试
            IUnityContainer container = new UnityContainer();
            UnityConfigurationSection section = ConfigurationManager.GetSection("unity") as UnityConfigurationSection;
            section.Configure(container, "ContainerEF");
            IArticleRepository target = container.Resolve<IArticleRepository>();

            IEnumerable<BlogArticle> list = target.GetList();

            Assert.IsTrue(list != null);
        }

        [TestMethod()]
        public void FindAllTest()
        {

            IArticleRepository target = IoCHelper.Resolve<IArticleRepository>();

            int PageIndex = 1;
            int PageSize = 10;
            Expression<Func<BlogArticle, bool>> condition = x => x.ArticleID > 0;
            Expression<Func<BlogArticle, int>> orderByExpression = x => x.ArticleID;
            bool IsDESC = true;

            ISpecification<BlogArticle> specification = new DirectSpecification<BlogArticle>(condition);

            PageData<BlogArticle> left;
            PageData<BlogArticle> right;
            left = target.Find<int>(PageIndex, PageSize, specification, orderByExpression, IsDESC);
            right = target.FindAll<int>(PageIndex, PageSize, specification, orderByExpression, IsDESC);
            Assert.IsTrue(right.DataList.Count > 0);
            Assert.IsTrue(left.DataList.Count < right.DataList.Count);

        }

        /// <summary>
        ///NewSave 的测试
        ///</summary>
        [TestMethod()]
        public void NewSaveTest()
        {

            //使用 IoCHelper 测试            
            IArticleRepository article = IoCHelper.Resolve<IArticleRepository>();
            ICategoryRepository category = IoCHelper.Resolve<ICategoryRepository>();

            BlogArticle model = new BlogArticle();
            int expected = 0;
            int actual = 0;

            model.Title = "测试标题" + new Random().Next(100000, 999999).ToString();
            model.IsTop = true;

            //model.BlogCategory = category.GetByCondition(new DirectSpecification<BlogCategory>(x => x.CateID == 2));
            model.BlogCategory = category.GetList()[0];

            model.Content = "这里是内容";
            model.PublishTime = DateTime.Now;
            model.CreateTime = DateTime.Now;
            model.UpdateTime = DateTime.Now;

            article.NewSave(model);
            article.SaveChanges();

            Assert.AreEqual(expected, actual);

        }


    }
}
