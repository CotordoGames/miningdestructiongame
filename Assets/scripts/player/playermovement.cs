using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class playermovement : MonoBehaviour
{
    //movement variables, durr
    [Header("Walking")]
    public float gspeed;
    public float gaccel;
    //less drag in air = more realistic gameplay
    public float aspeed;
    public float aaccel;
    [Header("Jumping")]
    public float jumpforce;
    public float jumpcut;
    public float fallspeed;
    public LayerMask ground;
    [Header("External Components")]
    private Rigidbody2D rb;
    private CircleCollider2D cc;
    public BoxCollider2D feet;
    [Header("Controls")]
    public InputAction Horizontal;
    public InputAction IJump;

    private void OnEnable() //enables/disables the controls with the obj
    {
        Horizontal.Enable();
        IJump.Enable();
    }

    private void OnDisable()
    {
        Horizontal.Disable();
        IJump.Disable();
    }








    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cc = GetComponent<CircleCollider2D>();
    }

    //velocityvars
    private float velX = 0;

    // Update is called once per frame
    void Update()
    {

        Walk();
        Jump();

        rb.linearVelocity = new Vector2(velX, rb.linearVelocityY);
    }

    void Walk()
    {
        if(isGrounded())//sets the velocity to the ground speed if the player is on the ground
        {
            velX = Mathf.Lerp(velX, Horizontal.ReadValue<float>() * gspeed, gaccel * Time.deltaTime * 55);
        } 
        else if (!isGrounded())//vice versa
        {
            velX = Mathf.Lerp(velX, Horizontal.ReadValue<float>() * aspeed, aaccel * Time.deltaTime * 55);
        }
    }

    void Jump()
    {
        if(IJump.IsPressed() && isGrounded())
        {
            rb.linearVelocity = new Vector2(velX, jumpforce);
        }
    }


    bool isGrounded()
    {
        return Physics2D.BoxCast(feet.bounds.center, feet.bounds.size, 0f, Vector2.down, 0.1f, ground); //simply checks if the player is touching the ground
    }
}
