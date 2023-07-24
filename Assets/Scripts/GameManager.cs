using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject[] allAllienSets;
    public GameObject currentSet;
    public Vector2 spawnPos = new Vector2(0, 10);

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SpawnNewWave();
    }

    public static void SpawnNewWave() 
    {
        Instance.StartCoroutine(Instance.SpawnWave());
    }

    private IEnumerator SpawnWave() 
    {
        if (currentSet != null)
        {
            Destroy(currentSet);
        }
        yield return new WaitForSeconds(3);
        currentSet = Instantiate(allAllienSets[Random.Range(0,allAllienSets.Length)], spawnPos, Quaternion.identity);
        UIManager.UpdateWave();
    }

}
