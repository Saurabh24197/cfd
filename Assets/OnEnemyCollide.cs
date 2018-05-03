using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnEnemyCollide : MonoBehaviour {

    ThiefController thiefController;

    private void Awake()
    {
        thiefController = GameObject.FindGameObjectWithTag("Player").GetComponent<ThiefController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("onEnemyCollide");
            thiefController.stopPlayer = true;
            StartCoroutine(wait3s());
        }
    }
    IEnumerator wait3s()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        //SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1, LoadSceneMode.Single);
    }
}
