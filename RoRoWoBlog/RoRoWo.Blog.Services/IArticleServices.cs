using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Linq.Expressions;
using RoRoWo.Blog.Repository;
using RoRoWo.Blog.Domain;
using RoRoWo.Blog.Domain.Entities;
using RoRoWo.Blog.Model;

namespace RoRoWo.Blog.Services
{
    public interface IArticleServices : IBaseServices<BlogArticle>
    {
        int NewArcitle(BlogArticle model, int cateid);
    }

}
