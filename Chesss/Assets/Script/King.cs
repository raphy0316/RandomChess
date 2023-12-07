using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : ChessPiece {
	public override bool[,] PossibleMove()
	{
		bool[,] r = new bool[8, 8];

		ChessPiece c;
		int i, j;

		int Character;

		if (isBlack) {
			Character = C.BCharacter;
		} else {
			Character = C.WCharacter;
		}
		if (Character == 2) {
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
		} else {
			//top side
			i = nowX -1;
			j = nowY +1;
			if (nowY!=7){
				for(int a = 0; a <3; a++){
					if(i>=0||i<8)
					{
						c = BoardManager.Instance.ChessPieces[i,j];
						if(c == null)
							r[i,j] = true;
						else if(isBlack != c.isBlack)
							r[i,j] = true;

					}
					i++;
				}
			}
			//down side
			i = nowX -1;
			j = nowY -1;
			if (nowY!=0){
				for(int a = 0; a <3; a++){
					if(i>=0||i<8)
					{
						c = BoardManager.Instance.ChessPieces[i,j];
						if(c == null)
							r[i,j] = true;
						else if(isBlack != c.isBlack)
							r[i,j] = true;

					}
					i++;
				}
			}

			//middle left
			if (nowX != 0) {
				c=BoardManager.Instance.ChessPieces [nowX - 1, nowY];
				if (c == null)
					r [nowX - 1, nowY] = true;
				else if (isBlack != c.isBlack)
					r [nowX - 1, nowY] = true;
			}
			//middle left
			if (nowX != 0) {
				c=BoardManager.Instance.ChessPieces [nowX - 1, nowY];
				if (c == null)
					r [nowX + 1, nowY]= true;
				else if (isBlack != c.isBlack)
					r [nowX + 1, nowY] = true;
			}

			return r;
		}

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
	
