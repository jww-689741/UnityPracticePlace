using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float jumpMomentum; // 점프 운동량에 관한 float형 필드
    public int deathCount = 3; // 목숨
    private int score = 0; // 스코어

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)) // 윗방향키를 입력하는것으로 실행
        {
            GetComponent<AudioSource>().Play(); // 효과음 출력
            GetComponent<Rigidbody>().velocity = new Vector3(0, jumpMomentum, 0); // 점프 운동량 필드의 값 만큼 Y축 방향으로 이동
        }
    }

    private void OnCollisionEnter(Collision collision) // 다른 오브젝트와 충돌 시 실행
    {
        if (collision.gameObject.tag == "Horizon") // 위 아래 경계면과 충돌했을 경우 실행
        {
            Gameover.totalScore = score; // 총 스코어 연산
            SceneManager.LoadScene("GameoverScene"); // 게임오버 씬 불러오기
        }
        else if(collision.gameObject.transform.parent.parent.gameObject.tag == "Wall") // 벽과 충돌했을 경우 실행
        {
            Destroy(GameObject.Find("Heart" + deathCount)); // 목숨 UI 하나 제거
            deathCount--; // 목숨 -1
            Destroy(collision.gameObject.transform.parent.parent.gameObject); // 충돌 오브젝트 삭제 ( 콜라이더가 적용된 오브젝트의 부모의 부모 오브젝트를 삭제해야 정상작동 )
        }
        if(deathCount == 0) // 목숨을 모두 소진했을 경우 실행
        {
            Gameover.totalScore = score; // 총 스코어 연산
            SceneManager.LoadScene("GameoverScene"); // 게임오버 씬 불러오기
        }
    }

    private void OnTriggerEnter(Collider other) // 트리거 발생 시 실행
    {
        score++; // 스코어 증가
        GameObject.Find("Score").GetComponent<Text>().text = "Score : " + score; // 스코어 값 출력
    }
}
