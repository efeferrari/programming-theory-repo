using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TitleManager : MonoBehaviour
{
    TMP_InputField playerInput;
    GameManager GM;

    private void Start()
    {
        playerInput = GameObject.Find("Input").GetComponent<TMP_InputField>();
        GM = GameManager.Instance;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            if (playerInput.text.Length > 0)
            {
                // Set current user name
                GM.CurrentPlayer = playerInput.text;

                // Go to Main Scene and start the game
                SceneManager.LoadScene(1);
            }
            else
            {
                Debug.Log("Empty name?");
            }
        }
    }
}
