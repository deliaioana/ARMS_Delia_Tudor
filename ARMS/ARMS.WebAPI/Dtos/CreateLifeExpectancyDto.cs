namespace ARMS.WebAPI.Dtos
{
    public class CreateLifeExpectancyDto
    {
        public int Year { get; set; }
        public string CountryName { get; set; }
        public float MaleLifeExpectancy { get; set; }
        public float FemaleLifeExpectancy { get; set; }
    }
}
