using DSPAlgorithms.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPAlgorithms.Algorithms
{
    public class Sampling : Algorithm
    {
        public int L { get; set; } //upsampling factor
        public int M { get; set; } //downsampling factor
        public Signal InputSignal { get; set; }
        public Signal OutputSignal { get; set; }




        public override void Run()
        {
            //Case #1 UP Sampling //Test case #2
            if (L != 0 && M == 0)
            {
                List<float> l1 = InputSignal.Samples;
                List<float> l2 = new List<float>();
                for (int i = 0; i < l1.Count; i++)
                {
                    l2.Add(l1[i]);
                    for (int j = 0; j < L - 1; j++)
                        l2.Add(0);
                }
                FIR low_filter = new FIR();
                Signal s = new Signal(l2, false);
                low_filter.InputFilterType = DSPAlgorithms.DataStructures.FILTER_TYPES.LOW;
                low_filter.InputFS = 8000;
                low_filter.InputStopBandAttenuation = 50;
                low_filter.InputCutOffFrequency = 1500;
                low_filter.InputTransitionBand = 500;
                low_filter.InputTimeDomainSignal = s;
                low_filter.Run();
                low_filter.OutputYn.Samples.RemoveRange(1165, 87);
                low_filter.OutputYn.SamplesIndices.RemoveRange(1165, 87);
                OutputSignal = low_filter.OutputYn;
            }
            //Case #2 DOWN Sampling  //Test case #3
            else if (L == 0 && M != 0)
            {
                FIR low_filter = new FIR();
                low_filter.InputFilterType = DSPAlgorithms.DataStructures.FILTER_TYPES.LOW;
                low_filter.InputFS = 8000;
                low_filter.InputStopBandAttenuation = 50;
                low_filter.InputCutOffFrequency = 1500;
                low_filter.InputTransitionBand = 500;
                low_filter.InputTimeDomainSignal = InputSignal;
                low_filter.Run();
                Signal filtered_sig = low_filter.OutputYn;
                List<float> l1 = filtered_sig.Samples;
                List<float> l2 = new List<float>();
                for (int i = 0; i < filtered_sig.Samples.Count; i += M)
                {
                    l2.Add(filtered_sig.Samples[i]);
                }
                filtered_sig = new Signal(l2, false);
                OutputSignal = filtered_sig;
            }
            //Case #3 Fraction //Test Case 1
            else if (L != 0 && M != 0)
            {
                List<float> l1 = InputSignal.Samples;
                List<float> l2 = new List<float>();
                for (int i = 0; i < l1.Count; i++)
                {
                    l2.Add(l1[i]);
                    for (int j = 0; j < L - 1; j++)
                        l2.Add(0);
                }
                FIR low_filter = new FIR();
                Signal s = new Signal(l2, false);
                low_filter.InputFilterType = DSPAlgorithms.DataStructures.FILTER_TYPES.LOW;
                low_filter.InputFS = 8000;
                low_filter.InputStopBandAttenuation = 50;
                low_filter.InputCutOffFrequency = 1500;
                low_filter.InputTransitionBand = 500;
                low_filter.InputTimeDomainSignal = s;
                low_filter.Run();
                List<float> l3 = low_filter.OutputYn.Samples;
                List<float> l4 = new List<float>();
                for (int i = 0; i < l3.Count; i += M)
                {
                    l4.Add(l3[i]);
                }
                s = new Signal(l4, false);
                OutputSignal = s;
            }
            else if (L == 0 && M == 0)
            {
                Console.WriteLine("ERROR");
            }
        }
    }

}
