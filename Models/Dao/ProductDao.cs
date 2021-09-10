using Models.EntityFramework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
    public class ProductDao
    {
        ShopGameDbContext db = null;
        public ProductDao()
        {
            db = new ShopGameDbContext();
        }
        public long Insert(Product entity)
        {
            db.Products.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(Product entity)
        {
            var product = db.Products.Find(entity.ID);
            product.Name = entity.Name;
            product.Code = entity.Code;
            product.MetaTitle = entity.MetaTitle;
            product.Description = entity.Description;
            product.Image = entity.Image;
            product.Price = entity.Price;
            product.PromotionPrice = entity.PromotionPrice;
            product.CategoryID = entity.CategoryID;
            product.Quantity = entity.Quantity;
            db.SaveChanges();
            return true;
        }
        public IEnumerable<Product> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Product> model = db.Products;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.Code.Contains(searchString)|| x.Description.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        public Product GetById(string name)
        {
            return db.Products.SingleOrDefault(x => x.Name == name);
        }
        public Product ViewDetail(int id)
        {
            return db.Products.Find(id);
        }
        public bool Delete(int id)
        {
            var product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return true;

        }
        public List<Product> ListNewProduct(int top)
        {
            return db.Products.OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }
        public List<Product> ListFeatureProduct(int top)
        {
            return db.Products.Where(x => x.TopHot != null && x.TopHot > DateTime.Now).OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }
        public Product ViewDetail(long id)
        {
            return db.Products.Find(id);
        }
    }
}
