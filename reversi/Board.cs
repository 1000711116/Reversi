using System;
using System.Collections.Generic;
using SwinGameSDK;


namespace MyGame
{
	public class Board : IBoard , ICheck
	{
		//field
		private List<Cell> _cells, _valid;
		private Player _p;
		private int _count, _black, _white, _address;


		//Properties
		public List<Cell> Cells			{	get{ return _cells;		 	}								}
		public List<Cell> Valid			{	get{ return _valid; 		}								}
		public int CellCount			{	get { return _count ;		}								}
		public int Address				{	get { return _address ;	 	}								}
		public Player P					{	get{ return _p;				}		set{ _p = value; }		}
		public int Black				{	get{ return _black; 		}		}
		public int White				{	get{ return _white;			}		}


		//Contructor
		public Board ()
		{	_cells =new List<Cell> ();
			_p = new Player ();
			_valid = new List<Cell> ();	}

		/// <summary>
		/// Adds the cell to the board
		/// </summary>
		/// <param name="c">C.</param>
		public void AddCell( Cell c)		{	_cells.Add(c);	}

		/// <summary>
		/// Adds the valid cell
		/// </summary>
		/// <param name="c">C.</param>
		public void AddValid(Cell c)		{	_valid.Add(c);		}

		/// <summary>
		/// Clears the board.
		/// </summary>
		public void ClearBoard()		{	_cells.Clear ();	}

		/// <summary>
		/// Draws the board.
		/// </summary>
		public void DrawBoard()
		{	foreach (Cell c in _cells)		{		c.Draw ();	}
			if (SwinGame.KeyTyped (KeyCode.vk_h))
			{
				foreach (Cell c in _valid)		{		c.Hint ();		}	
			}
		}	

		/// <summary>
		/// create a new board
		/// </summary>
		public void NewBoard()
		{
			for (int a= 0; a <=5; a++)
			{	for (int d=0; d <= 5; d++)
				{	Cell c = new Cell (a*100 ,d*100);
					AddCell (c);
					if (a == 2 && d == 2)
					{	c.CS = CellState.Black;			
					}
					if (a == 2&& d == 3)
					{	c.CS = CellState.White;		
					}
					if (a == 3 && d == 2)
					{	c.CS = CellState.White;			
					}
					if (a == 3 && d == 3)
					{	c.CS = CellState.Black;			
					}

				}
			}
			_count = 32;    P.Turn = 1;	
			_black = 2; 	_white = 2;
		}


		/// <summary>
		/// Gets the address of the _cells
		/// </summary>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		public void GetAddress(float x , float y)
		{
			if (x == 0 && y == 0)		{	_address = 0;	}		if (x == 0 && y == 100)		{	_address = 1;	}		if (x == 0 && y == 200)		{	_address = 2;	}	
			//3														//4														//5											
			if (x == 0 && y == 300)		{	_address = 3;	}		if (x == 0 && y == 400)		{	_address = 4;	}		if (x == 0 && y == 500)		{	_address = 5;	}
			//6														//7														//8
			if (x == 100 && y == 0)		{	_address = 6;	}		if (x == 100 && y == 100)	{	_address = 7;	}		if (x == 100 && y == 200)	{	_address = 8;	}
			//9														//10													//11
			if (x == 100 && y == 300)	{	_address = 9;	}		if (x == 100 && y == 400)	{	_address = 10;	}		if (x == 100 && y == 500)	{	_address = 11;	}
			//12													//13													//14	
			if (x == 200 && y == 0)		{	_address = 12;	}		if (x == 200 && y == 100)	{	_address = 13;	}		if (x == 200 && y == 200)	{	_address = 14;	}
			//15													//16													//17	
			if (x == 200 && y == 300)	{	_address = 15;	}		if (x == 200 && y == 400)	{	_address = 16;	}		if (x == 200 && y == 500)	{	_address = 17;	}
			//18													//19													//20	
			if (x == 300 && y == 0)		{	_address = 18;	}		if (x == 300 && y == 100)	{	_address = 19;	}		if (x == 300 && y == 200)	{	_address = 20;	}	
			//21													//22													//23	
			if (x == 300 && y == 300)	{	_address = 21;	}		if (x == 300 && y == 400)	{	_address = 22;	}		if (x == 300 && y == 500)	{	_address = 23;	}
			//24													//25													//26
			if (x == 400 && y == 0)		{	_address = 24;	}		if (x == 400 && y == 100)	{	_address = 25;	}		if (x == 400 && y == 200)	{	_address = 26;	}
			//27													//28													//29	
			if (x == 400 && y == 300)	{	_address = 27;	}		if (x == 400 && y == 400)	{	_address = 28;	}		if (x == 400 && y == 500)	{	_address = 29;	}	
			//30													//31													//32
			if (x == 500 && y == 0)		{	_address = 30;	}		if (x == 500 && y == 100)	{	_address = 31;	}		if (x == 500 && y == 200)	{	_address = 32;	}	
			//33													//34													//35	
			if (x == 500 && y == 300)	{	_address = 33;	}		if (x == 500 && y == 400)	{	_address = 34;	}		if (x == 500 && y == 500)	{	_address = 35;	}			
		}


		/// <summary>
		/// Check whether there is valid cell (adress plusing)
		/// </summary>
		/// <returns><c>true</c>, if plus was checked, <c>false</c> otherwise.</returns>
		/// <param name="adr">Adr.</param>
		/// <param name="maxvalue">Maxvalue.</param>
		/// <param name="plus">Plus.</param>
		/// <param name="cs1">Cs1.</param>
		/// <param name="cs2">Cs2.</param>
		public bool CheckPlus(int adr, int maxvalue , int plus , CellState cs1, CellState cs2)
		{
			adr = adr + plus;
				if(_cells[adr].CS == cs1 )
					{	while (adr <= (maxvalue-plus))
						{	
						if (_cells [adr  + plus ].CS == CellState.None)
								{		return false;		}
							if (_cells [adr  + plus ].CS == cs2 )
								{		return true;			}
							adr = adr + plus;
						}
					}
			return false;
		}

		/// <summary>
		/// Check whether there is valid cell (adress minusing)
		/// </summary>
		/// <returns><c>true</c>, if minus was checked, <c>false</c> otherwise.</returns>
		/// <param name="adr">Adr.</param>
		/// <param name="minvalue">Minvalue.</param>
		/// <param name="minus">Minus.</param>
		/// <param name="cs1">Cs1.</param>
		/// <param name="cs2">Cs2.</param>
		public bool CheckMinus(int adr, int minvalue , int minus , CellState cs1, CellState cs2)
		{	
			adr = adr - minus ;
				if (_cells [adr].CS == cs1)
				{	while (adr >= (minvalue + minus ))
					{
						if (_cells [adr - minus ].CS == CellState.None)
							{	return false;		}
						if (_cells [adr - minus ].CS == cs2)
							{	return true;		}
						adr = adr - minus;
					}
				}
			return false;
		}

		/// <summary>
		/// Checks whether there is valid cell in the board
		/// </summary>
		public void CheckStatus()
		{	
			_valid.Clear ();
			CellState cs1, cs2;
			if (P.Turn == 1)		{		cs1 = CellState.White;		cs2 = CellState.Black;		}
			else 					{	   cs1 = CellState.Black;		cs2 = CellState.White;		}

			foreach (Cell c in _cells)
			{
				if (c.CS == CellState.None)
				{
					GetAddress (c.X, c.Y);
					switch (Address)
					{
					case 0:
						if (CheckPlus (Address, 5, 1 ,cs1, cs2) == true || CheckPlus (Address, 35, 7 ,cs1, cs2) == true || 
							CheckPlus (Address, 30, 6 ,cs1, cs2) == true)
						{	AddValid (c);	}
						break;
					case 1:
						if (CheckPlus (Address, 31, 6 ,cs1, cs2) == true || CheckPlus (Address, 29, 7 ,cs1, cs2) == true	||	
							CheckPlus (Address, 5, 1,cs1, cs2) == true)
						{	AddValid (c);	}
						break;
					case 2:
						if (CheckMinus (Address, 0, 1,cs1, cs2) == true ||	CheckPlus (Address, 12, 5,cs1, cs2) == true	||	
							CheckPlus (Address, 32, 6,cs1, cs2) == true ||	CheckPlus (Address, 23, 7,cs1, cs2) == true	||	
							CheckPlus (Address, 5, 1,cs1, cs2) == true)
						{	AddValid (c);	}
						break;
					case 3:
						if (CheckMinus (Address, 0, 1,cs1, cs2) == true	|| CheckPlus (Address, 18, 5,cs1, cs2) == true	||
						    CheckPlus (Address, 33, 6,cs1, cs2) == true	|| CheckPlus (Address, 17, 7,cs1, cs2) == true	|| 
							CheckPlus (Address, 5, 1,cs1, cs2) == true)
						{	AddValid (c);	}
						break;
					case 4:
						if (CheckMinus (Address, 0, 1,cs1, cs2) == true || CheckPlus (Address, 24, 5,cs1, cs2) == true || 
							CheckPlus (Address, 34, 6,cs1, cs2) == true)
						{	AddValid (c);	}
						break;
					case 5:
						if (CheckMinus (Address, 0, 1,cs1, cs2) == true	||	CheckPlus (Address, 30, 5,cs1, cs2) == true	|| 
							CheckPlus (Address, 35, 6,cs1, cs2) == true)
						{	AddValid (c);	}
						break;
					case 6:
						if (CheckPlus (Address, 11, 1,cs1, cs2) == true || CheckPlus (Address, 34, 7,cs1, cs2) == true || 
							CheckPlus (Address, 30, 6,cs1, cs2) == true)
						{	AddValid (c);	}
						break;
					case 7:
						if (CheckPlus (Address, 11, 1,cs1, cs2) == true || CheckPlus (Address, 35, 7,cs1, cs2) == true || 
							CheckPlus (Address, 31, 6,cs1, cs2) == true)
						{	AddValid (c);	}
						break;
					case 8:
						if (CheckPlus (Address, 11, 1,cs1, cs2) == true || CheckPlus (Address, 29, 7,cs1, cs2) == true || 
							CheckPlus (Address, 32, 6,cs1, cs2) == true ||	CheckPlus (Address, 18, 5,cs1, cs2) == true ||	
							CheckMinus (Address, 6, 1,cs1, cs2) == true)
						{	AddValid (c);	}
						break;
					case 9:
						if (CheckPlus (Address, 11, 1,cs1, cs2) == true || CheckPlus (Address, 23, 7,cs1, cs2) == true || 
							CheckPlus (Address, 33, 6,cs1, cs2) == true	|| CheckPlus (Address, 24, 5,cs1, cs2) == true	||
							CheckMinus (Address, 6, 1,cs1, cs2) == true)
						{	AddValid (c);	}
						break;
					case 10:
						if (CheckPlus (Address, 34, 6,cs1, cs2) == true	|| CheckPlus (Address, 30, 5,cs1, cs2) == true || CheckMinus (Address, 6, 1,cs1, cs2) == true)
						{	AddValid (c);	}
						break;
					case 11:
						if (CheckPlus (Address, 35, 6,cs1, cs2) == true || CheckPlus (Address, 31, 5,cs1, cs2) == true || CheckMinus (Address, 6, 1,cs1, cs2) == true)
						{	AddValid (c);	}
						break;
					case 12:
						if (CheckMinus (Address, 0, 6,cs1, cs2) == true || CheckMinus (Address, 2, 5,cs1, cs2) == true || CheckPlus (Address, 17, 1,cs1, cs2) == true
							|| CheckPlus (Address, 33, 7,cs1, cs2) == true || CheckPlus (Address, 30, 6,cs1, cs2) == true)
						{	AddValid (c);	}
						break;
					case 13:
						if (CheckMinus (Address, 1, 6,cs1, cs2) == true || CheckMinus (Address, 3, 5,cs1, cs2) == true || CheckPlus (Address, 17, 1,cs1, cs2) == true
							|| CheckPlus (Address, 34, 7,cs1, cs2) == true || CheckPlus (Address, 31, 6,cs1, cs2) == true)
						{	AddValid (c);	}
						break;
					case 16:
						if (CheckMinus (Address, 2, 7,cs1, cs2) == true || CheckMinus (Address, 4, 6,cs1, cs2) == true || CheckPlus (Address, 34, 6,cs1, cs2) == true
							|| CheckPlus (Address, 31, 5,cs1, cs2) == true || CheckMinus (Address, 12, 1,cs1, cs2) == true)
						{	AddValid (c);	}
						break;	
					case 17:
						if (CheckMinus (Address, 3, 7,cs1, cs2) == true || CheckMinus (Address, 5, 6,cs1, cs2) == true || CheckPlus (Address, 35, 6,cs1, cs2) == true
							|| CheckPlus (Address, 32, 5,cs1, cs2) == true || CheckMinus (Address, 12, 1,cs1, cs2) == true)
						{	AddValid (c);	}
						break;
					case 18:
						if (CheckMinus (Address, 0, 6,cs1, cs2) == true || CheckMinus (Address, 3, 5,cs1, cs2) == true || CheckPlus (Address, 23, 1,cs1, cs2) == true
							|| CheckPlus (Address, 32, 7,cs1, cs2) == true || CheckPlus (Address, 30, 6,cs1, cs2) == true)
						{	AddValid (c);	}
						break;
					case 19:
						if (CheckMinus (Address, 1, 6,cs1, cs2) == true || CheckMinus (Address, 4, 5,cs1, cs2) == true || CheckPlus (Address, 23, 1,cs1, cs2) == true
							|| CheckPlus (Address, 33, 7,cs1, cs2) == true || CheckPlus (Address, 31, 6,cs1, cs2) == true)
						{	AddValid (c);	}
						break;
					case 22:
						if (CheckMinus (Address, 1, 7,cs1, cs2) == true || CheckMinus (Address, 4, 6,cs1, cs2) == true || CheckPlus (Address, 34, 6,cs1, cs2) == true
							|| CheckPlus (Address, 32, 5,cs1, cs2) == true || CheckMinus (Address, 18, 1,cs1, cs2) == true)
						{	AddValid (c);	}
						break;
					case 23:
						if (CheckMinus (Address, 2, 7,cs1, cs2) == true || CheckMinus (Address, 5, 6,cs1, cs2) == true || CheckPlus (Address, 35, 6,cs1, cs2) == true
							|| CheckPlus (Address, 33, 5,cs1, cs2) == true || CheckMinus (Address, 18, 1,cs1, cs2) == true)
						{	AddValid (c);	}
						break;
					case 24:
						if (CheckMinus (Address, 0, 6,cs1, cs2) == true || CheckMinus (Address, 4, 5,cs1, cs2) || CheckPlus (Address, 29, 1,cs1, cs2) == true)
						{	AddValid (c);	}
						break;
					case 25:
						if (CheckMinus (Address, 1, 6,cs1, cs2) == true || CheckMinus (Address, 5, 5,cs1, cs2) == true || CheckPlus (Address, 29, 1,cs1, cs2) == true)
						{	AddValid (c);	}
						break;
					case 26:
						if (CheckMinus (Address, 12, 7,cs1, cs2) == true || CheckMinus (Address, 2, 6,cs1, cs2) == true || CheckMinus (Address, 11, 5,cs1, cs2) == true
							|| CheckPlus (Address, 29, 1,cs1, cs2) == true || CheckMinus (Address, 24, 1,cs1, cs2) == true)
						{	AddValid (c);	}
						break;
					case 27:
						if (CheckMinus (Address, 6, 7,cs1, cs2) == true || CheckMinus (Address, 3, 6,cs1, cs2) == true || CheckMinus (Address, 27, 5,cs1, cs2) == true
							|| CheckPlus (Address, 29, 1,cs1, cs2) == true || CheckMinus (Address, 24, 1,cs1, cs2) == true)
						{	AddValid (c);	}
						break;
					case 28:
						if (CheckMinus (Address, 0, 7,cs1, cs2) == true || CheckMinus (Address, 4, 6,cs1, cs2) == true || CheckMinus (Address, 24, 1,cs1, cs2) == true)
						{	AddValid (c);	}
						break;
					case 29:
						if (CheckMinus (Address, 1, 7,cs1, cs2) == true || CheckMinus (Address, 5, 6,cs1, cs2) == true || CheckMinus (Address, 24, 1,cs1, cs2) == true)
						{	AddValid (c);	}
						break;
					case 30:
						if (CheckMinus (Address, 0, 6,cs1, cs2) == true || CheckMinus (Address, 5, 5,cs1, cs2) == true || CheckPlus (Address, 35, 1,cs1, cs2) == true)
						{	AddValid (c);	}
						break;
					case 31:
						if (CheckMinus (Address, 1, 6,cs1, cs2) == true || CheckMinus (Address, 11, 5,cs1, cs2) == true || CheckPlus (Address, 35, 1,cs1, cs2) == true)
						{	AddValid (c);	}
						break;
						case 32:
						if (CheckMinus (Address, 18, 7,cs1, cs2) == true || CheckMinus (Address, 2, 6,cs1, cs2) == true || CheckMinus (Address, 17, 5,cs1, cs2) == true
							|| CheckPlus (Address, 35, 1,cs1, cs2) == true || CheckMinus (Address, 30, 1,cs1, cs2) == true)
						{	AddValid (c);	}
						break;
					case 33:
						if (CheckMinus (Address, 12, 7,cs1, cs2) == true || CheckMinus (Address, 3, 6,cs1, cs2) == true || CheckMinus (Address, 23, 5,cs1, cs2) == true
							|| CheckPlus (Address, 35, 1,cs1, cs2) == true || CheckMinus (Address, 30, 1,cs1, cs2) == true)
						{	AddValid (c);	}
						break;
					case 34:
						if (CheckMinus (Address, 6, 7,cs1, cs2) == true || CheckMinus (Address, 4, 6,cs1, cs2) == true || CheckMinus (Address, 30, 1,cs1, cs2) == true)
						{	AddValid (c);	}
						break;			
					case 35:
						if (CheckMinus (Address, 0, 7,cs1, cs2) == true || CheckMinus (Address, 5, 6,cs1, cs2) == true || CheckMinus (Address, 30, 1,cs1, cs2) == true)
						{	AddValid (c);	}
						break;
					}
				}
			}
		}




		public void UpdatePlus(int adr, int maxvalue , int plus ,CellState cs1 ,CellState cs2)
		{	
				if (_cells [adr + plus].CS == cs2)
				{	
					int times = 1;
					while (adr <= (maxvalue - plus - plus))
					{	
						if (_cells [adr + plus + plus].CS == CellState.None)
						{	break;	}
						if (_cells [adr + plus + plus].CS == cs1)
						{	
							if(times == 1)
							{
								_cells [adr + plus].CS = cs1; 
								break;
							}
							if(times == 2)
							{
								_cells [adr + plus].CS = cs1;
								_cells [adr].CS = cs1;	
								break;
							}
							if(times == 3)
							{
								_cells [adr + plus].CS = cs1;
								_cells [adr].CS = cs1;
								_cells [adr - plus].CS = cs1;
								break;
							}
							if(times == 4)
							{
								_cells [adr + plus].CS = cs1;
								_cells [adr].CS = cs1;
								_cells [adr - plus].CS = cs1;
								_cells [adr - (plus * 2)].CS = cs1;
								break;
							}
							if(times == 5)
							{
								_cells [adr + plus].CS = cs1;
								_cells [adr].CS = cs1;
								_cells [adr - plus].CS = cs1;
								_cells [adr - (plus * 2)].CS = cs1;
								break;
							}
						}
						adr = adr + plus;
						times = times + 1;
					}
				}
		}




		public void UpadateMinus(int adr, int minvalue , int minus, CellState cs1 ,CellState cs2)
		{	
			if (_cells [adr - minus].CS == cs2)
				{
					int times = 1;
					while (adr >= (minvalue + minus + minus))
					{
						if (_cells [adr - minus - minus].CS == CellState.None)
						{
							break;
						}
						if (_cells [adr - minus - minus].CS == cs1)
						{
							if (times ==1)
								{
									_cells [adr - minus].CS = cs1;
									break;
								}
							if (times ==2)
								{
									_cells [adr - minus].CS = cs1;
									_cells [adr].CS = cs1;
									break;

								}
							if (times ==3)
								{
									_cells [adr - minus].CS = cs1;
									_cells [adr].CS = cs1;
									_cells [adr + minus].CS = cs1;
									break;
										
								}
							if (times ==4)
								{
									_cells [adr - minus].CS = cs1;
									_cells [adr].CS = cs1;
									_cells [adr + minus].CS = cs1;
									_cells [adr + (minus * 2)].CS = cs1;
									break;

								}
							if (times ==5)
								{
									_cells [adr - minus].CS = cs1;
									_cells [adr].CS = cs1;
									_cells [adr + minus].CS = cs1;
									_cells [adr + (minus * 2)].CS = cs1;
									_cells [adr + (minus * 3)].CS = cs1;
									break;
								}
			
						}
						adr = adr - minus;
						times = times + 1;
					}
				}

		}
			

		public void UpdateBoardStatus(float x , float y , CellState cs1 ,CellState cs2)
		{	
			GetAddress (x, y);
					switch (Address)
					{
					case 0:
						{
					UpdatePlus (Address, 5, 1, cs1,cs2);
					UpdatePlus (Address, 35, 7,cs1,cs2);
					UpdatePlus (Address, 30, 6, cs1,cs2);
							break;	}

					case 1:
						{
					UpdatePlus (Address, 31, 6, cs1,cs2);
					UpdatePlus (Address, 29, 7, cs1,cs2);
					UpdatePlus (Address, 5, 1, cs1,cs2);
							break;	}

					case 2:
						{
					UpadateMinus (Address, 0, 1, cs1,cs2);
					UpdatePlus (Address, 12, 5, cs1,cs2);
					UpdatePlus (Address, 32, 6, cs1,cs2);
					UpdatePlus (Address, 23, 7, cs1,cs2);
					UpdatePlus (Address, 5, 1, cs1,cs2);
							break;
						}
					case 3:
						{
					UpadateMinus (Address, 0, 1, cs1,cs2);
					UpdatePlus (Address, 18, 5, cs1,cs2);
					UpdatePlus (Address, 33, 6,cs1,cs2);
					UpdatePlus (Address, 17, 7, cs1,cs2);
					UpdatePlus (Address, 5, 1, cs1,cs2);
							break;
						}
					case 4:
						{
					UpadateMinus (Address, 0, 1, cs1,cs2);
					UpdatePlus (Address, 24, 5, cs1,cs2);
					UpdatePlus (Address, 34, 6, cs1,cs2);
							break;
						}
					case 5:
						{
					UpadateMinus (Address, 0, 1, cs1,cs2);
					UpdatePlus (Address, 30, 5, cs1,cs2);
					UpdatePlus (Address, 35, 6, cs1,cs2);
							break;
						}
					case 6:
						{
					UpdatePlus (Address, 11, 1, cs1,cs2);
					UpdatePlus (Address, 34, 7,cs1,cs2);
					UpdatePlus (Address, 30, 6, cs1,cs2);
							break;
						}
					case 7:
						{
					UpdatePlus (Address, 11, 1, cs1,cs2);
					UpdatePlus (Address, 35, 7, cs1,cs2);
					UpdatePlus (Address, 31, 6,cs1,cs2);
							break;
						}
					case 8:
						{
					UpdatePlus (Address, 11, 1, cs1,cs2);
					UpdatePlus (Address, 29, 7, cs1,cs2);
					UpdatePlus (Address, 32, 6, cs1,cs2);
					UpdatePlus (Address, 18, 5,cs1,cs2);
					UpadateMinus (Address, 6, 1, cs1,cs2);
							break;
						}
					case 9:
						{
					UpdatePlus (Address, 11, 1,cs1,cs2);
					UpdatePlus (Address, 23, 7,cs1,cs2);
					UpdatePlus (Address, 33, 6, cs1,cs2);
					UpdatePlus (Address, 24, 5,cs1,cs2);
					UpadateMinus (Address, 6, 1,cs1,cs2);
							break;
						}
					case 10:
						{
						UpdatePlus (Address, 34, 6, cs1,cs2);
						UpdatePlus (Address, 30, 5, cs1, cs2);
						UpadateMinus (Address, 6, 1, cs1,cs2);
							break;
						}
					case 11:
						{
							UpdatePlus (Address, 35, 6, cs1,cs2);
							UpdatePlus (Address, 31, 5, cs1,cs2);
							UpadateMinus (Address, 6, 1,cs1,cs2);
							break;
						}
					case 12:
						{
							UpadateMinus (Address, 0, 6, cs1,cs2);
							UpadateMinus (Address, 2, 5, cs1,cs2);
							UpdatePlus (Address, 17, 1,cs1,cs2);
							UpdatePlus (Address, 33, 7,cs1,cs2);
							UpdatePlus (Address, 30, 6,cs1,cs2);
							break;
						}
					case 13:
						{
							UpadateMinus (Address, 1, 6, cs1,cs2);
							UpdatePlus (Address, 3, 5, cs1,cs2);
							UpdatePlus (Address, 17, 1, cs1,cs2);
							UpdatePlus (Address, 34, 7, cs1,cs2);
							UpdatePlus (Address, 31, 6,cs1,cs2);
							break;
						}
					case 16:
						{
							UpadateMinus (Address, 2, 7, cs1,cs2);
							UpadateMinus (Address, 4, 6, cs1,cs2);
							UpdatePlus (Address, 34, 6, cs1,cs2);
							UpdatePlus (Address, 31, 5, cs1,cs2);
							UpadateMinus (Address, 12, 1,cs1,cs2);
							break;	
						}
					case 17:
						{
							UpadateMinus (Address, 3, 7,cs1,cs2);
							UpadateMinus (Address, 5, 6,cs1,cs2);
							UpdatePlus (Address, 35, 6,cs1,cs2);
							UpdatePlus (Address, 32, 5, cs1,cs2);
							UpadateMinus (Address, 12, 1, cs1,cs2);
							break;
						}
					case 18:
						{
							UpadateMinus (Address, 0, 6, cs1,cs2);
							UpadateMinus (Address, 3, 5, cs1,cs2);
							UpdatePlus (Address, 23, 1,cs1,cs2);
							UpdatePlus (Address, 32, 7,cs1,cs2);
							UpdatePlus (Address, 30, 6, cs1,cs2);
							break;
						}
					case 19:
						{
							UpadateMinus (Address, 1, 6, cs1,cs2);
							UpadateMinus (Address, 4, 5,cs1,cs2);
							UpdatePlus (Address, 23, 1, cs1,cs2);
							UpdatePlus (Address, 33, 7, cs1,cs2);
							UpdatePlus (Address, 31, 6, cs1,cs2);
							break;
						}
					case 22:
						{
							UpadateMinus (Address, 1, 7, cs1,cs2);
							UpadateMinus (Address, 4, 6, cs1,cs2);
							UpdatePlus (Address, 34, 6, cs1,cs2);
							UpdatePlus (Address, 32, 5, cs1,cs2);
							UpadateMinus (Address, 18, 1,cs1,cs2);
							break;
						}
					case 23:
						{
							UpadateMinus (Address, 2, 7,cs1,cs2);
							UpadateMinus (Address, 5, 6, cs1,cs2);
							UpdatePlus (Address, 35, 6, cs1,cs2);
							UpdatePlus (Address, 33, 5, cs1,cs2);
							UpadateMinus (Address, 18, 1, cs1,cs2);
							break;
						}
					case 24:
						{
							UpadateMinus (Address, 0, 6, cs1,cs2);
							UpadateMinus (Address, 4, 5, cs1,cs2);
							UpdatePlus (Address, 29, 1, cs1,cs2);
							break;
						}
					case 25:
						{
							UpadateMinus (Address, 1, 6, cs1,cs2);
							UpadateMinus (Address, 5, 5, cs1,cs2);
							UpdatePlus (Address, 29, 1, cs1,cs2);
							break;
						}
					case 26:
						{
							UpadateMinus (Address, 12, 7,cs1,cs2);
							UpadateMinus (Address, 2, 6,cs1,cs2);
							UpadateMinus (Address, 11, 5, cs1,cs2);
							UpdatePlus (Address, 29, 1,cs1,cs2);
							UpadateMinus (Address, 24, 1, cs1,cs2);
							break;
						}
					case 27:
						{
							UpadateMinus (Address, 6, 7, cs1,cs2);
							UpadateMinus (Address, 3, 6, cs1,cs2);
							UpadateMinus (Address, 17, 5, cs1,cs2);
							UpdatePlus (Address, 29, 1, cs1,cs2);
							UpadateMinus (Address, 24, 1, cs1,cs2);
							break;
						}
					case 28:
						{
							UpadateMinus (Address, 0, 7, cs1,cs2);
							UpadateMinus (Address, 4, 6, cs1,cs2);
							UpadateMinus (Address, 24, 1, cs1,cs2);
							break;
						}
					case 29:
						{
							UpadateMinus (Address, 1, 7, cs1,cs2);
							UpadateMinus (Address, 5, 6, cs1,cs2);
							UpadateMinus (Address, 24, 1,cs1,cs2);
							break;
						}
					case 30:
						{
							UpadateMinus (Address, 0, 6, cs1,cs2);
							UpadateMinus (Address, 5, 5, cs1,cs2);
							UpdatePlus (Address, 35, 1, cs1,cs2);
							break;
						}
					case 31:
						{
							UpadateMinus (Address, 1, 6, cs1,cs2);
							UpadateMinus (Address, 11, 5, cs1,cs2);
							UpdatePlus (Address, 35, 1, cs1,cs2);
							break;
						}
					case 32:
						{
							UpadateMinus (Address, 18, 7,cs1,cs2);
							UpadateMinus (Address, 2, 6, cs1,cs2);
							UpadateMinus (Address, 17, 5, cs1,cs2);
							UpdatePlus (Address, 35, 1,cs1,cs2);
							UpadateMinus (Address, 30, 1, cs1,cs2);
							break;
						}
					case 33:
						{
							UpadateMinus (Address, 12, 7, cs1,cs2);
							UpadateMinus (Address, 4, 6,cs1,cs2);
							UpadateMinus (Address, 23, 5, cs1,cs2);
							UpdatePlus (Address, 35, 1, cs1,cs2);
							UpadateMinus (Address, 30, 1, cs1,cs2);
							break;
						}
					case 34:
						{
							UpadateMinus (Address, 6, 7,cs1,cs2);	
							UpadateMinus (Address, 4, 6, cs1,cs2);
							UpadateMinus (Address, 30, 1,cs1,cs2);
							break;	
						}
					case 35:
						{	
							UpadateMinus (Address, 0, 7, cs1,cs2);
							UpadateMinus (Address, 5, 6, cs1,cs2);
							UpadateMinus (Address, 30, 1, cs1,cs2);
							break;
						}

			}
		}
			

		public void SelectCellAt(Point2D point)
		{
			foreach (Cell c in _valid )
			{
				if (c.IsAt (point) == true)
				{
					if (_p.Turn == 1)
					{
						c.CS = CellState.Black;
						_p.Increment ();
						_count = _count - 1;
						UpdateBoardStatus (c.X , c.Y , c.CS , CellState.White);

					}
					else
					{	
						c.CS = CellState.White;
						_p.Increment ();
						_count = _count - 1;
						UpdateBoardStatus (c.X , c.Y , c.CS , CellState.Black);

					}
				}
			}

		}




		public void GetColor()
		{	_black = 0; 	_white = 0;
			foreach (Cell c in _cells)
			{	if (c.CS == CellState.Black)	_black = _black + 1;
				if (c.CS == CellState.White)	_white = _white + 1;	}	}



		public void CheckWin()
		{	GetColor ();
			if 		(_black > _white )		{	BlackWin ();	}
			else if (_white > _black)		{	WhiteWin ();	}
			else                			{	NewBoard ();	}	}
		


		public void WhiteWin()
		{	
			foreach (Cell c in _cells)
			{
				c.CS = CellState.None;
			}
			_cells [1].CS = CellState.White;		_cells [2].CS = CellState.White;		_cells [3].CS = CellState.White;		
			_cells [4].CS = CellState.White;		_cells [10].CS = CellState.White;
			_cells [15].CS = CellState.White;		_cells [16].CS = CellState.White;		_cells [21].CS = CellState.White;
			_cells [22].CS = CellState.White;		_cells [28].CS = CellState.White;		_cells [32].CS = CellState.White;
			_cells [33].CS = CellState.White;		_cells [31].CS = CellState.White;		_cells [34].CS = CellState.White;
		
		}

		public void BlackWin()
		{	
			foreach (Cell c in _cells)
			{
				c.CS = CellState.None;
			}
			_cells [1].CS = CellState.Black;		_cells [2].CS = CellState.Black;		_cells [3].CS = CellState.Black;		
			_cells [4].CS = CellState.Black;		_cells [10].CS = CellState.Black;
			_cells [15].CS = CellState.Black;		_cells [16].CS = CellState.Black;		_cells [21].CS = CellState.Black;
			_cells [22].CS = CellState.Black;		_cells [28].CS = CellState.Black;		_cells [32].CS = CellState.Black;
			_cells [33].CS = CellState.Black;		_cells [31].CS = CellState.Black;		_cells [34].CS = CellState.Black;
	
		}

		public Board Clone()
		{
			return new Board();
		}
	}
}
