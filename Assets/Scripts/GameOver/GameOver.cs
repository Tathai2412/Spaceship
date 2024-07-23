using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;

    // Update is called once per frame
    void Update()
    {
        CheckGameOver();
    }

    void CheckGameOver()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
            Destroy(GameObject.FindGameObjectWithTag("Laser"));
            gameOverPanel.SetActive(true);
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
