using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rise : MonoBehaviour
{
    private Coroutine fadeRoutine;
    public float increaseValue = 1.0f;
    public float riseDuration = 1.0f;

    void Start(){
        fadeRoutine = StartCoroutine("Fade");
    }
    void FixedUpdate()
    {
        gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + increaseValue);
    }

    public void SetPosition(float x, float y){
        transform.position = new Vector2(x + (GetComponent<RectTransform>().rect.width/2), y);
    }

    public void StartFadeRoutine(){
        gameObject.SetActive(true);
        StopCoroutine(fadeRoutine);
        fadeRoutine = StartCoroutine("Fade");
    }
    IEnumerator Fade(){
        Text text = GetComponent<Text>();
        text.color = new Color(text.color.r, text.color.g, text.color.r, 1);
        float duration = 1.0f;
        float currentTime = 0f;
        while (currentTime < duration){
            float alpha = Mathf.Lerp(1f, 0f, currentTime/duration);
            text.color = new Color(text.color.r, text.color.g, text.color.r, alpha);
            currentTime += Time.deltaTime;
            yield return null;
        }
        gameObject.SetActive(false);
        yield break;
    }
}