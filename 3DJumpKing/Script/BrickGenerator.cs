using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickGenerator : MonoBehaviour
{
    public GameObject original; // �������� ������Ʈ
    public float interval = 1.0f; // ���� ����
    private float delta = 0; // ����ð�

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.interval)
        {
            this.delta = 0; // ����ð� �ʱ�ȭ
            GameObject copyObject = Instantiate(original) as GameObject; // ������Ʈ ������ ����
            copyObject.transform.position = new Vector3((int)(Random.Range(-4, 4)), 0.5f, (int)(Random.Range(0, 3))); // ������ġ�� ��ġ

        }
    }
}
