using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RoRoWo.Blog.Domain;
using RoRoWo.Blog.Domain.Entities;
using RoRoWo.Blog.Model;

namespace RoRoWo.Blog.Repository
{
    public interface ICategoryRepository : IRepository<BlogCategory, PageData<BlogCategory>>
    {

        
    }
}
