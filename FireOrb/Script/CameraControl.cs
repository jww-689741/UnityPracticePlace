using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float cameraReverseInterval; // ī�޶� ���� ���͹�
    private float delta = 0; // ����ð�
    private float nagative = -1;
    private float cameraPosZ;

    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > cameraReverseInterval)
        {
            this.delta = 0;
            cameraPosZ = transform.position.z * nagative;
            transform.Rotate(new Vector3(0, 180, 0));
            transform.position = new Vector3(-15, 0, cameraPosZ);
        }
    }
}
