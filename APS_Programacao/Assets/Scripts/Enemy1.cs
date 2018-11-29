using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class
    Enemy1 : MonoBehaviour
{
    public float speedX;
    public int damageEnemy1;
    public int healthEnemy1;
    //SpriteRenderer sprite;

    // Use this for initialization
    void Start()
    {
       // sprite = GetComponent<SpriteRenderer>();
        damageEnemy1 = 15;
        healthEnemy1 = 30;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speedX, 0, 0);
        print(healthEnemy1);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Tiro1")
        {
            DanoInimigo();
        }

        if (collision.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    void DanoInimigo()
    {
        healthEnemy1 -= TiroScript.DanoTiro1;

        if(healthEnemy1 <= 0)
        {
           Destroy(gameObject);
        }
    }
}
