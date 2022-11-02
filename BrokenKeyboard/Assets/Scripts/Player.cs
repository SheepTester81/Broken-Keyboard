using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Movement")]

    [Rename("Can Move?")]
    public bool canMove = false;
    [Rename("Jump Force")]
    [SerializeField] private float jumpVelocity = 15f; // jump force
    [Rename("Double Jump Force")]
    [SerializeField] private float doubleJumpVelocity = 20f; // double jump force
    [Rename("Movement Speed")]
    [SerializeField] private float speed = 5f; // walking speed(or running? idk)
    [Rename("Rigidbody2D")]
    [SerializeField] private Rigidbody2D rb; // rigidbody 2d
    [Rename("Box Collider")]
    [SerializeField] private Collider2D collider; // collider
    [Rename("Center")]
    [SerializeField] private Transform center; // collider

    [SerializeField] private LayerMask layerMask; // layermask
    private float horizontal = 0; // value(left = -1, right = 1)
    private bool doubleJump;

    /*
    [Header("Shooting")] // any shooting

    [Rename("Bullet Prefab")]
    [SerializeField] private GameObject bulletPrefab; // prefab object of bullet
    [Rename("Firepoint")]
    [SerializeField] private Transform firePoint; // firepoint
    [Rename("Bullet Speed")]
    [SerializeField] private float bulletSpeed = 20f; // speed of bullet(how fast it shoots)
    [Rename("Fire Rate")]
    [SerializeField] private float fireRate = 15f;
    [Rename("Can Shoot?")]
    [SerializeField] private bool CanShoot = true;

    private float nextTimeToFire = 0f;
    */

    [Header("Other")]

    [Rename("Input Manager")]
    [SerializeField] private HandleInput input;
    [Rename("Audio Manager")]
    [SerializeField] private AudioManager audio;
    [Rename("Animation Manager")]
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        horizontal = 0;
        if (isGrounded() && !Input.GetKey(KeyCode.Space))
        {
            doubleJump = false;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded() || doubleJump)
            {
                if (input.CanJump)
                {
                    rb.velocity = new Vector2(rb.velocity.x, doubleJump ? doubleJumpVelocity : jumpVelocity);

                    doubleJump = !doubleJump;
                }                
                
                audio.Play("jump");
                // JUMP
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            
            audio.Play("jump");
        }
        /* 
        if (Input.GetKey(Keycode.???))
        {
            horizontal++;
        }
        if (Input.GetKey(Keycode.???))
        {
            horizontal--;
        }

        if (Input.GetKey(KeyCode.???) && CanShoot)
        {
            if (Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                bullet.GetComponent<Rigidbody2D>().velocity = firePoint.right * bulletSpeed;
                
                audio.Play("shoot");
            }
        }
        */
    }
    
    void FixedUpdate()
    {
        if (canMove)
        {
            rb.velocity = new Vector2(speed * horizontal, rb.velocity.y);
            // constantly change player x direction
        }
    }

    bool isGrounded()
    {
        // checks if player is grounded using raycast
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(center.position, collider.bounds.size, 0f, Vector2.down, 0.55f, layerMask);
        return raycastHit2d != false; // returns raycast hit(true/false)
    }
}
