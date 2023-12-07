using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : ChessPiece {
	public override bool[,] PossibleMove(){
		bool[,] r = new bool[8, 8];

		ChessPiece c;
		int i, j;
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
		//Top left
		i = nowX;
		j = nowY;
		while (true) {
			i--;
			j++;
			if (i < 0 || j >=8)
				break;
			c = BoardManager.Instance.ChessPieces [i, j];
			if (c == null)
				r [i, j] = true;
			else {
				if (isBlack != c.isBlack)
					r [i, j] = true;
				break;
			}

		}
		//Top right
		i = nowX;
		j = nowY;
		while (true) {
			i++;
			j++;
			if (i >= 8 || j >= 8)
				break;
			c = BoardManager.Instance.ChessPieces [i, j];
			if (c == null)
				r [i, j] = true;
			else {
				if (isBlack != c.isBlack)
					r [i, j] = true;
				break;
			}

		}
		//down left
		i = nowX;
		j = nowY;
		while (true) {
			i--;
			j--;
			if (i < 0 || j < 0)
				break;
			c = BoardManager.Instance.ChessPieces [i, j];
			if (c == null)
				r [i, j] = true;
			else {
				if (isBlack != c.isBlack)
					r [i, j] = true;
				break;
			}

		}
		//down right
		i = nowX;
		j = nowY;
		while (true) {
			i++;
			j--;
			if (i >= 8 || j < 0)
				break;
			c = BoardManager.Instance.ChessPieces [i, j];
			if (c == null)
				r [i, j] = true;
			else {
				if (isBlack != c.isBlack)
					r [i, j] = true;
				break;
			}

		}

		return r;
	}
}
