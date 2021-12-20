using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpawner : MonoBehaviour
{
    public float speed;

    public void SpawnBackgroundObject(){
        GameObject obj = GetComponent<Spawner>().Spawn();
        if (obj == null) return;

        SetObjectDirection(obj.transform.position, obj.GetComponent<FixedMovement>());
        
        obj.SetActive(true);
    }

    private void SetObjectDirection(Vector2 pos, FixedMovement fm){
        if (fm == null) return;
        if (fm.xDir) fm.xMove = pos.x > 0 ? -1 : 1;
        if (fm.yDir) fm.yMove = pos.y > 0 ? -1 : 1;
        fm.speed = Random.Range(speed/2, speed*2);
    }
}
