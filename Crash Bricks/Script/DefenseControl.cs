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
        if (Input.GetMouseButton(0)) // ��Ŭ������ �̵�
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity)) // Ŭ���� �κ����� �����
            {
                transform.position = new Vector3(hit.point.x, 0.5f, -24.41f);
            }
        }
    }
}
