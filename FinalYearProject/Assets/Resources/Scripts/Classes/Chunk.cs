using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Chunk: UnityEngine.ScriptableObject
{
    public LevelGenerator lG;
    private Vector2 cspawn;
    private GameObject[,] chunkObjectArray;
    
    public Chunk(Vector2 spawn)
    {
        
        string filePath;
        Texture2D[] allPrefabs;
        if (spawn == new Vector2(0,0))
        {
             filePath = "Spawn";
        } 
        else if (spawn == new Vector2(44, 40)) 
        {
            filePath = "Exit";
        } 
        else 
        {
            filePath = "NormalChunks";
        }
        allPrefabs = Resources.LoadAll<Texture2D>(filePath);
        Texture2D cimage = allPrefabs[Random.Range(0, allPrefabs.Length)];
        chunkObjectArray = new GameObject[11, 13];
        cspawn = spawn;

        //double for loop to go through every pixel in the specified image
        for(int y=0; y < 10; y++)
        {
            for (int x=0; x < 12; x++)
            {
                //taking the colour of the pixel at current position and then converting that position to global co-ordinates
                Color imageColour = cimage.GetPixel(x,y);
                Vector2 currentPositionGlobal = cspawn + new Vector2(x,y);
                GameObject currentPositionObject; 
             if(imageColour.a== 0)
                {
                    //If the pixel is transparent and around the edge of the level then 
                    //it is instead turned to a ground tile in order to fill out the sides.
                    // Otherwise it is left empty
                    if (y == 0 && spawn.y == 0) 
                    {
                        currentPositionObject = (GameObject)Instantiate(Resources.Load("Prefabs/Terrain/Ground"), currentPositionGlobal, Quaternion.identity);
                        chunkObjectArray[y, x] = currentPositionObject;
                    } else if (x == 0 && spawn.x == 0)
                    {
                        currentPositionObject = (GameObject)Instantiate(Resources.Load("Prefabs/Terrain/Ground"), currentPositionGlobal, Quaternion.identity);
                        chunkObjectArray[y, x] = currentPositionObject;
                    } else if (y == 9 && spawn.y == 40)
                    {
                        currentPositionObject = (GameObject)Instantiate(Resources.Load("Prefabs/Terrain/Ground"), currentPositionGlobal, Quaternion.identity);
                        chunkObjectArray[y, x] = currentPositionObject;

                    } else if (x == 11 && spawn.x == 44)
                    {
                        currentPositionObject = (GameObject)Instantiate(Resources.Load("Prefabs/Terrain/Ground"), currentPositionGlobal, Quaternion.identity);
                        chunkObjectArray[y, x] = currentPositionObject;
                    } 

                } 
             //Colour of the pixel correlates to object spawned
                else if (imageColour.Equals(Color.black))
                {
                    currentPositionObject = (GameObject)Instantiate(Resources.Load("Prefabs/Terrain/Ground"), currentPositionGlobal, Quaternion.identity);
                    chunkObjectArray[y, x] = currentPositionObject;
                }
                else if (imageColour.Equals(Color.white))
                {
                    currentPositionObject = (GameObject)Instantiate(Resources.Load("Prefabs/Objects/Door"), currentPositionGlobal, Quaternion.identity);
                    chunkObjectArray[y, x] = currentPositionObject;
                }
                else if (imageColour.Equals(Color.green))
                {

                }
                else if (imageColour.Equals(Color.red))
                {
                    currentPositionObject = (GameObject)Instantiate(Resources.Load("Prefabs/Enemies/Spawner"),currentPositionGlobal,Quaternion.identity);
                    chunkObjectArray[y, x] = currentPositionObject;
                }
                else if (imageColour.Equals(Color.blue))
                {
                    currentPositionObject = (GameObject)Instantiate(Resources.Load("Prefabs/Player"), currentPositionGlobal, Quaternion.identity);
                    chunkObjectArray[y, x] = currentPositionObject;
                }
            }
        }
    }
}
