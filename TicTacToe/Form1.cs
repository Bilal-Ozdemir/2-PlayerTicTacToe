using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
	public partial class Form1 : Form
	{
		// Accessing the images. 
		Image imageX = TicTacToe.Properties.Resources.x;
		Image imageO = TicTacToe.Properties.Resources.o;

		// Creating an array for the pictureboxes
		public PictureBox[] cells;
		bool xTurn = true;
		public Form1()
		{

			InitializeComponent();
			// Initializing my cells
			cells = new PictureBox[] { cell1, cell2, cell3, cell4, cell5, cell6, cell7, cell8, cell9 };

			foreach (PictureBox cell in cells)
			{
				// Activating my CellClick method everytime a cell is clicked.
				cell.Click += CellClick;
			}

		}
		/// <summary>
		/// This is method acts based on the user's cell clicks.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CellClick(object sender, EventArgs e)
		{
			PictureBox cellClicked = (PictureBox)sender;

			if (cellClicked.Image != null)
			{

				return;
			}

			if (xTurn)
			{
				cellClicked.Image = imageX;
			}
			else
			{
				cellClicked.Image = imageO;
			}
			xTurn = !xTurn;



			if (CheckWinner())
			{
				// Displaying the win messages based on who won.
				if (xTurn)
				{
					MessageBox.Show("O Wins!!!");
					GameReset();
					return;
				}
				else
				{
					MessageBox.Show("X Wins!!!");
					GameReset();
					return;
				}

			}
			// Displaying the draw message if there is no winner after all the boxes are filled.
			if (AllCellsFilled())
			{
				MessageBox.Show("It's a Draw!!!");
				GameReset();
				return;
			}



		}

		/// <summary>
		/// This method is checking the win condition.
		/// It checks the rows, columns, and diagonals.
		/// </summary>
		/// <returns></returns>
		public bool CheckWinner()
		{
			// Loop for checking rows.
			for (int r = 0; r < 9; r += 3)
			{
				// Checking the winning conditions for rows. 
				if (cells[r].Image != null && cells[r].Image == cells[r + 1].Image && cells[r + 1].Image == cells[r + 2].Image)
				{
					return true;
				}
			}

			// Loop for checking columns
			for (int c = 0; c < 3; c++)
			{
				// Checking the winning conditions for columns. 
				if (cells[c].Image != null && cells[c].Image == cells[c + 3].Image && cells[c + 3].Image == cells[c + 6].Image)
				{
					return true;
				}
			}


			// Checking Diagonal (from top left to bottom right)
			if (cells[0].Image != null && cells[0].Image == cells[4].Image && cells[4].Image == cells[8].Image)
			{
				return true;
			}

			// Checking Diagonal (from top right to bottom left)
			else if (cells[2].Image != null && cells[2].Image == cells[4].Image && cells[4].Image == cells[6].Image)
			{
				return true;
			}

			return false;
		}

		/// <summary>
		/// This method checks if all the cells are filled. 
		/// </summary>
		/// <returns></returns>
		public bool AllCellsFilled()
		{
			// This loop checks if the cells are not null. If they are not all filled, it returns false.
			// If they are all filled, it returns true. 
			foreach (PictureBox cell in cells)
			{
				if (cell.Image == null)
				{
					return false;
				}

			}
			return true;

		}

		/// <summary>
		/// This method resets the game after the result is displayed. 
		/// </summary>
		public void GameReset()
		{
			// Reseting all the cells.
			foreach (PictureBox cell in cells)
			{
				cell.Image = null;
			}
			// Giving the turn to the x (since it's the start of the game).
			xTurn = true;
		}



	}
}
