using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllienMaster : MonoBehaviour
{
    public GameObject bulletPreFab;

    private Vector3 hMoveDistance = new Vector3(0.05f, 0, 0);
    private Vector3 vMoveDistance = new Vector3(0, 0.015f, 0);

    private const float Max_Left = -2.5f;
    private const float Max_Right = 2.5f;

    public static List<GameObject> allAlliens = new List<GameObject>();

    private bool movingRight;

    private float moveTimer = 0.01f;
    private float moveTime = 0.005f;

    private const float MaxMoveSpeed = 0.02f;

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
}
