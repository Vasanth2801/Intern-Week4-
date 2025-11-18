using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] private TextMeshProUGUI killText;
    [SerializeField] private int killCount;
    public EnemyKillState enemyState = new EnemyKillState();

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        killCount = 0;
        killText.text = "KillCount: " + killCount;
    }

    public void AddKill()
    {
        killCount++;
        DataManager.instance.enemyState.killCount += 1;
        UpdateUI();
    }

    void UpdateUI()
    {
        killText.text = "KillCount: " + killCount.ToString();
    }

    public void SaveData()
    {
        DataManager.instance.SaveFromJson();
    }

    public void LoadData()
    {
        DataManager.instance.LoadFromJson();
        killText.text = "KillCount: " + DataManager.instance.enemyState.killCount;
    }

    public void DeleteData()
    {
        DataManager.instance.DeleteFromJson();
    }
}
