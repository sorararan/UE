using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShogunLauncher : MonoBehaviour {
    private Vector3 INITIAL_POSITION = new Vector3(1.25f, 3.0f, 1.5f);
    private Quaternion INITIAL_ROTATION = Quaternion.Euler(new Vector3(45.0f, 0.0f, 0.0f));
    private bool is_reloaded;
    private GameObject shogun_prefab;
    private GameObject reloaded_shogun;

    void Start() {
        is_reloaded = false;
        shogun_prefab = (GameObject)Resources.Load("Prefabs/Shogun");
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)){
            ReloadShogun();
        }

        if(Input.GetKeyDown(KeyCode.Return)){
            LaunchShogun();
        }
    }

    void OnCollisionEnter(Collision collision) {
        reloaded_shogun = collision.gameObject;
    }

    private void ReloadShogun() {
        if(!is_reloaded){
            Instantiate(shogun_prefab, INITIAL_POSITION, INITIAL_ROTATION);
            is_reloaded = true;
        }
    }

    private void LaunchShogun() {
        if(is_reloaded){
            reloaded_shogun.GetComponent<ShogunController>().Launch();
            is_reloaded = false;
        }
    }
}
