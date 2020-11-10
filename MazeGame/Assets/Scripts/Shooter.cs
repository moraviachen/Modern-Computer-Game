using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject projectile;
    public GameObject player;
    
    void Start()
    {
        
    }

    // Update is called once per frame

    //once the mouse get click, shoot if still have bullet

    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            //check bullet number
            if(ScoreDisplay.score>0){
                GameObject bulletS=Instantiate(projectile);
                Vector3 temp=new Vector3(0,4,0);
                bulletS.transform.position=player.transform.position+player.transform.forward+temp;
                bulletS.transform.forward=player.transform.forward;
                ScoreDisplay.score-=1;
            }
        }

        
    }




}
