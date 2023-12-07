using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPiece : MonoBehaviour {

	public int nowX{ set; get; }
	public int nowY{ set; get; }
	public bool isBlack;
	public int randomAttack{ set; get; }
	public int randomDefence{ set; get; }

	public GameObject User;
	public Characteristic C;


	private void Awake(){
		C = GameObject.Find("User").GetComponent ("Characteristic") as Characteristic;
	}
		
	public void SetPosition(int x, int y)
	{
		nowX = x;
		nowY = y;
	}
	public virtual bool[,] PossibleMove()
	{
		return new bool[8,8];
	}
	public void ChooseStatus(ChessPiece c){
		int Character;
		if (c.isBlack) {
			Character = C.BCharacter;
		} else {
			Character = C.WCharacter;
		}
		if (Character == 0) {
			//전략가
			randomAttack = 9;
			randomDefence = 5;
		}
		else if (Character == 1) {
			//폭군
			randomAttack = 7;
			randomDefence = 4;
		}
		else if (Character == 2) {
			//영웅
			if (c.GetType () == typeof(King)) {
				randomAttack = 10;
				randomDefence = 5;
			} else {
				randomAttack = 7;
				randomDefence = 5;
			}

		}

	}
}
