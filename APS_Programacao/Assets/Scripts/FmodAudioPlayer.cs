using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FmodAudioPlayer : MonoBehaviour {

    public void BaterAsas()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Bater de Asas", GetComponent<Transform>().position);
    }

    public void Click()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Click", GetComponent<Transform>().position);
    }
}
