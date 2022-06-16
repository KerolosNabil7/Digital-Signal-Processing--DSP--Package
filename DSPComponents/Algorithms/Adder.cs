using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class Adder : Algorithm
    {
        public List<Signal> InputSignals { get; set; }
        public Signal OutputSignal { get; set; }

        public override void Run()
        {
            float res;
            List<float> result = new List<float>();
            for (int i = 0;i<InputSignals[0].Samples.Count;i++)
            {
                res = InputSignals[0].Samples[i] + InputSignals[1].Samples[i];
                result.Add(res);
            }
            OutputSignal = new Signal(result, true);
        }
    }
}