using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour {

    public List<GameObject> movePositions;
    public bool useRandomLocations = false;
    public float moveSpeed = 3f;
    public float waitTime = 1f;
    public bool locReached = false;

    public GameObject currentPosition;

    private float currentWaitTime;
    // Use this for initialization
    void Start ()
    {
        //movePositions = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMaster>().movePositions;
        currentWaitTime = waitTime;
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = Vector2.MoveTowards(transform.position, currentPosition.transform.position, moveSpeed * Time.deltaTime);
            

        if (Vector2.Distance(transform.position, currentPosition.transform.position) < .2f)
        {
            locReached = true;
        }
        else if (Vector2.Distance(transform.position, currentPosition.transform.position) > .2f)
        {
            currentWaitTime -= Time.deltaTime;
        }

        if (locReached || currentWaitTime <=0)
        {
            if (useRandomLocations)
            {
                currentPosition = movePositions[Random.Range(0, movePositions.Count)];
            }

            else currentPosition = movePositions[0];

            movePositions.Remove(currentPosition);
            movePositions.Insert(movePositions.Count - 1, currentPosition);
            currentWaitTime = waitTime;

            locReached = false;
        }

    }

    /*
    IEnumerator EnemyWait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        locReached = true;
    }*/
}
