using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Rigidbody2D rb;
    public float speed;
    Vector2 direction;


    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody2D>();
        speed = 10;
	}
	
	// Update is called once per frame
	void FixedUpdate() {

        Vector2 vel = rb.velocity;
        vel.y = Input.GetAxis("Vertical") * speed;

        rb.velocity = vel;
    }
}
