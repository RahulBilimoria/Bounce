using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void MusicVolumeChange(System.Single f){
        GameManager.manager.music.volume = f;
    }
    public void SoundEffectVolumeChange(System.Single f){
        GameManager.manager.sfx.volume = f;
    }
    public void PlaySoundEffect(AudioClip ac){
        GameManager.manager.PlaySoundEffect(ac);
    }

    public void PlayMusic(){
        GameManager.manager.PlayMusic();
    }

    IEnumerator ChangeClip(AudioClip ac){
        GameManager.manager.sfx.clip = ac;
        GameManager.manager.sfx.Play();
        yield return null;
    }
}
