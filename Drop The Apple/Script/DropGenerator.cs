using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropGenerator : MonoBehaviour
{
    public GameObject originalItem;
    public GameObject originalGranade;
    public int ratio;
    public float interval;
    public float speed;
    private float delta = 0;

    public void SetParameter(float interval, float speed, int ratio)
    {
        this.interval = interval;
        this.speed = speed;
        this.ratio = ratio;
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if(this.delta >= this.interval)
        {
            SetParameter(Random.Range(0.1f, 1.5f), Random.Range(-0.01f, -0.5f),this.ratio);
            this.delta = 0;
            GameObject copyItem;
            int dice = Random.Range(1, 100);
            if (dice <= this.ratio)
            {
                copyItem = Instantiate(originalGranade) as GameObject;
            }
            else
            {
                copyItem = Instantiate(originalItem) as GameObject;
            }
            float x = Random.Range(-1, 2);
            float z = Random.Range(-1, 2);
            copyItem.transform.position = new Vector3(x, 5, z);
            copyItem.GetComponent<ItemController>().dropSpeed = this.speed;
        }
    }
}
