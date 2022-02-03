using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallControl : MonoBehaviour
{
    public float ballSpeed = 100.0f; // 공의 이동속도
    private Rigidbody ballRigidbody; // 공의 Rigdbody 컴포넌트 필드
    public AudioClip bounceSound;
    public AudioClip crashSound;
    Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        ballRigidbody = GetComponent<Rigidbody>(); // 공의 Rigdbody 컴포넌트 대입
        startPosition = new Vector3(0, 0.5f, 0);
        ballRigidbody.AddForce(0, 0, -ballSpeed); // 공의 방향, 속도
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -5)
        {
            UIManager.score = 0;
            SceneManager.LoadScene("GameScene2");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            GetComponent<AudioSource>().PlayOneShot(crashSound);
            Destroy(collision.gameObject);
            UIManager.score += 1; // 1점추가

            Vector3 endPosition = collision.transform.position; // 충돌 대상의 위치
            Vector3 incomVector = endPosition - startPosition; // 현재 위치 벡터 - 출발위치 벡터 = 입사각
            Vector3 normalVector = collision.contacts[0].normal; // 법선벡터
            Vector3 reflectVector = Vector3.Reflect(incomVector, normalVector); // 반사각

            reflectVector = reflectVector.normalized; // 반사각 정규화
            ballRigidbody.AddForce(reflectVector * ballSpeed); // 반사 방향으로 이동
            GetComponent<AudioSource>().PlayOneShot(bounceSound);
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            Vector3 endPosition = collision.transform.position; // 충돌 대상의 위치
            Vector3 incomVector = endPosition - startPosition; // 현재 위치 벡터 - 출발위치 벡터 = 입사각
            Vector3 normalVector = collision.contacts[0].normal; // 법선벡터
            Vector3 reflectVector = Vector3.Reflect(incomVector, normalVector); // 반사각

            reflectVector = reflectVector.normalized; // 반사각 정규화
            ballRigidbody.AddForce(reflectVector * ballSpeed); // 반사 방향으로 이동
            GetComponent<AudioSource>().PlayOneShot(bounceSound);
        }
        startPosition = transform.position; // 현재 위치 벡터 대입
    }
}
