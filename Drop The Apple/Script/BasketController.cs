using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    public AudioClip itemSound;
    public AudioClip granadeSound;
    private AudioSource audioSource;
    public GameObject director;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit, Mathf.Infinity))
            {
                float moved_x = Mathf.RoundToInt(hit.point.x);
                float moved_z = Mathf.RoundToInt(hit.point.z);
                transform.position = new Vector3(moved_x, 0, moved_z);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            this.director.GetComponent<GameDirector>().AddedScore();
            AudioSource.PlayClipAtPoint(itemSound, transform.position);
        }
        else
        {
            this.director.GetComponent<GameDirector>().DecreasedScore();
            AudioSource.PlayClipAtPoint(granadeSound, transform.position);
        }
        Destroy(other.gameObject);
    }
}
