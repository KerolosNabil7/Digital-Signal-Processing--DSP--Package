using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class Shifter : Algorithm
    {
        public Signal InputSignal { get; set; }
        public int ShiftingValue { get; set; }
        public Signal OutputShiftedSignal { get; set; }

        public override void Run()
        {
            List<float> values = new List<float>();
            List<int> shiftedIndicies = new List<int>();

            for (int i = 0; i < InputSignal.Samples.Count; i++)
                values.Add(InputSignal.Samples[i]);
            for (int i = 0; i < InputSignal.Samples.Count; i++)
                shiftedIndicies.Add(InputSignal.SamplesIndices[i] - ShiftingValue);

            OutputShiftedSignal = new Signal(values, shiftedIndicies, false);
        }
    }
}