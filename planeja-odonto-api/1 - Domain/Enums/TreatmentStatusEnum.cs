using System.ComponentModel;

namespace PlanejaOdonto.Api.Domain.Enums
{
    public enum TreatmentStatusEnum : byte
    {
        [Description("Pendente")]
        Pendente = 1,

        [Description("Avaliação Completa")]
        AvaliacaoCompleta = 2,

        [Description("Em Progresso")]
        EmProgresso = 3,

        [Description("Finalizado")]
        Finalizado = 4
    }
}
