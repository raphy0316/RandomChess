using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardHighlights : Singleton<BoardHighlights> {

	private List<GameObject> highlights;
    public GameObject highlightPrefab;
    public GameObject tile;


    void Start () {
        
        highlights = new List<GameObject> ();
	}

	private GameObject GetHighlightObject()
	{
		
		GameObject ob = highlights.Find (g => !g.activeSelf);

		if (ob == null) {
			ob = Instantiate (highlightPrefab);
			highlights.Add (ob);
		}
		return ob;
	}

	public void HighlightAllowedMoves(bool[,] moves)
	{
		for (int i = 0; i < 8; i++) {
			for (int j = 0; j < 8; j++) {
				if (moves [i, j]) {
					GameObject ob = GetHighlightObject ();
					ob.SetActive (true);
					ob.transform.position = new Vector3 (i+0.5f, 0, j+0.5f);
				}
			}
		}
	}
	public GameObject selectinghighlights(int x, int y, GameObject tile){
        tile.transform.position = new Vector3 (x+0.5f, 0, y+0.5f);
		return tile;
	}
	public void hidehighlights(GameObject ob){
		//Destroy (ob);
		ob.SetActive(false);
	}

	public void HideAllhighlights()
	{
		foreach (GameObject ob in highlights)
			ob.SetActive (false);
	}
}
