using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gameover : MonoBehaviour
{
    public static int totalScore; // 총 스코어

    private void Start()
    {
        GameObject.Find("TotalScore").GetComponent<Text>().text = "Total Score : " + totalScore; // 총 스코어 출력
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space)) // 스페이스바 키 입력 시 실행
        {
            SceneManager.LoadScene("TitleScene"); // 타이틀 씬으로 이동
        }
    }
}
