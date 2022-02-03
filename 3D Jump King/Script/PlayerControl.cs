using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 1.0f; // 이동속도
    private float jumpMomentom = 0; // 점프 운동량
    private Rigidbody playerRigidbody; // 플레이어 물리

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>(); // 플레이어 물리 컴포넌트 불러오기
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) // 좌측 이동
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow)) // 우측 이동
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.UpArrow)) // 전방 이동
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.DownArrow)) // 후방 이동
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.Space)) // 점프 운동량 차징
        {
            if(this.jumpMomentom < 500.0f) // 운동량 최대치 제한
            {
                this.jumpMomentom += 0.5f; // 운동량 크기 증가
            }
        }
        else if (Input.GetKeyUp(KeyCode.Space)) // 점프
        {
            playerRigidbody.AddForce(0, this.jumpMomentom, 0);
            this.jumpMomentom = 0; // 운동량 초기화
        }
        if(transform.position.y < -5)
        {
            transform.position = new Vector3(0, 2, 0); // 리스폰
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Flag") // 목표지점 도달 시
        {
            
        }
    }
}
