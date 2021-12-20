using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponSystem;

public class ObjectPooler : MonoBehaviour{
    private List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int size;
    public bool canGrow;
    void Start()
    {
        pooledObjects = new List<GameObject>();
        for (int x = 0; x < size; x++){
            GameObject obj = (GameObject)Instantiate(objectToPool);
            obj.transform.parent = transform;
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }
    
    public GameObject getPooledObject(){
        for (int i = 0; i < pooledObjects.Count; i++){
            if (!pooledObjects[i].activeInHierarchy){
                return pooledObjects[i];
            }
        }
        return null;
    }
}
