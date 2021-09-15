using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : UnityEngine.ScriptableObject
{
    public GameObject myParent;
    public GameObject myPrefab;
    public GameObject myGameObject;
    public int health;
    public int damage;
    public int movespeed;

    public Enemy()
    {

    }

    public Enemy(int hp, int d, int ms)
    {
        health = hp;
        damage = d;
        movespeed = ms;

    }

    public virtual void Start()
    {

    }

    public virtual void Update()
    {
        if (health < 1)
        {
            commitdeath();
        }

    }

    public void commitdeath()
    {
        Destroy(myGameObject);
        myParent.GetComponent<Spawner>().listRemoval(this);
    }

    public void InstantiateMe(string location, Vector2 spawn)
    {
        myPrefab = (GameObject)Resources.Load(location);
        myGameObject = Instantiate(myPrefab, spawn, Quaternion.identity);
        PrefabHolder prefabHolder = myGameObject.AddComponent<PrefabHolder>() as PrefabHolder;
        prefabHolder.myParent = this;
    }

        
}
