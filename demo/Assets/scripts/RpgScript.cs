﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RpgScript : MonoBehaviour
{
    private Animator anim;
    public float speed=1;
    private bool right=true;
    public GameObject enemy;
    public enum State { stop,left,right,skillOne,skillTwo,skillThree,skillFour}
    public State currentState = State.stop;
    //无限地图
    public RoadLoop roadloop;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Airpos")
        {
            roadloop.changeroad(other.transform);

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        enemy=GameObject.Find("RPG-enemy");
         enemy.SetActive(false);
        // enemy.SetActive(false);
        Debug.Log("11111");
        anim =GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if((int)Time.time==3)
        {
         enemy.SetActive(true);
        }
        if(currentState == State.left)
        {
            // if(right==true){
            //     transform.Rotate(new Vector3(0,1*Time.deltaTime*300,0));
            //     if(transform.rotation == Quaternion.Euler(new Vector3(0,180,0))){
            //           this.right=false;
            //          anim.SetBool("walk",true);
            //        transform.Translate( new Vector3(0,0,-1) * speed * Time.deltaTime);  
            //     }
            // }
            anim.SetBool("walk",true);
          transform.Translate( new Vector3(0,0,-1) * speed * Time.deltaTime); 
            
        }
        
        if(currentState ==State.right)
        {
            // if(right==false){
            //     transform.Rotate(new Vector3(0,1*Time.deltaTime*100,0));
            //     if(transform.rotation.y==0){
            //           this.right=true;
            //           return ;  
            //     }
            // }
            anim.SetBool("walk",true);
            transform.Translate( new Vector3(0,0,1) * speed * Time.deltaTime);
        }
        if(currentState == State.stop)
        {
             
            anim.SetBool("walk",false);
        }
        //if(Input.GetKeyUp(KeyCode.D))
        //{
             
        //    anim.SetBool("walk",false);
        //}
        if(currentState == State.skillOne){

            anim.SetTrigger("Q Trigger");
        }
        if(currentState ==State.skillTwo){

            anim.SetTrigger("W Trigger");
        }if(currentState == State.skillThree){

            anim.SetTrigger("E Trigger");
        }if(currentState == State.skillFour){

            anim.SetTrigger("R Trigger");
        }
        if (currentState != State.left && currentState != State.right)
        {
            currentState = State.stop;
        }
        
    }
    public void FootR()
     {

     } 
     public void FootL()
     {

     } 
     public void Hit()
     {

     }

    public void setState(int i)
    {
        switch (i)
        {
            case -1:
                currentState = State.left;
                break;
            case -2:
                currentState = State.right;
                break;
            case 0:
                currentState = State.stop;
                break;
            case 1:
                currentState = State.skillOne;
                break;
            case 2:
                currentState = State.skillTwo;
                break;
            case 3:
                currentState = State.skillThree;
                break;
            case 4:
                currentState = State.skillFour;
                break;

        }
    }
}
