using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UpgradeSystem;
public class GameManager : MonoBehaviour
{
    public static GameManager manager;
    public AudioSource music, sfx;
    public UpgradeData udata;
    private string path;
    
    //settings values
    public float musicVolume;
    public float sfxVolume;

    //upgrade values
    public int points;
    public int ballIndex;
    public int pointsMultiIndex;
    public bool comboUnlocked;
    public int comboIndex;
    public bool tapStrengthUnlocked;
    public int tapStrengthIndex;
    public int weaponTypeIndex;
    public int weaponSpawnIndex;
    //upgrade limit

    public int maxBallAmount = 1;
    public int pointsMultiplier = 1;
    public int comboMultiplier = 0;
    public float tapStrengthIncrease = 0;
    public int weaponSpawnInterval = 10;
    void Awake()
    {
        if (manager == null){
            path = Application.persistentDataPath + "/playerSave.dat";
            DontDestroyOnLoad(gameObject);
            manager = this;
            music = GetComponents<AudioSource>()[0];
            sfx = GetComponents<AudioSource>()[1];
            Load();
            GetUpgradeValues();
        }
        else if (manager != this){
            Destroy(gameObject);
        }
    }

    public void Save(){
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file;

        if (File.Exists(path))  file = File.OpenWrite(path);
        else                    file = File.Create(path);

        PlayerData data = GetPlayerData();
        bf.Serialize(file, data);
        file.Close();
    }

    public void Load(){
        if (File.Exists(path)){
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(path, FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            LoadValues(
                data.points,
                data.ballIndex,
                data.pointsMultiIndex,
                data.comboUnlocked,
                data.comboIndex,
                data.tapStrengthUnlocked,
                data.tapStrengthIndex,
                data.weaponTypeIndex,
                data.weaponSpawnIndex
            );
            GetUpgradeValues();
        }
        else {
            LoadValues();
        }
    }

    public void LoadValues(int p = 0, int bi = 0, int pmi = 0, bool cu = false, int ci = 0, bool tsu = false, int tsi = 0, int wti = 0, int wsi = 0){
        points = p;
        ballIndex = bi;
        pointsMultiIndex = pmi;
        comboUnlocked = cu;
        comboIndex = ci;
        tapStrengthUnlocked = tsu;
        tapStrengthIndex = tsi;
        weaponTypeIndex = wti;
        weaponSpawnIndex = wsi;
    }

    public void IncreaseUpgradeIndex(int index){
        switch(index){
            case 0: ballIndex++;
                break;
            case 1: pointsMultiIndex++;
                break;
            case 2: comboIndex++;
                break;
            case 3: tapStrengthIndex++;
                break;
            case 4: weaponTypeIndex++;
                break;
            case 5: weaponSpawnIndex++;
                break;
            default: break;
        }
    }

    public void UnlockUpgrade(int index){
        switch(index){
            case 2: comboUnlocked = true;
                return;
            case 3: tapStrengthUnlocked = true;
                return;
            default: return;
        }
    }
    

    public void GetUpgradeValues(){
        maxBallAmount = udata.upgradeItems[0].UpgradeLevels[ballIndex].value;
        pointsMultiplier = udata.upgradeItems[1].UpgradeLevels[pointsMultiIndex].value;
        if (comboUnlocked) comboMultiplier = udata.upgradeItems[2].UpgradeLevels[comboIndex].value;
        if (tapStrengthUnlocked) tapStrengthIncrease = udata.upgradeItems[3].UpgradeLevels[tapStrengthIndex].value/100;
        weaponSpawnInterval = udata.upgradeItems[5].UpgradeLevels[weaponSpawnIndex].value;
    }
    public void PlaySoundEffect(AudioClip ac){
        StartCoroutine("ChangeClip", ac);
    }

    public void PlayMusic(){
        GameManager.manager.music.Play();
    }

    IEnumerator ChangeClip(AudioClip ac){
        GameManager.manager.sfx.clip = ac;
        GameManager.manager.sfx.Play();
        yield return null;
    }

    private PlayerData GetPlayerData(){
        PlayerData pd = new PlayerData();
        pd.points = points;
        pd.ballIndex = ballIndex;
        pd.pointsMultiIndex = pointsMultiIndex;
        pd.comboUnlocked = comboUnlocked;
        pd.comboIndex = comboIndex;
        pd.tapStrengthUnlocked = tapStrengthUnlocked;
        pd.tapStrengthIndex = tapStrengthIndex;
        pd.weaponTypeIndex = weaponTypeIndex;
        pd.weaponSpawnIndex = weaponSpawnIndex;
        return pd;
    }
}

[Serializable]
class PlayerData {
    public int points;
    public int ballIndex;
    public int pointsMultiIndex;
    public bool comboUnlocked;
    public int comboIndex;
    public bool tapStrengthUnlocked;
    public int tapStrengthIndex;
    public int weaponTypeIndex;
    public int weaponSpawnIndex;
}