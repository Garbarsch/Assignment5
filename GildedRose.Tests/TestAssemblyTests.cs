using Xunit;
using System.Collections.Generic;
using GildedRose.Console;

namespace GildedRose.Tests
{
    public class TestAssemblyTests 
    {
         Program test;
        public TestAssemblyTests()
        {
            test = new Program();
            
                test.Items = new List<Item>
                {
                    new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 30},
                    new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                    new AgedItem {Name = "Aged Brie", SellIn = 5, Quality = 0},
                    new LegendaryItem {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                    new BackStageItem {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 5},
                    new ConjuredItem {Name = "Conjured", SellIn = 5, Quality = 7}
                };
            
        }
         [Fact]
        public void TestTheTruth()
        {
            Assert.True(true);
        }


        [Fact]
        public void Sulfuras_quality_doesnt_decrement()
        {
            var expected = test.Items[3].Quality;
        
            test.UpdateQuality();
            var actual = test.Items[3].Quality;

            Assert.Equal(expected, actual);
        }
          [Fact]
        public void Brie_quality_increments_one_when_not_expired()
        {
            
            var item = test.Items[2];
            var oldQuality = item.Quality;
            var oldSellIn = item.SellIn;

           
            test.UpdateQuality();
            var newQuality = oldQuality + 1;
            var newSellIn = oldSellIn - 1;

        
            Assert.Equal(newSellIn, item.SellIn);
            Assert.Equal(newQuality, item.Quality);
        }
        [Fact]
        public void Backstage_quality_increments_when_SellIn_higher_than_10(){
            var item = test.Items[4];
            var oldQuality = item.Quality;
            var oldSellIn = item.SellIn;

             test.UpdateQuality();
            var newQuality = oldQuality + 1;
            var newSellIn = oldSellIn - 1;

        
            Assert.Equal(newSellIn, item.SellIn);
            Assert.Equal(newQuality, item.Quality);


        }
         [Fact]
        public void Backstage_quality_increments_when_SellIn_lower_than_10_over_5(){
            var item = test.Items[4];
          
            while(item.SellIn>11 && item.SellIn>6){
                test.UpdateQuality();
            }
            var oldQuality = item.Quality;
            var oldSellIn = item.SellIn;

            test.UpdateQuality();
            var newQuality = oldQuality+2;
            var newSellIn = oldSellIn -1;


            Assert.Equal(newSellIn, item.SellIn);
            Assert.Equal(newQuality, item.Quality);

        }
        [Fact]
        public void Backstage_quality_increments_when_SellIn_lower_than_5_over_0(){
            var item = test.Items[4];
          
            while(item.SellIn > 6 && item.SellIn>0){
                test.UpdateQuality();
            }
            var oldQuality = item.Quality;
            var oldSellIn = item.SellIn;

            test.UpdateQuality();
            var newQuality = oldQuality+3;
            var newSellIn = oldSellIn -1;


            Assert.Equal(newSellIn, item.SellIn);
            Assert.Equal(newQuality, item.Quality);


        }
        [Fact]
        public void Backstage_quality_increments_when_SellIn_is_over_date(){
            var item = test.Items[4];
          
            while(item.SellIn>0){
                test.UpdateQuality();
            }
            var oldQuality = item.Quality;
            var oldSellIn = item.SellIn;

            test.UpdateQuality();
            var newQuality = 0;
            var newSellIn = oldSellIn -1;


            Assert.Equal(newSellIn, item.SellIn);
            Assert.Equal(newQuality, item.Quality);


        }
        [Fact]
        public void Item_quality_decrement_one_when_SellIn_not_negative(){
            var item = test.Items[0];
            var oldQuality = item.Quality;
            var oldSellIn = item.SellIn;

            test.UpdateQuality();
            var newQuality = oldQuality - 1;
            var newSellIn = oldSellIn - 1; 
            Assert.Equal(newQuality, item.Quality);
            Assert.Equal(newSellIn, item.SellIn);
        }
        [Fact]
        public void Item_quality_decrement_two_when_SellIn_negative(){
            var item = test.Items[0];

              while(item.SellIn>0){
                test.UpdateQuality();
            }
            var oldQuality = item.Quality;
            var oldSellIn = item.SellIn;

            test.UpdateQuality();
            var newQuality = oldQuality - 2;
            var newSellIn = oldSellIn - 1; 
            Assert.Equal(newQuality, item.Quality);
            Assert.Equal(newSellIn, item.SellIn);
        }

       [Fact]
        public void Quality_is_never_above_50(){
            var item = test.Items[2];
                item.SellIn = 50;
              while(item.Quality<50){
                test.UpdateQuality();
            }
            var oldQuality = item.Quality;
            var oldSellIn = item.SellIn;

            test.UpdateQuality();
            var newQuality = oldQuality;
            var newSellIn = oldSellIn - 1; 
            Assert.Equal(newQuality, item.Quality);
            Assert.Equal(newSellIn, item.SellIn);
        }
        [Fact]
        public void Quality_is_never_below_0(){
            var item = test.Items[0];

              while(item.Quality>0){
                test.UpdateQuality();
            }
            var oldQuality = item.Quality;
            var oldSellIn = item.SellIn;

            test.UpdateQuality();
            var newQuality = oldQuality;
            var newSellIn = oldSellIn - 1; 
            Assert.Equal(newQuality, item.Quality);
            Assert.Equal(newSellIn, item.SellIn);
        } 
    
        [Fact]
        public void Conjured_items_Quality_degrades_twice_as_fast()
        {
            var conjuredItem = test.Items[5];
            var normalItem = test.Items[1];
            Assert.True(conjuredItem.Quality==normalItem.Quality);

            var expConjuredQuality = conjuredItem.Quality - 2; 
            var expNormItemQuality = normalItem.Quality -1;

            conjuredItem.Update();
            normalItem.Update();

            Assert.True(conjuredItem.Quality < normalItem.Quality);
            Assert.Equal(expConjuredQuality, conjuredItem.Quality);
            Assert.Equal(expNormItemQuality, normalItem.Quality);
        }
    }
}