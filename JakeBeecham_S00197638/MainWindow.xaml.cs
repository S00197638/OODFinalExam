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

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new GameData();//Getting Access to Database

            var query = db.Games
                .Select(g => g);

            lbxGames.ItemsSource = query.ToList();
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
    }
}
