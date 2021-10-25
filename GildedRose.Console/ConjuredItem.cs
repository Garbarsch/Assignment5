namespace GildedRose.Console{
 
    public class ConjuredItem : Item{

        public override void Update()
        {
            SellIn -= 1;
            if (SellIn < 0 ){
                Quality -= 4;

            }
            
            else{
                Quality -= 2;

            } 
            
            if (Quality < 0){
                Quality = 0;
            }
        }
    } 
}

 