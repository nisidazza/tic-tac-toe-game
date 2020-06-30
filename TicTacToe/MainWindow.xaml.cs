﻿using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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

        /// <summary>
        /// True if it is player 1's turn (X) or player 2's turn (O)
        /// </summary>
        private bool mPlayer1Turn;

        /// <summary>
        /// True if the game has ended
        /// </summary>
        private bool mGameEnded;

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

        /// <summary>
        /// Starts a new game and clears all values back to the start
        /// </summary>
        private void NewGame()
        {
            //create a new blank array of free cells
            mResults = new MarkType[9];

            for (var i = 0; i < mResults.Length; i++)
            {
                mResults[i] = MarkType.Free;
            }

            //Make sure Player 1 starts the game
            mPlayer1Turn = true;

            //take all the elements in the grid container, cast them to buttons, convert them from Enum to a list and iterate through them
            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                //change background, foreground and content to default values
                button.Content = string.Empty;
                button.Background = Brushes.White;
                button.Foreground = Brushes.Blue;
            });

            //make sure the game hasn't finished
            mGameEnded = false;
        }

        /// <summary>
        /// Handles a  button click event
        /// </summary>
        /// <param name="sender">The button was clicked</param>
        /// <param name="e">The event of the click</param>
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Start a new game on the click after it finished
            if (mGameEnded)
            {
                NewGame();
                return;
            }

            //Explicit cast that converts the sender obj to a button
            var button = (Button) sender;

            //Find the buttons position in the array
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            // access the value in the array
            var index = column + (row * 3);

            //Don't do anything if the cell already has a value in it
            if (mResults[index] != MarkType.Free) return;

            //Set the cell value based on which player turn is it
            mResults[index] = mPlayer1Turn ? MarkType.Cross : MarkType.Nought;

            //Set button text to the result
            button.Content = mPlayer1Turn ? "X" : "O";


            // Change the player's turn - shortcut (bitwise operator): mPlayer1Turn ^=true;
            if (mPlayer1Turn)
            {
                mPlayer1Turn = false;
            }
            else
            {
                mPlayer1Turn = true;
            }
            
        }
    }
}
