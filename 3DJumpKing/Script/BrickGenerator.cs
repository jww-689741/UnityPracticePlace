using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickGenerator : MonoBehaviour
{
    public GameObject original; // 오리지날 오브젝트
    public float interval = 1.0f; // 생성 간격
    private float delta = 0; // 진행시간

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
            this.delta = 0; // 진행시간 초기화
            GameObject copyObject = Instantiate(original) as GameObject; // 오브젝트 프리팹 생성
            copyObject.transform.position = new Vector3((int)(Random.Range(-4, 4)), 0.5f, (int)(Random.Range(0, 3))); // 랜덤위치에 배치

        }
    }
}
