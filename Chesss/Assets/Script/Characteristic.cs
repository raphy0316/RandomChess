using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characteristic : Singleton<Characteristic> {
	public int BCharacter{ set; get; }
	public int WCharacter{ set; get; }
	private void printCharacter(int Character){
		if (Character == 0) {
			Debug.Log ("Character is 전략가");
		} else if (Character == 1) {
			Debug.Log ("Character is 폭군");
		} else if (Character == 2) {
			Debug.Log ("Character is 영웅");
		} else {
			Debug.Log ("error");
		}

	}
	public void ChooseCharacter(){
		BCharacter = Random.Range(0,3);
		WCharacter = Random.Range(0,3);
		printCharacter (BCharacter);
		printCharacter (WCharacter);
	}
}
