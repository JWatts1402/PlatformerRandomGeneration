using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using Random = System.Random;

public class Spawner : MonoBehaviour
{
    Vector2 SpawnPos;
    List<System.Type> enemySubTypes;
    public Enemy spawnedEnemy;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPos = new Vector2(transform.position.x, transform.position.y);
        var baseType = typeof(Enemy);
        var assembly = typeof(Enemy).Assembly;
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(baseType));
        enemySubTypes = types.ToList();
        int i = RNGSeed.SeedGenerator.Next(0, (enemySubTypes.Count()));
       
        //Object[] parameters = { new Vector2(0, 0), "hi" }; <- syntax for if we ever need multiple parameters
        spawnedEnemy = (Enemy)Activator.CreateInstance(enemySubTypes[i], SpawnPos);
        spawnedEnemy.myParent = this.gameObject;
        spawnedEnemy.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnedEnemy != null)
        {
        spawnedEnemy.Update();
        }
    }

    public void listRemoval(Enemy enemy)
    {
        spawnedEnemy = null;
    }
}
