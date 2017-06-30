using System;
using SwinGameSDK;


namespace MyGame
{
    public class GameMain
    {
        public static void Main()
        {
            //Open the game window
            SwinGame.OpenGraphicsWindow("Reversi", 900 , 600);
		
	

			Board b = new Board ();
			b.NewBoard ();
			Chess ch = new Chess (660, 450);
			Font f = new Font ("arial", 24);
			Font f1 = new Font ("arial", 18);
			string bv, wv;

		
            //Run the game loop
            while(false == SwinGame.WindowCloseRequested())
            {
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();

                //Clear the screen and draw the framerate
				SwinGame.ClearScreen(Color.YellowGreen);
                SwinGame.DrawFramerate(0,0);


				//get Valid cell
				b.CheckStatus ();

				//random AI 
				if (b.P.Turn == 2)
				{
					Random r = new Random ();
					int adr , adr2 ;
					adr = r.Next (0, 600 );
					adr2 = r.Next (0, 600 );
					Point2D p = new Point2D();
					p.X = adr;
					p.Y = adr2;
					b.SelectCellAt (p);
					b.GetColor ();
				}

				//check whether the point is at valid cell
				if (SwinGame.MouseClicked (MouseButton.LeftButton))
				{	b.SelectCellAt (SwinGame.MousePosition() );
					b.GetColor ();
				}

				//New game
				if (SwinGame.KeyTyped (KeyCode.vk_F2))
				{
					b.ClearBoard ();
					b.NewBoard ();
				}

				//Pass the move , when the player has no valid move
				if (SwinGame.KeyTyped (KeyCode.vk_p))
				{
					b.P.Increment ();
					b.CheckStatus ();
				}

				//endgame or there is no cell to fill , check who win
				if (SwinGame.KeyTyped (KeyCode.vk_e) || b.CellCount == 0)
				{
					b.CheckWin ();
				}
			
					
				//return to player1 after player2
				if (b.P.Turn == 3)
				{
					b.P.Reset ();
				}

				//check whose turn 
				if (b.P.Turn == 1)
				{		ch.CS = CellState.Black;	}
				else
				{		ch.CS = CellState.White;	}

				//Show whose turn
				ch.Draw ();


				bv = b.Black.ToString ();
				wv = b.White.ToString ();


				//Decription
				SwinGame.DrawText ("Decription", Color.Black ,f, 610, 00);
				SwinGame.DrawText ("Reversi is a classic board game for", Color.Black , 610, 40);
				SwinGame.DrawText ("two players  Black and white,", Color.Black , 610, 60);
				SwinGame.DrawText ("Reversi is a very dynamic board game" , Color.Black , 610, 80);
				SwinGame.DrawText (	";the board position can change" , Color.Black , 610, 100);
				SwinGame.DrawText (	"dramatically with each move", Color.Black , 610, 120);
	

				SwinGame.DrawText ("Button", Color.Black, f,610, 150);
				SwinGame.DrawText ("F2 = New Game", Color.Black, f1,610, 180);
				SwinGame.DrawText ("H  = Hint", Color.Black, f1,610, 200);
				SwinGame.DrawText ("P  = Pass Move", Color.Black, f1,610, 220);
				SwinGame.DrawText ("E  = End Game", Color.Black, f1,610, 240);


				SwinGame.DrawText ("Total of Black and White", Color.Black,f ,610, 280);
				SwinGame.DrawText ("Black Count", Color.Black,f1 ,610, 320);
				SwinGame.DrawText ( bv, Color.Black,f1, 750, 320);
				SwinGame.DrawText ( "White Count", Color.Black,f1, 610, 340);
				SwinGame.DrawText (	wv, Color.Black, f1,750, 340);


				SwinGame.DrawText ("Player Turn", Color.Black,f,610, 420);

				SwinGame.DrawText ("Credit @ Terence Wong Mee Zhiu", Color.Black,650, 580);

                //Draw onto the screen
				b.DrawBoard ();


				SwinGame.RefreshScreen(60);
            }
        }
    }
}