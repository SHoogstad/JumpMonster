using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class startButton : MonoBehaviour
{
    public Button yourButton;

    private void Start () {
        PlayerMovement.Level = 1;
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(LoadLevel);
    }

    private void Update(){
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private static void LoadLevel()
    {
        SceneManager.LoadScene("Level1");
    }
}
