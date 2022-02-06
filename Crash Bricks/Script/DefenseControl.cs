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
        if (Input.GetMouseButton(0)) // 좌클릭으로 이동
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity)) // 클릭한 부분으로 따라옴
            {
                transform.position = new Vector3(hit.point.x, 0.5f, -24.41f);
            }
        }
    }
}
