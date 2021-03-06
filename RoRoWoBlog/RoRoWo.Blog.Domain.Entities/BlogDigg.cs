//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace RoRoWo.Blog.Domain.Entities
{
    public partial class BlogDigg
    {
        #region Primitive Properties
    
        public virtual int AutoID
        {
            get;
            set;
        }
    
        public virtual string DiggName
        {
            get;
            set;
        }
    
        public virtual int SurpportType
        {
            get;
            set;
        }
    
        public virtual int State
        {
            get;
            set;
        }
    
        public virtual string IP
        {
            get;
            set;
        }
    
        public virtual System.DateTime CreateTime
        {
            get;
            set;
        }
    
        public virtual Nullable<int> BlogArticle_ArticleID
        {
            get { return _blogArticle_ArticleID; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_blogArticle_ArticleID != value)
                    {
                        if (BlogArticle != null && BlogArticle.ArticleID != value)
                        {
                            BlogArticle = null;
                        }
                        _blogArticle_ArticleID = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private Nullable<int> _blogArticle_ArticleID;

        #endregion
        #region Navigation Properties
    
        public virtual BlogArticle BlogArticle
        {
            get { return _blogArticle; }
            set
            {
                if (!ReferenceEquals(_blogArticle, value))
                {
                    var previousValue = _blogArticle;
                    _blogArticle = value;
                    FixupBlogArticle(previousValue);
                }
            }
        }
        private BlogArticle _blogArticle;

        #endregion
        #region Association Fixup
    
        private bool _settingFK = false;
    
        private void FixupBlogArticle(BlogArticle previousValue)
        {
            if (previousValue != null && previousValue.BlogDigg.Contains(this))
            {
                previousValue.BlogDigg.Remove(this);
            }
    
            if (BlogArticle != null)
            {
                if (!BlogArticle.BlogDigg.Contains(this))
                {
                    BlogArticle.BlogDigg.Add(this);
                }
                if (BlogArticle_ArticleID != BlogArticle.ArticleID)
                {
                    BlogArticle_ArticleID = BlogArticle.ArticleID;
                }
            }
            else if (!_settingFK)
            {
                BlogArticle_ArticleID = null;
            }
        }

        #endregion
    }
}
