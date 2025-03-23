using Microsoft.AspNetCore.Mvc;
using SurvivorWebApiEF.Context;
using SurvivorWebApiEF.Entities;
using SurvivorWebApiEF.Models;
using SurvivorWebApiEF.Models.Categories;
using SurvivorWebApiEF.Models.Competitors;

namespace SurvivorWebApiEF.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompetitorsController : ControllerBase
    {
        private readonly SurvivorDbContext _db;
        public CompetitorsController(SurvivorDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public IActionResult Add(CompetitorAddRequest request)
        {
            var competitor = new CompetitorEntity { FirstName = request.FirstName, LastName = request.LastName };
            _db.Competitors.Add(competitor);
            _db.SaveChanges();
            return Created();
        }

        [HttpGet]
        public IActionResult ListAll()
        {
            var response = _db.Competitors.Where(x => x.IsDeleted == false).OrderBy(x => x.FirstName).ThenBy(x => x.LastName).Select(x => new CompetitorListAllResponse { Id = x.Id, FirstName = x.FirstName, LastName = x.LastName }).ToList();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult List(int id)
        {
            var competitor = _db.Competitors.FirstOrDefault(x => x.Id == id);
            if (competitor is null)
            {
                return NotFound();
            }

            var response = new CompetitorListAllResponse
            {
                FirstName = competitor.FirstName,
                LastName = competitor.LastName,
                Id = competitor.Id

            };
            return Ok(response);
        }

        [HttpGet("categories/{categoryid}")]
        public IActionResult ListWithCategoryId(int categoryid)
        {
            var competitor = _db.Competitors.FirstOrDefault(x => x.CategoryId == categoryid);
            if (competitor is null)
            {
                return NotFound();

            }
            var response = new CompetitorCategoryIdResponse { Id = competitor.Id, FirstName = competitor.FirstName, LastName = competitor.LastName, CategoryId = competitor.CategoryId };
            return Ok(response);

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CompetitorAddRequest request)
        {
            var competitor = _db.Competitors.FirstOrDefault(x => x.Id == id);
            if (competitor is null)
            {
                return NotFound();
            }
            competitor.FirstName = request.FirstName;
            competitor.LastName = request.LastName;
            _db.Competitors.Update(competitor);
            _db.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var competitor = _db.Competitors.FirstOrDefault(x => x.Id == id);
            if (competitor is null)
            {
                return NotFound();
            }
            competitor.IsDeleted = true;
            _db.Competitors.Update(competitor);
            _db.SaveChanges();
            return Ok();

        }






    }

}