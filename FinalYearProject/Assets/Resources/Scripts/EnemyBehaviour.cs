using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    int direction = 1;
    float speed = 3f;
    public GameObject enemy;
    private Rigidbody2D rb2D;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = new Vector2(speed * direction, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (direction > 0)
        {
           RaycastHit2D foundHit = Physics2D.Raycast(transform.position, transform.right, 0.6f, ~(1<<8));
            if (foundHit == true)
            {
                direction *= -1;
            }
        }
        else if (direction < 0)
        {
            RaycastHit2D foundHit = Physics2D.Raycast(transform.position, -transform.right, 0.6f, ~(1 << 8));
            if (foundHit == true)
            {
                direction *= -1;
                
            }
        }
        rb2D.velocity = new Vector2(speed * direction, 0);
    
    }


}
