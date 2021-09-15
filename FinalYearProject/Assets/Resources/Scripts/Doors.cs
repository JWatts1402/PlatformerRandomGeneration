using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Doors : MonoBehaviour
{
    int levelNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            levelNumber += 1;
            if (levelNumber > 4)
            {
                SceneManager.LoadScene("Boss");
            } else
            {
                SceneManager.LoadScene("Game");
            }
            
            
        }
    }
}
