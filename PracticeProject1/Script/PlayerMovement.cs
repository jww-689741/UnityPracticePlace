using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float jumpMomentum; // ���� ����� ���� float�� �ʵ�

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)) // ������Ű�� �Է��ϴ°����� ����
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, jumpMomentum, 0); // ���� ��� �ʵ��� �� ��ŭ Y�� �������� �̵�
        }
    }

    private void OnCollisionEnter(Collision collision) // �ٸ� ������Ʈ�� �浹 �� ����
    {
        SceneManager.LoadScene("GameoverScene"); // ���ӿ��� �� �ҷ�����
    }
}
