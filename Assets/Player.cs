using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Animator animator;
    private float lastAttackTime;

    public int targetSceneBuildIndex = 0;

    private bool deathActionTriggered = false;
    private float jumpForce = 8f;

    private bool isGrounded = true;
    public float attackCooldown = 2f;

    [SerializeField]
    private float speed = 20f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Handle movement
        float horizontalInput = Input.GetAxis("Horizontal");
        //float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, 0f);


        if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-15, 14, 1);
        }
        else if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(15, 14, 1);
        }

        transform.Translate(movement * Time.deltaTime * speed);

        // Handle animations
        if (movement.magnitude > 0.1f)
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //isGrounded= false;
            if (isGrounded)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
                isGrounded = false;
                animator.SetTrigger("Jump");

                //animator.SetTrigger("JumpEnd");
                OnJumpEnd();


            }

            OnFallEnd();
            isGrounded = true;
            
            
        }

        // Handle attacks
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time - lastAttackTime > attackCooldown)
            {
                if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1"))
                {
                    animator.SetTrigger("Attack1");
                    lastAttackTime = Time.time;
                }
            }
            else
            {
                if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack2"))
                {
                    animator.SetTrigger("Attack2");
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.F) && !deathActionTriggered) // Check if the Enter key is pressed.
        {

            TriggerDeathAnimation();
            // Set the flag to indicate that the death action has been triggered.
            deathActionTriggered = true;
            // Load the target scene based on its build index.
            //TriggerDeathAnimation();

            SceneManager.LoadScene(targetSceneBuildIndex);
        }

    }

    

    void TriggerDeathAnimation()
    {
        animator.SetTrigger("Death");
    }

    

    /*void OnCollisionEnter(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    */

    void OnJumpEnd()
    {
        animator.SetTrigger("JumpEnd");
    }

    void OnFallEnd()
    {
        animator.SetTrigger("Fall");
    }
    

}