using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPiece : MonoBehaviour {

	public int nowX{ set; get; }
	public int nowY{ set; get; }
	public bool isBlack;

    public int randomAttack = 7;
    public int randomDefence = 3;

	public void SetPosition(int x, int y)
	{
		nowX = x;
		nowY = y;
	}
	public virtual bool[,] PossibleMove()
	{
		return new bool[8,8];
	}
}
