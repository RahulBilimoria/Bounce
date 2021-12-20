using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponSystem;

public class WeaponSpawner : MonoBehaviour
{
    public GameObject weaponHolder;
    public WeaponData data;

    public void SpawnWeapon(){
        GameObject obj = GetComponent<Spawner>().Spawn();
        if (obj == null) return;
        obj.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        SetWeaponType(obj, GetWeaponType());
        obj.SetActive(true);
    }

    public void SpawnSpecial(){
        GameObject obj = GetComponent<Spawner>().Spawn();
        if (obj == null) return;
        SetSpecialType(obj, GetSpecialType());
        obj.SetActive(true);
    }
    
    public int GetWeaponType(){
        int type = Random.Range(0, data.weapons[GameManager.manager.weaponTypeIndex].spawnChanceValue);
        if (type < 50) return 0; //50%
        else if (type < 75) return 1; //25%
        else if (type < 85) return 2; //10%
        else if (type < 93) return 3; //8%
        else if (type < 98) return 4; //5%
        else if (type < 100) return 5; //2%
        return 0;
    }

    public void SetWeaponType(GameObject obj, int index){
        obj.name = data.weapons[index].weaponName;
        obj.transform.localScale = new Vector3(data.weapons[index].size, data.weapons[index].size, 1);
        obj.GetComponent<SpriteRenderer>().sprite = data.weapons[index].sprite;
        obj.GetComponent<Tap>().clip = data.weapons[index].clip;
        obj.GetComponent<Ball>().points = data.weapons[index].points;
        obj.GetComponent<Ball>().xForce = data.weapons[index].xForce;
        obj.GetComponent<Ball>().yForce = data.weapons[index].yForce;
    }

    public int GetSpecialType(){
        int i = Random.Range(0, 10);
        if (i < 9) return 0;
        else return 1;
    }

    public void SetSpecialType(GameObject obj, int index){
        obj.name = data.special[index].name;
        obj.transform.localScale = new Vector3(data.special[index].size, data.special[index].size, 1);
        obj.GetComponent<SpriteRenderer>().sprite = data.special[index].sprite;
        obj.GetComponent<Tap>().clip = data.special[index].clip;
        obj.GetComponent<Special>().points = data.special[index].points;
        obj.GetComponent<Special>().type = index;
        obj.GetComponent<Special>().weaponHolder = weaponHolder;

    }
}
