using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : ChessPiece {

	public override bool[,] PossibleMove (){
		bool[,] r = new bool[8, 8];
		ChessPiece c, c2;
		//흰색팀
		if (isBlack) {
			if (nowX != 0 && nowY != 7) {
				c = BoardManager.Instance.ChessPieces [nowX - 1, nowY + 1];
				if (c != null && !c.isBlack)
					r [nowX - 1, nowY + 1] = true;
			}
			if (nowX != 7 && nowY != 7) {
				c = BoardManager.Instance.ChessPieces [nowX + 1, nowY + 1];
				if (c != null && !c.isBlack)
					r [nowX + 1, nowY + 1] = true;
			}
			if (nowY != 7) {
				c = BoardManager.Instance.ChessPieces [nowX, nowY + 1];
				if (c == null) {
					r [nowX, nowY + 1] = true;

				}
			}
			if (nowY == 1) {
				c = BoardManager.Instance.ChessPieces [nowX, nowY + 1];
				c2 = BoardManager.Instance.ChessPieces [nowX, nowY + 2];
				if (c == null & c2 == null)
					r [nowX, nowY + 2] = true;
			}
		}
        //검은팀
        else { 
			if (nowX != 0 && nowY != 0) {
				c = BoardManager.Instance.ChessPieces [nowX - 1, nowY - 1];
				if (c != null && c.isBlack)
					r [nowX - 1, nowY - 1] = true;
			}
			if (nowX != 7 && nowY != 0) {
				c = BoardManager.Instance.ChessPieces [nowX + 1, nowY -1];
				if (c != null && c.isBlack)
					r [nowX + 1, nowY - 1] = true;
			}
			if (nowY != 0) {
				c = BoardManager.Instance.ChessPieces [nowX, nowY - 1];
				if (c == null) {
					r [nowX, nowY - 1] = true;

				}
			}
			if (nowY == 6) {
				c = BoardManager.Instance.ChessPieces [nowX, nowY - 1];
				c2 = BoardManager.Instance.ChessPieces [nowX, nowY - 2];
				if (c == null & c2 == null)
					r [nowX, nowY - 2] = true;
			}

		}
			

		return r;

	}
}
