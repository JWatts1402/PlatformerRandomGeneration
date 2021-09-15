using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake: Enemy
{
    int direction = -1;
    public Rigidbody2D rb2D;
    Vector2 snakeSpawn;

    public Snake(Vector2 spawn)
        :base(1, 1, 4)
    {
        snakeSpawn = spawn;
    }

    public Snake(int hp, int d, int ms, Vector2 spawn)
        : base(hp, d, ms)
    {
        snakeSpawn = spawn;
    }
    
    // This is called after the spawner has set up the game object
    public override void Start()
    {
        InstantiateMe("Prefabs/Enemies/Snake", snakeSpawn);
        rb2D = myGameObject.GetComponent<Rigidbody2D>();
    }

    // The spawner calls this every frame
   public override void Update()
    {
      

        if (direction > 0)
        {
            RaycastHit2D foundHit = Physics2D.Raycast(myGameObject.transform.position, myGameObject.transform.right, 0.48f, ~(1 << 8));
            if (foundHit == true)
            {
                direction *= -1;
            }
        }
        else if (direction < 0)
        {
            RaycastHit2D foundHit = Physics2D.Raycast(myGameObject.transform.position, -myGameObject.transform.right, 0.48f, ~(1 << 8));
            if (foundHit == true)
            {
                direction *= -1;
            }
        }
        rb2D.velocity = new Vector2(movespeed * direction, rb2D.velocity.y);
        
    }
}
