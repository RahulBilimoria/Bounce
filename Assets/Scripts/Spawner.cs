using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public ObjectPooler pooler;
    public GameObject[] spawnAreas;
    protected Vector3 spawnPos, spawnScale;

    public GameObject Spawn(){
        GameObject obj = pooler.getPooledObject();
        if (obj == null) return obj;

        SetSpawnArea();
        obj.transform.position = new Vector2(Random.Range(spawnPos.x - (spawnScale.x/2), spawnPos.x + (spawnScale.x/2)), Random.Range(spawnPos.y + (spawnScale.y/2), spawnPos.y - (spawnScale.y/2)));
        return obj;
    }

    public void SetSpawnArea(){
        int sa = Random.Range(0, spawnAreas.Length);
        spawnPos = spawnAreas[sa].transform.position;
        spawnScale = spawnAreas[sa].GetComponent<BoxCollider2D>().size;
    }
}
