using UnityEngine;

public class PlayerSwitch : MonoBehaviour
{
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;

    private void Start()
    {
        player1.SetActive(true);
        player2.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            bool isPlayer1Active = player1.activeSelf;
            player1.SetActive(!isPlayer1Active);
            player2.SetActive(isPlayer1Active);
        }
    }
}
