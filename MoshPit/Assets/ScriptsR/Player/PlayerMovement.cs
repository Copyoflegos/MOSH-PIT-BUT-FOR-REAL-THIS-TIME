using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    


    bool Right;
    bool Left;
    bool Up;
    bool Down;
    
   
    //temp velocity to add to player 
    Vector3 velocity;

    //Acceleration Speed
    public float AccSpeed;
    

    Rigidbody2D Rb;

    private void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();   
    }


    private void Update()
    {
        //Set bools equal to input (GetButton is for Input from project settings)
        Right = Input.GetButton("Right");
        Left = Input.GetButton("Left");
        Up = Input.GetButton("Up");
        Down = Input.GetButton("Down");
       

        //Series of ifs for detecting input and adding to velocity
        if (Right )
        {
            velocity.x = AccSpeed;
        }
        if (Left )
        {
            velocity.x = -AccSpeed;
        }
        if (Up )
        {
            velocity.y = AccSpeed;
        }
        if (Down )
        {
            velocity.y = -AccSpeed;
        }

        if(Left && Right)
        {
            velocity.x = 0;
        }
        if(Up && Down)
        {
            velocity.y = 0;
        }

        
        if(!Right && !Left)
        {
            velocity.x = 0;
        }
        if(!Up && !Down)
        {
            velocity.y = 0;
        }

        
        
    }
    private void FixedUpdate()
    {
        Rb.AddForce(velocity);
        
    }
}
