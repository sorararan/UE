using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageController : MonoBehaviour {
    private Vector3 speed;
    private Rigidbody rb;
    private bool is_in_position_range;
    private float x_range;

    void Start() {
        speed = new Vector3(4.0f, 0.0f, 0.0f);
        x_range = 8.0f;
        rb = GetComponent<Rigidbody>();
        rb.velocity = speed;
        is_in_position_range = true;
    }

    void FixedUpdate() {
        if(transform.localPosition.x > x_range || transform.localPosition.x < -x_range){
            if(is_in_position_range){
                rb.velocity = -rb.velocity;
                is_in_position_range = false;
            }
        }else if(!is_in_position_range){
            is_in_position_range = true;
        }
    }

    void OnCollisionEnter(Collision collision) {
        Rigidbody rb = this.GetComponent<Rigidbody>();
        this.transform.parent = collision.transform;
        rb.constraints = RigidbodyConstraints.None;
        rb.isKinematic = true;
    }
}
