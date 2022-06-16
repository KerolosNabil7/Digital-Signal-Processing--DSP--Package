using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;
using System.IO;

namespace DSPAlgorithms.Algorithms
{
    public class DiscreteFourierTransform : Algorithm
    {
        public Signal InputTimeDomainSignal { get; set; }
        public float InputSamplingFrequency { get; set; }
        public Signal OutputFreqDomainSignal { get; set; }
        //Helper Func
        public override void Run()
        {
            List<float> amplitudes = new List<float>();
            List<float> phaseShifts = new List<float>();

            float pow_e, realTerm, imaginaryTerm;


            for (int i = 0; i < InputTimeDomainSignal.Samples.Count; i++)
            {
                realTerm = imaginaryTerm = 0;
                for (int j = 0; j < InputTimeDomainSignal.Samples.Count; j++)
                {
                    pow_e = (2 * (float)Math.PI * i * j) / InputTimeDomainSignal.Samples.Count;
                    realTerm += InputTimeDomainSignal.Samples[j] * (float)Math.Cos(pow_e);
                    imaginaryTerm += -InputTimeDomainSignal.Samples[j] * (float)Math.Sin(pow_e);
                }
                double amplitude = Math.Sqrt(Math.Pow(realTerm, 2) + Math.Pow(imaginaryTerm, 2));
                amplitudes.Add((float)amplitude);
                double phaseShift = Math.Atan2(imaginaryTerm , realTerm);
                phaseShifts.Add((float)phaseShift);
            }
            OutputFreqDomainSignal = new Signal(InputTimeDomainSignal.Samples, false);
            OutputFreqDomainSignal.FrequenciesAmplitudes = amplitudes;
            OutputFreqDomainSignal.FrequenciesPhaseShifts = phaseShifts;
            StreamWriter writeData = new StreamWriter("DFT Results.txt");
            for(int i=0;i<amplitudes.Count;i++)
            {
                writeData.WriteLine(amplitudes[i]);
            }
            writeData.Close();
        }
    }
}