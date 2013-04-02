using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.Objects;
using System.Linq.Expressions;
using RoRoWo.Blog.Domain;
using RoRoWo.Blog.Domain.Entities;
using RoRoWo.Blog.Domain.Specification;
using RoRoWo.Blog.Model;
using RoRoWo.Blog.Repository;

namespace RoRoWo.Blog.Infrastructure.Repository
{
    public class CategoryRepository : BaseRepository<BlogCategory>, ICategoryRepository
    {
        public CategoryRepository(IUnitOfWork _context) : base(_context) { }
                
    }
}
