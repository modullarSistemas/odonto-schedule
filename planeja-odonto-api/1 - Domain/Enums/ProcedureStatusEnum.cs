using System.ComponentModel;

namespace PlanejaOdonto.Api.Domain.Enums
{
    public enum ProcedureStatusEnum
    {
        [Description("Pendente")]
        Pendente = 1,

        [Description("Agendado")]
        Agendado = 2,

        [Description("Finalizado")]
        Finalizado = 3,
    }
}
