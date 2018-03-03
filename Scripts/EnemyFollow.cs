using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyFollow : MonoBehaviour
{
    public float enemySpeed = 3f;
    private Transform playerTarget;
    public List<Vector3> movePositions;

    private Tilemap tMap;

    private void Awake()
    {
        movePositions = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMaster>().movePositions;
        playerTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Use this for initialization
    void Start () {

        movePositions[0] = playerTarget.transform.position;
        tMap = GameObject.FindGameObjectWithTag("MasterTiles").GetComponent<Tilemap>();
    }
	
	// Update is called once per frame
	void Update () {

        if (movePositions[movePositions.Count - 1] != null)
        {
            Vector3 current = movePositions[movePositions.Count - 1];
            //movePositions.Remove(current);


            if (Vector2.Distance(transform.position, current) > 0.25f)
                transform.position = Vector2.MoveTowards(transform.position, current, enemySpeed * Time.deltaTime);
        }
    }
}
