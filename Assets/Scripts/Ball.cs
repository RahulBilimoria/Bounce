using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponSystem;

public class Ball : MonoBehaviour
{
    public int points;
    public float xForce, yForce;
    private Vector3 pos, scale;

    public void ApplyForce(Vector2 forceApplied){
        Vector3 cur = GetComponent<Rigidbody2D>().velocity;
        if (cur.x < 0) cur.x = 0;
        if (cur.y < 0) cur.y = 0;
        GetComponent<Rigidbody2D>().velocity = new Vector2(cur.x + (forceApplied.x * xForce * (1 + GameManager.manager.tapStrengthIncrease)), cur.y + (yForce * (1 + GameManager.manager.tapStrengthIncrease)));
        GetComponent<Rigidbody2D>().AddTorque(-forceApplied.x, ForceMode2D.Impulse);
    }

    public void ApplySpecialForce(){
        ApplyForce(new Vector2(0, transform.localScale.y));
    }

    public int GetPoints(){
        return points;
    }
}
