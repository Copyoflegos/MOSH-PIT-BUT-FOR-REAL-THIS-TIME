using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    RaycastHit2D LeftCheck;
    RaycastHit2D RightCheck;
    RaycastHit2D UpCheck;
    RaycastHit2D DownCheck;

    float HorOffset = 8;
    float VerOffset = 4;

    float VerSize = 2;
    float HorSize = 4;

    [SerializeField]
    LayerMask EdgeMask;
    [SerializeField]
    GameObject Player;
    [SerializeField]
    float speed,lerpSpeed;

    Vector3 velocity = Vector3.zero;
    private void Update()
    {
        LeftCheck = Physics2D.BoxCast(new Vector2(transform.position.x - HorOffset, transform.position.y), new Vector2(1,VerSize),0,-transform.right,0,EdgeMask);
        RightCheck = Physics2D.BoxCast(new Vector2(transform.position.x + HorOffset, transform.position.y), new Vector2(1, VerSize), 0, transform.right, 0, EdgeMask);
        UpCheck = Physics2D.BoxCast(new Vector2(transform.position.x, transform.position.y + VerOffset), new Vector2(HorSize, 1), 0, transform.up, 0, EdgeMask);
        DownCheck = Physics2D.BoxCast(new Vector2(transform.position.x, transform.position.y - VerOffset), new Vector2(HorSize, 1), 0, -transform.up, 0, EdgeMask);




        if (!LeftCheck && Player.transform.position.x < transform.position.x)
        {
            print("Move Left");
            
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(Player.transform.position.x - 0.5f, transform.position.y, -10), ref velocity, lerpSpeed);
        }
        if (!RightCheck && Player.transform.position.x > transform.position.x)
        {
            print("Move Right");
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(Player.transform.position.x + 0.5f, transform.position.y, -10), ref velocity, lerpSpeed);

        }


        if (UpCheck)
        {
            print("Up");
        }
        if (DownCheck)
        {
            print("Down");
        }


    }
    private void FixedUpdate()
    {
        
    }
}
