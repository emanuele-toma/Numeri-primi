using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace Numeri_primi
{
    class Program
    {
        static void Main()
        {
            Console.Title = "Calcolatore di numeri primi";

            int massimo = default, attuale = default, n = default, occorrenze = default, colonna = default;
            string msg = default;
            decimal percentuale = default;
            List<int> primi = new List<int> { 1, 2 };

            do
            {
                Console.Write("Inserisci il numero a cui vuoi arrivare: ");
            }
            while (!int.TryParse(Console.ReadLine(), out massimo));

            Console.WriteLine($"Calcolo di tutti i numeri primi fino a {massimo} in corso...");
            Console.WriteLine("======================================================================");

            attuale = 3;
            
            while(attuale <= massimo)
            {
                percentuale = Math.Round((decimal)attuale / (decimal)massimo * 100, 0);
                Console.Write("\r                                " + percentuale.ToString() + "%                 ");
                n = 0;
                occorrenze = 0;
                while (n < primi.Count)
                {
                    if (attuale % primi[n] == 0) 
                    {
                        occorrenze++;
                    }

                    if(occorrenze > 1)
                    {
                        n = primi.Count;
                    } else
                    {
                        n++;
                    }
                    
                }

                if (occorrenze == 1)
                {
                    primi.Add(attuale);
                }

                attuale =attuale+2;
            }
            Console.WriteLine("\n======================================================================");
            Console.WriteLine($"Lista dei numeri primi fino a {massimo}:\n");
            n = 0;
            while (n < primi.Count)
            {
                colonna++;
                if(n == primi.Count - 1 || colonna == 10)
                {
                    msg = primi[n++].ToString();
                } else
                {
                    msg = primi[n++].ToString() + ", ";
                }
                if(colonna == 10 && primi.Count > 300)
                {
                    colonna = 0;
                    msg += "\n";
                }
                Console.Write(msg);
                
            }
            Console.WriteLine("\n======================================================================");
            Console.WriteLine("\n\nPremi un tasto per terminare...");
            Console.ReadKey();
        }
    }
}
