using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
        //when the player touches the bullet object
        //destroy the bullet then add to bullet count
        ScoreDisplay.score+=1;
        Destroy(gameObject);
    }
}
