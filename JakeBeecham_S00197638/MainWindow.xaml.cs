using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JakeBeecham_S00197638
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Setup
        GameData db;//Reference to Database
        List<Game> AllGames;//List of all Games

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new GameData();//Getting Access to Database
            AllGames = new List<Game>();//Creating new list

            //Populate Combo Box
            string[] filterTypes = { "All", "PC", "PS", "Switch", "Xbox" };
            cbGameFilter.ItemsSource = filterTypes;
            cbGameFilter.SelectedItem = "All";

            //Using Linq to get Games from Database
            var query = db.Games
                .Select(g => g);

            //Setting the list of all games to the result of the query
            AllGames = query.ToList();

            //Setting source of the listbox to the list of games
            lbxGames.ItemsSource = AllGames;
        }
        #endregion

        #region Selection
        //Listbox Event Handler
        private void lbxGames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Get the selected Game
            Game selectedGame = lbxGames.SelectedItem as Game;

            //Checking there is a game selected
            if (selectedGame != null)
            {
                //Outputting Game Details
                tblkGamePlatform.Text = $"{selectedGame.Platform}";
                tblkGamePrice.Text = $"{selectedGame.Price:C}";
                tblkGameDescription.Text = $"{selectedGame.Description}";
            }
        }
        #endregion

        #region Filter
        //ComboBox Event Handler
        private void cbGameFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Determine what is selected
            string selectedFilter = cbGameFilter.SelectedItem as string;
            //Setup Filter List
            List<Game> filteredGames = new List<Game>();
            //Check Filters
            CheckFilters(selectedFilter, filteredGames);
        }

        //Method to Check Filters
        private void CheckFilters(string selectedFilter, List<Game> filteredGames)
        {
            //Using Switch statement to check each filter option
            switch (selectedFilter)
            {
                //Setting source to all games
                case "All":
                    lbxGames.ItemsSource = null;
                    lbxGames.ItemsSource = AllGames;
                    Reset();
                    break;
                case "PC"://Setting Source to PC game
                    lbxGames.ItemsSource = null;
                    var queryPC = db.Games
                        .Where(g => g.ID == 1)
                        .Select(g => g);
                    filteredGames = queryPC.ToList();
                    lbxGames.ItemsSource = filteredGames;
                    Reset();
                    break;
                case "PS"://Setting Source to PS Game
                    lbxGames.ItemsSource = null;
                    var queryPS = db.Games
                        .Where(g => g.Platform == "PS")
                        .Select(g => g);
                    filteredGames = queryPS.ToList();
                    lbxGames.ItemsSource = filteredGames;
                    Reset();
                    break;
                case "Switch"://Setting Source to Switch Game
                    lbxGames.ItemsSource = null;
                    var queryS = db.Games
                        .Where(g => g.Platform == "Switch")
                        .Select(g => g);
                    filteredGames = queryS.ToList();
                    lbxGames.ItemsSource = filteredGames;
                    Reset();
                    break;
                case "Xbox"://Setting Source to Xbox Game
                    lbxGames.ItemsSource = null;
                    var queryX = db.Games
                        .Where(g => g.Platform == "Xbox")
                        .Select(g => g);
                    filteredGames = queryX.ToList();
                    lbxGames.ItemsSource = filteredGames;
                    Reset();
                    break;
            }
        }

        //Reset Screen
        private void Reset()
        {
            //Resetting back to defaults
            lbxGames.SelectedItem = null;
            tblkGamePlatform.Text = "";
            tblkGamePrice.Text = "";
            tblkGameDescription.Text = "";
        }
        #endregion
    }
}
