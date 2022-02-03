using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseControl : MonoBehaviour
{

    public float speed = 10.0f; // 이동속도
    private Rigidbody defenderRigidbody; // 수비수 물리

    // Start is called before the first frame update
    void Start()
    {
        defenderRigidbody = GetComponent<Rigidbody>(); // 플레이어 물리 컴포넌트 불러오기
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) // 좌측이동
        {
            defenderRigidbody.AddForce(-speed, 0, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow)) // 우측이동
        {
            defenderRigidbody.AddForce(speed, 0, 0);
        }
    }
}
