using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour {

    public float healthEnemy3;


    public static int damageEnemy3;
    public int HealthEnemy3;
    public Transform firepoint;
    public GameObject prefabTiro;
    public float fireRateInimigo3;


    // Use this for initialization
    void Start()
    {
        // sprite = GetComponent<SpriteRenderer>();
        damageEnemy3 = 30;
        healthEnemy3= 30;
        fireRateInimigo3 = 3;
    }

    // Update is called once per frame
    void Update()
    {

        print(healthEnemy3);
        fireRateInimigo3 -= Time.deltaTime;

        ChamaTiro();
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
        healthEnemy3 -= TiroScript.DanoTiro1;

        if (healthEnemy3 <= 0)
        {
            Destroy(gameObject);
        }
    }

    void ChamaTiro()
    {
        if (fireRateInimigo3 <= 0)
        {
            Instantiate(prefabTiro, firepoint.position, firepoint.rotation);
            fireRateInimigo3 = 3f;
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Bola de canhão", GetComponent<Transform>().position);
        }
    }
}

