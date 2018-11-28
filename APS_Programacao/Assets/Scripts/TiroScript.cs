using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroScript : MonoBehaviour
{
    Vector3 inicial;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        Rigidbody2D rb;
        rb = GetComponent<Rigidbody2D>();
        Vector2 vetor = new Vector2(100, 0);
        rb.AddForce(vetor);
    }
}
