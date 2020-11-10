using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mazeGen : MonoBehaviour
{
    public  static int[,] map=new int[5,5];
    public int extendNum=0;
    public int zInc=42;
    public int xDev=27;

    public int xStart=600;
    public int zStart=360;
    public GameObject empty;
    public GameObject left;
    public GameObject right;
    public GameObject up;
    public GameObject down;
    public GameObject upleft;
    public GameObject upright;
    public GameObject downleft;
    public GameObject downright;
    public GameObject leftright;
    public GameObject updown;
    public GameObject updownleft;
    public GameObject updownright;
    public GameObject upleftright;
    public GameObject downleftright;

    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        createmap();
        createMaze();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //this fuction is used to create the map for the maze
    void createmap(){
        mazeGen.map[0,0]=1;
        mazeGen.map[0,1]=2;
        mazeGen.map[0,2]=3;
        mazeGen.map[0,3]=4;
        mazeGen.map[0,4]=5;
        shuffleRow(0);
        extendRow(0);


        for(int i=1;i<5;i++){
            createRow(i);
            shuffleRow(i);
            checkAfterShuffle(i);
            

            /*while(compareRow(i)){
                createRow(i);
                shuffleRow(i);
                checkAfterShuffle(i);
            }*/
            if(i!=4){
                extendRow(i);
            }
        }
    }

    void shuffleRow(int row){
        //throw random number to shuffle row
        

        int rdm = Random.Range(2,3);

        //shuffle
        while(rdm!=0){

            //randomly choose number to shuffle
            int temp= Random.Range(0,4);
            mazeGen.map[row,temp+1]=mazeGen.map[row,temp];
            rdm-=1;
        }
    }

    void extendRow(int row){
        //extend every number appeared in the last row to the Range row
        int dealt=0;
        
        //i used extendnum as property so the maze would be less repetitive (still repetitive but its only 5x5)
        if(extendNum==0){
            for(int i=0;i<5;i++){
                if(dealt==0 || dealt!=mazeGen.map[row,i]){
                    dealt=mazeGen.map[row,i];
                    mazeGen.map[row+1,i]=dealt;
                }
            }
            extendNum=1;
        }else{
            for(int i=4;i>=0;i--){
                if(dealt==0 || dealt!=mazeGen.map[row,i]){
                    dealt=mazeGen.map[row,i];
                    mazeGen.map[row+1,i]=dealt;
            }
            extendNum=0;
        }
    }
    }

    


    void createRow(int row){
        //fill the row with random number

        for(int i=0;i<5;i++){
            if(mazeGen.map[row,i]==0){
                mazeGen.map[row,i]=Random.Range(4,7);
            }
        }
    }

    void checkAfterShuffle(int row){
        
        //after shuffle the row, check whether the number from the row before has extended down
        int passed=0;

        for(int i=0;i<5;i++){
            if(mazeGen.map[row-1,i]!=passed){

                //if map[row,i] is not equal to map[row-1,i]
                //change row i to the row-1 i
                if(mazeGen.map[row,i]==mazeGen.map[row-1,i]){
                    passed=mazeGen.map[row,i];
                }else{
                    if(i==4){
                        mazeGen.map[row,i]=mazeGen.map[row-1,i];
                        
                    }else{
                        if(mazeGen.map[row-1,i+1]!=mazeGen.map[row-1,i]){
                            mazeGen.map[row,i]=mazeGen.map[row-1,i];
                            passed=mazeGen.map[row,i];

                        }
                    }
                }

            }else{
                if(i!=0){
                    if(mazeGen.map[row,i]!=mazeGen.map[row,i-1]){
                        mazeGen.map[row,i]=mazeGen.map[row,i-1];
                }
                }
            }
        }

        //loop through to makesure there's no isolating cells
        /*for(int i=0;i<5;i++){
            if(i==0){
                if(mazeGen.map[row,i]!=mazeGen.map[row,i+1]&& mazeGen.map[row,i]!=mazeGen.map[row-1,i]){
                    mazeGen.map[row,i]=mazeGen.map[row+1,i];
                }

                }else if(i==4){
                    if(mazeGen.map[row,i]!=mazeGen.map[row,i-1]&& mazeGen.map[row,i]!=mazeGen.map[row-1,i]){
                    mazeGen.map[row,i]=mazeGen.map[row+1,i];
                }
                }else{
                    if(mazeGen.map[row,i]!=mazeGen.map[row,i+1]&&mazeGen.map[row,i]!=mazeGen.map[row,i-1]&& mazeGen.map[row,i]!=mazeGen.map[row-1,i]){
                        int tempooo=a.Range(0,2);
                        if(tempooo==0){
                            mazeGen.map[row,i]=mazeGen.map[row+1,i];
                        }else{
                            mazeGen.map[row,i]=mazeGen.map[row+1,i];
                        }
                }
                }
            
        }*/
    }


    


    void createMaze(){
        //call this function to create maze
        //i made 15 prefabs to satisfy different form of the maze pieces
        //check which piece it should be placed then instantiate the piece in place according to its i and j value
        for(int i=0;i<5;i++){
            for(int j=0;j<5;j++){
                //process the first row

                if(i==0){
                    if(j==0){
                        if(mazeGen.map[i,j]==mazeGen.map[i+1,j]){
                            if(mazeGen.map[i,j]==mazeGen.map[i,j+1]){
                                
                                Instantiate(upleft, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                            }else{
                                
                                Instantiate(upleftright, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                            }
                        }else{
                            
                            Instantiate(updownleft, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                        }
                    }else if(j==4){
                        if(mazeGen.map[i,j]==mazeGen.map[i+1,j]){
                            if(mazeGen.map[i,j]==mazeGen.map[i,j-1]){
                                
                                Instantiate(upright, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                            }else{
                                
                                Instantiate(upleftright, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                            }
                        }else{
                            
                            Instantiate(updownright, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                        }
                    }else if(j==2){
                        //the exit of the maze
                        if(mazeGen.map[i,j]==mazeGen.map[i+1,j]){
                            if(mazeGen.map[i,j]==mazeGen.map[i,j-1]){
                                if(mazeGen.map[i,j]==mazeGen.map[i,j+1]){
                                    Instantiate(empty, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                                }else{
                                
                                Instantiate(right, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                                }
                            }else{
                                
                                if(mazeGen.map[i,j]==mazeGen.map[i,j+1]){
                                    Instantiate(left, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                                }else{
                                
                                Instantiate(leftright, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                                }
                            }
                        }else{
                            if(mazeGen.map[i,j]==mazeGen.map[i,j-1]){
                                if(mazeGen.map[i,j]==mazeGen.map[i,j+1]){
                                    Instantiate(down, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                                }else{
                                
                                Instantiate(downright, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                                }
                            }else{
                                
                                if(mazeGen.map[i,j]==mazeGen.map[i,j+1]){
                                    Instantiate(downleft, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                                }else{
                                
                                Instantiate(downleftright, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                                }
                            }
                            
                            
                        }
                    }else{
                        //all the other cases
                        //check downwards
                        if(mazeGen.map[i,j]==mazeGen.map[i+1,j]){
                            //check right
                            if(mazeGen.map[i,j]==mazeGen.map[i,j+1]){
                                //check left
                                if(mazeGen.map[i,j]==mazeGen.map[i,j-1]){
                                    
                                    Instantiate(up, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                                }else{
                                    
                                    Instantiate(upleft, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                                }
                            }else{
                                if(mazeGen.map[i,j]==mazeGen.map[i,j-1]){
                                    
                                    Instantiate(upright, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                                }else{
                                    
                                    Instantiate(upleftright, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                                }
                            }
                        }else{
                            //check right
                            if(mazeGen.map[i,j]==mazeGen.map[i,j+1]){
                                if(mazeGen.map[i,j]==mazeGen.map[i,j-1]){
                                    
                                    Instantiate(updown, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                                }else{
                                    
                                    Instantiate(updownleft, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                                }
                            }else{
                                
                                Instantiate(updownright, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                            }
                        }
                    }
                }else if(i==4){
                    //deal with the last row
                    //i would not close the down part

                    if(j==0){
                        //check up
                        if(mazeGen.map[i,j]==mazeGen.map[i-1,j]){
                            if(mazeGen.map[i,j]==mazeGen.map[i,j+1]){
                                
                                Instantiate(left, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                            }else{
                                
                                Instantiate(leftright, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                            }
                        }else{
                            if(mazeGen.map[i,j]==mazeGen.map[i,j+1]){
                                
                                Instantiate(upleft, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                            }else{
                                Instantiate(upleftright, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                            }
                        }
                    }else if(j==4){
                        //check up
                        if(mazeGen.map[i,j]==mazeGen.map[i-1,j]){
                            if(mazeGen.map[i,j]==mazeGen.map[i,j-1]){
                                
                                Instantiate(right, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                            }else{
                                
                                Instantiate(leftright, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                            }
                        }else{
                            if(mazeGen.map[i,j]==mazeGen.map[i,j+1]){
                                
                                Instantiate(upright, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                            }else{
                                
                                Instantiate(upleftright, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                            }
                        }

                    }else{
                        //check up
                        if(mazeGen.map[i,j]==mazeGen.map[i-1,j]){
                            if(mazeGen.map[i,j]==mazeGen.map[i,j+1]){
                                if(mazeGen.map[i,j]==mazeGen.map[i,j-1]){
                                    
                                    Instantiate(empty, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                                }else{
                                    
                                    Instantiate(left, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                                }
                            }else{
                                if(mazeGen.map[i,j]==mazeGen.map[i,j-1]){
                                    
                                    Instantiate(right, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                                }else{
                                    
                                    Instantiate(leftright, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                                }
                            }
                        }else{
                            //eliminate up
                            if(mazeGen.map[i,j]==mazeGen.map[i,j+1]){
                                if(mazeGen.map[i,j]==mazeGen.map[i,j-1]){
                                    
                                    Instantiate(up, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                                }else{
                                    
                                    Instantiate(upleft, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                                }
                            }else{
                                if(mazeGen.map[i,j]==mazeGen.map[i,j-1]){
                                    
                                    Instantiate(upright, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                                }else{
                                    
                                    Instantiate(upleftright, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                                }
                            }
                        }
                    }


                }else{
                    //everything other than the first row and the last row

                    if(j==0){
                        
                        //check up
                        if(mazeGen.map[i,j]==mazeGen.map[i-1,j]){
                            //check down
                            if(mazeGen.map[i,j]==mazeGen.map[i+1,j]){
                                //check right
                                if(mazeGen.map[i,j]==mazeGen.map[i,j+1]){
                                    
                                    Instantiate(left, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                                }else{
                                    
                                    Instantiate(leftright, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                                }
                            }else if(mazeGen.map[i,j]==mazeGen.map[i,j+1]){
                                
                                Instantiate(downleft, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                            }else{
                                
                                Instantiate(downleftright, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                            }
                            
                        }else if(mazeGen.map[i,j]==mazeGen.map[i+1,j]){
                            //up, check down
                            if(mazeGen.map[i,j]==mazeGen.map[i,j+1]){
                                    
                                    Instantiate(upleft, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                                }else{
                                    
                                    Instantiate(upleftright, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                                }
                        }else{
                            
                            Instantiate(updownleft, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                        }
                        

                    }else if(j==4){
                        //check up
                        if(mazeGen.map[i,j]==mazeGen.map[i-1,j]){
                            //check down
                            if(mazeGen.map[i,j]==mazeGen.map[i+1,j]){
                                //check left
                                if(mazeGen.map[i,j]==mazeGen.map[i,j-1]){
                                    
                                    Instantiate(right, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                                }else{
                                    
                                    Instantiate(leftright, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                                }
                            }else if(mazeGen.map[i,j]==mazeGen.map[i,j-1]){
                                
                                Instantiate(downright, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                            }else{
                                
                                Instantiate(downleftright, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                            }
                            
                        }else if(mazeGen.map[i,j]==mazeGen.map[i+1,j]){
                            //up, check down
                            if(mazeGen.map[i,j]==mazeGen.map[i,j-1]){
                                    
                                    Instantiate(upright, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                                }else{
                                    
                                    Instantiate(upleftright, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                                }
                        }else{
                            
                            Instantiate(updownright, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                        }

                        
                    }else{
                        //check up
                        if(mazeGen.map[i,j]==mazeGen.map[i-1,j]){
                            //check down
                            if(mazeGen.map[i,j]==mazeGen.map[i+1,j]){
                                //check right
                                if(mazeGen.map[i,j]==mazeGen.map[i,j+1]){
                                    //check left
                                    if(mazeGen.map[i,j]==mazeGen.map[i,j-1]){
                                        
                                        Instantiate(empty, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                                    }else{
                                        
                                        Instantiate(left, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                                    }
                                }else{
                                    if(mazeGen.map[i,j]==mazeGen.map[i,j-1]){
                                        
                                        Instantiate(right, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                                    }else{
                                        
                                        Instantiate(leftright, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                                    }
                                }
                            }else if(mazeGen.map[i,j]==mazeGen.map[i,j+1]){
                                if(mazeGen.map[i,j]==mazeGen.map[i,j-1]){
                                    
                                    Instantiate(down, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                                }else{
                                    
                                    Instantiate(downleft, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                                }
                            }else{
                                
                                Instantiate(downleftright, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                            }
                            
                        }else if(mazeGen.map[i,j]==mazeGen.map[i+1,j]){
                            //check down
                            if(mazeGen.map[i,j]==mazeGen.map[i+1,j]){
                                //check right
                                if(mazeGen.map[i,j]==mazeGen.map[i,j+1]){
                                    //check left
                                    if(mazeGen.map[i,j]==mazeGen.map[i,j-1]){
                                        
                                        Instantiate(up, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                                    }else{
                                        
                                        Instantiate(upleft, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                                    }
                                }else{
                                    if(mazeGen.map[i,j]==mazeGen.map[i,j-1]){
                                        
                                        Instantiate(upright, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                                    }else{
                                        
                                        Instantiate(upleftright, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                                    }
                                }
                            }else if(mazeGen.map[i,j]==mazeGen.map[i,j+1]){
                                if(mazeGen.map[i,j]==mazeGen.map[i,j-1]){
                                    
                                    Instantiate(updown, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                                }else{
                                    
                                    Instantiate(updownleft, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                                }
                            }else{
                                Instantiate(bullet, new Vector3(xStart-(j*xDev),61, zStart+(i*zInc)), Quaternion.identity);
                            }
                        }

                    }
                }


            }
        }
    }




}
