using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI textMesh;

    public int score;
    public int coinCount;
    public string scoreString = "Score:";

	// Use this for initialization
	void Start () {
	}

    public void IncrementPoint(int point)
    {
        score++;
        textMesh.text = scoreString + score;

        if (score == coinCount)
        {
            StartCoroutine(wait3s());
        }
    }

    IEnumerator wait3s()
    {
        yield return new WaitForSeconds(3);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

}
