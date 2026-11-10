
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    private bool victory = false;

    void Update()
    {
        if (!victory && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            victory = true;

            Debug.Log("VICTORY! All enemies have been eliminated.");

            StartCoroutine(RestartGame());
        }
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
