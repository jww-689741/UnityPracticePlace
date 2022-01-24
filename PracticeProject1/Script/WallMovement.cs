using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour
{
    public float movementMomentum; // ���� ����� ���� �ʵ�
    public float distroyInterval = 5.0f; // ������Ʈ ���� �ð�

    private void Start()
    {
        Destroy(gameObject, distroyInterval); // distroyInterval �ʵ��� �� ��ŭ�� �ð� �� ������Ʈ ����
    }

    private void Update()
    {
        transform.Translate(movementMomentum * Time.deltaTime, 0, 0); // ��� * ������ ��ŭ �� �̵�
    }
}
