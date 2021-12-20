using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTime : MonoBehaviour
{
    // Start is called before the first frame update
    private Text text;
    private int m;
    private int s;
    void Start()
    {
        m = 0;
        s = 0;
        text = GetComponent<Text>();
    }

    public void updateTime(int t){
        if (updateSeconds(t)){
            updateMinutes(1);
        }

        updateText();
    }

    private bool updateSeconds(int x){
        s+=x;
        if (s > 59){
            s-=60;
            return true;
        }
        return false;
    }

    private void updateMinutes(int x){
        m += x;
    }

    private void updateText(){
        string seconds, minutes;
        if (s < 10) seconds = "0" + s;
        else seconds = s+"";
        if (m < 10) minutes = "0" + m;
        else minutes = m + "";

        text.text = "Time: " + minutes + ":" + seconds;
    }
    
}
