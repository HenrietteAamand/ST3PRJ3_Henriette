using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MiniTests
{
    class Program
    {
        static void Main(string[] args)
        {
            double mean =0;
            List<double> sinusvaerdier = new List<double>();
            for (int i = 0; i < 99; i++)
            {
                sinusvaerdier.Add(Math.Sin(i * 0.2) * 15 + 100);
                
                Console.Write(sinusvaerdier[i].ToString("F3") + "    ");
                mean += sinusvaerdier[0];
            }

            mean = mean / sinusvaerdier.Count;

            Console.WriteLine("Gennemsnit = " + mean.ToString("F3"));


        }

        private List<double> sinusValue(int verticalForskydning)
        {
            List<double> sinusvaerdier = new List<double>();
            for (int i = 0; i < 99; i++)
            {
                sinusvaerdier.Add(Math.Sin(i * 0.2) * 15 + 100);
            }

            return sinusvaerdier;
        }
    }

}
