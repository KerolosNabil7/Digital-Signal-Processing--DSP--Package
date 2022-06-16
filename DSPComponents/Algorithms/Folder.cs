using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class Folder : Algorithm
    {
        public Signal InputSignal { get; set; }
        public Signal OutputFoldedSignal { get; set; }

        public override void Run()
        {
            List<float> values = new List<float>();
            List<int> foldedIndicies = new List<int>();
            for (int i = 0; i < InputSignal.Samples.Count; i++)
                values.Add(InputSignal.Samples[i]);
            values.Reverse();

            OutputFoldedSignal = new Signal(values, InputSignal.SamplesIndices, false);
        }
    }
}
