using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gameover : MonoBehaviour
{
    public static int totalScore; // �� ���ھ�

    private void Start()
    {
        GameObject.Find("TotalScore").GetComponent<Text>().text = "Total Score : " + totalScore; // �� ���ھ� ���
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space)) // �����̽��� Ű �Է� �� ����
        {
            SceneManager.LoadScene("TitleScene"); // Ÿ��Ʋ ������ �̵�
        }
    }
}
