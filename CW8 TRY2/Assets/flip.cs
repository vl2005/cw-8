using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flip : MonoBehaviour
{
    SpriteRenderer sprite;
    bool FaceRight = true;

    public GameObject bullet;
    GameObject bulletClone;

    public Transform leftSpawn;

    public float speed;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        FlipPlayer();
        Fire();
    }
    void FlipPlayer()
    {
        if (Input.GetKeyDown (KeyCode.D) && FaceRight == false)
        {
            sprite.flipX = false;
            FaceRight = true;
        }
         else if (Input.GetKeyDown(KeyCode.A) && FaceRight == true)
        {
            sprite.flipX = true;
            FaceRight = false;
        }
    }
    void Fire()
    {
        if (Input.GetMouseButtonDown(0) && FaceRight)
        {
            bulletClone = Instantiate(bullet, transform.position, transform.rotation);
            bulletClone.GetComponent<Rigidbody2D>().velocity = transform.right * speed;
            Destroy(bulletClone , 2f);
         }
        else if (Input.GetMouseButtonDown(0) && !FaceRight)
        {
            bulletClone = Instantiate(bullet, leftSpawn.position, leftSpawn.rotation);
            bulletClone.GetComponent<Rigidbody2D>().velocity = transform.right * -speed;
            Destroy(bulletClone, 2f);

        }
    }
}
