using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float jumpMomentum; // 점프 운동량에 관한 float형 필드

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)) // 윗방향키를 입력하는것으로 실행
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, jumpMomentum, 0); // 점프 운동량 필드의 값 만큼 Y축 방향으로 이동
        }
    }

    private void OnCollisionEnter(Collision collision) // 다른 오브젝트와 충돌 시 실행
    {
        SceneManager.LoadScene("GameoverScene"); // 게임오버 씬 불러오기
    }
}
