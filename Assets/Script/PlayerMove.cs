using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody rb;

    public float PlayerSpeed = 5f;
    public float JumpPower = 5f;

    public int CoinCount = 0;
    public int TotalCoin = 5;

    public bool IsGround = true;


    private void Start()
    {
        IsGround = true;
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(moveHorizontal * PlayerSpeed, rb.velocity.y, moveVertical * PlayerSpeed);
    }

    private void Jump()
    {
        if(Input.GetButtonDown("Jump")&&IsGround)
        {
            rb.AddForce(Vector3.up*JumpPower,ForceMode.Impulse);
            IsGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            IsGround = true;
            Debug.Log("���� �پҽ��ϴ�.");
        }

        if(collision.gameObject.tag == "Door" && CoinCount >= TotalCoin)
        {
            Debug.Log("EndGame");
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else if(collision.gameObject.tag == "Door" && CoinCount < TotalCoin)
        {
            Debug.Log($"{TotalCoin - CoinCount}���� ������ �� ��������");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Coin"))
        {
            CoinCount++;
            Destroy(other.gameObject);
            Debug.Log($"���� ȹ��: {CoinCount}/{TotalCoin}");
        }
    }
}

