using System;

namespace TaskOne
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. Buy Fish From The Market");
            Console.WriteLine("2. Buy Fish From The Hatchery");

            int choice = Convert.ToInt32(Console.ReadLine());

            int totalFishAmount = 20;

            Fish fish = new Fish();
            fish.totalAmount = totalFishAmount;

            
            while(true){
                if(choice == 1){

                    Console.WriteLine("Fish: ");
                    string fishName = Console.ReadLine();
                    Console.WriteLine("How many fish you want to buy:(Maximum 20 pieces) ");
                    int fishAmount = Convert.ToInt32(Console.ReadLine());

                    fish.name = fishName;
                    fish.fishAmount = fishAmount;
                    
                    BuyFish buyFish = new BuyFish(fish);
                    BuyMarketFish buyMarketFish = new BuyMarketFish();

                    buyFish.MarketFishBuyEvent += buyMarketFish.onFishBuyFromMarket;

                    buyFish.buyFishFromMarket();

            } else{
                    Console.WriteLine("Fish: ");
                    string fishName = Console.ReadLine();
                    Console.WriteLine("How many fish you want to buy: ");
                    int fishAmount = Convert.ToInt32(Console.ReadLine());

                    fish.name = fishName;
                    fish.fishAmount = fishAmount;

                    BuyFish buyFish = new BuyFish(fish);
                    BuyHatcharyFish hatcharyfish = new BuyHatcharyFish();

                    buyFish.HatcharyFishBuyEvent += hatcharyfish.onFishBuyFromHatchary;
                    buyFish.buyFishFromHatchary();
            }

            }

        }
    }

    public class BuyMarketFish{
        public void onFishBuyFromMarket(){
            Console.WriteLine("You are buying fish from the market");
        }
    }
    public class BuyHatcharyFish{
        public void onFishBuyFromHatchary(){
            Console.WriteLine("You are buying fish from the hatchary");
        }
    }
}
