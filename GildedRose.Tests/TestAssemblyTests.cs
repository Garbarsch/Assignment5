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
            test = new Program()
            {
                Items = new List<Item>
                {
                    new Item {Name = "Generic Item", SellIn = 5, Quality = 20},
                    new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                    new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                    new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 5}
                }
            };
        }

        [Fact]
        public void Sulfuras_quality_doesnt_decrement()
        {
            var expected = test.Items[2].Quality;

           
            test.UpdateQuality();
            var actual = test.Items[2].Quality;

            Assert.Equal(expected, actual);
        }
          [Fact]
        public void Brie_quality_increments_one_when_not_expired()
        {
            
            var item = test.Items[1];
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
            var item = test.Items[3];
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
            var item = test.Items[3];
          
            while(item.SellIn>10 && item.SellIn>5){
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
            var item = test.Items[3];
          
            while(item.SellIn>5 && item.SellIn>0){
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
            var item = test.Items[3];
          
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
    public void Generic_quality_decrement_one_when_SellIn_not_negative(){
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
    public void Generic_quality_decrement_two_when_SellIn_negative(){
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
            var item = test.Items[1];

              while(item.Quality<=50){
                test.UpdateQuality();
                System.Console.WriteLine("hej");
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

              while(item.Quality>=0){
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
}
}