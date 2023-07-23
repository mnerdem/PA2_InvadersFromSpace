using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllienMaster : MonoBehaviour
{
    public GameObject bulletPreFab;

    private Vector3 hMoveDistance = new Vector3(0.05f , 0 , 0);
    private Vector3 vMoveDistance = new Vector3(0 , 0.15f , 0);

    private const float Max_Left = -2.5f;
    private const float Max_Right = 2.5f;

    public static List<GameObject> allAlliens = new List<GameObject>();

    private bool movingRight;

    private float moveTimer = 0.01f;
    private float moveTime = 0.005f;

    private float shootTimer = 3f;
    private const float shootTime = 3f;

    private const float MaxMoveSpeed = 0.02f;

    [SerializeField] private ObjectPool objectPool = null;

    public GameObject motherShipPrefab;
    private Vector3 motherShipSpawnPos = new Vector3(3.72f , 3.45f , 0);
    private float motherShipTimer = 15f;
    private const float motherShip_Min = 15f;
    private const float motherShip_Max = 60f;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Allien"))
        {
            allAlliens.Add(go);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (moveTimer<=0)
        {
            MoveEnemies();
        }
        moveTimer -= Time.deltaTime;

        if (shootTimer <= 0 )
        {
            Shoot();
        }
        shootTimer -= Time.deltaTime;

        if (motherShipTimer <= 0)
        {
            SpawnMotherShip();
        }
        motherShipTimer -= Time.deltaTime;
    }

    private void MoveEnemies()
    {
        int hitMax = 0;

        if (allAlliens.Count > 0)
        {
            for (int i = 0; i < allAlliens.Count; i++)
            {
                if (movingRight)
                {
                    allAlliens[i].transform.position += hMoveDistance;
                }
                else
                {
                    allAlliens[i].transform.position -= hMoveDistance;
                }
                if (allAlliens[i].transform.position.x > Max_Right || allAlliens[i].transform.position.x < Max_Left)
                {
                    hitMax++;
                }
            }
            if (hitMax > 0)
            {
                for (int i = 0; i < allAlliens.Count; i++)
                {
                    allAlliens[i].transform.position -= vMoveDistance;
                }
                movingRight = !movingRight;
            }
            moveTimer = GetMoveSpeed();
        }
    }

    private float GetMoveSpeed() 
    {
        float f = allAlliens.Count * moveTime;

        if (f < MaxMoveSpeed)
        {
            return MaxMoveSpeed;
        }
        else
        {
            return f;
        }
    }

    private void Shoot()
    {
        Vector2 pos = allAlliens[Random.Range(0,allAlliens.Count)].transform.position;

        //Instantiate(bulletPreFab, pos, Quaternion.identity); -- object pool öncesi

        GameObject obj = objectPool.GetPooledObject();
        obj.transform.position = pos;

        shootTimer = shootTime;
    }
    private void SpawnMotherShip()
    {
        Instantiate(motherShipPrefab, motherShipSpawnPos, Quaternion.identity);
        motherShipTimer = Random.Range(motherShip_Min,motherShip_Max);
    }
}
