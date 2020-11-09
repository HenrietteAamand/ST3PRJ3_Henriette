using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using LogicLayer;

namespace MiniTests
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> values = new List<double>();
            bool addX = true;

            double x = 20;
            double y = 5;
            
            for (int i = 0; i < 120; i++)
            {
                if (addX == true)
                {
                    values.Add(x);
                    addX = false;
                }
                else if (addX == false)
                {
                    values.Add(y);
                    addX = true;
                }
            }

            double gennemsnit = 0;
            foreach (var VARIABLE in values)
            {
                gennemsnit += VARIABLE;
                Console.WriteLine(VARIABLE);
            }

            gennemsnit = gennemsnit / values.Count;
            Console.WriteLine("Gennemsnit = " + gennemsnit);
            

            //double systolic = 10;
            //double limitOne = systolic + 2;
            //double limitTwo = systolic + 1;
            //bool switchBool = false;
            //List<double> vaerdier = new List<double>(); 
            //int i = 0;


            //// Første del
            //while (i < limitOne)
            //{
            //    vaerdier.Add(i);
            //    i++;
            //}

            //while (i > (-1 * limitOne))
            //{
            //    vaerdier.Add(i);
            //    i--;
            //}

            //while (i <= 0)
            //{
            //    vaerdier.Add(i);
            //    i++;
            //}

            //// Anden del
            //while (i < limitTwo)
            //{
            //    vaerdier.Add(i);
            //    i++;
            //}

            //while (i > (-1 * limitTwo))
            //{
            //    vaerdier.Add(i);
            //    i--;
            //}

            //while (i <= 0)
            //{
            //    vaerdier.Add(i);
            //    i++;
            //}

            ////Sidste del
            //while (i < systolic)
            //{
            //    vaerdier.Add(i);
            //    i++;
            //}

            //while (i > (-1 * systolic))
            //{
            //    vaerdier.Add(i);
            //    i--;
            //}

            //while (i <= 0)
            //{
            //    vaerdier.Add(i);
            //    i++;
            //}

            //foreach (var VARIABLE in vaerdier)
            //{
            //    Console.WriteLine(VARIABLE);
            //}


            
            double wishedPuls = 90;
            

            double constant = wishedPuls / 60;
            double ts = 1 / 120;

            List<double> sinusvaerdier = new List<double>();
            for (int i = 0; i < 1000; i++)
            {
                sinusvaerdier.Add(Math.Sin(i * 2 * Math.PI * ts * constant) * 15 + 100);
            }

            foreach (var VARIABLE in sinusvaerdier)
            {
                Console.WriteLine(VARIABLE);   
            }


            /*
            //Sådan skal vores mainTheread kalde alle kontrollerklasserne på RPi'en.
            UC1 uc1 = new UC1();
            bool done = true;
           Thread batterThread = new Thread(uc1.CheckBatteryStatus);

            batterThread.Start(); // INDE I WHILE?
            while (true)
            {
                //Alternativt ikke have det i et thrad og her bare skrive
                uc1.MakeZeroPointAdjustment();
                done = false;

                while (done == false)
                {
                    if (isStartPressed == true)
                    {
                        uc2.Run();
                        done = true;
                    }
                    else if (kalibrate.isOn() == true)
                    {
                        kalibrate.Run();
                        done = true;
                    }
                }


            }
            */



            /*
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

            Console.ReadLine();
            Console.WriteLine("Første værdi: ");

            offset = 95;
            //sinusvaerdier.Clear();

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


            Console.ReadLine();
            offset = 90;
            //sinusvaerdier.Clear();

            for (int i = 0; i < howLong; i++)
            {
                sinusvaerdier.Add(Math.Sin(i * 0.01*Math.PI) * 15 + offset);

                Console.Write(sinusvaerdier[i].ToString("F3") + "    ");
                mean += sinusvaerdier[0];
            }

            mean = mean / sinusvaerdier.Count;
            Console.WriteLine("Sidste værdi for 90: " + sinusvaerdier[sinusvaerdier.Count - 1]);
            Console.WriteLine("Mean for 90: " + mean);

            foreach (double måling in sinusvaerdier)
            {
                Console.WriteLine(måling.ToString("F2") + "   ");
            }

        }

        private List<double> sinusValue(int verticalForskydning)
        {
            List<double> sinusvaerdier = new List<double>();
            for (int i = 0; i < 99; i++)
            {
                sinusvaerdier.Add(Math.Sin(i * 0.2) * 15 + 100);
            }

            return sinusvaerdier;
            */
        }
    }

}
