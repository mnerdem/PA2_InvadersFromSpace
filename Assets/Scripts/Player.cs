using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject bulletPrefab;
    public const float maxX = 3f;
    public const float minX = -3f;
    
    //private float speed = 3f;
    private bool isShooting;
    //private float cooldown = 0.5f;
    [SerializeField] private ObjectPool objectPool = null;

    public ShipStats shipStats;

    private Vector2 offScreenPos = new Vector2(0, -20f);
    private Vector2 startPos = new Vector2(0, -5f);

    private void Start()
    {
        shipStats.currentHealth = shipStats.maxhealth;
        shipStats.currentLives = shipStats.maxLives;
        transform.position = startPos;
    }


    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.A) && transform.position.x > minX)
        {
            transform.Translate(Vector2.left * Time.deltaTime * shipStats.shipSpeed);
        }

        if (Input.GetKey(KeyCode.D) && transform.position.x < maxX)
        {
            transform.Translate(Vector2.right * Time.deltaTime * shipStats.shipSpeed);
        }
        if (Input.GetKey(KeyCode.Space) && !isShooting)
        {
            StartCoroutine(Shoot());
        }
#endif
    }

    private IEnumerator Shoot ()
    {
        isShooting = true;

        //Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        GameObject obj = objectPool.GetPooledObject();
        obj.transform.position = gameObject.transform.position;

        yield return new WaitForSeconds(shipStats.fireRate);

        isShooting = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Debug.Log("player damaged!..");
            collision.gameObject.SetActive(false);
            TakeDamage();
        }
    }

    public void TakeDamage() 
    {
        shipStats.currentHealth--;

        if (shipStats.currentHealth <= 0)
        {
            shipStats.currentLives--;

            if (shipStats.currentLives <= 0)
            {
                Debug.Log("Game Over !..");
            }
            else
            {
                Debug.Log("Respawn !..");
                StartCoroutine(Respawn());
            }
        }
    }

    private IEnumerator Respawn() 
    {
        transform.position = offScreenPos;

        yield return new WaitForSeconds(2);
        
        shipStats.currentHealth = shipStats.maxhealth;
        
        transform.position = startPos;
    }
}
