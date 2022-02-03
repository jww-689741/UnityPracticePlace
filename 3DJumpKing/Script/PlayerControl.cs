using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    public float speed = 1.0f; // �̵��ӵ� ���
    private float Momentom = 0; // ���
    private Rigidbody playerRigidbody; // �÷��̾� ����

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>(); // �÷��̾� ���� ������Ʈ �ҷ�����
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) // ��� ��¡
        {
            if(this.Momentom < 500.0f) // ��� �ִ�ġ ����
            {
                this.Momentom += 0.5f; // ��� ũ�� ����
            }
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow)) // �����̵�
        {
            playerRigidbody.AddForce(-(this.Momentom * speed), 0, 0);
            this.Momentom = 0; // ��� �ʱ�ȭ
        }
        else if (Input.GetKey(KeyCode.RightArrow)) // ��� ��¡
        {
            if (this.Momentom < 500.0f) // ��� �ִ�ġ ����
            {
                this.Momentom += 0.5f; // ��� ũ�� ����
            }
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow)) // �����̵�
        {
            playerRigidbody.AddForce(this.Momentom * speed, 0, 0);
            this.Momentom = 0; // ��� �ʱ�ȭ
        }
        else if (Input.GetKey(KeyCode.UpArrow)) // ��� ��¡
        {
            if (this.Momentom < 500.0f) // ��� �ִ�ġ ����
            {
                this.Momentom += 0.5f; // ��� ũ�� ����
            }
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow)) // �����̵�
        {
            playerRigidbody.AddForce(0, 0, this.Momentom * speed);
            this.Momentom = 0; // ��� �ʱ�ȭ
        }
        else if (Input.GetKey(KeyCode.DownArrow)) // ��� ��¡
        {
            if (this.Momentom < 500.0f) // ��� �ִ�ġ ����
            {
                this.Momentom += 0.5f; // ��� ũ�� ����
            }
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow)) // �Ĺ��̵�
        {
            playerRigidbody.AddForce(0, 0, -(this.Momentom * speed));
            this.Momentom = 0; // ��� �ʱ�ȭ
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
