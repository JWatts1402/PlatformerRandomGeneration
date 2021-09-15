using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LevelGenerator : MonoBehaviour
{
    public bool exitSpawned = false;
    // Start is called before the first frame update
    void Start()
    {
        Chunk chunk1 = new Chunk(new Vector2(0, 0));
        Chunk chunk2 = new Chunk(new Vector2(11, 0));
        Chunk chunk3 = new Chunk(new Vector2(22, 0));
        Chunk chunk4 = new Chunk(new Vector2(33, 0));
        Chunk chunk5 = new Chunk(new Vector2(44, 0));
        Chunk chunk6 = new Chunk(new Vector2(0, 10));
        Chunk chunk7 = new Chunk(new Vector2(11, 10));
        Chunk chunk8 = new Chunk(new Vector2(22, 10));
        Chunk chunk9 = new Chunk(new Vector2(33, 10));
        Chunk chunk10 = new Chunk(new Vector2(44, 10));
        Chunk chunk11 = new Chunk(new Vector2(0, 20));
        Chunk chunk12 = new Chunk(new Vector2(11, 20));
        Chunk chunk13 = new Chunk(new Vector2(22, 20));
        Chunk chunk14 = new Chunk(new Vector2(33, 20));
        Chunk chunk15 = new Chunk(new Vector2(44, 20));
        Chunk chunk16 = new Chunk(new Vector2(0, 30));
        Chunk chunk17 = new Chunk(new Vector2(11, 30));
        Chunk chunk18 = new Chunk(new Vector2(22, 30));
        Chunk chunk19 = new Chunk(new Vector2(33, 30));
        Chunk chunk20 = new Chunk(new Vector2(44, 30));
        Chunk chunk21 = new Chunk(new Vector2(0, 40));
        Chunk chunk22 = new Chunk(new Vector2(11, 40));
        Chunk chunk23 = new Chunk(new Vector2(22, 40));
        Chunk chunk24 = new Chunk(new Vector2(33, 40));
        Chunk chunk25 = new Chunk(new Vector2(44, 40));
    }
}

