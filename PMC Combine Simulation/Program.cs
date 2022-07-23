using System;
using System.Collections;
using System.Collections.Generic;

namespace PMC_Combine_Simulation
{
    class Program
    {

        static Random rnd = new Random();
        static int r = 0;

        static void Main(string[] args)
        {

            Program program = new Program();
            ArrayList rarePmcs = new ArrayList();
            ArrayList epicPmcs = new ArrayList();
            ArrayList legendPmcs = new ArrayList();
            ArrayList mythicPmcs = new ArrayList();

            program.FillPMCType(rarePmcs, epicPmcs, legendPmcs, mythicPmcs);

            int rareFailCombines = 0;
            int epicFailCombines = 0;
            int legendFailCombines = 0;

            int rareDuplicates = 0;
            int epicDuplicates = 0;
            int legendDuplicates = 0;

            int rarePmcUsed = 0;

            Dictionary<int, object> rMap = new Dictionary<int, object>();
            Dictionary<int, object> eMap = new Dictionary<int, object>();
            Dictionary<int, object> lMap = new Dictionary<int, object>();
            Dictionary<int, object> mMap = new Dictionary<int, object>();





            while (mMap.ContainsKey(0) == false) //Run while we do not have a Mythic PMC
            {

                //Duplicate Rare Check
                if (rareDuplicates == 3) //If we have 3 duplicate Rare PMC, run the combine.
                {
                    rareDuplicates = 0;
                    r = rnd.Next(1, 11); //Get RNG value between 1 and 10
                    if (r == 10) //If RNG value is 10, perform successful combination (simulates the 1/10 chance)
                    {
                        program.AcquireEpicPMC(ref epicPmcs, ref eMap, ref epicDuplicates);

                    }

                    else //Fail combination, 9/10 chance
                    {
                        program.AcquireRarePMC(ref rarePmcs, ref rMap, ref rareDuplicates);
                        rareFailCombines++; //Increment Rare Fails
                    }
                }

                //Pity Epic Check
                if (rareFailCombines == 20) //Pity Epic
                {
                    Console.WriteLine("Rolling for Pity Epic...");
                    program.AcquireEpicPMC(ref epicPmcs, ref eMap, ref epicDuplicates);
                    Console.WriteLine("Rare Fail Combines reset to 0.");
                    rareFailCombines = 0; //Reset to 0;
                }


                //Duplicate Epic Check
                if (epicDuplicates == 3) //If we have 3 duplicate Epic PMC, run the combine.
                {
                    epicDuplicates = 0;
                    r = rnd.Next(1, 11); //Get RNG value between 1 and 10
                    if (r == 11) //If RNG value is 10, perform successful combination (simulates the 1/10 chance)
                    {
                        program.AcquireLegendaryPMC(ref legendPmcs, ref lMap, ref legendDuplicates);
                    }

                    else //Fail combination, 9/10 chance
                    {
                        program.AcquireEpicPMC(ref epicPmcs, ref eMap, ref epicDuplicates);
                        epicFailCombines++; //Increment Epic Fails
                    }


                }

                //Pity Legendary Check
                if (epicFailCombines == 20) //Pity Legendary
                {
                    Console.WriteLine("Rolling for Pity Legendary...");
                    program.AcquireLegendaryPMC(ref legendPmcs, ref lMap, ref legendDuplicates);
                    Console.WriteLine("Epic Fail Combines reset to 0.");
                    epicFailCombines = 0; //Reset to 0;
                }




                //Run Legendary PMC Checks

                //Duplicate Legendary Check
                if (legendDuplicates == 3) //If we have 3 duplicate Legendary, run the combine.
                {
                    legendDuplicates = 0;
                    r = rnd.Next(1, 11); //Get RNG value between 1 and 10
                    if (r == 10) //If RNG value is 10, perform successful combination (simulates the 1/10 chance)
                    {
                        program.AcquireMythicPMC(ref mythicPmcs, ref mMap);
                        Console.WriteLine("Congratulations! You have acquired Mythic PMC: " + mMap[r]);
                        break;
                    }

                    else //Fail combination, 9/10 chance
                    {

                        program.AcquireLegendaryPMC(ref legendPmcs, ref lMap, ref legendDuplicates);
                        legendFailCombines++; //Increment Legendary Fails
                        Console.WriteLine("Shoot! You failed a Legendary Combine. Fail Count: " + legendFailCombines);
                    }
                }




                //Pity Mythic Check
                if (legendFailCombines == 5) //Pity Mythic
                {
                    Console.WriteLine("Rolling for Pity Legendary... How Unlucky");
                    program.AcquireMythicPMC(ref mythicPmcs, ref mMap);
                    Console.WriteLine("You have acquired Mythic PMC: " + mMap[r] + " from pity...");
                    Console.WriteLine("Legendary Fail Combines reset to 0.");
                    legendFailCombines = 0; //Reset to 0;
                    break;
                }


                //Add Rare PMC
                program.AcquireRarePMC(ref rarePmcs, ref rMap, ref rareDuplicates);
                rarePmcUsed++;


            }
            //Print how many Rare PMC used to acquire Mythic
            Console.WriteLine("It took " + rarePmcUsed + " Rare PMC to acquire your Mythic!");
        }



        public void AcquireRarePMC(ref ArrayList rarePmcs, ref Dictionary<int, object> rMap, ref int rareDuplicates)
        {
            r = rnd.Next(rarePmcs.Count);
            if (rMap.ContainsKey(r))
            {

                rareDuplicates++;

            }
            else
            {
                rMap.Add(r, rarePmcs[r]);
                Console.WriteLine("New Rare!");
            }
        }

        public void AcquireEpicPMC(ref ArrayList epicPmcs, ref Dictionary<int, object> eMap, ref int epicDuplicates)
        {
            r = rnd.Next(epicPmcs.Count);
            if (eMap.ContainsKey(r))
            {
                epicDuplicates++;

            }
            else
            {
                eMap.Add(r, epicPmcs[r]);
                Console.WriteLine("New Epic!");
            }
        }

        public void AcquireLegendaryPMC(ref ArrayList legendPmcs, ref Dictionary<int, object> lMap, ref int legendDuplicates)
        {
            r = rnd.Next(legendPmcs.Count);
            if (lMap.ContainsKey(r))
            {
                legendDuplicates++;
                Console.WriteLine("Duplicate Legendary Acquired. Duplicate Legendary Count: " + legendDuplicates);
            }
            else
            {
                lMap.Add(r, legendPmcs[r]);
                Console.WriteLine("New Legendary!");
            }
        }

        public void AcquireMythicPMC(ref ArrayList mythicPmcs, ref Dictionary<int, object> mMap)
        {
            r = rnd.Next(mythicPmcs.Count); //Since there are only one of each mythic, we do not need to check 
            mMap.Add(r, mythicPmcs[r]);     //for an existing one. We just add the one from the list.

        }






        public void FillPMCType(ArrayList rarePmcs, ArrayList epicPmcs, ArrayList legendPmcs, ArrayList mythicPmcs)
        {
            rarePmcs.Add("Ann");
            rarePmcs.Add("Cobalt");
            rarePmcs.Add("Benny");
            rarePmcs.Add("Mikhail");
            rarePmcs.Add("Juri");
            rarePmcs.Add("Jaden");
            rarePmcs.Add("Odie");
            rarePmcs.Add("Sebastian");
            rarePmcs.Add("Kobil");
            rarePmcs.Add("Pastor");
            rarePmcs.Add("Kenneth");
            rarePmcs.Add("Melody");
            rarePmcs.Add("Abato");
            rarePmcs.Add("Beshila");
            rarePmcs.Add("Kikan");
            rarePmcs.Add("Frond");
            rarePmcs.Add("Vaude");
            rarePmcs.Add("Jarter");
            rarePmcs.Add("Veril");
            rarePmcs.Add("Daniel");
            rarePmcs.Add("Gillian");
            rarePmcs.Add("Dodoba");
            rarePmcs.Add("Baruru");
            rarePmcs.Add("Duyamo");
            rarePmcs.Add("Nightmare Evelyn");
            rarePmcs.Add("Regretful Millia");
            rarePmcs.Add("Ambitious Cassel");
            rarePmcs.Add("Kreps");
            rarePmcs.Add("Trippe");
            rarePmcs.Add("Palmin");
            rarePmcs.Add("Carnelia");
            rarePmcs.Add("Vagodon");
            rarePmcs.Add("Mobly");
            rarePmcs.Add("Menon");
            rarePmcs.Add("Brioka");
            rarePmcs.Add("Tobos");
            rarePmcs.Add("Lacob");
            rarePmcs.Add("Hadon");
            rarePmcs.Add("Benas");
            rarePmcs.Add("Runde");

            epicPmcs.Add("Shuryl");
            epicPmcs.Add("Gordon Zikus");
            epicPmcs.Add("Kanoteon");
            epicPmcs.Add("Tharsi");
            epicPmcs.Add("Archero");
            epicPmcs.Add("Guardion");
            epicPmcs.Add("Racite");
            epicPmcs.Add("Abyss Latz");
            epicPmcs.Add("Pibiba");
            epicPmcs.Add("Lita");
            epicPmcs.Add("Young Millia");
            epicPmcs.Add("Young Latz");
            epicPmcs.Add("Nuyamo");
            epicPmcs.Add("Zouk");
            epicPmcs.Add("Pamila");
            epicPmcs.Add("Lenore");
            epicPmcs.Add("Shushupi");
            epicPmcs.Add("Lyn");
            epicPmcs.Add("Young Cassel");
            epicPmcs.Add("Tamaron");
            epicPmcs.Add("Huz");
            epicPmcs.Add("Keligo");
            epicPmcs.Add("Tarhan");

            legendPmcs.Add("Viviana");
            legendPmcs.Add("Lenore");
            legendPmcs.Add("Talidisca");
            legendPmcs.Add("Adete");
            legendPmcs.Add("Pienche Fanden");
            legendPmcs.Add("Retibelle");
            legendPmcs.Add("Dien");
            legendPmcs.Add("Cheryl");
            legendPmcs.Add("Edelmia");

            mythicPmcs.Add("Valion");
        }
    }
}
