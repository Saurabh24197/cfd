using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public ScoreManager scoreManager;
    public AudioClip coinPickup;
    public GameObject coinParticle;

    private int collisionCount = 0;
    private int maxCollisonCount = 10;

    private void Start()
    {
        scoreManager = GameObject.FindGameObjectWithTag("Score").GetComponentInChildren<ScoreManager>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.transform.tag == "Player")
        {
            scoreManager.IncrementPoint(1);
            AudioSource.PlayClipAtPoint(coinPickup, transform.position);
            Instantiate(coinParticle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
