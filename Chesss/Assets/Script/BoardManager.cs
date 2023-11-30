using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : Singleton<BoardManager> {
	
	private const float TILE_SIZE = 1.0f;
	private const float TILE_OFFSET = 0.5f;

	private int selectX = -1;
	private int selectY = -1;

    public ChessPiece[,] ChessPieces { set; get; }
    private ChessPiece selectedChessPiece;

    public List<GameObject> chesspiecePrefabs;
	private List<GameObject> activeChessPiece = new List<GameObject>();

	private Quaternion orientation = Quaternion.Euler(0,90,0);
	private Quaternion orientationB = Quaternion.Euler(0,270,0);

    private bool[,] allowedMoves { set; get; }

    GameObject tile;

	public bool isBlackTurn = true;

	private void Start()
	{
        MakeTile();
		SpawnAllChessPieces ();
	}

	private void Update()
	{
		UpdateSelection ();
		SelectedLocate ();
		if (Input.GetMouseButtonDown (0)) {
			if (selectX >= 0 && selectY >= 0) {
				if (selectedChessPiece == null) {
					SelectChessPiece (selectX, selectY);
				} else {
					MoveChessPiece(selectX,selectY);
				}
			}
		}
	}
	private void SelectChessPiece(int x, int y)
	{
		if (ChessPieces [x, y] == null)
			return;
		if (ChessPieces [x, y].isBlack != isBlackTurn)
			return;

		allowedMoves = ChessPieces [x, y].PossibleMove ();

		selectedChessPiece = ChessPieces [x, y];
		BoardHighlights.Instance.HighlightAllowedMoves (allowedMoves);
	}
    private bool Kill(ChessPiece attackChessPiece, ChessPiece defenceChessPiece)
    {
        int r = Random.Range(0, 10);
        int r2 = Random.Range(0, 10);
        int a = attackChessPiece.randomAttack;
        int d = defenceChessPiece.randomDefence;
        if (r < a)
        {
            if (r < d)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
	private void MoveChessPiece(int x, int y)
	{
		if (allowedMoves[x,y]) {

            ChessPiece c = ChessPieces[x, y];
            bool win = true;
            if (c != null && c.isBlack != isBlackTurn)
            {
                if (c.GetType() == typeof(King))
                {
                    //끝
                    return;
                }
                if (Kill(selectedChessPiece, c))
                {
                    activeChessPiece.Remove(c.gameObject);
                    Destroy(c.gameObject);
                    win = true;

                }
                else
                {
                    activeChessPiece.Remove(selectedChessPiece.gameObject);
                    Destroy(selectedChessPiece.gameObject);
                    win = false;

                }


            }
            if (win)
            {
                ChessPieces[selectedChessPiece.nowX, selectedChessPiece.nowY] = null;
                selectedChessPiece.transform.position = GetTileLocate(x, y);
                selectedChessPiece.SetPosition(x, y);

                ChessPieces[x, y] = selectedChessPiece;
            }

            isBlackTurn = !isBlackTurn;
        }
		BoardHighlights.Instance.HideAllhighlights ();
		selectedChessPiece = null;
	}
	private void UpdateSelection()
	{
		if (!Camera.main)
			return;
		RaycastHit hit;
		if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit, 25.0f, LayerMask.GetMask ("ChessPlane"))) {
			selectX = (int)hit.point.x;
			selectY = (int)hit.point.z;
		} else {
			selectX = -1;
			selectY = -1;
		}
	}
	private void SpawnChessPiece(int index, int x, int y,char color)
	{
        GameObject ob;
        if(color == 'w')
            ob = Instantiate(chesspiecePrefabs[index], GetTileLocate(x, y), orientation) as GameObject;
        else
            ob = Instantiate(chesspiecePrefabs[index], GetTileLocate(x, y), orientationB) as GameObject;


        ob.transform.SetParent (transform);
		ChessPieces [x, y] = ob.GetComponent<ChessPiece> ();
		ChessPieces [x, y].SetPosition (x, y);
		activeChessPiece.Add (ob);
	}

	private void SpawnAllChessPieces()
	{
		activeChessPiece = new List<GameObject> ();
		ChessPieces = new ChessPiece[8, 8];
	//black
		//king
		SpawnChessPiece (0,3,0,'w');

		//queen
		SpawnChessPiece (1,4,0,'w');

		//Rooks
		SpawnChessPiece (2,7,0,'w');
		SpawnChessPiece (2,0,0,'w');

		//bishops
		SpawnChessPiece (3,2,0,'w');
		SpawnChessPiece (3,5,0,'w');

		//knights
		SpawnChessPiece (4,1,0,'w');
		SpawnChessPiece (4,6,0,'w');

		//pawns
		for(int i = 0; i<8; i++){
			SpawnChessPiece (5,i,1,'w');
		}
	//white
		//king
		SpawnChessPiece (6,4,7,'b');

		//queen
		SpawnChessPiece (7,3,7,'b');

		//Rooks
		SpawnChessPiece (8,7,7,'b');
		SpawnChessPiece (8,0,7,'b');

		//bishops
		SpawnChessPiece (9,2,7,'b');
		SpawnChessPiece (9,5,7,'b');

		//knights
		SpawnChessPiece (10,1,7,'b');
		SpawnChessPiece (10,6,7,'b');

		//pawns
		for(int i = 0; i<8; i++){
			SpawnChessPiece (11,i, 6,'b');
		}
	}

	private Vector3 GetTileLocate(int x, int y)
	{
		Vector3 origin = Vector3.zero;
		origin.x += (TILE_SIZE * x) + TILE_OFFSET;
		origin.z += (TILE_SIZE * y) + TILE_OFFSET;
		return origin;

	}

	private void SelectedLocate(){
		if (selectX >= 0 && selectY >= 0) {
            tile.SetActive(true);
            if (selectX >= 8 || selectY >= 8||selectX < 0 || selectY<0)
                tile.SetActive(false);
			tile = BoardHighlights.Instance.selectinghighlights (selectX, selectY, tile);

        }
    }

    private void MakeTile()
    { 
        tile = Instantiate(BoardHighlights.Instance.highlightPrefab);
    }
}
