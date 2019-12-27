using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimation : MonoBehaviour {
    public void CameraWork() {
        iTween.MoveTo(
            gameObject, 
            iTween.Hash(
                "x", 1.5f,
                "y", 2f, 
                "z", 15f,
                "time", 30f
            )
        );
    }
}
