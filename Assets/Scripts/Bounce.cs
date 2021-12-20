using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    private Vector2 v;
    public Vector2 direction;
    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "Weapon") v = col.GetComponent<Rigidbody2D>().velocity;
    }
    void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.tag == "Weapon") col.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(v.x * direction.x, v.y * direction.y);
    }
}
