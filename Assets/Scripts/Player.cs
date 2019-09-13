using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public float speed;
    public float increment;
    public float maxY;
    public float minY;
    public float maxX;
    public float minX;

    private Vector2 targetPos;

    public int health;
    public int score;
    private int healthCounter;

    public GameObject moveEffect;
    public Animator camAnim;
    public Text healthDisplay;
    public Text scoreDisplay;

    public GameObject spawner;
    public GameObject restartDisplay;
    public GameObject thisParent;
    public GameObject OppositesParent;

    public GameObject moveXSound;
    public GameObject moveYSound;

    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

    private void Update()
    {
        UpdateUI();

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if ((Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxY) || Swipe() == "up") {
            camAnim.SetTrigger("shake");
            Instantiate(moveYSound,transform.position,Quaternion.identity);
            Instantiate(moveEffect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y + increment);
        } else if ((Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minY) || Swipe() == "down") {
            Instantiate(moveYSound,transform.position,Quaternion.identity);
            camAnim.SetTrigger("shake");
            Instantiate(moveEffect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y - increment);
        } else if ((Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x < maxX) || Swipe() == "right") {
            Instantiate(moveXSound,transform.position,Quaternion.identity);
            camAnim.SetTrigger("shake");
            Instantiate(moveEffect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x + increment,transform.position.y);
        } else if ((Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x > minX) || Swipe() == "left") {
            Instantiate(moveXSound,transform.position,Quaternion.identity);
            camAnim.SetTrigger("shake");
            Instantiate(moveEffect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x - increment,transform.position.y);
        }
    }

    public string Swipe(){
     if(Input.touches.Length > 0) {
         Touch t = Input.GetTouch(0);
         if(t.phase == TouchPhase.Began) {
              //save began touch 2d point
             firstPressPos = new Vector2(t.position.x,t.position.y);
         }
         if(t.phase == TouchPhase.Ended) {
              //save ended touch 2d point
             secondPressPos = new Vector2(t.position.x,t.position.y);
                           
              //create vector from the two points
             currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
               
             //normalize the 2d vector
             currentSwipe.Normalize();
 
             //swipe upwards
             if(currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f) {
                 return "up";
             }
             //swipe down
             if(currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f) {
                 return "down";
             }
             //swipe left
             if(currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f) {
                 return "left";
             }
             //swipe right
             if(currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f) {
                 return "right";
             }
         }
     }
     return null;
}

    private void UpdateUI(){
        if(healthCounter - health > 1){
            health += 1;
        }
        healthCounter = health;
        if (health <= 0 && thisParent.name != "Dead") {
            spawner.SetActive(false);
            restartDisplay.SetActive(true);
            thisParent.SetActive(false);
            OppositesParent.SetActive(true);
            healthDisplay.text = "";
            scoreDisplay.color = Color.yellow;
        } else if(thisParent.name != "Dead"){
            scoreDisplay.text = "Score: " + score.ToString();
            if(health < 2){
                healthDisplay.color = Color.red;
            } else {
                healthDisplay.color = Color.white;
            }
            healthDisplay.text = "Lives: " + health.ToString();
        }
        
    }
}
