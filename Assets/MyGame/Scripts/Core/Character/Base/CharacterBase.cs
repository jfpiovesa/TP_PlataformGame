using UnityEngine;



[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(StatusCharacterBase))]
public class CharacterBase : MonoBehaviour, I_Damageable<Srl_ObjectDamege>
{
    [Header("Character ")]
    [SerializeField] private Transform charancter;

    [Header("Target Cam ")]
    [SerializeField] private Transform targetCam;

    [Header("Setting Info moviments"), Space(5)]
    public bool CanMove = false;
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] public float jumpForce = 10f;

    [Header("Info moviments"), Space(5)]
    [SerializeField] private Vector2 moveInput;
    [SerializeField] private bool jumpInput;
    [SerializeField] private bool isGrounded;

    [Header("Ground Check "), Space(5)]
    [SerializeField] public Transform groundCheck;
    [SerializeField] public float checkRadius = 0.2f;
    [SerializeField] public LayerMask layerIsGround;

    [Header("Components Requerid"), Space(5)]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;

    private PlayerInputActions playerInputActions;
    private StatusCharacterBase statusCharacter;

    public bool IsLive => statusCharacter.isAlive;

    private void Awake()
    {

        playerInputActions = new PlayerInputActions();

        playerInputActions.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        playerInputActions.Player.Move.canceled += ctx => moveInput = Vector2.zero;

        playerInputActions.Player.Jump.performed += ctx => jumpInput = true;
        playerInputActions.Player.Jump.canceled += ctx => jumpInput = false;



    }

    void Start()
    {
        statusCharacter = GetComponent<StatusCharacterBase>();
        rb = GetComponent<Rigidbody2D>();
        animator = charancter.GetComponent<Animator>();

        St_StageAction.currentStageController.playerCharacter = this;
        St_StageAction.SetTagerCamInStage(targetCam);
        St_StageAction.currentStageController.StartingStage();

        CanMove = true;
    }

    void Update()
    {
        CheckGround();

        Jump();

        Animations();

    }

    void FixedUpdate()
    {
        Moviment();
    }

    void Moviment()
    {
        if (!CanMove)
        {
            moveInput.x = 0;
            return;
        }

        rb.velocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);

        if (moveInput.x > 0)
            charancter.GetComponent<SpriteRenderer>().flipX = false;
        else if (moveInput.x < 0)
            charancter.GetComponent<SpriteRenderer>().flipX = true;
    }

    void Jump()
    {
        if (isGrounded && jumpInput && CanMove)
        {
            rb.velocity = Vector2.up * jumpForce;
            jumpInput = false;
        }
    }
    void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, layerIsGround);
    }
    void Animations()
    {
        animator.SetFloat("Speed", Mathf.Abs(moveInput.x));
        animator.SetBool("isJumping", !isGrounded);
    }

    private void OnEnable()
    {
        playerInputActions.Player.Enable();
    }

    private void OnDisable()
    {
        playerInputActions.Player.Disable();
    }
    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
        }
    }
    public void TakeDamage(Srl_ObjectDamege s_ObjectDamege)
    {
        statusCharacter.RemoveHealth(s_ObjectDamege.amount);
    }
}
