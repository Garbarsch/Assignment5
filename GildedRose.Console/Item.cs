 namespace GildedRose.Console{
 
 public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    
    public virtual void Update(){
        SellIn -= 1;
        if (SellIn < 0 ){
            Quality -= 2;

        } else
        {
            Quality -= 1;

        } 
        if (Quality < 0){
            Quality = 0;
        }

    }
 }
 }
