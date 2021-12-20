using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tap : MonoBehaviour
{
    public AudioClip clip;

    public void Tapped(Vector2 forceApplied){
        GameManager.manager.PlaySoundEffect(clip);
        switch(tag){
            case "Weapon": 
                GetComponent<Ball>().ApplyForce(forceApplied);
                break;
            case "Special":
                GetComponent<Special>().ApplySpecial();
                break;
            case "PowerUp":
                break;
        }
    }

    public int GetPoints(){
        switch(tag){
            case "Weapon": return GetComponent<Ball>().GetPoints();
            case "Special": return GetComponent<Special>().GetPoints();
            case "PowerUp": return 0;
        }
        return 0;
    }
}
