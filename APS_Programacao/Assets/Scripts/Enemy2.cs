using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour {

    public float speedX;
    public static int damageEnemy2;
    public int healthEnemy2;
    public Transform firepoint;
    public GameObject prefabTiro;
    public float fireRateInimigo;

    public GameObject player;
    public float playerDistancia;
    public float ataqueDistancia;

    //SpriteRenderer sprite;

    // Use this for initialization
    void Start()
    {
        // sprite = GetComponent<SpriteRenderer>();
        damageEnemy2 = 30;
        healthEnemy2 = 30;
        fireRateInimigo = 3;
    }

    // Update is called once per frame
    void Update() {

        transform.Translate(speedX, 0, 0);

        print(healthEnemy2);
        fireRateInimigo -= Time.deltaTime;


        playerDistancia = transform.position.x - player.transform.position.x;

        if (Mathf.Abs(playerDistancia) < ataqueDistancia)
        {
            ChamaTiro();
        }   
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
        healthEnemy2 -= TiroScript.DanoTiro1;

        if (healthEnemy2 <= 0)
        {
            Destroy(gameObject);
        }
    }

    void ChamaTiro()
    {
        if (fireRateInimigo <= 0)
        {
            Instantiate(prefabTiro, firepoint.position, firepoint.rotation);
            fireRateInimigo = 3f;
        }
    }
}
