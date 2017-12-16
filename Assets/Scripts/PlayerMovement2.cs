using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{

    private Rigidbody2D rigidbody2D;       //Store a reference to the Rigidbody2D component required to use 2D Physics.
    public KeyCode moveLeft = KeyCode.LeftArrow;
    public KeyCode moveRight = KeyCode.RightArrow;
    public KeyCode moveDown = KeyCode.DownArrow;
    public KeyCode moveUp = KeyCode.UpArrow;

    private float targetTime = 2.0f;  // max keypress time
    private float currentTime = 0.0f; // already pressed time
    private float Speed = 0;

    public float MaxSpeed = 6;
    public float SpeedRampupTime = 0.2f;

    public float vSpeed = 2;

    public float vSpeedDefault = 2;
    public float vSpeedMax = 8;

    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var velocity = rigidbody2D.velocity;

        float horizontalSpeed = GetHorizontalSpeed(velocity);
        float verticalSpeed = GetVerticalSpeed(velocity);             

        rigidbody2D.velocity = new Vector2(horizontalSpeed, verticalSpeed);

        //ALTERNATIVE RAMPUP SOLUTION
        //		rigidbody2D.velocity = new Vector2(0, 0);
        //if ((Input.GetKey(moveLeft)) && (Speed < MaxSpeed))
        //    Speed = Speed - Acceleration * Time.deltaTime;
        //else if ((Input.GetKey(moveRight)) && (Speed > -MaxSpeed))
        //    Speed = Speed + Acceleration * Time.deltaTime;
        //else
        //{
        //    if (Speed > Deceleration * Time.deltaTime)
        //        Speed = Speed - Deceleration * Time.deltaTime;
        //    else if (Speed < -Deceleration * Time.deltaTime)
        //        Speed = Speed + Deceleration * Time.deltaTime;
        //    else
        //        Speed = 0;
        //}
    }

    private float GetHorizontalSpeed(Vector2 currentVelocity)
    {
        float horizontalSpeed = 0;
        if (Input.GetKey(moveLeft))
        {
            if (SpeedRampupTime > 0)
            {
                float speedChange = MaxSpeed / SpeedRampupTime * Time.deltaTime;
                float speed = Mathf.Min(0, currentVelocity.x); //Instant direction change
                speed -= speedChange;

                speed = Mathf.Max(speed, -MaxSpeed);
                horizontalSpeed = speed;
            }
            else
            {
                horizontalSpeed = -MaxSpeed;
            }
        }
        else if (Input.GetKey(moveRight))
        {
            if (SpeedRampupTime > 0)
            {
                float speedChange = MaxSpeed / SpeedRampupTime * Time.deltaTime;
                float speed = Mathf.Max(0, currentVelocity.x); //Instant direction change
                speed += speedChange;
                speed = Mathf.Min(speed, MaxSpeed);
                horizontalSpeed = speed;
            }
            else
            {
                horizontalSpeed = MaxSpeed;
            }
        }

        return horizontalSpeed;
    }

    private float GetVerticalSpeed(Vector2 currentVelocity)
    {
        float verticalSpeed = currentVelocity.y;
        if (Input.GetKey(moveDown))
        {
            currentTime += Time.deltaTime;

            // increase the key-pressed timer
            if (currentTime < targetTime)
            {
                speedUp();
            }

            //1-(1/(A1*100))

            //			vSpeed = -8+(1 + (1 / (Mathf.Ceil(currentTime))));

            rigidbody2D.velocity = new Vector2(0, vSpeed * -1f);


        }
        else if (Input.GetKey(moveUp))
        {
            //			rigidbody2D.velocity = new Vector2(0, vSpeed/2);




            rigidbody2D.velocity = new Vector2(0, 0);
            currentTime = 0;
        }

        return verticalSpeed;
    }

    private void speedUp()
    {
        this.vSpeed += (1f / 3f);
        print(vSpeed);
    }

    private void slowDown()
    {
        vSpeed -= (1 / 3);
    }

}
