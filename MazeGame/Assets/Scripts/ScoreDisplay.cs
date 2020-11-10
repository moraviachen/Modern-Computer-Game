using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public GameObject textLine;
    public GameObject vicDisplay;
    public GameObject player;
    public static int score=3;
    public static bool isDistroyed=false;
    public static string vicOrNo="";


    // Update is called once per frame
    //update the score
    void Update()
    {
        //display & update the UI per frame
        textLine.GetComponent<Text>().text= "BULLETS: " + score;
        checkPlayerPos();
        vicDisplay.GetComponent<Text>().text=ScoreDisplay.vicOrNo;
    }

    void checkPlayerPos(){
        //if the player fell from the terrain, he would fail

        if(player.transform.position.y<55){
            ScoreDisplay.vicOrNo="YOU FAILED";
        }else if(player.transform.position.z<360){
            //only if the player distroyed the right tile and stand on the correct position
            if(isDistroyed) ScoreDisplay.vicOrNo="YOU WIN!";
        }else if(score==0){
            //if you dont have any bullet left
            ScoreDisplay.vicOrNo="YOU FAILED";
        }
        
    }
}
