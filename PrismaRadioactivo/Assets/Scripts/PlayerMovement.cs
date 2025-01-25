using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpSpeed = 5f;


    [Header("Dash Variables")]
    public float dashingVelocity = 14f;
    public float dashingTime = 0.3f;
    public float dashingCooldown = 0.5f;
    private Vector2 dashingDir;
    private bool isDashing;
    private bool canDash = true;


    [Header("References")]
    Animator myAnimator;
    Vector2 moveInput;
    Rigidbody myrigidbody;
    BoxCollider myBodyCollider;
    BoxCollider myFeetCollider;

    float gravityAtStart;
    public float distToGround;

    [Header("CameraShake")]
    public float cameraShake;
    public float mag = 0.3f;
    public float tims = 0.4f;
    

    void Start()
    {
        myrigidbody = GetComponent<Rigidbody>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<BoxCollider>();
        myFeetCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnJump();
            return;
        }
        var dashInput = Input.GetKeyDown(KeyCode.E);

        if (dashInput && canDash)
        {
            isDashing = true;
            canDash = false;
            dashingDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if (dashingDir == Vector2.zero)
            {
                dashingDir = new Vector2(transform.localScale.x, 0f);
            }
            StartCoroutine(StopDashing());

        }

        if (isDashing)
        {
            myrigidbody.velocity = dashingDir.normalized * dashingVelocity;
            return;
        }
    }

    

    void OnJump()
    {
        if (!IsGrounded()) { return; }
        myrigidbody.velocity += new Vector3(1f, jumpSpeed, 0f);
        myAnimator.SetTrigger("IsJumping");
        
    }
    public bool IsGrounded() {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 1.5f);
    }


    public void Run()
    {
        Vector2 PlayerVelocity = new Vector2(1 * runSpeed, myrigidbody.velocity.y);
        myrigidbody.velocity = PlayerVelocity;

        bool isMyManJumping = Mathf.Abs(myrigidbody.velocity.y) > Mathf.Epsilon;

        bool isMyManRunning = Mathf.Abs(myrigidbody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("IsRunning", isMyManRunning);
    }

  

    void JumpCheck()
    {
    }

    private IEnumerator StopDashing()
    {
        yield return new WaitForSeconds(dashingTime);
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

}
