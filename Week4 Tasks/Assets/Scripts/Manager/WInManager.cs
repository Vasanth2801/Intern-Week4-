using System.Collections;
using UnityEngine;

public class WInManager : MonoBehaviour
{
    [SerializeField] GameObject winUI;
    [SerializeField] float time = 2f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(WinGame());
        }
    }

    IEnumerator WinGame()
    {
        winUI.SetActive(true);
        Time.timeScale = 0f; 
        yield return new WaitForSecondsRealtime(time);
    }
}
