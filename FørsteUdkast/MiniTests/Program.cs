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

            int offset = 100;
            int howLong = 190;

            List<double> sinusvaerdier = new List<double>();
            for (int i = 0; i < howLong; i++)
            {
                sinusvaerdier.Add(Math.Sin(i * 0.01 * Math.PI) * 15 + offset);
                
                Console.Write(sinusvaerdier[i].ToString("F3") + "    ");
                mean += sinusvaerdier[0];
            }
            mean = mean / sinusvaerdier.Count;
            Console.WriteLine("Sidste værdi for 100: " + sinusvaerdier[sinusvaerdier.Count-1]);
            Console.WriteLine("Mean for 100: " + mean);
            mean = 0;



            offset = 95;
            sinusvaerdier.Clear();

            for (int i = 0; i < howLong; i++)
            {
                sinusvaerdier.Add(Math.Sin(i * 0.01 * Math.PI) * 15 + offset);

                Console.Write(sinusvaerdier[i].ToString("F3") + "    ");
                mean += sinusvaerdier[0];
            }

            mean = mean / sinusvaerdier.Count;
            Console.WriteLine("Sidste værdi for 95: " + sinusvaerdier[sinusvaerdier.Count - 1]);
            Console.WriteLine("Mean for 95: " + mean);
            mean = 0;

            offset = 90;
            sinusvaerdier.Clear();

            for (int i = 0; i < howLong; i++)
            {
                sinusvaerdier.Add(Math.Sin(i * 0.01*Math.PI) * 15 + offset);

                Console.Write(sinusvaerdier[i].ToString("F3") + "    ");
                mean += sinusvaerdier[0];
            }

            mean = mean / sinusvaerdier.Count;
            Console.WriteLine("Sidste værdi for 90: " + sinusvaerdier[sinusvaerdier.Count - 1]);
            Console.WriteLine("Mean for 90: " + mean);



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
