using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{

    [SerializeField] float LevelLoadDelay = 2f;
    [SerializeField] float LevelExitSLowMoFactor = 0.2f;

    void OnTriggerEnter2D(Collider2D other)
    {
        //start coroutine
        StartCoroutine(LoadNextLevel());
    }

    IEnumerator LoadNextLevel()
    {
        //how fast the entire game can run
        Time.timeScale = LevelExitSLowMoFactor;

        //yield with a delay
        yield return new WaitForSecondsRealtime(LevelLoadDelay);

        //return entire game to normal running time
        Time.timeScale = 1f;

        //load the next scene
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

}
