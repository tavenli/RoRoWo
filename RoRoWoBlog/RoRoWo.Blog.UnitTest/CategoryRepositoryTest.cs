using RoRoWo.Blog.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using System.Linq.Expressions;
using RoRoWo.Blog.Domain;
using RoRoWo.Blog.Domain.Entities;
using RoRoWo.Blog.Domain.Specification;
using RoRoWo.Blog.Infrastructure;
using RoRoWo.Blog.Model;
using System.Configuration;
using RoRoWo.Blog.IoC;

namespace RoRoWo.Blog.UnitTest
{


    /// <summary>
    ///这是 CategoryRepositoryTest 的测试类，旨在
    ///包含所有 CategoryRepositoryTest 单元测试
    ///</summary>
    [TestClass()]
    public class CategoryRepositoryTest
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

        [TestMethod()]
        public void FindAllTest()
        {
            FindAllTestHelper<int>();

            ICategoryRepository target = IoCHelper.Resolve<ICategoryRepository>();

            int PageIndex = 1; // TODO: 初始化为适当的值
            int PageSize = 10; // TODO: 初始化为适当的值
            Expression<Func<BlogCategory, bool>> condition = x => x.CateID > 0; // TODO: 初始化为适当的值
            Expression<Func<BlogCategory, int>> orderByExpression = x => x.CateID; // TODO: 初始化为适当的值
            bool IsDESC = false; // TODO: 初始化为适当的值
            PageData<BlogCategory> expected = null; // TODO: 初始化为适当的值
            PageData<BlogCategory> actual;

            ISpecification<BlogCategory> specification = new DirectSpecification<BlogCategory>(condition);

            actual = target.FindAll<int>(PageIndex, PageSize, specification, orderByExpression, IsDESC);
            Assert.IsTrue(actual.DataList.Count > 0);

        }

        /// <summary>
        ///NewSave 的测试
        ///</summary>
        [TestMethod()]
        public void NewSaveTest()
        {
            ICategoryRepository category = IoCHelper.Resolve<ICategoryRepository>();

            BlogCategory model = new BlogCategory();
            int expected = 0;
            int actual = 0;

            model.CateName = "新分类" + new Random().Next(100000, 999999).ToString();
            model.ParentID = 0;
            model.State = 0;
            model.CreateTime = DateTime.Now;

            category.NewSave(model);
            category.SaveChanges();

            Assert.AreEqual(expected, actual);

        }
    }
}
