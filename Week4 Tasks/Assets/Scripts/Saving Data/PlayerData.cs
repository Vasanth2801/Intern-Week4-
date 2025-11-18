using UnityEngine;
using System.IO;

public class PlayerData : MonoBehaviour
{
    public EnemyKillSate enemyState = new EnemyKillSate();

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SaveToJson();
        }

        if(Input.GetKeyDown(KeyCode.L))
        {
            LoadFromJson();
        }
    }

    public void SaveToJson()
    {
        string killState = JsonUtility.ToJson(enemyState);
        string filePath = Application.persistentDataPath + "/killSate.json";
        Debug.Log(filePath);
        File.WriteAllText(filePath, killState);
        Debug.Log("Save File Created");
    }

    public void LoadFromJson()
    {
        string filePath = Application.persistentDataPath + "/killSate.json";
        string killState = File.ReadAllText(filePath);

        enemyState = JsonUtility.FromJson<EnemyKillSate>(killState);
        Debug.Log("File Loaded");
    }
}

[System.Serializable]
public class EnemyKillSate
{
    public int killCount = 0;
    public string enemyName;
}
