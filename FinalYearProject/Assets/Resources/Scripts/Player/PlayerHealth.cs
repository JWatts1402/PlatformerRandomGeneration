using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    int playerHealth = 10;
    bool IFramesActive = false;
    float IFramesTimer = 0;
    float IFramesStart;
    public Text health_UI;
    public GameObject player;
    public string collisionTag;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        health_UI.text = playerHealth.ToString();
        
        if (IFramesActive == true)
        {
            IFramesTimer = Time.time;
            if(IFramesTimer > IFramesStart + 1.5)
            {
                IFramesActive = false;
            }
        }
        if(playerHealth < 1)
        {
            Destroy(player, 0.5f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collisionTag = collision.gameObject.tag;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collisionTag = "";
    }
    void OnCollisionStay2D(Collision2D collider)
    {
        if((collisionTag == "Enemy") && IFramesActive == false)
        {
            print(playerHealth);
            playerHealth = playerHealth - 1;
            IFramesActive = true;
            IFramesStart = Time.time;
        }
    }

    //working right now, everything above is seemingly borked
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<PrefabHolder>().myParent.commitdeath();
        }
    }
}
