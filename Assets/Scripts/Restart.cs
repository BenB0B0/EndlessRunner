using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {


	void Update () {
        if (Input.GetKeyDown(KeyCode.R) || Input.touches.Length > 0){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
	}
}
