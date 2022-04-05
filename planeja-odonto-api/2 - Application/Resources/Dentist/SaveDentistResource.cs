namespace PlanejaOdonto.Api.Application.Resources.Dentist
{
    public class SaveDentistResource
    {
        public string Name { get; set; }

        public int FranchiseId { get; set; }

        public int Category { get; set; }

        public double Comission { get; set; }

        public int UserId { get; set; }
    }
}
