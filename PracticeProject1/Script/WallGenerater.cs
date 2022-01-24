using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerater : MonoBehaviour
{
    public GameObject original; // �������� ������Ʈ
    public float interval = 1.0f; // ���� ����
    public float range = 0; // Y�� ��ġ ����
    private float delta = 0; // ����ð�

    void Update()
    {
        this.delta += Time.deltaTime;
        if(this.delta > this.interval)
        {
            this.delta = 0; // ����ð� �ʱ�ȭ
            GameObject copyObject = Instantiate(original) as GameObject; // ������Ʈ ������ ����
            copyObject.transform.position = new Vector3(0, Random.Range(-range,range),0); // range ���� �� ��ŭ Y�� ��ġ ����
        }
    }
}