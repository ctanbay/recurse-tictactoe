using System;
using System.Collections.Generic;
					
public class TicTacToe
{
	//game board
	static List<List<string>> _board = new List<List<string>>();
	static string _nextMove = "X";
	static string _winner = "";
	
	public static void Main()
	{
		InitBoard();
		while(!GameOver())
		{
			GetMove();
			PrintBoard();
		}
		
		Console.WriteLine(_winner);
		Console.WriteLine("Thanks for playing.");
	}
	
	static void InitBoard()
	{
		_board.Add(new List<string>() { " "," "," " });
		_board.Add(new List<string>() { " "," "," " });
		_board.Add(new List<string>() { " "," "," " });

		Console.WriteLine("X goes first.  Specify move by Column-Row, e.g. A1\n");
		PrintBoard();
	}

	static Boolean GameOver()
	{
		//9 ways a game can end
		//8 winning layouts:
		//across the top
		if ( ( _board[0][0] == _board[1][0] ) && ( _board[1][0] == _board[2][0] ) && (_board[2][0] != " " ) )
		{
			_winner = _board[2][0] + " wins!";
			return true;
		}
		//across the middle
		if ( ( _board[0][1] == _board[1][1] ) && ( _board[1][1] == _board[2][1] ) && (_board[2][1] != " " ) )
		{
			_winner = _board[0][2] + " wins!";
			return true;
		}
		//across the bottom
		if ( ( _board[0][2] == _board[1][2] ) && ( _board[1][2] == _board[2][2] ) && (_board[2][2] != " " ) )
		{
			_winner = _board[0][2] + " wins!";
			return true;
		}
		//left column
		if ( ( _board[0][0] == _board[0][1] ) && ( _board[0][1] == _board[0][2] ) && (_board[0][2] != " " ) )
		{
			_winner = _board[0][2] + " wins!";
			return true;
		}
		//middle column
		if ( ( _board[1][0] == _board[1][1] ) && ( _board[1][1] == _board[1][2] ) && (_board[1][2] != " " ) )
		{
			_winner = _board[1][2] + " wins!";
			return true;
		}
		//right column
		if ( ( _board[2][0] == _board[2][1] ) && ( _board[2][1] == _board[2][2] ) && (_board[2][2] != " " ) )
		{
			_winner = _board[2][2] + " wins!";
			return true;
		}
		//diag left to right
		if ( ( _board[0][0] == _board[1][1] ) && ( _board[1][1] == _board[2][2] ) && (_board[2][2] != " " ) )
		{
			_winner = _board[2][2] + " wins!";
			return true;
		}
		//diag right to left
		if ( ( _board[2][0] == _board[1][1] ) && ( _board[1][1] == _board[0][2] ) && (_board[0][2] != " " ) )
		{
			_winner = _board[0][2] + " wins!";
			return true;
		}
		//no moves left
		if ( !_board[0].Contains(" ") && !_board[1].Contains(" ") && !_board[2].Contains(" ") ) 
		{
			_winner = "It's a tie!";
			return true;
		}

		return false;
	}
	
	static void GetMove()
	{
		Boolean validMove = false;
		
		while (!validMove)
		{
			Console.Write("Enter move (ColRow, e.g. A1) ==> ");
			string move = Console.ReadLine().ToUpper();
			if ( move.Length != 2 )
				Console.WriteLine("Please enter two characters only: Column (A,B,C) and Row (1,2,3) e.g. A1");
			else
			{
				if ( ( move[0] != 'A' ) && (move[0] != 'B') && (move[0] != 'C') )
					Console.WriteLine("First character of the move should be a Column header (A,B,C).  Please try again.");
				else if ( ( move[1] != '1' ) && (move[1] != '2') && (move[1] != '3') )
					Console.WriteLine("Second character of the move should be a Row identifier (1,2,3).  Please try again.");
				else
				{
					int col = ((int) move[0])-65;
					int row = ((int) move[1])-49;
					if ( _board[row][col] != " " )
						Console.WriteLine("Cannot go there as " + _board[row][col] + " has that spot.  Please try again.");
					else
					{
						_board[row][col] = _nextMove;
						validMove = true;
						if ( _nextMove == "X" )
							_nextMove = "O";
						else
							_nextMove = "X";
					}					
				}
			}
		}
	}

	static void PrintBoard()
	{
		Console.WriteLine("  A B C ");
		Console.WriteLine(" -------");
		Console.WriteLine("1|"+_board[0][0]+"|"+_board[0][1]+"|"+_board[0][2]+"|");
		Console.WriteLine(" -------");
		Console.WriteLine("2|"+_board[1][0]+"|"+_board[1][1]+"|"+_board[1][2]+"|");
		Console.WriteLine(" -------");
		Console.WriteLine("3|"+_board[2][0]+"|"+_board[2][1]+"|"+_board[2][2]+"|");
		Console.WriteLine(" -------\n");
	}
}