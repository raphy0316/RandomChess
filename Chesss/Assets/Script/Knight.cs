using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : ChessPiece {
	public override bool[,] PossibleMove(){
		bool[,] r = new bool[8, 8];

		//UpLeft
		KnightMove (nowX -1, nowY+2, ref r);
		//upright
		KnightMove (nowX +1, nowY+2, ref r);
		//rightup
		KnightMove (nowX +2, nowY+1, ref r);
		//rightdown
		KnightMove (nowX +2, nowY-1, ref r);
		//downLeft
		KnightMove (nowX -1, nowY-2, ref r);
		//downright
		KnightMove (nowX +1, nowY-2, ref r);
		//leftup
		KnightMove (nowX -2, nowY+1, ref r);
		//leftdown
		KnightMove (nowX -2, nowY-1, ref r);

		return r;
	}
	public void KnightMove(int x, int y, ref bool[,] r)
	{
		ChessPiece c;
		if (x >= 0 && x < 8 && y >= 0 && y < 8) {
			c = BoardManager.Instance.ChessPieces [x, y];
			if (c == null)
				r [x, y] = true;
			else if (isBlack != c.isBlack)
				r [x, y] = true;
		}
	}
}
