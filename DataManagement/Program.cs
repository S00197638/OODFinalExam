using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JakeBeecham_S00197638;

namespace DataManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            GameData db = new GameData();

            using (db)
            {
                //Create some Game objects
                Game g1 = new Game()
                {
                    Name = "It Takes Two",
                    Platform = "PC, Xbox, PS, Switch",
                    MetacriticScore = 88,
                    Price = 69.99m,
                    Game_Image = "/images/ittakes2.jpg",
                    Description = " From Hazelight comes It Takes Two an innovative co-op adventure where uniquely varied gameplay and emotional storytelling intertwine in a fantastical journey. Founded to push the creative boundaries of what's possible in games, Hazelight is the award-winning studio behind the critically acclaimed A Way Out and Brothers: A Tale of Two Sons."
                };

                Game g2 = new Game()
                {
                    Name = "Miles Morales",
                    Platform = "PS",
                    MetacriticScore = 85,
                    Price = 79.99m,
                    Game_Image = "/images/milesmorales.jpg",
                    Description = "The latest adventure in the Spider-Man universe builds on and expand Marvel’s Spider-Man through an all-new story. Players experience the rise of Miles Morales as he masters new powers to become his own Spider-Man. With PS5’s SSD, players can near-instantaneously fast-travel across Marvel’s New York City, or feel the tension of each one of Miles’s web-swings, punches, web shots, and venom blasts with the DualSense wireless controller’s haptic feedback. Highly-detailed character models and enhanced visuals across the game intensify the story of Miles Morales as he faces great, new challenges while learning to be his own Spider-Man."
                };

                Game g3 = new Game()
                {
                    Name = "Halo 5",
                    Platform = "Xbox",
                    MetacriticScore = 84,
                    Price = 59.99m,
                    Game_Image = "/images/halo.jpg",
                    Description = "Peace has been devastated as colony worlds are unexpectedly attacked. What's more, when humanity's greatest hero goes missing, a new Spartan is assigned the task of hunting the Master Chief and solving a mystery that threatens the whole of the galaxy."
                };

                Game g4 = new Game()
                {
                    Name = "Animal Crossing",
                    Platform = "Switch",
                    MetacriticScore = 90,
                    Price = 49.99m,
                    Game_Image = "/images/animalcrossing.jpg",
                    Description = " If the hustle and bustle of modern life’s got you down, Tom Nook has a new business venture up his sleeve that he knows you’ll adore: the Nook Inc. Deserted Island Getaway Package. Sure, you’ve crossed paths with colorful characters near and far. Had a grand time as one of the city folk. May’ve even turned over a new leaf and dedicated yourself to public service. But deep down, isn’t there a part of you that longs for…freedom? Then perhaps a long walk on the beach of a deserted island, where a rich wealth of untouched nature awaits, is just what the doctor ordered. Peaceful creativity and charm await as you roll up your sleeves and make your new life whatever you want it to be. Collect resources and craft everything from creature comforts to handy tools. Embrace your green thumb as you interact with flowers and trees in new ways. Set up a homestead where the rules of what goes indoors and out no longer apply. Make friends with new arrivals, enjoy the seasons, pole-vault across rivers as you explore, and more."
                };

                //Add to database
                db.Games.Add(g1);
                db.Games.Add(g2);
                db.Games.Add(g3);
                db.Games.Add(g4);
                Console.WriteLine("Added Games to Database!");

                //Save Changes
                db.SaveChanges();
                Console.WriteLine("Database Saved Sucessfully!");
            }
        }
    }
}
