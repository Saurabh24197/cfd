using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExplosionAttack : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
        StartCoroutine(wait3s());
	}

    IEnumerator wait3s()
    {
        yield return new WaitForSeconds(0.75f);
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }

        if (collision.tag == "Player")
        {
            //Debug.Log("Explosion death!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

    }
}
