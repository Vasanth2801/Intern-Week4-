using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameObject noLoadData;

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

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadGame()
    {
        noLoadData.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Application Quit.....");
    }
}