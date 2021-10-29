using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController _controller;
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _gravity = -20f;
    [SerializeField] private float _jumpHeight = 3f;

    [SerializeField] private Transform _ground;
    [SerializeField] private float _groundDistance = 0.4f;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private Animator _animator;
    public BattleStatus status;


    bool jump = false;
    byte jumps = 0;
    const byte maxJumps = 1;
    private Vector3 _velocity;
    private bool _isGrounded;

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jumping();
        Refilling();
    }

    // Movement functionality with animating
    void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        _animator.SetFloat("isMove", Mathf.Max(Mathf.Abs(x), Mathf.Abs(z)));
        Vector3 move = transform.right * x + transform.forward * z;
        _controller.Move(move * _speed * Time.deltaTime);    
    }

    // Jumping functionality with animating
    void Jumping()
    {   
        jump = Input.GetButtonDown("Jump") && jumps < maxJumps;
        if (jump)
        {
            _animator.SetBool("isJump", true);
            _velocity.y = Mathf.Sqrt(_jumpHeight * _gravity * -2);
            jumps++;
        }
        
        _velocity.y += _gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);

        _isGrounded = Physics.CheckSphere(_ground.position, _groundDistance, _groundMask);
        if (_isGrounded)
        {
            OnLanding();
        }
    }

    // Refill hp-ap with health-armor packs
    void Refilling()
    {
        if (Input.GetButtonDown("FillHp"))
            status.UseHpPack();
        if (Input.GetButtonDown("FillAp"))
            status.UseApPack();
    }

    // When our player is landing - refresh jumps
    public void OnLanding()
    {
        _animator.SetBool("isJump", false);
        jumps = 0;
    }
}
