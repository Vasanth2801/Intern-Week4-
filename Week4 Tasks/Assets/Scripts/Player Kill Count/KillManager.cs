using TMPro;
using UnityEngine;

public class KillManager : MonoBehaviour
{
    public static KillManager instance;
    [SerializeField] private int killCount = 0;
    [SerializeField] private TextMeshProUGUI killText;


    void Awake()
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
        UpdateUI();
    }

    void UpdateUI()
    {
        killText.text = "KillCount: " + killCount.ToString();
    }
}
