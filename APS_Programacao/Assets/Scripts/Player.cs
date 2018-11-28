using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Rigidbody2D rb;
    public float speedY;
    public float speedX;
    Vector2 direction;
    


    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody2D>();
        speedY = 10;
	}
	
	// Update is called once per frame
	void FixedUpdate() {

        transform.Translate(0, speedX, 0);
        Move();
    }

    void Move()
    {
        Vector2 vel = rb.velocity;
        vel.y = Input.GetAxis("Vertical") * speedY;
        rb.velocity = vel;


        Vector3 posicao = transform.position;
        posicao.y = Mathf.Clamp(posicao.y, -3, 3);
        transform.position = posicao;
    }
}
