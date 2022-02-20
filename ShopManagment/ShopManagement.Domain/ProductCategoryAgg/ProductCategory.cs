using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public class ProductCategory:EntityBase
    {
        public string  Name { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string MetaDescription { get; set; }
        public string Keyword { get; set; }
        public string Slug { get; set; }
        public List<Product> Products { get; set; }

        public ProductCategory(string name, string picture, string pictureAlt, string pictureTitle, string metaDescription, string keyword, string slug)
        {
            Name = name;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            MetaDescription = metaDescription;
            Keyword = keyword;
            Slug = slug;
            Products = new List<Product>();
        }

        public void Edit(string name, string picture, string pictureAlt, string pictureTitle, string metaDescription, string keyword, string slug)
        {
            Name = name;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            MetaDescription = metaDescription;
            Keyword = keyword;
            Slug = slug;
        }



    }
}
