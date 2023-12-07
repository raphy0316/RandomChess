using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextManager : MonoBehaviour {

	private Characteristic C;
	public Text player;
	public Text result;
	public Text subresult;
	// Use this for initialization
	void Start () {
		C = GameObject.Find("User").GetComponent ("Characteristic") as Characteristic;
		C.ChooseCharacter ();
		printCharacter (C.BCharacter,1);
	}


	// Update is called once per frame
	void Update () {
		UpdateUiText ();
		if (BoardManager.Instance.finish) {
			printResult ();
		}
		else {
			removeResult ();
		}
	}
	IEnumerator bw(){
		yield return new WaitForSeconds (0.3f);
		printCharacter (C.BCharacter,1);
	}
	IEnumerator ww(){
		yield return new WaitForSeconds (0.3f);
		printCharacter (C.WCharacter,2);
	}

	private void UpdateUiText(){
		if (BoardManager.Instance.isBlackTurn) {
			StartCoroutine ("bw");
		} else {
			StartCoroutine ("ww");
		}
	}
	public void printResult(){
		result.text = "You Win!";
		subresult.text = "Please press mouse's right button to restart" +
			"\nPress mouse's left, game will end";
	}
	public void removeResult(){
		result.text = "";
		subresult.text = "";
	}
	public void printCharacter(int Character, int x){
		if (Character == 0) {
			player.text = "Player"+x+" : 전략가";
		} else if (Character == 1) {
			player.text = "Player"+x+" : 폭군";
		} else if (Character == 2) {
			player.text = "Player"+x+" : 영웅";
		} else {
			Debug.Log ("error");
		}
	}
}
