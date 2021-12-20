using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose : MonoBehaviour
{
    public GameObject weaponsList;
    public GameLoop gameLoop;
    void OnTriggerEnter2D(Collider2D col){
        col.gameObject.SetActive(false);
        if (col.gameObject.tag == "Weapon"){
            gameLoop.score.ResetTapCombo();
            foreach (Transform child in weaponsList.GetComponentInChildren<Transform>()){
                if(child.gameObject.activeSelf) return;
            }
            gameLoop.EndGame();
        }
    }
}
