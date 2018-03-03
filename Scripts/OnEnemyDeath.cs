using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnemyDeath : MonoBehaviour {

    public GameObject particleDeath;

    private void OnDestroy()
    {
        Instantiate(particleDeath, transform.position, Quaternion.identity);
    }
}
