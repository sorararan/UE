using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShogunController : MonoBehaviour {
    private Vector3 launched_velocity = new Vector3(0f, 15.0f, 15.0f);
    private Rigidbody rb;
    private AudioSource audio_source;
    private bool is_grounded;
    private GameObject camera;
    private bool is_viewed;

    void Start() {
        rb = this.GetComponent<Rigidbody>();
        audio_source = GetComponent<AudioSource>();
        is_grounded = false;
        camera = GameObject.Find("Main Camera");
        is_viewed = false;
    }

    void FixedUpdate() {
        if(is_viewed){
            transform.Rotate(new Vector3(0, 3f, 0));
        }
    }

    public void Launch() {
        rb.velocity = launched_velocity;
        audio_source.Play();
    }

    void OnCollisionEnter(Collision collision) {
        if(!is_grounded){
            if(collision.gameObject.tag == "Ground"){
                rb.constraints = RigidbodyConstraints.FreezeAll;
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                transform.position = new Vector3(0f, 2.75f, 20f);
                is_grounded = true;
                camera.GetComponent<CameraAnimation>().CameraWork();
                is_viewed = true;
                Invoke("DisplayText", 5.0f);
            }
        }
    }

    void DisplayText() {
        GameObject.Find("Canvas").transform.Find("Text").gameObject.SetActive(true);
    }
}
