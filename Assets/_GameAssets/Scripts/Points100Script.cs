using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points100Script : MonoBehaviour {
    public int timeToDestroy = 5;
	void Start () {
        Destroy(this.gameObject, timeToDestroy);
	}
	
	void Update () {
        transform.Translate(Vector2.up * Time.deltaTime);	
	}
}
