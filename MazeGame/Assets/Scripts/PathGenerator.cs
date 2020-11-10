using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGenerator : MonoBehaviour
{
    public GameObject starting;//the starting position
    public GameObject tile;
    public GameObject bullet;
    public int xMax= 475;
    public int xMin=415;
    public int zEnd=620;//stop when the path reaches this point
    public int bulletGenerated=0;
    

    // Start is called before the first frame update
    void Start()
    {
        

        //generate the road at the beginning of the game
        generateRoad();
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    //
    public void generateRoad(){
        //set current tile to the starting tile
        Vector3 current=starting.transform.position;
        
        while(true){
            //generate a random direction
            Vector3 temp=generateDir(current);

            //check whether the tile is within the range
            while(temp.x>xMax || temp.x<xMin){
                temp=generateDir(current);
            }

            //create the tile
            Instantiate(tile, temp, Quaternion.identity);

            //generate bullet
            if(bulletGen()==true){
                Instantiate(bullet, new Vector3(temp.x,temp.y+2, temp.z), Quaternion.identity);
            }

            current=temp;

            //check whether this reaches to the yEnd
            if(current.z<=zEnd)break;
            
            
        }

    }

    public Vector3 generateDir(Vector3 current){
        //set the direction of the next tile by a random generator
        //0 is forward, 1 is left and 2 is right

        int temp = Random.Range(0,3);

        if(temp==0){
            return new Vector3(current.x, current.y, current.z-10);
        }else{
            if(temp==1){
                return new Vector3(current.x+10, current.y, current.z);
            }else{
                return new Vector3(current.x-10, current.y, current.z);
            }
        }

        
    }


    //random generator to decide whether we generate a bullet at the current position
    bool bulletGen(){

        //generate no more than 10 bullets
        if(bulletGenerated>=10)return false;

        int temp=Random.Range(0,3);
        if(temp==2){
            bulletGenerated+=1;
            return true;
        }
        return false;
    }
}
