using System;
using SwinGameSDK;

namespace MyGame
{
	public abstract class Shape
	{
		//field
		private Color _clr;
		private float _x, _y;
		private CellState cs;

		//property
		public Color Color
		{
			get { return _clr;	 }
			set { _clr = value;	 }
		}

		public float X
		{
			get { return _x;	}
			set { _x = value; 	}
		}

		public float Y
		{
			get { return _y;	}
			set { _y = value; 	}
		}

		public CellState CS
		{
			get { return cs; }
			set { cs = value; }
		}


		/// <summary>
		/// abstract draw method
		/// </summary>
		public abstract void Draw();




	}
}

