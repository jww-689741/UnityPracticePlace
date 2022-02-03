using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 1.0f; // �̵��ӵ�
    private float jumpMomentom = 0; // ���� ���
    private Rigidbody playerRigidbody; // �÷��̾� ����

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>(); // �÷��̾� ���� ������Ʈ �ҷ�����
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) // ���� �̵�
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow)) // ���� �̵�
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.UpArrow)) // ���� �̵�
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.DownArrow)) // �Ĺ� �̵�
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.Space)) // ���� ��� ��¡
        {
            if(this.jumpMomentom < 500.0f) // ��� �ִ�ġ ����
            {
                this.jumpMomentom += 0.5f; // ��� ũ�� ����
            }
        }
        else if (Input.GetKeyUp(KeyCode.Space)) // ����
        {
            playerRigidbody.AddForce(0, this.jumpMomentom, 0);
            this.jumpMomentom = 0; // ��� �ʱ�ȭ
        }
        if(transform.position.y < -5)
        {
            transform.position = new Vector3(0, 2, 0); // ������
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Flag") // ��ǥ���� ���� ��
        {
            
        }
    }
}
