using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float jumpMomentum; // ���� ����� ���� float�� �ʵ�
    public int deathCount = 3; // ���
    private int score = 0; // ���ھ�

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)) // ������Ű�� �Է��ϴ°����� ����
        {
            GetComponent<AudioSource>().Play(); // ȿ���� ���
            GetComponent<Rigidbody>().velocity = new Vector3(0, jumpMomentum, 0); // ���� ��� �ʵ��� �� ��ŭ Y�� �������� �̵�
        }
    }

    private void OnCollisionEnter(Collision collision) // �ٸ� ������Ʈ�� �浹 �� ����
    {
        if (collision.gameObject.tag == "Horizon") // �� �Ʒ� ����� �浹���� ��� ����
        {
            Gameover.totalScore = score; // �� ���ھ� ����
            SceneManager.LoadScene("GameoverScene"); // ���ӿ��� �� �ҷ�����
        }
        else if(collision.gameObject.transform.parent.parent.gameObject.tag == "Wall") // ���� �浹���� ��� ����
        {
            Destroy(GameObject.Find("Heart" + deathCount)); // ��� UI �ϳ� ����
            deathCount--; // ��� -1
            Destroy(collision.gameObject.transform.parent.parent.gameObject); // �浹 ������Ʈ ���� ( �ݶ��̴��� ����� ������Ʈ�� �θ��� �θ� ������Ʈ�� �����ؾ� �����۵� )
        }
        if(deathCount == 0) // ����� ��� �������� ��� ����
        {
            Gameover.totalScore = score; // �� ���ھ� ����
            SceneManager.LoadScene("GameoverScene"); // ���ӿ��� �� �ҷ�����
        }
    }

    private void OnTriggerEnter(Collider other) // Ʈ���� �߻� �� ����
    {
        score++; // ���ھ� ����
        GameObject.Find("Score").GetComponent<Text>().text = "Score : " + score; // ���ھ� �� ���
    }
}
