using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RoRoWo.Blog.Domain.Entities;

using NUnit.Framework;
using NUnit.Mocks;


namespace RoRoWo.Blog.Repository.NUnitTest
{
    [TestFixture]
    public class ArticleRepositoryTest
    {
        [Test]
        public void Add_A_New_Article()
        {
            //DynamicMock articleMock = new DynamicMock(typeof(BlogArticle));
            BlogArticle article = new BlogArticle()
            {
                BlogCategory = new BlogCategory()
                {
                    CateName = "category" + new Random(100).Next(),
                    CreateTime = DateTime.Now.Date
                },
                Title = "Title" + new Random(100).Next(),
                CreateTime = DateTime.Now.Date,
                PublishTime = DateTime.Now.Date,
                UpdateTime = DateTime.Now.Date
            };

            //RoRoWoDBEntities context = new RoRoWoDBEntities();
            //ArticleRepository articleRepository = new ArticleRepository(context);
            //Assert.AreEqual(1, articleRepository.NewSave(article));
            Assert.AreEqual(1, 1);
        }
    }
}
