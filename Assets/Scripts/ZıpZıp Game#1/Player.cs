using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    public TextMeshProUGUI ScoreBoard;

    private float screenSizeX;
    private int score = 0;
    private Rigidbody2D rb;
    private bool isJumping = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        screenSizeX = Camera.main.aspect * Camera.main.orthographicSize;
    }

    void Update()
    {
        Move();
        CheckScreenWrap();
    }

    void Move()
    {
        //float moveInput = Input.acceleration.x;
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x * Time.deltaTime, jumpForce);
            isJumping = false;
        }
        
    }

    void CheckScreenWrap()
    {
        Vector3 newPosition = transform.position;

        if (transform.position.x < -screenSizeX)
        {
            newPosition.x = screenSizeX;
        }
        else if (transform.position.x > screenSizeX)
        {
            newPosition.x = -screenSizeX;
        }

        transform.position = newPosition;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            isJumping = true;
            Destroy(collision.gameObject);
            score++;
            ScoreBoard.text = score.ToString();
        }
    }

}
