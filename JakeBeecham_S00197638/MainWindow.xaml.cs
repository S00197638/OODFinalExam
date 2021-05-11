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

            var query = db.Games
                .Select(g => g);

            AllGames = query.ToList();

            lbxGames.ItemsSource = AllGames;
        }
        #endregion

        #region Selection
        private void lbxGames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Game selectedGame = lbxGames.SelectedItem as Game;

            if (selectedGame != null)
            {
                tblkGameDetails.Text = $"Price: {selectedGame.Price:C}\n" +
                    $"Platform(s): {selectedGame.Platform}";
                tblkGameDescription.Text = $"Game Description: {selectedGame.Description}";
            }
        }
        #endregion

        #region Filter
        private void cbGameFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Determine what is selected
            string selectedFilter = cbGameFilter.SelectedItem as string;
            //Setup Filter List
            List<Game> filteredGames = new List<Game>();
            //Check Filters
            CheckFilters(selectedFilter, filteredGames);
        }

        private void CheckFilters(string selectedFilter, List<Game> filteredGames)
        {
            switch (selectedFilter)
            {
                case "All":
                    lbxGames.ItemsSource = null;
                    lbxGames.ItemsSource = AllGames;
                    Reset();
                    break;
                case "PC":
                    lbxGames.ItemsSource = null;
                    var queryPC = db.Games
                        .Where(g => g.ID == 1)
                        .Select(g => g);
                    filteredGames = queryPC.ToList();
                    lbxGames.ItemsSource = filteredGames;
                    Reset();
                    break;
                case "PS":
                    lbxGames.ItemsSource = null;
                    var queryPS = db.Games
                        .Where(g => g.Platform == "PS")
                        .Select(g => g);
                    filteredGames = queryPS.ToList();
                    lbxGames.ItemsSource = filteredGames;
                    Reset();
                    break;
                case "Switch":
                    lbxGames.ItemsSource = null;
                    var queryS = db.Games
                        .Where(g => g.Platform == "Switch")
                        .Select(g => g);
                    filteredGames = queryS.ToList();
                    lbxGames.ItemsSource = filteredGames;
                    Reset();
                    break;
                case "Xbox":
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

        private void Reset()
        {
            lbxGames.SelectedItem = null;
            tblkGameDetails.Text = "";
            tblkGameDescription.Text = "";
        }
        #endregion
    }
}
