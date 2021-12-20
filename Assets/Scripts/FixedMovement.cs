using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedMovement : MonoBehaviour
{
    public bool xDir, yDir;
    public int xMove = 0, yMove = 0;
    public float speed = 0.000001f;

    void FixedUpdate()
    {
        gameObject.transform.position = new Vector2(gameObject.transform.position.x + (xMove * speed), gameObject.transform.position.y + (yMove * speed));
    }

    public void OnTriggerExit2D(Collider2D col){
        if (col.gameObject.tag == "PlayArea") gameObject.SetActive(false);
    }
}
