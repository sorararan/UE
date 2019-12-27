using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour {
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            go_next_scene_from(SceneManager.GetActiveScene().name);
		}
    }

    public static void go_next_scene_from(string now_scene_name){
        if (now_scene_name == "Title"){
            SceneManager.LoadScene ("Scenes/Main");
            return;
        }

        if (now_scene_name == "Main"){
            SceneManager.LoadScene ("Scenes/Title");
            return;
        }

        return;
    }
}
