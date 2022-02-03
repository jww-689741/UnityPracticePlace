using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseControl : MonoBehaviour
{

    public float speed = 10.0f; // �̵��ӵ�
    private Rigidbody defenderRigidbody; // ����� ����

    // Start is called before the first frame update
    void Start()
    {
        defenderRigidbody = GetComponent<Rigidbody>(); // �÷��̾� ���� ������Ʈ �ҷ�����
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) // �����̵�
        {
            defenderRigidbody.AddForce(-speed, 0, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow)) // �����̵�
        {
            defenderRigidbody.AddForce(speed, 0, 0);
        }
    }
}
