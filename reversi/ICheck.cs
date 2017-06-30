using System;

namespace MyGame
{
	/// <summary>
	/// Checking method
	/// </summary>
	public interface ICheck
	{
		void CheckStatus();
		bool CheckPlus(int adr, int maxvalue , int plus , CellState cs1, CellState cs2);
		bool CheckMinus(int adr, int minvalue , int minus , CellState cs1, CellState cs2);
		void UpdatePlus(int adr, int maxvalue , int plus ,CellState cs1 ,CellState cs2);
		void UpadateMinus(int adr, int minvalue , int minus ,CellState cs1 ,CellState cs2);
		void UpdateBoardStatus(float x , float y , CellState cs1 ,CellState cs2);
	}
}

