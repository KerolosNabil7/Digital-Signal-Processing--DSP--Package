using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class MovingAverage : Algorithm
    {
        public Signal InputSignal { get; set; }
        public int InputWindowSize { get; set; }
        public Signal OutputAverageSignal { get; set; }
 
        public override void Run()
        {
            int ratio = InputWindowSize / 2;
            List<float> temp = new List<float>();
            for(int i = 0; i<InputSignal.Samples.Count;i++)
            {
                float sum = 0;
                for(int j = 0;j<InputWindowSize;j++)
                {
                    if (i >= ratio && i < InputSignal.Samples.Count - ratio)
                        sum += InputSignal.Samples[i + j - ratio];
                }
                if (i < ratio || i >= InputSignal.Samples.Count - ratio)
                    continue;
                sum /= InputWindowSize;
                temp.Add(sum);
            }
            OutputAverageSignal = new Signal(temp, false);














            /*
            List<float> values = new List<float>();
            float sum;
            for(int i =0;i<InputSignal.Samples.Count;i++)
            {
                sum = 0;
                sum += InputSignal.Samples[i];
                for (int j = 1; j < InputWindowSize - 2; j++)
                    sum += InputSignal.Samples[i + j];
                values.Add(sum);
            }
            OutputAverageSignal = new Signal(values, false);
            */
            /*
            for(int i =0;i<InputSignal.Samples.Count;i++)
            {
                sum = 0;
                sum += InputSignal.Samples[i];
                for (int j = 0; j < InputWindowSize%2 ; j++)
                {
                    if (i == 0)
                        sum += InputSignal.Samples[0];
                    else
                        sum += (InputSignal.Samples[i + j] + InputSignal.Samples[i - j]);
                    values.Add((float)sum / InputWindowSize);
                }
                //sum += (InputSignal.Samples[i+j] + InputSignal.Samples[i-j]);
            }
            */

        }
    }
}