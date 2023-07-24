using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Allien : MonoBehaviour
{

    public int scoreValue;
    public GameObject explosion;

    public void Kill() 
    {
        UIManager.UpdateScore(scoreValue);
        AllienMaster.allAlliens.Remove(gameObject);
        Instantiate(explosion, transform.position, Quaternion.identity);

        if (AllienMaster.allAlliens.Count == 0)
        {
            GameManager.SpawnNewWave();
        }

        gameObject.SetActive(false);
    }
}
