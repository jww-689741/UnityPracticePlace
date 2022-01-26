using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerater : MonoBehaviour
{
    public GameObject original; // 오리지날 오브젝트
    public float interval = 1.0f; // 생성 간격
    public float range = 0; // Y축 위치 범위
    public int wallUpAndDownRange; // 벽 상하운동 확률
    private float delta = 0; // 진행시간

    void Update()
    {
        this.delta += Time.deltaTime;
        if(this.delta > this.interval)
        {
            this.delta = 0; // 진행시간 초기화
            
            GameObject copyObject = Instantiate(original) as GameObject; // 오브젝트 프리팹 생성
            if (Random.Range(0, 100) < wallUpAndDownRange)
            {
                copyObject.transform.GetComponent<Animator>().SetBool("movementFlag", true);
            }
            copyObject.transform.position = new Vector3(0, Random.Range(-range,range),0); // range 범위 값 만큼 Y축 위치 변경
        }
    }
}
