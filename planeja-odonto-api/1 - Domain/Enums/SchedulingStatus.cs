using System.ComponentModel;

namespace PlanejaOdonto.Api.Domain.Enums
{
    public enum SchedulingStatus : byte
    {
        [Description("Novo agendamento")]
        New = 1,

        [Description("Paciente presente")]
        Presence = 2,

        [Description("Paciente ausente")]
        Absent = 3,

        [Description("Paciente confirmou")]
        Confirmed = 4
    }
}
