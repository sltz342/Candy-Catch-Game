using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Vars for speeds
    [SerializeField] private float speed;

    //Vars for jumping
    [SerializeField] private float jumpForce;
    private Boolean isGrounded;
    private Rigidbody2D rb;
    private float depth;

    [SerializeField] private LayerMask groundLayers;


    //Vars for movement
    private Vector3 _moveDir;

    //For spawning coins
    [SerializeField] private GameObject coinPrefab;



    void Start()
    {
        InputManager.Init(this);

        rb = GetComponent<Rigidbody2D>();
        depth = GetComponent<Collider2D>().bounds.size.y;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.rotation * (speed * Time.deltaTime * _moveDir);
        CheckGround();

    }

    public void setMovementDirection(Vector2 newDirection)
    {
        _moveDir = newDirection;

    }

    public void spawnBoxOnJ()
    {
        Vector3 coinSpawn = new Vector3(0, 2, 0);
        GameObject newCoin = Instantiate(coinPrefab, coinSpawn, Quaternion.identity);
        Destroy(newCoin.gameObject, 4);
    }

    public void jump()
    {
        Debug.Log("Jump called");
        if (isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce);
        }


    }

    private void CheckGround()
    {
        isGrounded = Physics.Raycast(transform.position, Vector2.down, depth, groundLayers);

        Debug.DrawRay(transform.position, Vector2.down * depth, Color.red, 0, false);
    }

}
