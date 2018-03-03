using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMaster : MonoBehaviour {

    public List<Vector3> movePositions;

    private float waitTime;
    public float checkTime = 3f;
    private Tilemap tileMap;

    public void Awake()
    {
        movePositions = new List<Vector3>();
        tileMap = GameObject.FindGameObjectWithTag("MasterTiles").GetComponent<Tilemap>();
    }
    public void AddPosition(Vector2 movePos)
    {
        
        float x = movePos.x;
        float y = movePos.y;

        movePositions.Add(movePos);
        //go.transform.SetParent(transform);
    }

    private void Update()
    {
        if (Time.time > waitTime)
        {
            waitTime=Time.time + checkTime;

            if (movePositions.Count > 5)
                movePositions.RemoveAt(0);
        }
    }
}
