using DSPAlgorithms.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DSPAlgorithms.Algorithms
{
    public class DCT: Algorithm
    {
        public Signal InputSignal { get; set; }
        public Signal OutputSignal { get; set; }

        public override void Run()
        {
            List<float> f = new List<float>();
            double a;
            for (int k = 0; k < InputSignal.Samples.Count; k++)
            {
                double x;
                if (k == 0)
                {
                    x = (double)1 / (double)InputSignal.Samples.Count;
                    a = Math.Sqrt(x);
                }
                else
                {
                    x = (double)2 / (double)InputSignal.Samples.Count;
                    a = Math.Sqrt(x);
                }
                double sum = 0;
                for (int j = 0; j < InputSignal.Samples.Count; j++)
                {
                    double num = (2 * j + 1) * k * Math.PI;
                    double dem = 2 * InputSignal.Samples.Count;
                    double cosPart = Math.Cos(num / dem);
                    sum += InputSignal.Samples[j]*cosPart;
                }
                f.Add((float)(a * sum));
            }
            OutputSignal = new Signal(f, false);
            //String value;
            //Console.Write("Enter The Number of Cofficient to be Saved: ");
            //value = Console.ReadLine();
            //int N = Convert.ToInt32(value);
            //StreamWriter writeData = new StreamWriter("DCT Results.txt");
            //writeData.WriteLine(N + "DCT Results");
            //for (int i = 0; i < N; i++)
            //    writeData.WriteLine(i + "\t" + OutputSignal.Samples[i]);
            //writeData.Close();
        }
    }
}
