using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{

    public float speedy;
    public static int healthBoss;
    public int direcao;
    public float tempoMuda;

    public Transform firepoint;
    public GameObject prefabFlecha;
    public GameObject prefabBomba;

    public float tempoMudaTiro;
    private Animator animator;
    

    // Use this for initialization
    void Start()
    {
        healthBoss = 150;
        direcao = -1;
        speedy = 0.1f;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        print("Vida Boss " + healthBoss);

        Vector3 posicao = transform.position;
        posicao.y = Mathf.Clamp(posicao.y, -3, 3);
        transform.position = posicao;

        transform.Translate(0, speedy * direcao, 0);

        MudaDirecao();
        Ataques();

        tempoMuda -= Time.deltaTime;
        tempoMudaTiro += Time.deltaTime;
    }

    void MudaDirecao()
    {
        if (tempoMuda <= 0)
        {
            direcao *= -1;
            tempoMuda = Random.Range(1f, 4f);
        }
    }

   public void ChamaFlecha()
    {
            Instantiate(prefabFlecha, firepoint.position, firepoint.rotation);
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Flecha", GetComponent<Transform>().position);
    }

   public void ChamaBomba()
    {
            Instantiate(prefabBomba, firepoint.position, firepoint.rotation);
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Flecha", GetComponent<Transform>().position);
    }


    void Ataques()
    {
        if (tempoMudaTiro >= 0 && tempoMudaTiro <= 5f)
        {
            animator.SetBool("BombaAtiva", false);
        }

        if (tempoMudaTiro >= 6f)
        {
            animator.SetBool("BombaAtiva", true);

            if (tempoMudaTiro > 10f)
            {
                tempoMudaTiro = 0f;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "LimiteBoss")
        {
            direcao *= -1;
        }

        if (collision.tag == "Tiro1")
        {
            DanoInimigo();
        }
    }


    void DanoInimigo()
    {
        healthBoss -= TiroScript.DanoTiro1;

        if (healthBoss <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetSceneAt(4).name);

        }
    }
}
