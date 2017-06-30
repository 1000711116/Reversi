using System;
using SwinGameSDK;

namespace MyGame
{
	public class Chess : Shape
	{
		//field
		private int _radius;

		//Contructor
		public Chess (float x , float y)
		{
			X = x + 50;
			Y = y +50;
			_radius = 40;
			CS = CellState.None;
		}

	
		/// <summary>
		/// Check the cellstate 
		/// if none then draw chess with forest green color.
		/// if black then draw chess with black color.
		/// if white then draw chess with white color.  
		/// </summary>
		public override void Draw ()
		{
			if (CS == CellState.None)
				SwinGame.FillCircle ( Color.ForestGreen , X , Y, _radius);
			if (CS == CellState.Black)
				SwinGame.FillCircle ( Color.Black , X , Y, _radius);
			if (CS == CellState.White )
				SwinGame.FillCircle ( Color.White , X , Y, _radius);
		}
	}
}

