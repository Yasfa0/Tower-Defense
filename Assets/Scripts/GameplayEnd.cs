using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayEnd : MonoBehaviour
{
    float timer = 0;

    private void Update()
    {
        if (Data.isGameOver)
        {
            timer += Time.deltaTime;
            if(timer > 2)
            {
                SceneManager.LoadScene("Gameover");
            }

            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }
}
