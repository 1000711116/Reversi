using System;

namespace MyGame
{
	public class Player
	{
		//field
		private int _turn;

		/// <summary>
		/// Contructor
		/// </summary>
		public Player ()
		{	_turn = 1;	}

		/// <summary>
		/// Reset this the turn.
		/// </summary>
		public void Reset()
		{
			_turn = 1;
		}

		/// <summary>
		/// increase the turn by 1
		/// </summary>
		public void Increment()
		{
			_turn++;
		}

		/// <summary>
		/// Gets or sets the turn.
		/// </summary>
		/// <value>The turn.</value>
		public int Turn
		{
			get{ return _turn;		}
			set{ _turn = value;	}
		}
	}
}

