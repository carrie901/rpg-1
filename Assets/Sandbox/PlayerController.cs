using UnityEngine;
using UnityEngine.EventSystems;
using OdinSerializer;

[RequireComponent(typeof(Animator), typeof(CapsuleCollider), typeof(Rigidbody))]
public class PlayerController : SerializedMonoBehaviour
{
    public PlayerCurrentMovementSpeed CurrentMovementSpeed { get { return _currentMovementSpeed; } set { _currentMovementSpeed = value; } }
    [OdinSerialize] private PlayerCurrentMovementSpeed _currentMovementSpeed;

    public float TurnSpeed = 2.0f;
    public float FallHeight = 3.0f;
    public bool RunIsToggle = false;
    public bool RunAfterFall = false;

    private Animator Animator { get; set; }
    private Rigidbody Rigidbody { get; set; }

    private AnimatorStateInfo currentBaseState;
    public GameMode Mode = GameMode.RPG;

    static int idleState = Animator.StringToHash("Idle.Idle");
    static int walkJumpState = Animator.StringToHash("Base Layer.Walk Jump");
    static int runJumpState = Animator.StringToHash("Base Layer.Run Jump");
    static int idleJumpState = Animator.StringToHash("Base Layer.Idle Jump");
    static int fallState = Animator.StringToHash("Base Layer.Fall");

    private bool rightMouseDown = false;
    private bool leftMouseDown = false;

    private void Awake()
    {
        Animator = GetComponent<Animator>();
        Rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!Input.GetButton("Fire1")) leftMouseDown = false;
        if (!Input.GetButton("Fire2")) rightMouseDown = false;

        float s = Input.GetAxis("Strafe");
        Animator.SetFloat("Strafe", s);

        float h = Input.GetAxis("Horizontal");
        if (rightMouseDown || Mode == GameMode.FPS)
            Animator.SetFloat("Strafe", Animator.GetFloat("Strafe") + h);
        else
        {
            Animator.SetFloat("Direction", h);
            transform.Rotate(0.0f, h * TurnSpeed, 0.0f, Space.World);
        }

        // if the user has both mouse buttons pressed, should move forward, otherwise respond to vertical input axis			
        if (leftMouseDown && rightMouseDown)
        {
            Animator.SetFloat("Speed", Mathf.Lerp(Animator.GetFloat("Speed"), 1, Time.deltaTime * 10));
        }
        else
        {
            float v = Input.GetAxis("Vertical");
            Animator.SetFloat("Speed", Mathf.Lerp(Animator.GetFloat("Speed"), v, Time.deltaTime * 10));
        }

        Animator.speed = CurrentMovementSpeed.Numeric;


        currentBaseState = Animator.GetCurrentAnimatorStateInfo(0);

        //do things we need to do based on what state we are in
        if (currentBaseState.fullPathHash == idleState)
        {
            if (Input.GetAxis("Vertical") < 0.1 || !RunAfterFall)
            {
                Animator.SetBool("Run", false);
            }
        }
        else if (currentBaseState.fullPathHash == walkJumpState)
        {
            Animator.SetBool("Jump", false);
        }
        else if (currentBaseState.fullPathHash == runJumpState)
        {
            Animator.SetBool("Jump", false);
        }
        else if (currentBaseState.fullPathHash == idleJumpState)
        {
            Animator.SetBool("Jump", false);
        }
        else if (currentBaseState.fullPathHash == fallState)
        {
            if (!isFalling())
            {
                //we have landed
                Animator.SetBool("Fall", false);
                return; //nothing else to do this frame
            }
        }
        //first, check if we are falling
        if (isFalling())
        {
            //we are falling
            Animator.SetBool("Fall", true);
            return; //return because we can't do anything while falling
        }

        //handle input
        if (Input.GetButtonDown("Jump"))
        {
            Animator.SetBool("Jump", true);
        }

        if (RunIsToggle)
        {
            if (Input.GetButtonDown("Run"))
            {
                Animator.SetBool("Run", !Animator.GetBool("Run"));
            }
        }
        else
        {
            if (Input.GetButton("Run"))
            {
                Animator.SetBool("Run", true);
            }
            else
            {
                Animator.SetBool("Run", false);
            }
        }
    }

    private bool isFalling()
    {
        RaycastHit rayInfo;
        Vector3 raySource = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z);
        Physics.Raycast(raySource, Vector3.down, out rayInfo, FallHeight);
        Debug.DrawRay(raySource, Vector3.down * FallHeight, Color.yellow);
        if (rayInfo.collider == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void OnPointerDown(BaseEventData eventdata)
    {
        PointerEventData ped = eventdata as PointerEventData;

        if (ped.button == PointerEventData.InputButton.Left) leftMouseDown = true;
        if (ped.button == PointerEventData.InputButton.Right) rightMouseDown = true;
    }

}
