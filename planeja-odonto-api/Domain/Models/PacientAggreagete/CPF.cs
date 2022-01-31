namespace PlanejaOdonto.Api.Domain.Models.PacientAggregate
{
    public class CPF
    {
        public Pacient Pacient { get; set; }

        public int PacientId { get; set; }


        public string Value { get; set; }

        public static bool IsValid()
        {

            return true;
        }
    }
}