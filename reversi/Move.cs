using System;

namespace MyGame
{
	public class Move
	{
		private int _address;
		private Board b;
	
		public Board B
		{	get { return b; } }

		public Move (Board _b)
		{
			b = _b;
		}

		public int Address
		{
			get { return _address;	}
			set	{ _address = value;	}
		}


		public void GetAddress(float x , float y)
		{	//0														//1														//2	
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


		public bool CheckBesideWhite(int adr)
		{
			if(B.P.Turn ==1)
			{	switch (adr)
				{
				case 0:
					{	if (B.Cells [_address + 6].CS == CellState.White || B.Cells  [_address + 7].CS == CellState.White	|| B.Cells  [_address + 1].CS == CellState.White)
						{	return true;	}
					else
					{	return false;	}
					break;				}
				case 5:
					{	if (B.Cells  [_address - 1].CS == CellState.White || B.Cells  [_address + 5].CS == CellState.White	|| B.Cells  [_address + 6].CS == CellState.White)
						{	return true;	}
					else
					{	return false;	}
					break;				}
				case 30:
					{	if (B.Cells  [_address - 6].CS == CellState.White || B.Cells  [_address - 5].CS == CellState.White	|| B.Cells  [_address + 5].CS == CellState.White)
						{	return true;	}
					else
					{	return false;	}
					break;				}
				case 35:
					{
						if (B.Cells  [_address - 6].CS == CellState.White || B.Cells  [_address - 7].CS == CellState.White	|| B.Cells  [_address - 1].CS == CellState.White)
						{	return true;	}
						else
						{	return false;	}
						break;
					}
				case 1: case 2: case 3: case 4: 
					{
						if (B.Cells  [_address - 1].CS == CellState.White || B.Cells  [_address + 5].CS == CellState.White	|| B.Cells  [_address + 6].CS == CellState.White
							|| B.Cells  [_address + 7].CS == CellState.White || B.Cells  [_address + 1].CS == CellState.White )
						{	return true;	}
						else
						{	return false;	}
						break;
					}
				case 6: case 12: case 18: case 24: 
					{
						if (B.Cells  [_address - 6].CS == CellState.White || B.Cells  [_address - 5].CS == CellState.White	|| B.Cells  [_address + 1].CS == CellState.White
							|| B.Cells  [_address + 7].CS == CellState.White || B.Cells  [_address + 6].CS == CellState.White )
						{	return true;	}
						else
						{	return false;	}
						break;
					}
				case 31: case 32: case 33: case 34: 
					{
						if (B.Cells  [_address - 1].CS == CellState.White || B.Cells  [_address - 7].CS == CellState.White	|| B.Cells  [_address - 6].CS == CellState.White
							|| B.Cells  [_address - 5].CS == CellState.White || B.Cells  [_address + 1].CS == CellState.White )
						{	return true;	}
						else
						{	return false;	}
						break;
					}
				case 11: case 17: case 23: case 29: 
					{
						if (B.Cells  [_address - 6].CS == CellState.White || B.Cells  [_address - 7].CS == CellState.White	|| B.Cells  [_address - 1].CS == CellState.White
							|| B.Cells  [_address + 5].CS == CellState.White || B.Cells  [_address + 6].CS == CellState.White )
						{	return true;	}
						else
						{	return false;	}
						break;
					}
				case 7: case 8: case 9: case 10: case 13:  case 14: case 15: case 16: case 19: case 20: case 21: case 22: case 25: case 26: case 27:
				case 28:	
					{
						if (B.Cells  [_address - 7].CS == CellState.White || B.Cells  [_address - 1].CS == CellState.White	|| B.Cells  [_address + 5].CS == CellState.White
							|| B.Cells  [_address + 6].CS == CellState.White || B.Cells  [_address + 7].CS == CellState.White || B.Cells  [_address + 1].CS == CellState.White
							|| B.Cells  [_address - 5].CS == CellState.White || B.Cells  [_address - 6].CS == CellState.White )
						{	return true;	}
						else
						{	return false;	}
						break;
					}
				}
			}

			else
			{	switch (adr)
				{
				case 0:
					{
						if (B.Cells  [_address + 6].CS == CellState.Black || B.Cells  [_address + 7].CS == CellState.Black	|| B.Cells  [_address + 1].CS == CellState.Black)
						{	return true;	}
						else
						{	return false;	}
						break;
					}
				case 5:
					{
						if (B.Cells  [_address - 1].CS == CellState.Black || B.Cells  [_address + 5].CS == CellState.Black	|| B.Cells  [_address + 6].CS == CellState.Black)
						{	return true;	}
						else
						{	return false;	}
						break;
					}
				case 30:
					{
						if (B.Cells  [_address - 6].CS == CellState.Black || B.Cells  [_address - 5].CS == CellState.Black	|| B.Cells  [_address + 5].CS == CellState.Black)
						{	return true;	}
						else
						{	return false;	}
						break;
					}
				case 35:
					{
						if (B.Cells  [_address - 6].CS == CellState.Black || B.Cells  [_address -7 ].CS == CellState.Black	|| B.Cells  [_address -1 ].CS == CellState.Black)
						{	return true;	}
						else
						{	return false;	}
						break;
					}
				case 1: case 2: case 3: case 4: 
					{
						if (B.Cells  [_address - 1].CS == CellState.Black || B.Cells  [_address + 5].CS == CellState.Black	|| B.Cells  [_address + 6].CS == CellState.Black
							|| B.Cells  [_address + 7].CS == CellState.Black || B.Cells  [_address + 1].CS == CellState.Black )
						{	return true;	}
						else
						{	return false;	}
						break;
					}
				case 6: case 12: case 18: case 24: 
					{
						if (B.Cells  [_address - 6].CS == CellState.Black || B.Cells  [_address - 5].CS == CellState.Black	|| B.Cells  [_address + 1].CS == CellState.Black
							|| B.Cells  [_address + 7].CS == CellState.Black || B.Cells  [_address + 6].CS == CellState.Black )
						{	return true;	}
						else
						{	return false;	}
						break;
					}

				case 31: case 32: case 33: case 34: 
					{
						if (B.Cells  [_address - 1].CS == CellState.Black || B.Cells  [_address - 7].CS == CellState.Black	|| B.Cells  [_address - 6].CS == CellState.Black
							|| B.Cells  [_address - 5].CS == CellState.Black || B.Cells  [_address + 1].CS == CellState.Black )
						{	return true;	}
						else
						{	return false;	}
						break;
					}

				case 11: case 17: case 23: case 29: 
					{
						if (B.Cells  [_address - 6].CS == CellState.Black || B.Cells  [_address - 7].CS == CellState.Black	|| B.Cells  [_address - 1].CS == CellState.Black
							|| B.Cells  [_address + 5].CS == CellState.Black || B.Cells  [_address + 6].CS == CellState.Black )
						{	return true;	}
						else
						{	return false;	}
						break;
					}
				case 7: case 8: case 9: case 10: case 13:  case 14: case 15: case 16: case 19: case 20: case 21: case 22: case 25: case 26: case 27 :
				case 28:	
					{
						if (B.Cells  [_address - 7].CS == CellState.Black || B.Cells  [_address - 1].CS == CellState.Black	|| B.Cells  [_address + 5].CS == CellState.Black
							|| B.Cells  [_address + 6].CS == CellState.Black || B.Cells  [_address + 7].CS == CellState.Black || B.Cells  [_address + 1].CS == CellState.Black
							|| B.Cells  [_address - 5].CS == CellState.Black || B.Cells  [_address - 6].CS == CellState.Black )
						{	return true;	}
						else
						{	return false;	}
						break;
					}
				}

			}
			return false;
		}

		public bool CheckPlus(int adr, int maxvalue , int plus)
		{
			if (B.P.Turn == 1)
			{	while (adr <= maxvalue)
				{	if (B.Cells  [adr + plus + plus].CS == CellState.Black)
					{		return true;	break;		}
					adr = adr + plus;
				}
			}
			else 
			{	while (adr <= maxvalue)
				{	if (B.Cells  [adr + plus + plus].CS == CellState.White)
					{		return true;	break;		}
					adr = adr + plus;
				}
			}	
			return false;
		}

		public bool CheckMinus(int adr, int minvalue , int minus)
		{	
			if (B.P.Turn == 1)
			{	while (adr >= minvalue)
				{	if (B.Cells  [adr - minus - minus].CS == CellState.Black)
					{		return true;	break;		}
					adr = adr- minus;
				}
			}
			else 
			{	while (adr >= minvalue)
				{	if (B.Cells  [adr - minus - minus].CS == CellState.White)
					{		return true;	break;	}
					adr = adr - minus;
				}
			}	
			return false;
		}

		public void getValid()
		{	
			B.Valid.Clear ();
			foreach (Cell c in B.Cells)
			{
				if (c.CS == CellState.None)
				{
					GetAddress (c.X, c.Y);
					switch (Address)
					{
					case 0:
						{
							if (CheckBesideWhite (Address) == true)
							{
								if (CheckPlus (Address, 5, 1) == true || CheckPlus (Address, 35, 7) == true || CheckPlus (Address, 30, 6) == true)
								{
									B.AddValid (c);
								}
							}
							break;
						}
					case 1:
						{
							if (CheckBesideWhite (Address) == true)
							{
								if (CheckPlus (Address, 31, 6) == true || CheckPlus (Address, 29, 7) == true	||	CheckPlus (Address, 5, 1) == true)
								{
									B.AddValid  (c);
								}
							}
							break;
						}
					case 2:
						{
							if (CheckBesideWhite (Address) == true)
							{
								if (CheckMinus (Address, 0, 1) == true ||	CheckPlus (Address, 12, 5) == true	||	CheckPlus (Address, 32, 6) == true ||
									CheckPlus (Address, 23, 7) == true	||	CheckPlus (Address, 5, 1) == true)
								{
									B.AddValid  (c);
								}
							}
							break;
						}
					case 3:
						{
							if (CheckBesideWhite (Address) == true)
							{
								if (CheckMinus (Address, 0, 1) == true	|| CheckPlus (Address, 18, 5) == true	|| CheckPlus (Address, 33, 6) == true
									|| CheckPlus (Address, 17, 7) == true	|| CheckPlus (Address, 5, 1) == true)
								{
									B.AddValid  (c);
								}
							}
							break;
						}
					case 4:
						{
							if (CheckBesideWhite (Address) == true)
							{
								if (CheckMinus (Address, 0, 1) == true || CheckPlus (Address, 24, 5) == true || CheckPlus (Address, 34, 6) == true)
								{
									B.AddValid  (c);
								}
							}
							break;
						}
					case 5:
						{
							if (CheckBesideWhite (Address) == true)
							{
								if (CheckMinus (Address, 0, 1) == true	||	CheckPlus (Address, 30, 5) == true	|| CheckPlus (Address, 35, 6) == true)
								{
									B.AddValid  (c);
								}
							}
							break;
						}
					case 6:
						{
							if (CheckBesideWhite (Address) == true)
							{
								if (CheckPlus (Address, 11, 1) == true || CheckPlus (Address, 34, 7) == true || CheckPlus (Address, 30, 6) == true)
								{
									B.AddValid  (c);
								}
							}
							break;
						}
					case 7:
						{
							if (CheckBesideWhite (Address) == true)
							{
								if (CheckPlus (Address, 11, 1) == true || CheckPlus (Address, 35, 7) == true || CheckPlus (Address, 31, 6) == true)
								{
									B.AddValid  (c);
								}
							}
							break;
						}
					case 8:
						{
							if (CheckBesideWhite (Address) == true)
							{
								if (CheckPlus (Address, 11, 1) == true || CheckPlus (Address, 29, 7) == true || CheckPlus (Address, 32, 6) == true
									||	CheckPlus (Address, 18, 5) == true || CheckMinus (Address, 6, 1) == true)
								{
									B.AddValid  (c);
								}
							}
							break;
						}
					case 9:
						{
							if (CheckBesideWhite (_address) == true)
							{
								if (CheckPlus (Address, 11, 1) == true || CheckPlus (Address, 23, 7) == true || CheckPlus (Address, 33, 6) == true
									||	CheckPlus (Address, 24, 5) == true	|| CheckMinus (Address, 6, 1) == true)
								{
									B.AddValid  (c);
								}
							}
							break;
						}
					case 10:
						{
							if (CheckBesideWhite (Address) == true)
							{
								if (CheckPlus (Address, 34, 6) == true	|| CheckPlus (Address, 35, 5) == true || CheckMinus (Address, 6, 1) == true)
								{
									B.AddValid  (c);
								}
							}
							break;
						}
					case 11:
						{
							if (CheckBesideWhite (Address) == true)
							{
								if (CheckPlus (Address, 35, 6) == true || CheckPlus (Address, 31, 5) == true || CheckMinus (Address, 6, 1) == true)
								{
									B.AddValid  (c);
								}
							}
							break;
						}
					case 12:
						{
							if (CheckBesideWhite (Address) == true)
							{
								if (CheckMinus (Address, 0, 6) == true || CheckMinus (Address, 2, 5) == true || CheckPlus (Address, 17, 1) == true
									|| CheckPlus (Address, 33, 7) == true || CheckPlus (Address, 30, 6) == true)
								{
									B.AddValid  (c);
								}
							}
							break;
						}
					case 13:
						{
							if (CheckBesideWhite (Address) == true)
							{
								if (CheckMinus (Address, 1, 6) == true || CheckMinus (Address, 3, 5) == true || CheckPlus (Address, 17, 1) == true
									|| CheckPlus (Address, 34, 7) == true || CheckPlus (Address, 31, 6) == true)
								{
									B.AddValid  (c);
								}
							}
							break;
						}
					case 16:
						{
							if (CheckBesideWhite (Address) == true)
							{
								if (CheckMinus (Address, 2, 7) == true || CheckMinus (Address, 4, 6) == true || CheckPlus (Address, 34, 6) == true
									|| CheckPlus (Address, 31, 5) == true || CheckMinus (Address, 12, 1) == true)
								{
									B.AddValid  (c);
								}
							}
							break;	
						}
					case 17:
						{
							if (CheckBesideWhite (Address) == true)
							{
								if (CheckMinus (Address, 3, 7) == true || CheckMinus (Address, 5, 6) == true || CheckPlus (Address, 35, 6) == true
									|| CheckPlus (Address, 32, 5) == true || CheckMinus (Address, 12, 1) == true)
								{
									B.AddValid  (c);
								}
							}
							break;
						}
					case 18:
						{
							if (CheckBesideWhite (Address) == true)
							{
								if (CheckMinus (Address, 0, 6) == true || CheckMinus (Address, 3, 5) == true || CheckPlus (Address, 23, 1) == true
									|| CheckPlus (Address, 32, 7) == true || CheckPlus (Address, 30, 6) == true)
								{
									B.AddValid  (c);
								}
							}
							break;
						}
					case 19:
						{
							if (CheckBesideWhite (Address) == true)
							{
								if (CheckMinus (Address, 1, 6) == true || CheckMinus (Address, 4, 5) == true || CheckPlus (Address, 23, 1) == true
									|| CheckPlus (Address, 33, 7) == true || CheckPlus (Address, 31, 6) == true)
								{
									B.AddValid  (c);
								}
							}
							break;
						}
					case 22:
						{
							if (CheckBesideWhite (Address) == true)
							{
								if (CheckMinus (Address, 1, 7) == true || CheckMinus (Address, 4, 6) == true || CheckPlus (Address, 34, 6) == true
									|| CheckPlus (Address, 32, 5) == true || CheckMinus (Address, 18, 1) == true)
								{
									B.AddValid  (c);
								}
							}
							break;
						}	
					case 23:
						{
							if (CheckBesideWhite (Address) == true)
							{
								if (CheckMinus (Address, 2, 7) == true || CheckMinus (Address, 5, 6) == true || CheckPlus (Address, 35, 6) == true
									|| CheckPlus (Address, 33, 5) == true || CheckMinus (Address, 18, 1) == true)
								{
									B.AddValid  (c);
								}
							}
							break;
						}
					case 24:
						{
							if (CheckBesideWhite (Address) == true)
							{
								if (CheckMinus (Address, 0, 6) == true || CheckMinus (Address, 4, 5) || CheckPlus (Address, 29, 1) == true)
								{
									B.AddValid  (c);
								}
							}
							break;
						}	
					case 25:
						{
							if (CheckBesideWhite (Address) == true)
							{
								if (CheckMinus (Address, 1, 6) == true || CheckMinus (Address, 5, 5) == true || CheckPlus (Address, 29, 1) == true)
								{
									B.AddValid  (c);
								}
							}
							break;
						}	
					case 26:
						{
							if (CheckBesideWhite (Address) == true)
							{
								if (CheckMinus (Address, 12, 7) == true || CheckMinus (Address, 2, 6) == true || CheckMinus (Address, 11, 5) == true
									|| CheckPlus (Address, 29, 1) == true || CheckMinus (Address, 24, 1) == true)
								{
									B.AddValid  (c);
								}
							}
							break;
						}	
					case 27:
						{
							if (CheckBesideWhite (Address) == true)
							{
								if (CheckMinus (Address, 6, 7) == true || CheckMinus (Address, 3, 6) == true || CheckMinus (Address, 27, 5) == true
									|| CheckPlus (Address, 29, 1) == true || CheckMinus (Address, 24, 1) == true)
								{
									B.AddValid  (c);
								}
							}
							break;
						}	
					case 28:
						{
							if (CheckBesideWhite (Address) == true)
							{
								if (CheckMinus (Address, 0, 7) == true || CheckMinus (Address, 4, 6) == true || CheckMinus (Address, 24, 1) == true)
								{
									B.AddValid  (c);
								}
							}
							break;
						}
					case 29:
						{
							if (CheckBesideWhite (Address) == true)
							{
								if (CheckMinus (Address, 1, 7) == true || CheckMinus (Address, 5, 6) == true || CheckMinus (Address, 24, 1) == true)
								{
									B.AddValid  (c);
								}
							}
							break;
						}	
					case 30:
						{
							if (CheckBesideWhite (Address) == true)
							{
								if (CheckMinus (Address, 0, 6) == true || CheckMinus (Address, 5, 5) == true || CheckPlus (Address, 35, 1) == true)
								{
									B.AddValid  (c);
								}
							}
							break;
						}	
					case 31:
						{
							if (CheckBesideWhite (Address) == true)
							{
								if (CheckMinus (Address, 1, 6) == true || CheckMinus (Address, 11, 5) == true || CheckPlus (Address, 35, 1) == true)
								{
									B.AddValid  (c);
								}
							}
							break;
						}	
					case 32:
						{
							if (CheckBesideWhite (Address) == true)
							{
								if (CheckMinus (Address, 18, 7) == true || CheckMinus (Address, 2, 6) == true || CheckMinus (Address, 17, 5) == true
									|| CheckPlus (Address, 35, 1) == true || CheckMinus (Address, 30, 1) == true)
								{
									B.AddValid  (c);
								}
							}
							break;
						}	
					case 33:
						{
							if (CheckBesideWhite (Address) == true)
							{
								if (CheckMinus (Address, 12, 7) == true || CheckMinus (Address, 3, 6) == true || CheckMinus (Address, 23, 5) == true
									|| CheckPlus (Address, 35, 1) == true || CheckMinus (Address, 30, 1) == true)
								{
									B.AddValid  (c);
								}
							}
							break;
						}	
					case 34:
						{
							if (CheckBesideWhite (Address) == true)
							{
								if (CheckMinus (Address, 6, 7) == true || CheckMinus (Address, 4, 6) == true || CheckMinus (Address, 30, 1) == true)
								{
									B.AddValid  (c);
								}
							}
							break;
						}	
					case 35:
						{
							if (CheckBesideWhite (Address) == true)
							{
								if (CheckMinus (Address, 0, 7) == true || CheckMinus (Address, 5, 6) == true || CheckMinus (Address, 30, 1) == true)
								{
									B.AddValid  (c);
								}
							}
							break;
						}
					}
				}
			}
		}


	}
}

