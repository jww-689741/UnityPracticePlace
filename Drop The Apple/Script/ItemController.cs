using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public float dropSpeed = -0.01f;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, dropSpeed * Time.deltaTime, 0);
        if(transform.position.y < -1)
        {
            Destroy(gameObject);
        }
    }
}
