using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class ThiefController : MonoBehaviour
{
    private Transform player;
    Vector2 movePos;
    float speed = 7f;

    public GameObject bomb;
    private Tilemap tileMap;

    private PlayerMaster playerMaster;
    public bool addedLoc = false;
    public bool stopPlayer = false;

    public float checkRate = 3f;
    private float waitTime;

    // Use this for initialization
    void Start () {
		movePos = new Vector2();
        player = transform;
        tileMap = GameObject.FindGameObjectWithTag("MasterTiles").GetComponent<Tilemap>();
        playerMaster = GetComponent<PlayerMaster>();
        waitTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {

        if (!stopPlayer)
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");

            movePos.x = x * Time.deltaTime * speed;
            movePos.y = y * Time.deltaTime * speed;


            player.Translate(movePos);

        }

        if (Time.time > waitTime)
        {
            waitTime = Time.time + checkRate;
            movePos= transform.position;
            playerMaster.AddPosition(movePos);
        }
            
        if (Input.GetKeyUp(KeyCode.Space))
        {
           
            Vector3Int currentPos = new Vector3Int((int)transform.position.x, (int)transform.position.y, (int)transform.position.z);
            Instantiate(bomb, tileMap.WorldToCell(transform.position), Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
	}

}
