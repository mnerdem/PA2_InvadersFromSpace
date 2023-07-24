using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public Sprite[] states;
    private int health;
    private SpriteRenderer SR;


    // Start is called before the first frame update
    void Start()
    {
        health = 4;
        SR = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet") || collision.gameObject.CompareTag("FriendlyBullet"))
        {
            collision.gameObject.SetActive(false);
            health--;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                SR.sprite = states[health - 1];
            }
        }
    }
}
