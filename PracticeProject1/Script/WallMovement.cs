using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour
{
    public float movementMomentum; // 벽의 운동량에 관한 필드
    public float distroyInterval = 5.0f; // 오브젝트 제거 시간

    private void Start()
    {
        Destroy(gameObject, distroyInterval); // distroyInterval 필드의 값 만큼의 시간 후 오브젝트 제거
    }

    private void Update()
    {
        transform.Translate(movementMomentum * Time.deltaTime, 0, 0); // 운동량 * 딜레이 만큼 벽 이동
    }
}
