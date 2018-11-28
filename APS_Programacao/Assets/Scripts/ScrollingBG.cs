using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBG : MonoBehaviour {

    public Vector2 speed = new Vector2(1, 1);
    public Vector2 direction = new Vector2(-1, 0);


	// Update is called once per frame
	void Update () {

        Vector2 movement = new Vector2(speed.x * direction.x, speed.y * direction.y);

        movement *= Time.deltaTime;

        transform.Translate(movement);
	}
}
