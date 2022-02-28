namespace PlanejaOdonto.Api.Application.Resources.Dentist
{
    public class DentistResource
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Name { get; set; }

        public int FranchiseId { get; set; }

        public string Category { get; set; }
    }
}
