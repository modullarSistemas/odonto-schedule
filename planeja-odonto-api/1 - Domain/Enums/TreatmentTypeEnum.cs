using System.ComponentModel;

namespace PlanejaOdonto.Api.Domain.Enums
{
    public enum TreatmentTypeEnum : byte
    {
        [Description("Clínico Geral")]
        ClinicoGeral = 1,

        [Description("Ortodontia")]
        Ortondia = 2,

        [Description("Implantodontia")]
        Implantodontia = 3,

        [Description("Harmonização Facial")]
        HarmonizacaoFacial = 4,
    }
}
