 namespace GildedRose.Console{
 
 public class BackStageItem : Item
    {
        public override void Update()
        {
             SellIn -= 1;
            
          if (SellIn < 11)
                            {
                                if (Quality < 50)
                                {
                                    Quality = Quality + 2;
                                }
                            }

                            if (SellIn < 6)
                            {
                                if (Quality < 50)
                                {
                                    Quality = Quality +1;
                                }
                            }
                            if (SellIn <0 )
                            {
                                Quality =0;
                            }
        }
    }
 }
           

        
    
    