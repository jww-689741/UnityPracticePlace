using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleCotrol : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            SceneManager.LoadScene("GameScene");
        }
    }

    public void GameStart()
    {
        SceneManager.LoadScene("GameScene");
    }
}
