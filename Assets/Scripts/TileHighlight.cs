using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileHighlight : MonoBehaviour
{
    public GameObject tile_N;
    public GameObject tile_NE;
    public GameObject tile_E;
    public GameObject tile_SE;
    public GameObject tile_S;
    public GameObject tile_SW;
    public GameObject tile_W;
    public GameObject tile_NW;

    private GameObject[] tiles;

    private int previousTile;
    private int currentTile;

    private void Awake()
    {
        tiles = new GameObject[8];
        tiles[0] = tile_N;
        tiles[1] = tile_NE;
        tiles[2] = tile_E;
        tiles[3] = tile_SE;
        tiles[4] = tile_S;
        tiles[5] = tile_SW;
        tiles[6] = tile_W;
        tiles[7] = tile_NW;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentTile = 9;
        previousTile = 10;


    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
            StartCoroutine(OneRound());
        }
    }

    IEnumerator OneRound()
    {
        NewRound();

        yield return new WaitForSeconds(1);

        ResetRound();
    }

    void NewRound ()
    {
        currentTile = Random.Range(0, tiles.Length);
        Debug.Log("Current Tile Number " + currentTile);
        tiles[currentTile].gameObject.GetComponent<Renderer>().material.color = new Color(0,0,1,1);

    }

    void ResetRound()
    {
        if (currentTile < tiles.Length)     //checks if it's the first round
        {
            previousTile = currentTile;
            tiles[currentTile].gameObject.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
        }
    }

    public void OnClick()
    {
        if (previousTile == currentTile)
        {
            Debug.Log("Well Done");
        }
        else
        {
            Debug.Log("Better luck next time...");
        }
    }
}
