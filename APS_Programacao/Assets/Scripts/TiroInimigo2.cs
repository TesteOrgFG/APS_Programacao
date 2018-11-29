using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroInimigo2 : MonoBehaviour {

    public static int danoTiroInimigo2 = 15;
    public float velocidade;

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rb;
        rb = GetComponent<Rigidbody2D>();
        Vector2 vetor = new Vector2(velocidade, 0);
        rb.AddForce(vetor);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
        }  
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
