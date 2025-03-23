namespace SurvivorWebApiEF.Entities
{
    public class CategoryEntity : BaseEntity
    {
        public string Name { get; set; }

        //Relational Property
        public List<CompetitorEntity> Competitors { get; set; }

    }

}