using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroScript : MonoBehaviour
{
    Vector3 inicial;

	// Use this for initialization
	void Start ()
    {
        Rigidbody2D rb;
        rb = GetComponent<Rigidbody2D>();
        Vector2 vetor = new Vector2(1000, 0);
        rb.AddForce(vetor);

        //Destroy(gameObject, 2);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (inicial == null)
        {
            inicial = transform.position;
        }

        if (transform.position.x - inicial.x > 10)
        {
            Destroy(gameObject);
        }
	}
}
