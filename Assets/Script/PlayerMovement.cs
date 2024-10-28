using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private float horizontal;
    private float vertical;
    private Animator animator;

    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        animator.SetFloat("Speed", Mathf.Abs(horizontal !=0 ? horizontal : vertical));
        SpriteFlip(horizontal);
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(horizontal * moveSpeed, vertical * moveSpeed, 0.0f);
        transform.position = transform.position + movement * Time.deltaTime;      
    }

    private void SpriteFlip(float horizontalInput) 
    {
        if(horizontalInput < 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }
 
}
