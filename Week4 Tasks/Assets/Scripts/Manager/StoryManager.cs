using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class StoryManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI storyText1;
    [SerializeField] private float typingSpeed = 0.05f;

    void Start()
    {
        StartCoroutine(TypeStory(storyText1.text));
    }

    IEnumerator TypeStory(string sentence)
    {
        storyText1.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            storyText1.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void Skip()
    {
        SceneManager.LoadScene(2);
    }

    public void StartButton()
    {
        SceneManager.LoadScene(2);
    }
}