using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Domain.ProductAgg
{
    public class Product:EntityBase
    {
        public string Name { get; set; }
        public Guid Code { get; set; }
        public bool IsInStock { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string MetaDescription { get; set; }
        public string Keyword { get; set; }
        public string Slug { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public int CategoryId  { get; set; }

        public Product(string name,string picture,string pictureAlt,string pictureTitle,string metaDescription, 
        string keyword,string slug,int categoryId)
        {
            Name = name;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            MetaDescription = metaDescription;
            Keyword = keyword;
            Slug = slug;
            CategoryId = categoryId;
        }

        public void Edit(string name, string picture, string pictureAlt, string pictureTitle, string metaDescription,
            string keyword, string slug, int categoryId)
        {
            Name = name;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            MetaDescription = metaDescription;
            Keyword = keyword;
            Slug = slug;
            CategoryId = categoryId;
        }

        public void InStock()
        {
            IsInStock = true;
        }

        public void NotInStock()
        {
            IsInStock = false;
        }
    }
}
