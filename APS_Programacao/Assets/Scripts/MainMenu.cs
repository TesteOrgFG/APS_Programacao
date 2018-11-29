using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    [SerializeField] private string newLevel;

    // Use this for initialization
    public void PlayGame()
    {
        SceneManager.LoadScene(newLevel);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void PlaySound()
    {

    }

    public void BaterAsas()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Bater de Asas", GetComponent<Transform>().position);
    }

    public void Click()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Click", GetComponent<Transform>().position);
    }

    public void MenuInicial()
    {
        SceneManager.LoadScene("Menu Inicial");
    }
}
