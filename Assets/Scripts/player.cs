using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;


public class player : MonoBehaviour
{
    public SpriteRenderer Characters;
    public Animator animator;
    public float MoveSpeed = 5f;
    public Vector2 MoveInput;
    private Rigidbody2D rb;
    private PlayerInput playerInput;

    public EatGun eatgun;


    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
    }
    private void Update()
    {
        MoveInput = playerInput.actions["Move"].ReadValue<Vector2>();
        transform.position += (Vector3)MoveInput * MoveSpeed * Time.deltaTime;
        animator.SetFloat("Speed", MoveInput.sqrMagnitude);
        if (MoveInput.x != 0)
        {
            Characters.transform.localScale = new Vector3(Mathf.Sign(MoveInput.x), 1, 1);
            //sẽ trả về 1 nếu MoveInput.x lớn hơn 0, -1 nếu MoveInput.x nhỏ hơn 0
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            //rb.velocity = Vector2.zero;
            //rb.angularVelocity = 0.0f;
            this.gameObject.SetActive(false);
            FindObjectOfType<Manage>().PlayerDie();
            
            
            
        }
        else if (collision.gameObject.tag == "Gun")
        {
            eatgun.Show();
            Destroy(collision.gameObject);
        }
    }
}
