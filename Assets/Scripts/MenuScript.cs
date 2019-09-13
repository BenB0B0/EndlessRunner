using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{

    public GameObject healthDisplay;
    public GameObject scoreDisplay;
    public GameObject game;

    // Update is called once per frame
    void Update() {
     if (Input.GetKeyDown(KeyCode.S) || Input.touches.Length > 0){
         scoreDisplay.SetActive(true);
         healthDisplay.SetActive(true);
         game.SetActive(true);
         gameObject.SetActive(false);
     }   
    }
}
