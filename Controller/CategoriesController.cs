using Microsoft.AspNetCore.Mvc;
using SurvivorWebApiEF.Context;
using SurvivorWebApiEF.Entities;
using SurvivorWebApiEF.Models;
using SurvivorWebApiEF.Models.Categories;

namespace SurvivorWebApiEF.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly SurvivorDbContext _db;
        public CategoriesController(SurvivorDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public IActionResult Post(CategoryAddRequest request)
        {
            var category = new CategoryEntity
            {
                Name = request.Name
            };
            _db.Categories.Add(category);
            _db.SaveChanges();


            return Created();

        }



        [HttpGet]
        public IActionResult ListAll()
        {
            var response = _db.Categories.Where(x => x.IsDeleted == false).OrderBy(x => x.Name).Select(x => new CategoryListAllResponse { Name = x.Name, Id = x.Id }).ToList();

            return Ok(response);

        }

        [HttpGet("{id}")]
        public IActionResult List(int id)
        {
            var category = _db.Categories.FirstOrDefault(x => x.Id == id);
            if (category is null)
            {
                return NotFound();
            }
            var response = new CategoryListAllResponse
            {
                Name = category.Name,
                Id = category.Id
            };


            return Ok(response);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CategoryUpdateRequest request)
        {
            var category = _db.Categories.FirstOrDefault(x => x.Id == id);
            if (category is null)
            {
                return NotFound();
            }

            category.Name = request.Name;
            _db.Categories.Update(category);
            _db.SaveChanges();
            return Ok("it is updated.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = _db.Categories.Find(id);
            if (category is null)
            {
                return NotFound();
            }
            category.IsDeleted = true;
            _db.Categories.Update(category);
            _db.SaveChanges();
            return Ok();
        }




    }
}