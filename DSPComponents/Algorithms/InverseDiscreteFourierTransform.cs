using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;
using System.Numerics;

namespace DSPAlgorithms.Algorithms
{
    public class InverseDiscreteFourierTransform : Algorithm
    {
        public Signal InputFreqDomainSignal { get; set; }
        public Signal OutputTimeDomainSignal { get; set; }

        public override void Run()
        {
            List<Complex> complexNumber = new List<Complex>();
            List<Complex> values = new List<Complex>();
            for (int i = 0; i < InputFreqDomainSignal.FrequenciesAmplitudes.Count; i++)
            {
                complexNumber.Add(Complex.FromPolarCoordinates(InputFreqDomainSignal.FrequenciesAmplitudes[i], InputFreqDomainSignal.FrequenciesPhaseShifts[i]));
            }
            double ans_term = 0;
            for (int i = 0; i < InputFreqDomainSignal.FrequenciesAmplitudes.Count; i++)
            {
                values.Add(ans_term);
                for (int j = 0; j < InputFreqDomainSignal.FrequenciesAmplitudes.Count; j++)
                {
                    double pow_e = (2 * Math.PI * i * j) / InputFreqDomainSignal.FrequenciesAmplitudes.Count;
//                    values[i] += complexNumber[j] * (Math.Cos(pow_e) + Complex.ImaginaryOne * Math.Sin(pow_e));
                    values[i] += (complexNumber[j].Real * Math.Cos(pow_e) + Complex.ImaginaryOne * complexNumber[j].Real * Math.Sin(pow_e)) + (complexNumber[j].Imaginary * -1 * Math.Cos(pow_e) + complexNumber[j].Imaginary * -1 * Math.Sin(pow_e)); 
                }
                values[i] /= InputFreqDomainSignal.FrequenciesAmplitudes.Count;
            }
            List<float> real_term = new List<float>();
            for (int i = 0; i < InputFreqDomainSignal.FrequenciesAmplitudes.Count; i++)
                real_term.Add((float)values[i].Real);
            OutputTimeDomainSignal = new Signal(real_term, false);
        }
    }
}