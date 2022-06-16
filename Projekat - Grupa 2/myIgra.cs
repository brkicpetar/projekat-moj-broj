using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.IO;

namespace Projekat___Grupa_2
{
    internal class myIgra
    {
        struct Izraz
        {
            public int rezultat;
            public string izrazString;
        }

        private List<Izraz> ponudjeniBrojevi;
        private int konacniBroj;
        private Stack<string> stack;
        private bool daLiJeKompjuterDosaoDoResenja;
        private bool daLiJeTacanBroj = false;
        private int priblizanBroj = 9999999;
        private int brojBodova = 0;

        static List<Izraz> moguciRezultati(int broj1, int broj2, string izraz1, string izraz2)
        {
            List<Izraz> list = new List<Izraz>();
            Izraz i = new Izraz();
            i.rezultat = broj1 + broj2;
            i.izrazString = "(" + izraz1 + "+" + izraz2 + ")";
            list.Add(i);
            if (broj1 != 1 && broj2 != 1)
            {
                i.rezultat = broj1 * broj2;
                i.izrazString = "(" + izraz1 + "*" + izraz2 + ")";
                list.Add(i);
            }
            if (broj1 >= broj2 && broj1 - broj2 != broj2)
            {
                i.rezultat = broj1 - broj2;
                i.izrazString = "(" + izraz1 + "-" + izraz2 + ")";
                list.Add(i);
            }
            if (broj2 > broj1 && broj2 - broj1 != broj1)
            {
                i.rezultat = broj2 - broj1;
                i.izrazString = "(" + izraz2 + "-" + izraz1 + ")";
                list.Add(i);
            }
            if (broj2 != 0 && broj1 % broj2 == 0 && broj1 / broj2 != broj2 && broj2 != 1)
            {
                i.rezultat = broj1 / broj2;
                i.izrazString = "(" + izraz1 + "/" + izraz2 + ")";
                list.Add(i);
            }
            if (broj1 != 0 && broj2 % broj1 == 0 && broj2 / broj1 != broj1 && broj1 != 1)
            {
                i.rezultat = broj2 / broj1;
                i.izrazString = "(" + izraz2 + "/" + broj1 + ")";
                list.Add(i);
            }
            return list;
        }
        static bool RezultatMedjukorak(List<Izraz> list, int tacanBroj, ref Stack<string> stack)
        {
            if (list.Count == 1) return Math.Abs(list[0].rezultat - tacanBroj) == 0;
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    List<Izraz> preostaliBrojeviPlusRezultat = new List<Izraz>();
                    for (int k = 0; k < list.Count; k++)
                    {
                        if (k != i && k != j) preostaliBrojeviPlusRezultat.Add(list[k]);
                    }
                    foreach (var item in moguciRezultati(list[i].rezultat, list[j].rezultat, list[i].izrazString, list[j].izrazString))
                    {
                        Izraz iz = new Izraz();
                        iz.rezultat = item.rezultat;
                        iz.izrazString = item.izrazString;
                        preostaliBrojeviPlusRezultat.Add(iz);
                        if (RezultatMedjukorak(preostaliBrojeviPlusRezultat, tacanBroj, ref stack))
                        {
                            stack.Push(item.izrazString);
                            return true;
                        }
                        preostaliBrojeviPlusRezultat.RemoveAt(preostaliBrojeviPlusRezultat.Count - 1);
                    }
                }
            }
            return false;
        }

        void RacunarResava()
        {
            daLiJeKompjuterDosaoDoResenja = RezultatMedjukorak(ponudjeniBrojevi, konacniBroj, ref stack);
            if (!daLiJeKompjuterDosaoDoResenja)
            {
                for (int i = 1; i <= konacniBroj; i++)
                {
                    daLiJeKompjuterDosaoDoResenja = RezultatMedjukorak(ponudjeniBrojevi, konacniBroj + i, ref stack);
                    if (daLiJeKompjuterDosaoDoResenja)
                    {
                        priblizanBroj = konacniBroj + i;
                        break;
                    }
                    else
                    {
                        daLiJeKompjuterDosaoDoResenja = RezultatMedjukorak(ponudjeniBrojevi, konacniBroj - i, ref stack);
                        if (daLiJeKompjuterDosaoDoResenja)
                        {
                            priblizanBroj = konacniBroj - i;
                            break;
                        }
                    }
                }
            }
            else daLiJeTacanBroj = true;
            Thread.CurrentThread.Abort();
        }

        string ReadLine()
        {
            ReadLineDelegate a = Console.ReadLine;
            var result = a.BeginInvoke(null, null);
            result.AsyncWaitHandle.WaitOne(60000);
            Console.CursorVisible = false;
            if (result.IsCompleted) return a.EndInvoke(result);
            else return null;
        }
        delegate string ReadLineDelegate();

        public void PokreniIgru()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(@"
          .         .                                                                                                                          
         ,8.       ,8.           ,o888888o.                8 8888           8 888888888o   8 888888888o.      ,o888888o.                8 8888 
        ,888.     ,888.       . 8888     `88.              8 8888           8 8888    `88. 8 8888    `88.  . 8888     `88.              8 8888 
       .`8888.   .`8888.     ,8 8888       `8b             8 8888           8 8888     `88 8 8888     `88 ,8 8888       `8b             8 8888 
      ,8.`8888. ,8.`8888.    88 8888        `8b            8 8888           8 8888     ,88 8 8888     ,88 88 8888        `8b            8 8888 
     ,8'8.`8888,8^8.`8888.   88 8888         88            8 8888           8 8888.   ,88' 8 8888.   ,88' 88 8888         88            8 8888 
    ,8' `8.`8888' `8.`8888.  88 8888         88            8 8888           8 8888888888   8 888888888P'  88 8888         88            8 8888 
   ,8'   `8.`88'   `8.`8888. 88 8888        ,8P 88.        8 8888           8 8888    `88. 8 8888`8b      88 8888        ,8P 88.        8 8888 
  ,8'     `8.`'     `8.`8888.`8 8888       ,8P  `88.       8 888'           8 8888      88 8 8888 `8b.    `8 8888       ,8P  `88.       8 888' 
 ,8'       `8        `8.`8888.` 8888     ,88'     `88o.    8 88'            8 8888    ,88' 8 8888   `8b.   ` 8888     ,88'     `88o.    8 88'  
,8'         `         `8.`8888.  `8888888P'         `Y888888 '              8 888888888P   8 8888     `88.    `8888888P'         `Y888888 '    




                                                             Traži se broj: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorVisible = false;
            Random random = new Random();
            int kcifra1 = -1;
            int kcifra2 = -1;
            int kcifra3 = -1;

            ConsoleKeyInfo key = Console.ReadKey(true);
            while(key.Key != ConsoleKey.Enter) key = Console.ReadKey(true);
            kcifra1 = random.Next(0,9);
            Console.Write(kcifra1);
            key = Console.ReadKey(true);
            while (key.Key != ConsoleKey.Enter) key = Console.ReadKey(true);
            kcifra2 = random.Next(0, 9);
            Console.Write(kcifra2);
            key = Console.ReadKey(true);
            while (key.Key != ConsoleKey.Enter) key = Console.ReadKey(true);
            kcifra3 = random.Next(0, 9);
            Console.WriteLine(kcifra3);
            konacniBroj = kcifra1 * 100 + kcifra2 * 10 + kcifra3;
            //konacniBroj = 418;

            int cifra1 = -1;
            int cifra2 = -1;
            int cifra3 = -1;
            int cifra4 = -1;
            int broj1 = -1;
            int broj2 = -1;

            int[] b1 = { 10, 15, 20 };
            int[] b2 = { 25, 50, 75, 100 };
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nPonuđeni brojevi:");
            Console.ForegroundColor = ConsoleColor.White;
            key = Console.ReadKey(true);
            while (key.Key != ConsoleKey.Enter) key = Console.ReadKey(true);
            cifra1 = random.Next(1, 9);
            Console.Write(cifra1 + "  ");
            key = Console.ReadKey(true);
            while (key.Key != ConsoleKey.Enter) key = Console.ReadKey(true);
            cifra2 = random.Next(1, 9);
            Console.Write(cifra2 + "  ");
            key = Console.ReadKey(true);
            while (key.Key != ConsoleKey.Enter) key = Console.ReadKey(true);
            cifra3 = random.Next(1, 9);
            Console.Write(cifra3 + "  ");

            key = Console.ReadKey(true);
            while (key.Key != ConsoleKey.Enter) key = Console.ReadKey(true);
            cifra4 = random.Next(1, 9);
            Console.Write(cifra4 + "    ");
            key = Console.ReadKey(true);
            while (key.Key != ConsoleKey.Enter) key = Console.ReadKey(true);
            broj1 = b1[random.Next(0, 2)];
            Console.Write(broj1 + "     ");
            key = Console.ReadKey(true);
            while (key.Key != ConsoleKey.Enter) key = Console.ReadKey(true);
            broj2 = b2[random.Next(0, 3)];
            Console.WriteLine(broj2);


            List<int> l = new List<int>(){ cifra1, cifra2, cifra3, cifra4, broj1, broj2 };
            //List<int> l = new List<int>() { 1,8,8,7,20,100 };
            ponudjeniBrojevi = new List<Izraz>();
            foreach (var item in l)
            {
                Izraz iz = new Izraz();
                iz.rezultat = item;
                iz.izrazString = item.ToString();
                ponudjeniBrojevi.Add(iz);
            }
            
            stack = new Stack<string>();

            Thread t = new Thread(new ThreadStart(RacunarResava));
            t.Start();

            Console.Write("\nVaš postupak za rešavanje: ");

            Console.CursorVisible = true;
            string postupak = ReadLine();
            string[] kombi = { "+-", "-+", "+/", "/+", "+*", "*+", "-*", "*-", "-/", "/-", "*/", "*/" };
            char[] znaci = { '(', ')', '+', '-', '*', '/' };

            bool decimalno = false;

            if (!string.IsNullOrEmpty(postupak))
            {
                try
                {
                    string[] temp = postupak.Split(znaci);
                    if (!kombi.Any(n => postupak.Contains(n)))
                    {
                        foreach (var item in temp)
                        {
                            if (item != "" && !l.Contains(Convert.ToInt32(item.Trim())))
                            {
                                Console.WriteLine("Broj {0} nije u ponudi ili je već iskorišćen!", item);
                                break;
                            }
                            if (item != "") l.Remove(Convert.ToInt32(item.Trim()));
                        }
                        var resenje = new System.Data.DataTable().Compute(postupak, null);
                        double r = Convert.ToDouble(resenje);
                        if (r != (int)r)
                        {
                            decimalno = true;
                            Console.WriteLine("Rešenje je decimalno!");
                        }
                        if (r == konacniBroj || (Math.Abs(r - konacniBroj) <= Math.Abs(konacniBroj - priblizanBroj) && priblizanBroj != 9999999) && !decimalno)
                        {
                            Console.WriteLine("Osvojili ste 30 poena!");
                            brojBodova = 30;
                        }
                        else if ((Math.Abs(Math.Abs(r - konacniBroj) - Math.Abs(konacniBroj - priblizanBroj)) < 2 && priblizanBroj != 9999999) || Math.Abs(r - konacniBroj) < 2 && !decimalno)
                        {
                            Console.WriteLine("Osvojili ste 20 poena");
                            brojBodova = 20;
                        }
                        else if ((Math.Abs(Math.Abs(r - konacniBroj) - Math.Abs(konacniBroj - priblizanBroj)) < 5 && priblizanBroj != 9999999) || Math.Abs(r - konacniBroj) < 5 && !decimalno)
                        {
                            Console.WriteLine("Osvojili ste 10 poena");
                            brojBodova = 10;
                        }
                        else
                        {
                            Console.WriteLine("Osvojili ste 0 poena.");
                            brojBodova = 0;
                        }
                    }
                    else Console.WriteLine("Operatori nisu dobro upareni!");
                }
                catch (System.Data.SyntaxErrorException ex)
                {
                    if (ex.Message.Contains("The expression is missing the closing parenthesis") || ex.Message.Contains("The expression has too many closing parentheses"))
                    {
                        Console.WriteLine("Zagrade nisu dobro uparene!");
                    }
                    else Console.WriteLine("Pogrešno unet izraz!");
                }
            }
            else Console.WriteLine("\nNišta nije uneto. Osvojili ste 0 poena.");
            if (t.ThreadState == ThreadState.Running) Console.WriteLine("Kompjuter još uvek računa, sačekajte...");
            while (t.ThreadState == ThreadState.Running)
            {

            }

            if (daLiJeTacanBroj)
            {
                Console.WriteLine("Kompjuter je došao do tačnog broja!");
                while (stack.Count > 1) stack.Pop();
                Console.WriteLine(stack.Pop() + " = " + konacniBroj);
            }
            else
            {
                Console.WriteLine("Kompjuter nije mogao da dođe do tačnog broja, već približnog rešenja {0}", priblizanBroj);
                while (stack.Count > 1) stack.Pop();
                Console.WriteLine(stack.Pop() + " = " + priblizanBroj);
            }
        }
    }
}
