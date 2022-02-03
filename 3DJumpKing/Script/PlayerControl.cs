using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    public float speed = 1.0f; // 이동속도 계수
    private float Momentom = 0; // 운동량
    private Rigidbody playerRigidbody; // 플레이어 물리

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>(); // 플레이어 물리 컴포넌트 불러오기
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) // 운동량 차징
        {
            if(this.Momentom < 500.0f) // 운동량 최대치 제한
            {
                this.Momentom += 0.5f; // 운동량 크기 증가
            }
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow)) // 좌측이동
        {
            playerRigidbody.AddForce(-(this.Momentom * speed), 0, 0);
            this.Momentom = 0; // 운동량 초기화
        }
        else if (Input.GetKey(KeyCode.RightArrow)) // 운동량 차징
        {
            if (this.Momentom < 500.0f) // 운동량 최대치 제한
            {
                this.Momentom += 0.5f; // 운동량 크기 증가
            }
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow)) // 우측이동
        {
            playerRigidbody.AddForce(this.Momentom * speed, 0, 0);
            this.Momentom = 0; // 운동량 초기화
        }
        else if (Input.GetKey(KeyCode.UpArrow)) // 운동량 차징
        {
            if (this.Momentom < 500.0f) // 운동량 최대치 제한
            {
                this.Momentom += 0.5f; // 운동량 크기 증가
            }
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow)) // 전방이동
        {
            playerRigidbody.AddForce(0, 0, this.Momentom * speed);
            this.Momentom = 0; // 운동량 초기화
        }
        else if (Input.GetKey(KeyCode.DownArrow)) // 운동량 차징
        {
            if (this.Momentom < 500.0f) // 운동량 최대치 제한
            {
                this.Momentom += 0.5f; // 운동량 크기 증가
            }
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow)) // 후방이동
        {
            playerRigidbody.AddForce(0, 0, -(this.Momentom * speed));
            this.Momentom = 0; // 운동량 초기화
        }
        if (transform.position.y < -5)
        {
            SceneManager.LoadScene("GameScene");
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
