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
        PlayerDeath();


        fireRate -= Time.deltaTime;

        print(healthPlayer);
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
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Flecha", GetComponent<Transform>().position);
        }
    }

    void Special()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            Instantiate(flameDragon, firepointDragon.position, firepointDragon.rotation);
            //FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Bafo do Dragão", GetComponent<Transform>().position);
        }
    }

   void PlayerDeath()
    {
        if (healthPlayer <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetSceneAt(3).name);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            healthPlayer -= Enemy1.damageEnemy1;
        }

        if(collision.tag == "Enemy2")
        {
            healthPlayer -= Enemy2.damageEnemy2;
        }

        if (collision.tag == "Enemy3")
        {
            healthPlayer -= Enemy3.damageEnemy3;
        }

        if (collision.tag == "TiroInimigo2")
        {
            healthPlayer -= TiroInimigo2.danoTiroInimigo2;
        }

        if (collision.tag == "TiroInimigo3")
        {
            healthPlayer -= TiroInimigo3.danoTiroInimigo3;
        }

        if (collision.tag == "AcionaBoss")
        {
            SceneManager.LoadScene(SceneManager.GetSceneAt(2).name);
        }
    }
}
