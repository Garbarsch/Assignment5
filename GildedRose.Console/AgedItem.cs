 namespace GildedRose.Console{
 
 public class AgedItem : Item
    {
        public override void Update()
        {
            SellIn -= 1;

            if(SellIn>0){
                if(Quality != 50){
                Quality += 1;
                }

            }
        }
    }
    
    }