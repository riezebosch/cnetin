using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject1
{
    public class JSONDemo
    {
        [Fact]
        public void SchrijfNaarJson()
        {
            var items = new[]{
                new Serie
                {
                    Season = new[]
                    {
                        new Season
                        {
                            Name = "Season 1",
                            Episodes = new[] 
                            {
                                new Episode
                                {
                                    Title = "The Law of Non-Contradiction",
                                    Ranking = 5
                                }
                            }
                        }
                    }
                }
            };

            var json = JsonConvert.SerializeObject(items);

            var terug = JsonConvert.DeserializeObject<Serie[]>(json);
            Assert.Equal("Season 1", terug[0].Season[0].Name);
        }
    }
}
