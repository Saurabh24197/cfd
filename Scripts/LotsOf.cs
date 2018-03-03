using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LotsOf : MonoBehaviour {

    public GameObject[] enemyList;
    public GameObject player;
    public Sprite[] blocks;
    public GameObject coin;

    [Space]
    public List<GameObject> lotsOf;
    private Tilemap tileMap;
    public GameObject tileCollider;

    public int coinCount = 0;

    public ScoreManager scoreManager;


    // Use this for initialization
    void Awake()
    {
        tileMap = GameObject.FindGameObjectWithTag("MasterTiles").GetComponent<Tilemap>();
        scoreManager = GameObject.FindGameObjectWithTag("Score").GetComponentInChildren<ScoreManager>();
    }

    private void Start()
    {

        foreach (GameObject go in lotsOf)
        {
            if (go == null) continue;
            int index = Random.Range(0, 3) ;

            switch (index)
            {
                case 0:
                    if (Random.value < 0.2f)
                    {
                        if (Random.value > 0.3f) continue;
                        Instantiate(enemyList[Random.Range(0, enemyList.Length)], go.transform.position, Quaternion.identity);
                    }
                    break;
                case 1:
                    if (Random.value > 0.7f)
                    {
                        Tile tile = new Tile();
                        tile.sprite = blocks[Random.Range(0, enemyList.Length)];
                        
                        Vector3Int pos = tileMap.WorldToCell(go.transform.position);
                        //tile.colliderType = Tile.ColliderType.Grid;
                        tile.colliderType = Tile.ColliderType.Sprite;

                        //Instantiate(tileCollider, pos, Quaternion.identity);
                        tileMap.SetTile(pos, tile);
                    }
                    break;

                case 2:
                    if (Random.value > 0.5f)
                    {
                        if (Random.value > 0.5f) continue;
                        coinCount++;
                        Instantiate(coin, go.transform.position, Quaternion.identity);
                    }

                    break;
            }
        }

        scoreManager.coinCount = coinCount;

    }
}
