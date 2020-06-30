using System;
using System.Windows;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Private Members
        /// <summary>
        /// Holds the current results of cells in the active game
        /// </summary>
        private MarkType[] mResults;
        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>

        public MainWindow()
        {
            InitializeComponent();

            NewGame();
        }

        #endregion

        private void NewGame()
        {
            throw new NotImplementedException();
        }
    }
}
