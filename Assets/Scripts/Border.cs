using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    public bool left;
    public new Camera camera;
    private BoxCollider2D myBorder;
    private int x = 1, y = 1;
    void Start()
    {
        myBorder = GetComponent<BoxCollider2D>();
        if (left) x = -1;
        transform.position = new Vector2(camera.transform.position.x + (x * ((camera.orthographicSize * camera.aspect) + (myBorder.size.x/2))), camera.transform.position.y);
    }
}
