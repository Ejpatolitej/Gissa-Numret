using System;

namespace Gissa_Numret
{
    class Program
    {
        static void Main(string[] args)
        {
            bool keepRunning = true;
            while (keepRunning == true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("\tHejsan! Välkommen till mitt \"gissa numret\" spel!");
                    Console.WriteLine("\tVilken svårighetsgrad vill du köra på? (1-1000)");
                    Console.Write("\t");
                    int difficulty = Int32.Parse(Console.ReadLine());
                    checkNumber(difficulty);
                    Console.Clear();

                    Console.WriteLine("\tVill du spela igen? Ja / Nej");
                    Console.Write("\t");
                    bool keepAsking = true;
                    while (keepAsking)
                    {
                        string keepPlaying = Console.ReadLine();

                        if (keepPlaying.ToUpper() == "JA")
                        {
                            keepAsking = false;
                        }
                        else if (keepPlaying.ToUpper() == "NEJ")
                        {
                            Console.Clear();
                            Console.WriteLine("\tTack för att du spelade!");
                            keepAsking = false;
                            keepRunning = false;
                        }
                        else
                        {
                            //Console.Clear();
                            Console.WriteLine("\tNu skrev du något konstigt, försök igen! Ja / Nej");
                        }

                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Hoppsan! Nu var det något som gick fel!");
                }
            }
        }
        public static void checkNumber(int difficulty)
        {
            try
            {
                string[] tooHigh = { "Tyvärr, för högt!", "Attans, det var för högt!", "Nej, nej. För högt!", "Aj då, gissa på ett lägre tal!", "Nix pix fågelkrix! Nu vart det för högt!" };
                string[] tooLow = { "Tyvärr, för lågt!", "Attans, det var för lågt!", "Nej, nej. För lågt!", "Aj då, gissa på ett högre tal!", "Nix pix fågelkrix! Nu vart det för lågt!" };

                Random rnd = new Random();
                int rndNmbr = rnd.Next(1, difficulty);
                int chances = 5 + difficulty / 20;

                for (int i = 0; i < chances; i++)
                {
                    Console.WriteLine("\tDu har " + (chances - i) + " chanser på dig");
                    Console.Write("\tGissa på ett nummer: ");
                    int guess = Int32.Parse(Console.ReadLine());

                    if (guess == rndNmbr)
                    {
                        Console.Clear();
                        Console.WriteLine("\tGrattis! Du gissade rätt!");
                        break;
                    }
                    else if (guess > rndNmbr)
                    {
                        if (guess <= rndNmbr + 2)
                        {
                            Console.Clear();
                            Console.WriteLine("\tNu bränns det!");
                        }
                        else if (guess <= rndNmbr + 5)
                        {
                            Console.Clear();
                            Console.WriteLine("\tNu är det nära! Lite lägre!");
                        }
                        else if (guess > rndNmbr)
                        {
                            int rndTooHigh = rnd.Next(tooHigh.Length);
                            Console.Clear();
                            Console.WriteLine($"\t{tooHigh[rndTooHigh]}");
                        }
                    }
                    else if (guess < rndNmbr)
                    {
                        if (guess >= rndNmbr - 2)
                        {
                            Console.Clear();
                            Console.WriteLine("\tNu bränns det!");
                        }
                        else if (guess >= rndNmbr - 5)
                        {
                            Console.Clear();
                            Console.WriteLine("\tNu är det nära! Lite högre!");
                        }
                        else if (guess < rndNmbr)
                        {
                            int rndTooLow = rnd.Next(tooLow.Length);
                            Console.Clear();
                            Console.WriteLine($"\t{tooLow[rndTooLow]}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nu blev det fel!");
                    }
                }
                Console.WriteLine("\tRätt nummer var " + rndNmbr + "!");
                Console.ReadKey();
                Console.Clear();
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("\tHoppsan! Nu var det något som blev fel!");
                Console.ReadKey();
            }
        }
    }
}
