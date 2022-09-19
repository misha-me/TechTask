using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public List<GameObject> objectsToSpawn;
    public GameManager gameManager;
    public List<Vector3> rows;

    public void Spawn(int objectIndex, int count, int materialIndex, Vector3 spawnPosition)
    {
        GameObject objectToSpawn = objectsToSpawn[objectIndex];

        if (objectIndex == 0)
            objectToSpawn.GetComponent<MoveToCamera>().materialIndex = materialIndex;
        else
            objectToSpawn.GetComponent<ColorChange>().materialIndex = materialIndex;

        objectsToSpawn[objectIndex].GetComponent<Renderer>().material = gameManager.materials[materialIndex];
        
        for (int i=0; i < count; i++)
        {
            Vector3 offset = new Vector3(0, .5f, i * 5);
            Instantiate(objectsToSpawn[objectIndex], transform.position + spawnPosition + offset, transform.rotation);
        }
        
    }
}
