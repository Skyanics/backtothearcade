using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveDataPoint : MonoBehaviour {

    public SaveDataManager dataManager;
    public GameObject player;
    public PlayerStatsMono playerStats;
    public bool isNear;
    public Text saveText;
    public GameObject sphere;
    public Light light;

    void Update()
    {
        if (isNear == true && Input.GetKeyDown(KeyCode.Q))
        {
            dataManager.SaveData();
            light.color = Color.white;
            Renderer rend = sphere.GetComponent<Renderer>();
            rend.material.shader = Shader.Find("Shallow");
            rend.material.SetColor("_Shallow", Color.white);
            player.GetComponent<Player>().spawnpos.transform.position = player.transform.position;
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isNear = true;
            saveText.text = "Press Q to save the game";
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isNear = false;
            saveText.text = " ";
        }
    }

    
}
