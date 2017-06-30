using System;

namespace MyGame
{
	/// <summary>
	/// Board stucture method
	/// </summary>
	public interface IBoard
	{
		void NewBoard();
		void ClearBoard();
		void DrawBoard();
		void AddCell(Cell c);
		void AddValid(Cell c);


	}
}

