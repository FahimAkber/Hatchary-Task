using System;
using System.Threading;

namespace TaskOne{
    public class BuyFish{
        Fish fish;

        public delegate void MarketFishHandler();
        public event MarketFishHandler MarketFishBuyEvent;

        protected virtual void OnMarketFishBuying(){
            if(MarketFishBuyEvent != null){
                MarketFishBuyEvent();
            }
        }

        public delegate void HatcharyFishHandler();
        public event HatcharyFishHandler HatcharyFishBuyEvent;
        protected virtual void OnHatcharyFishBuying(){
            if(HatcharyFishBuyEvent != null){
                HatcharyFishBuyEvent();
            }
        }

        public BuyFish(Fish fish){
            this.fish = fish;
        }

        public void buyFishFromMarket(){
            if(fish.fishAmount > fish.totalAmount){
                Console.WriteLine("Insufficient fish amount");
                Console.WriteLine("you have "+fish.totalAmount+"fish in the market. request to buy fish from hatchary");
            } else{
                Console.WriteLine("You want to buy "+fish.fishAmount+" fish from market");
                fish.totalAmount = fish.totalAmount - fish.fishAmount;

                Thread.Sleep(3000);

                OnMarketFishBuying();

                Console.WriteLine("Successfully buying");
            }
        }

        public void buyFishFromHatchary(){
            if(fish.totalAmount <= 20){
                Console.WriteLine("You want to buy "+fish.fishAmount+"fish from Hatchary");
                fish.totalAmount = fish.totalAmount + fish.fishAmount;
                
                Thread.Sleep(3000);

                OnHatcharyFishBuying();
                Console.WriteLine("Successfully buying");
            } else{
                Console.WriteLine("you have enough fish in the market. (20 pieces)");
            }

        }

    }
}