using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroScript : MonoBehaviour
{
    Vector3 inicial;
    public static int DanoTiro1 = 15;

    // Use this for initialization
    void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rb;
        rb = GetComponent<Rigidbody2D>();
        Vector2 vetor = new Vector2(100, 0);
        rb.AddForce(vetor);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(gameObject);
        }

        if (collision.tag == "Enemy2")
        {
            Destroy(gameObject);
        }

        if (collision.tag == "Enemy3")
        {
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
