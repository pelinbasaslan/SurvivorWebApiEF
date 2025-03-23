using SurvivorWebApiEF.Entities;
namespace SurvivorWebApiEF.Entities
{
    public class CompetitorEntity : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int CategoryId { get; set; }

        //Relational property

        public CategoryEntity Category { get; set; }


    }

}
