using System;
using NUnit.Framework;

namespace MyGame
{
	[TestFixture()]
	public class UNitTesting
	{
		
		/// <summary>
		/// Tests the clear board.
		/// </summary>
		[Test()]
		public void TestClearBoard()
		{
			Board b = new Board ();
			b.NewBoard ();
			b.ClearBoard ();
			Assert.AreEqual (0, b.Cells.Count);
		}

		/// <summary>
		/// Tests the valid Move.
		/// </summary>
		[Test()]
		public void TestValidMove()
		{
			Board b = new Board ();
			b.NewBoard ();
			b.CheckStatus ();
			Assert.AreEqual (4, b.Valid.Count);
		}

		/// <summary>
		/// Tests the pass turn.
		/// </summary>
		[Test()]
		public void TestPassTurn()
		{
			Board b = new Board ();
			b.NewBoard ();
			b.P.Increment ();
			Assert.AreEqual (2, b.P.Turn);
		}

		/// <summary>
		/// Tests the get address.
		/// </summary>
		[Test()]
		public void TestGetAddress()
		{
			Board b = new Board ();
			b.NewBoard ();
			b.GetAddress (0, 100);
			Assert.AreEqual (7, b.Address );
		}

		/// <summary>
		/// Tests the update cell.
		/// </summary>
		[Test()]
		public void  TestUpdateCell ()
		{
			Board b = new Board ();
			b.NewBoard ();
			b.Cells [25].CS = CellState.Black;
		//	b.UpdateBoardStatus (b.Cells [25].X, b.Cells [25].Y ,b.Cells [25].CS);
			Assert.AreEqual (CellState.White, b.Cells[20].CS);
		}
	}
}

