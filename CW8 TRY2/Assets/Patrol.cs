using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Patrol : MonoBehaviour
{
    public Transform groundPos;
    public float speed;
    public LayerMask groundLayer;
    public float rad;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyPatrol();
    }
    void EnemyPatrol()
    {
        rb.velocity = new Vector2(speed, 0f);

        bool isGrounded = Physics2D.OverlapCircle(groundPos.position, rad, groundLayer);

        if (!isGrounded)
        {
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            speed *= -1;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            Invoke("Restart", 0.5f);
        }
        else if (collision.gameObject.tag == "bullet")
        {
            Destroy(gameObject);
        }
    }
    void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
