using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JakeBeecham_S00197638
{
    public class Game
    {
        #region Properties
        public int ID { get; set; }
        public string Name { get; set; }
        public int MetacriticScore { get; set; }
        public string Description { get; set; }
        public string Platform { get; set; }
        public decimal Price { get; set; }
        public string Game_Image { get; set; }
        #endregion

        #region Constructors
        public Game(string name, int score, string description, string platform, decimal price, string gameImg = "")
        {
            Name = name;
            MetacriticScore = score;
            Description = description;
            Platform = platform;
            Price = price;
            Game_Image = gameImg;
        }

        public Game() { }
        #endregion
    }
}
