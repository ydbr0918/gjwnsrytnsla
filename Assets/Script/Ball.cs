using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Debug.Log("���� �ֽ�");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ť�� ���� �ȿ� ����");
    }
}
