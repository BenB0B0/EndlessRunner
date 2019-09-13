using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour {

    public GameObject obstacle;
    private Vector3 obstaclePos;
    private float[] acceptableYPos = {-10f,-7.5f,-5f,-2.5f,0f,2.5f,5f,7.5f,10f}; 

    private void Start()
    {   
        int rand = Random.Range(0, acceptableYPos.Length);
        obstaclePos = new Vector3(transform.position.x, acceptableYPos[rand], 0);
        Instantiate(obstacle, obstaclePos, Quaternion.identity);
    }
}
