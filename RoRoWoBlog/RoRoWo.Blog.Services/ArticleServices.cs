using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Linq.Expressions;
using RoRoWo.Blog.Repository;
using RoRoWo.Blog.Domain;
using RoRoWo.Blog.Domain.Entities;
using RoRoWo.Blog.Domain.Specification;
using RoRoWo.Blog.Model;

namespace RoRoWo.Blog.Services
{
    public class ArticleServices : BaseServices<BlogArticle>, IArticleServices
    {
        ICategoryRepository categoryRepository;

        public ArticleServices(IUnitOfWork _context, IArticleRepository _Repository, ICategoryRepository _categoryRepository)
            : base(_context, _Repository)
        {
            this.categoryRepository = _categoryRepository;
        }

        public int NewArcitle(BlogArticle model, int cateid)
        {
            ISpecification<BlogCategory> condition = new DirectSpecification<BlogCategory>(x => x.CateID == cateid);
            model.BlogCategory = categoryRepository.GetByCondition(condition);

            return this.NewSave(model);
            
        }



    }
}
