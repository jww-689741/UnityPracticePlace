using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallControl : MonoBehaviour
{
    public float ballSpeed = 100.0f; // ���� �̵��ӵ�
    private Rigidbody ballRigidbody; // ���� Rigdbody ������Ʈ �ʵ�
    public AudioClip bounceSound;
    public AudioClip crashSound;
    Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        ballRigidbody = GetComponent<Rigidbody>(); // ���� Rigdbody ������Ʈ ����
        startPosition = new Vector3(0, 0.5f, 0);
        ballRigidbody.AddForce(0, 0, -ballSpeed); // ���� ����, �ӵ�
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
            UIManager.score += 1; // 1���߰�

            Vector3 endPosition = collision.transform.position; // �浹 ����� ��ġ
            Vector3 incomVector = endPosition - startPosition; // ���� ��ġ ���� - �����ġ ���� = �Ի簢
            Vector3 normalVector = collision.contacts[0].normal; // ��������
            Vector3 reflectVector = Vector3.Reflect(incomVector, normalVector); // �ݻ簢

            reflectVector = reflectVector.normalized; // �ݻ簢 ����ȭ
            ballRigidbody.AddForce(reflectVector * ballSpeed); // �ݻ� �������� �̵�
            GetComponent<AudioSource>().PlayOneShot(bounceSound);
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            Vector3 endPosition = collision.transform.position; // �浹 ����� ��ġ
            Vector3 incomVector = endPosition - startPosition; // ���� ��ġ ���� - �����ġ ���� = �Ի簢
            Vector3 normalVector = collision.contacts[0].normal; // ��������
            Vector3 reflectVector = Vector3.Reflect(incomVector, normalVector); // �ݻ簢

            reflectVector = reflectVector.normalized; // �ݻ簢 ����ȭ
            ballRigidbody.AddForce(reflectVector * ballSpeed); // �ݻ� �������� �̵�
            GetComponent<AudioSource>().PlayOneShot(bounceSound);
        }
        startPosition = transform.position; // ���� ��ġ ���� ����
    }
}
