using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flip : MonoBehaviour
{
    SpriteRenderer sprite;
    bool FaceRight = true;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        FlipPlayer();
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
}
