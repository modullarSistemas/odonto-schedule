using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Domain.Models.TreatmentAggregate
{
    public enum TreatmentStatusEnum
    {
        Pendente = 1,
        AvaliacaoCompleta = 2,
        EmProgresso = 3,
        Finalizado = 4
    }
}
