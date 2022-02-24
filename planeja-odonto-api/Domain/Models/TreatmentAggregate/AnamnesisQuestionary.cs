using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Domain.Models.TreatmentAggregate
{
    public class AnamnesisQuestionary : BaseModel
    {
        public string BothersTheMost { get; set; }
        public string WouldChangeAesthetically { get; set; }
        public bool WouldChangeToothShape { get; set; }
        public bool WhiterTeeths { get; set; }
        public bool CardiacDisease { get; set; }
        public bool Hepatites { get; set; }
        public bool HighLowPressure { get; set; }
        public bool Anemia { get; set; }
        public bool KidneyDisease { get; set; }
        public bool Hiv { get; set; }
        public bool BreathingDisease { get; set; }
        public bool NeuralDisease { get; set; }
        public bool Diabetes { get; set; }
        public bool Epilepsy { get; set; }
        public bool Reumatism { get; set; }
        public bool Depression { get; set; }
        public bool ReumaticFever { get; set; }
        public bool MyProperty { get; set; }


    }
}
