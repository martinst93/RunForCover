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
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly RunForCoverDbContext _db;

        public CategoryRepository(RunForCoverDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }
    }
}
