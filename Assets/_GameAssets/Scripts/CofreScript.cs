using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CofreScript : MonoBehaviour {
    Rigidbody2D rb2d;
    public int force;
	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        InvokeRepeating("Zasca", 3, 5);
	}
	
	void Zasca() {
        rb2d.AddForce(Vector2.up * force, ForceMode2D.Impulse);
    }
}
