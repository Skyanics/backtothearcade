using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class SaveDataManager : MonoBehaviour {

    public GameObject player;
    public GameObject camera;
    public GameObject butterfly;
    public PlayerStatsMono playerStats;
    public SaveData saveData = new SaveData();

    void OnEnable()
	{
            LoadData();
	}

	public void SaveData()
	{
        //Save Player Stats
			saveData.curHealth = playerStats.curHealth;
			saveData.curMana = playerStats.curMana;
            saveData.playerPos = playerStats.playerPos;
            saveData.butterflyPos = playerStats.butterflyPos;
            saveData.cameraPos = playerStats.cameraPos;
			saveData.manaAttackCharge = playerStats.manaAttackCharge;
			saveData.pickUpHealth = playerStats.pickUpHealth;
			saveData.pickUpMana = playerStats.pickUpMana;
            saveData.spawnpos = playerStats.playerPos;

			string jsonData = JsonUtility.ToJson(saveData, true);
        	File.WriteAllText(Application.persistentDataPath + "/RiyahTheGameSaveData.json", jsonData);
       		Debug.Log("Save Data file saved at:" + Application.persistentDataPath + "/RiyahTheGameSaveData.json");

	}

	public void LoadData()
	{
		saveData = JsonUtility.FromJson<SaveData>(File.ReadAllText(Application.persistentDataPath + "/RiyahTheGameSaveData.json"));
        playerStats.curHealth = saveData.curHealth;
		playerStats.curMana = saveData.curMana;
        playerStats.playerPos = saveData.playerPos;
        playerStats.cameraPos = saveData.cameraPos;
        playerStats.butterflyPos = saveData.butterflyPos;
		playerStats.manaAttackCharge = saveData.manaAttackCharge;
		playerStats.pickUpHealth = saveData.pickUpHealth;
		playerStats.pickUpMana = saveData.pickUpMana;
        player.GetComponent<Player>().spawnpos.transform.position = saveData.spawnpos;

        player.transform.position = playerStats.playerPos;
        camera.transform.position = playerStats.cameraPos;
        butterfly.transform.position = playerStats.butterflyPos;
	}
}
