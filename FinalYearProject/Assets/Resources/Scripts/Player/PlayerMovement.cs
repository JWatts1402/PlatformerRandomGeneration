using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    int speed = 12;
    public bool canJump;
    int dashInterval = 3;
    float nextDash;
    float dashTime = 1.0f;
    float dashTick = 0.01f;
    float currentTimer = 0.0f;
    int direction;
    string collisionTag;

    // Start is called before the first frame update
    void Start()
    {
        canJump = true;
        nextDash = Time.time;
        CameraMovement cmovement = FindObjectOfType<CameraMovement>();
        cmovement.player = this.gameObject;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump == true)
        {
            canJump = false;
            rb.AddForce(new Vector2(0, 925));
        }
        if (Input.GetKey(KeyCode.LeftShift) && Time.time > nextDash)
        {
            nextDash = Time.time + dashInterval;
            currentTimer = 0.0f;
            while (currentTimer < dashTime)
            {
                rb.AddForce(new Vector2(180 * direction, 0));
                currentTimer += dashTick;
                canJump = true;
            }
        }
    }

    //Called at fixed intervals many times a second 
    void FixedUpdate()
    {
        if (Input.GetKey("e") &&  collisionTag == "Wall")
        {
            rb.velocity = new Vector2(0, 0);
        }
        if (Input.GetKey("a"))
        {
            direction = -1;
            if (rb.velocity.x > 0)
            {
                rb.velocity = new Vector2(5 * direction, rb.velocity.y);
            }
            if (rb.velocity.x + (speed*direction) >= -12)
            {
                rb.AddForce(new Vector2(speed*direction, 0));
            }
            else
            {
                rb.velocity = new Vector2(12 * direction, rb.velocity.y);
            }
        }
        
        if (Input.GetKey("d"))
        {
            direction = 1;
            if (rb.velocity.x < 0)
            {
                rb.velocity = new Vector2(5 * direction, rb.velocity.y);
            }
            if (rb.velocity.x + (speed*direction) <= 12)
            {
                rb.AddForce(new Vector2(speed*direction, 0));
            }
            else
            {
                rb.velocity = new Vector2(12 * direction, rb.velocity.y);
            }

        }
        
        if (!Input.GetKey("d") && !Input.GetKey("a"))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

   
    }

    //Called when the Object with this script collides with othe robjects
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Stores the tag of the object we collide with, meaning 
        collisionTag = collision.gameObject.tag;
       
        if(collisionTag == "Ground")
        {
            canJump = true;
        }
    }

    //Activates if the object has contact with a collider marked as a trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.CompareTag("Enemy"))
        {
            rb.AddForce(new Vector2(0, 2000));
        }
       else if (collision.gameObject.CompareTag("Money"))
        {

        }
    }

    //Gets called when object script is attached to leaves a collision
    private void OnCollisionExit(Collision collision)
    {
        collisionTag = "";
    }




}
  
