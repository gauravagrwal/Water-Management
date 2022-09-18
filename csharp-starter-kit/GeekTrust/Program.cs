using System;
using System.IO;

namespace GeekTrust
{
    public class Program
    {
        #region Input Commands
        public const string ALLOT_WATER = "ALLOT_WATER";
        public const string ADD_GUESTS = "ADD_GUESTS";
        public const string BILL = "BILL";
        #endregion

        static void Main(string[] args)
        {
            try
            {
                string[] inputData = File.ReadAllLines(args[0]);
                //Add your code here to process the input commands
                // inputs
                int apartmentType = 0, noOfGuests = 0;
                int[] waterRatio = new int[2];

                // outputs
                int totalWater = 0, totalCost = 0;

                foreach (var line in inputData)
                {
                    if (line.StartsWith(ALLOT_WATER))
                    {
                        string[] inputArgs = line.Split(' ');
                        apartmentType = int.Parse(inputArgs[1]);
                        waterRatio = Array.ConvertAll(inputArgs[2].Split(':'), int.Parse);
                    }
                    else if (line.StartsWith(ADD_GUESTS))
                    {
                        string[] inputArgs = line.Split(' ');
                        noOfGuests += int.Parse(inputArgs[1]);
                    }
                }

                int waterAllotedByCorporationAndBorewell;

                if (apartmentType == 2)
                    waterAllotedByCorporationAndBorewell = 900;
                else
                    waterAllotedByCorporationAndBorewell = 1500;

                int allotedCorporationWater = waterRatio[0] * (waterAllotedByCorporationAndBorewell / (waterRatio[0] + waterRatio[1]));
                int allotedBorewellWater = waterRatio[1] * (waterAllotedByCorporationAndBorewell / (waterRatio[0] + waterRatio[1]));
                int allotedTankerWater = noOfGuests * 10 * 30;

                totalWater = CalculateTotalWaterConsumed(allotedCorporationWater, allotedBorewellWater, allotedTankerWater);
                totalCost = CalculateTotalCost(allotedCorporationWater, allotedBorewellWater, allotedTankerWater);

                Console.WriteLine($"{totalWater} {totalCost}");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        public static int CalculateTotalWaterConsumed(int corporationWater, int borewellWater, int tankerWater)
        {
            return corporationWater + borewellWater + tankerWater;
        }

        public static int CalculateCostForTankerWater(int waterAmount)
        {
            int tankerWaterCost, slab1 = 500, slab2 = 1000, slab3 = 1500;

            tankerWaterCost =
                (waterAmount <= 500) ? (waterAmount * 2) :
                (waterAmount >= 501 && waterAmount <= 1500) ? (slab1 * 2 + (waterAmount - slab1) * 3) :
                (waterAmount >= 1501 && waterAmount <= 3000) ? (slab1 * 2 + slab2 * 3 + waterAmount - (slab1 + slab2) * 5) :
                (slab1 * 2 + slab2 * 3 + slab3 * 5 + (waterAmount - (slab1 + slab2 + slab3)) * 8);

            return tankerWaterCost;
        }

        public static int CalculateTotalCost(int allotedCorporationWater, int allotedBorewellWater, int allotedTankerWater)
        {
            int corporationWaterCost = allotedCorporationWater * 1;
            int borewellWaterCost = Convert.ToInt32(allotedBorewellWater * 1.5);
            int tankerWaterCost = CalculateCostForTankerWater(allotedTankerWater);

            return corporationWaterCost + borewellWaterCost + tankerWaterCost;
        }
    }
}
