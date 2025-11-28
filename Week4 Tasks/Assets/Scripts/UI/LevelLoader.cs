using System.Collections;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public Animator transtions;


    private void Update()
    {
        StartCoroutine(SceneTranstions());
    }

    IEnumerator SceneTranstions()
    {
        transtions.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        GameManager.instance.PlayGame();
    }
}
