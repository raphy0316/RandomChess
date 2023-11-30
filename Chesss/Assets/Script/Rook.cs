using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : ChessPiece {
	public override bool[,] PossibleMove()
	{
		bool[,] r = new bool[8, 8];
		ChessPiece c;
		int i;
		//right
		i = nowX;
		while (true) {
			i++;
			if (i >= 8)
				break;
			c = BoardManager.Instance.ChessPieces [i, nowY];
			if (c == null)
				r [i, nowY] = true;
			else {
				if (c.isBlack != isBlack)
					r [i, nowY] = true;

				break;
			}
		}
		//left
		i = nowX;
		while (true) {
			i--;
			if (i < 0)
				break;
			c = BoardManager.Instance.ChessPieces [i, nowY];
			if (c == null)
				r [i, nowY] = true;
			else {
				if (c.isBlack != isBlack)
					r [i, nowY] = true;

				break;
			}
		}
		//up
		i = nowY;
		while (true) {
			i++;
			if (i >= 8)
				break;
			c = BoardManager.Instance.ChessPieces [nowX, i];
			if (c == null)
				r [nowX,i] = true;
			else {
				if (c.isBlack != isBlack)
					r [nowX,i] = true;

				break;
			}
		}
		//down
		i = nowY;
		while (true) {
			i--;
			if (i < 0)
				break;
			c = BoardManager.Instance.ChessPieces [nowX,i];
			if (c == null)
				r [nowX, i] = true;
			else {
				if (c.isBlack != isBlack)
					r [nowX,i] = true;

				break;
			}
		}
		return r;
	}
}
