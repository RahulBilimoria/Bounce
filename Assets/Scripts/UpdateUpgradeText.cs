using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UpgradeSystem;
using WeaponSystem;
using UnityEngine.SceneManagement;
public class UpdateUpgradeText : MonoBehaviour
{
    public int points;
    public UpgradeData data;
    public WeaponData weaponData;
    public Text pointsText;
    public Text[] upgradeTitles = new Text[4];
    public Text[] upgradeInfo = new Text[4];
    public Button[] upgradeButton = new Button[4];
    // Start is called before the first frame update
    void Start()
    {
        data.UpdateIndex();
        LoadAllValues();
    }

    private void LoadAllValues(){
        points = GameManager.manager.points;
        pointsText.text = "Points: " + points;
        for (int x = 0; x < upgradeTitles.Length; x++){
            int i = data.upgradeItems[x].currentIndex;
            string infoText;
            upgradeTitles[x].text = data.upgradeItems[x].upgradeName;
            if (i < data.upgradeItems[x].UpgradeLevels.Length-1){
                if (data.upgradeItems[x].unlocked){
                    infoText = GetIncreaseText(x, "Current", data.upgradeItems[x].UpgradeLevels[i].value)
                         + "\n" + GetIncreaseText(x, "Next", data.upgradeItems[x].UpgradeLevels[i+1].value)
                         + "\n   Cost: " + data.upgradeItems[x].UpgradeLevels[i+1].buyCost
                         + " pts";
                }
                else {
                    infoText = "   LOCKED"
                             + "\n   Unlock for " + data.upgradeItems[x].unlockCost + " pts";
                }
            }
            else {
                infoText = GetIncreaseText(x, "Current", data.upgradeItems[x].UpgradeLevels[i].value)
                         + "\n   MAXED";
            }
            upgradeInfo[x].text = infoText;
            if (i == data.upgradeItems[x].UpgradeLevels.Length-1){
                upgradeButton[x].interactable = false;
            }
        }
    }

    public void BuyItem(int upgradeType){
        int upgradeLevelIndex = data.upgradeItems[upgradeType].currentIndex;
        int cost;
        if (data.upgradeItems[upgradeType].unlocked) cost = data.upgradeItems[upgradeType].UpgradeLevels[upgradeLevelIndex+1].buyCost;
        else                                         cost = data.upgradeItems[upgradeType].unlockCost;
        if (points >= cost){
            points -= cost;
            if (data.upgradeItems[upgradeType].unlocked){
                data.upgradeItems[upgradeType].currentIndex++;
                GameManager.manager.IncreaseUpgradeIndex(upgradeType);
                UpdateLabel(upgradeType, ++upgradeLevelIndex, CheckMaxedUpgrade(upgradeType, upgradeLevelIndex));
            } else {
                data.upgradeItems[upgradeType].unlocked = true;
                GameManager.manager.UnlockUpgrade(upgradeType);
                UpdateLabel(upgradeType, upgradeLevelIndex, CheckMaxedUpgrade(upgradeType, upgradeLevelIndex));
            }
        }
        
    }

    private bool CheckMaxedUpgrade(int index, int upgradeLevelIndex){
        if (upgradeLevelIndex == data.upgradeItems[index].UpgradeLevels.Length-1){
            upgradeButton[index].interactable = false;
            return true;
        }
        return false;
    }

    private void UpdateLabel(int index, int uli, bool maxed){
        pointsText.text = "Points: " + points;
        if (!maxed) {
            upgradeInfo[index].text = GetIncreaseText(index, "Current", data.upgradeItems[index].UpgradeLevels[uli].value)
                         + "\n" + GetIncreaseText(index, "Next", data.upgradeItems[index].UpgradeLevels[uli+1].value)
                         + "\n   Cost: " + data.upgradeItems[index].UpgradeLevels[uli+1].buyCost
                         + " pts";
        } else {
            upgradeInfo[index].text = GetIncreaseText(index, "Current", data.upgradeItems[index].UpgradeLevels[uli].value)
                         + "\n   MAXED";
        }
    }

    private string GetIncreaseText(int index, string t, int value){
        string text = "   " + t;
        switch(index){
            case 0: return text + " Maximum: " + value;
            case 1: return text + " Multiplier: " + value + "x";
            case 2: return text + " Maximum Combo: " + value + "x";
            case 3: return text + " Increase: " + value + "%";
            case 4: return text + " Weapon: " + weaponData.weapons[value].weaponName;
            case 5: return text + " Spawn Interval: " + value + "s";
            default: return"";
        }
    }

    private void SaveIndexValues(){
        GameManager.manager.LoadValues(
            points,
            data.upgradeItems[0].currentIndex,
            data.upgradeItems[1].currentIndex,             
            data.upgradeItems[2].unlocked,
            data.upgradeItems[2].currentIndex,             
            data.upgradeItems[3].unlocked,
            data.upgradeItems[3].currentIndex,
            data.upgradeItems[4].currentIndex,
            data.upgradeItems[5].currentIndex
        );
        GameManager.manager.Save();
    }

    public void Back(){
        SaveIndexValues();
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
