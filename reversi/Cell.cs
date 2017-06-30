using System;
using SwinGameSDK;

namespace MyGame
{
	public class Cell : Shape 
	{
		//field
		private int _width;
		private int _height;
		private Chess _chess;

		//contructor
		public Cell (float x , float y) 
		{
			_width = 100;
			_height = 100;
			X = x;
			Y = y;
			CS = CellState.None;
			_chess = new Chess (x, y );
		}

		/// <summary>
		/// Checks the cellstate of cell , then change chess status same as cell
		/// </summary>
		public void CheckStatus ()
		{
			if (CS == CellState.None)
			{
				_chess.CS = CellState.None;
			}
			else if (CS == CellState.Black)
			{
				_chess.CS = CellState.Black;
			}
			else 
			{
				_chess.CS = CellState.White;
			}
		}

		/// <summary>
		/// Draw this Circle and Chess.
		/// </summary>
		public override void Draw()
		{
			CheckStatus ();
			SwinGame.FillRectangle (Color.ForestGreen, X, Y, _width, _height);
			SwinGame.DrawRectangle (Color.Black, X, Y, _width + 2, _height + 2);
			_chess.Draw ();
		}


		/// <summary>
		/// Draw the Cell which is valid
		/// </summary>
		public void Hint()
		{
			SwinGame.FillRectangle (Color.LimeGreen, X, Y, _width, _height);
			SwinGame.DrawRectangle (Color.Black, X, Y, _width + 2, _height + 2);
		}

		/// <summary>
		/// Determines whether the point in the cell
		/// </summary>
		/// <returns><c>true</c> if this instance is at the specified pt; otherwise, <c>false</c>.</returns>
		/// <param name="pt">Point.</param>
		public bool IsAt(Point2D pt)
		{
			if (SwinGame.PointInRect(pt , X , Y, _width, _height))
			{	return true ;	}
			else
			{	return false;	}
		}
	}
}

