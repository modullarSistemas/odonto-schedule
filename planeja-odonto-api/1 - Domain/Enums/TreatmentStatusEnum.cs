using System.ComponentModel;

namespace PlanejaOdonto.Api.Domain.Enums
{
    public enum TreatmentStatusEnum 
    {
        [Description("Pendente")]
        Pendente = 1,

        [Description("Avaliação Completa")]
        AvaliacaoCompleta = 2,

        [Description("Em Negociação")]
        EmNegociação = 3,


        [Description("Em Progresso")]
        EmProgresso = 4,

        [Description("Finalizado")]
        Finalizado = 5,

        [Description("Cancelado")]
        Cancelado = 6,
    }
}
