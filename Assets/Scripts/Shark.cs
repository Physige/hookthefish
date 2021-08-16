using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : MonoBehaviour {
    public Rigidbody rb;
    public float speed = 5f;

    public bool isRight = false;

    // gets rigid body and applies a velocity to make it move
    void Start() {
        rb = this.GetComponent<Rigidbody>();
        if (isRight) {
            rb.velocity = new Vector3(-speed, 0, 0);
        } else {
            rb.velocity = new Vector3(speed, 0, 0);
        }
    }
    
    // checks to see if shark moves out of bounds, if so delete the instance
    void Update() {
        var sharkPositionX = gameObject.transform.position.x;
        if (isRight) {
            if (sharkPositionX < -23) {
                Destroy(this.gameObject);
            }
        } else {
            if (sharkPositionX > 23) {
                Destroy(this.gameObject);
            }
        }
    }
}
