using System;
using System.Collections.Generic;

namespace MyGame
{
	public class BoardStatus
	{
		private List<Board> _boards;

		public BoardStatus ()
		{
			_boards = new List<Board> ();
		}

		public void AddBoard(Board b)
		{
			_boards.Add (b);
		}

		public void Draw()
		{
			foreach (Board b in _boards)
			{
				b.DrawBoard ();
			}
		}
	}
}

