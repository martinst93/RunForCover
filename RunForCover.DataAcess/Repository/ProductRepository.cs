using RunForCover.Data;
using RunForCover.DataAcess.Repository.IRepository;
using RunForCover.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunForCover.DataAcess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly RunForCoverDbContext _db;

        public ProductRepository(RunForCoverDbContext db) : base (db)
        {
            _db = db;
        }

        public void Update(Product obj)
        {
            var objFormDb = _db.Products.FirstOrDefault(x => x.Id == obj.Id);

            if (objFormDb != null)
            {
                objFormDb.Title = obj.Title;
                objFormDb.Description = obj.Description;
                objFormDb.Category = obj.Category;
                objFormDb.CoverType = obj.CoverType;
                objFormDb.CoverTypeId = obj.CoverTypeId;
                objFormDb.Description = obj.Description;
                objFormDb.Author = obj.Author;
                objFormDb.ISBN = obj.ISBN;
                objFormDb.ListPrice = obj.ListPrice;
                objFormDb.Price = obj.Price;
                objFormDb.Price100 = obj.Price100;
                objFormDb.Price50 = obj.Price50;
                objFormDb.CategoryId = obj.CategoryId;

                if (obj.ImageUrl != null)
                {
                    objFormDb.ImageUrl = obj.ImageUrl;
                }
            }
        }
    }
}
