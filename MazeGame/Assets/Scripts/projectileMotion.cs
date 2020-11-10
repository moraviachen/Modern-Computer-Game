using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileMotion : MonoBehaviour
{
    public float speed =20f;
    public float lifetime = 3f;
    private float lifeTimer;

    

    // Start is called before the first frame update
    void Start()
    {
        //track the bullet's lifetime
        lifeTimer=lifetime;
    }

    // Update is called once per frame
    void Update()
    {
        //update the bullet position
        transform.position+=transform.forward * speed *Time.deltaTime;

        //if the bullet exsited for too lone, remove it
        lifeTimer-=Time.deltaTime;
        if(lifeTimer<=0f){

            Destroy(gameObject);
        }
        
    }

        void OnCollisionEnter(Collision collision){
            //distroy maze object when the the bullet touches it
        if(collision.gameObject.CompareTag("MazeComponent")){
            //calculate the i and j index of the maze object within the map 2d array
            //so we know whether it destroyed the correct piece
            int xPos=(int)collision.gameObject.transform.position.x;
            int zPos=(int)collision.gameObject.transform.position.z;

            int jIndex=(int)((513-xPos)/27);
            int iIndex=(int)((zPos-409)/42);

            
            //check if the piece the bullet hit is within the correct route
            if(mazeGen.map[iIndex,jIndex]==mazeGen.map[0,2]){
                ScoreDisplay.isDistroyed=true;
            }

            //destroy the object regardless
            DestroyObject(collision.gameObject);

        }
    }
}
