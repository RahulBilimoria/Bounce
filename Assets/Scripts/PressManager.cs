using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressManager : MonoBehaviour
{

    public GameScore score;
    public Rise comboText;

    void Update()
    {
        if (!GameLoop.paused){
            if (Input.GetMouseButtonDown(0)){
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

                RaycastHit2D ray = Physics2D.Raycast(mousePos2D, Vector2.zero);

                if (ray.collider != null && ray.collider.gameObject.GetComponent<Tap>() != null){
                    Vector2 objPos2D = ray.collider.attachedRigidbody.GetRelativePoint(Vector2.zero);
                    ray.collider.attachedRigidbody.gameObject.GetComponent<Tap>().Tapped(objPos2D - mousePos2D);

                    comboText.SetPosition(Input.mousePosition.x, Input.mousePosition.y);
                    comboText.StartFadeRoutine();

                    score.UpdateScore(ray.collider.attachedRigidbody.gameObject.GetComponent<Tap>().GetPoints());
                    score.AddTapCombo();
                }
                else score.ResetTapCombo();
            }
        }
    }
}
