using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace CSharpStruct
{
    class Program
    {

        public struct Itinerary
        {
            public string First;
            public string Final;
            public int Num;
            public int Distance;
        }

        public static void ConsoleConfig(string title)
        {
            Console.Title = title;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.OutputEncoding = Encoding.GetEncoding(1251); // може буть несумісність кодувань
            Console.InputEncoding = Encoding.GetEncoding(1251);
        }

        public static void Write(Itinerary[] mas)
        {
            StreamWriter output = new StreamWriter(@"output.txt");
            foreach (Itinerary it in mas)
            {
                Console.Write(it.First + " ");
                Console.Write(it.Final + " ");
                Console.Write(it.Num + " ");
                Console.WriteLine(it.Distance);
                output.Write(it.First + " ");
                output.Write(it.Final + " ");
                output.Write(it.Num + " ");
                output.WriteLine(it.Distance);

            }
        }
             public static void WriteNum (Itinerary [] mas,uint num)
        {
            bool l = true;
        foreach(Itinerary it in mas) 
            if(it.Num==num)
            {
                l = false;
    Console.Write(it.First+" ");
    Console.Write(it.Final+" ");
    Console.Write(it.Num+" ");
    Console.WriteLine(it.Distance);
            }
        if (l) Console.Write("Таких маршрутів немає!!!");

    }
       
            private static int Compar (Itinerary x,Itinerary y)
        {return y.Distance-x.Distance ;}
       


        static void Main(string[] args)
        {
            ConsoleConfig("Задания на структуры Часть 1");
            FileInfo input = new FileInfo(@"input.txt");
            if (input.Exists)
            {
                Regex regexp = new Regex(@"(\w+) (\w+) (\d+) (\d+)");
                string str = input.OpenText().ReadToEnd();
                MatchCollection matches = regexp.Matches(str);
                Itinerary[] it = new Itinerary[matches.Count];
                int i = 0;
                if (matches.Count > 0)
                    foreach (Match match in matches)
                    {
                        it[i].First = match.Groups[1].Value;
                        it[i].Final = match.Groups[2].Value;
                        it[i].Num = int.Parse(match.Groups[3].Value);
                        it[i].Distance = int.Parse(match.Groups[4].Value);
                        i++;
                    }

                Array.Sort<Itinerary>(it, Compar);
                 Write(it);
                Console.Write("Введіть номер маршруту про який ви хочете дізнатись: ");
                uint number = uint.Parse(Console.ReadLine());
                WriteNum(it, number);

            }
            Console.ReadKey();


        }
    }
}
