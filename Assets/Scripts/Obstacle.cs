using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    public float speed;
    public GameObject effect;
    public GameObject crashSound;
    public string objectName;

	void Update () {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && objectName == "Enemy") {
            Instantiate(crashSound,transform.position,Quaternion.identity);
            other.GetComponent<Player>().health--;
            other.GetComponent<Player>().camAnim.SetTrigger("shake");
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        } else if (other.CompareTag("Player") && objectName == "Heart") {
            Instantiate(crashSound,transform.position,Quaternion.identity);
            if(other.GetComponent<Player>().health < 3)
                other.GetComponent<Player>().health++;
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        } else if (other.CompareTag("Player") && objectName == "Coin") {
            Instantiate(crashSound,transform.position,Quaternion.identity);
            other.GetComponent<Player>().score++;
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        } else if (other.CompareTag("Player") && objectName == "Swirl") {
            Instantiate(crashSound,transform.position,Quaternion.identity);
            speed = speed * -1;
        } else if (other.CompareTag("Swirl")){
            Instantiate(crashSound,transform.position,Quaternion.identity);
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

      
    }
}
