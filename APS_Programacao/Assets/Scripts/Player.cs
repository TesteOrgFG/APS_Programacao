using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    Rigidbody2D rb;
    public float speedY;
    public float speedX;
    Vector2 direction;
    public Transform firepoint;
    public Transform firepointDragon;

    public GameObject bullet;
    public GameObject flameDragon;

    private float fireRate;
    public int healthPlayer;



    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speedY = 10;
        healthPlayer = 100;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(speedX, 0, 0);
        Move();
        Fire();
        Special();


        fireRate -= Time.deltaTime;
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

    void Fire()
    {
        if (Input.GetKey(KeyCode.Space) && fireRate < 0)
        {
            Instantiate(bullet, firepoint.position, firepoint.rotation);
            fireRate = 0.3f;
        }
    }

    void Special()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            Instantiate(flameDragon, firepointDragon.position, firepointDragon.rotation);
        }
    }

   void PlayerDeath()
    {
        if (healthPlayer <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
        }
    }
}
