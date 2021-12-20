using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special : MonoBehaviour
{
    public GameObject weaponHolder;
    public int type;
    public int points;

    public void ApplySpecial(){
        switch(type){
            case 0: 
                foreach (Ball weapon in weaponHolder.GetComponentsInChildren<Ball>()){
                    weapon.ApplySpecialForce();
                }
                break;
        }
        gameObject.SetActive(false);
    }

    public int GetPoints(){
        return points;
    }
}
