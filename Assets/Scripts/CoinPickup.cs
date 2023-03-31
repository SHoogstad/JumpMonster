
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        var score = PlayerMovement.Level += 1;
        Destroy(gameObject);

        if (score == 5)
        {
            SceneManager.LoadScene("StartScreen");

            return;
        }
        
        SceneManager.LoadScene("Level" + score);
    }
}
