
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("For Player Movement")]
    [SerializeField] CharacterController _playerController;
    [SerializeField] Vector3 _direction;
    [Range(0f, 20f)]
    [SerializeField] float _speedMove = 12f;
    [SerializeField] float Gravity = 20f;
    
    [Header("Player Jump")]
    [SerializeField] float _jumpFroce;
    [SerializeField] Transform _groundCheck;
    [SerializeField] float _groundDistance;
    [SerializeField] LayerMask _groundMask;

    
    [HideInInspector] Vector3 _velocity;
    // Start is called before the first frame update
    void Start()
    {
        _playerController = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
        //CheckMap();
    }
    //void CheckMap()
    //{
    //    _isGrounded = Physics.CheckSphere(_groundCheck.position,_groundDistance,_groundMask);
    //    if(_isGrounded && _velocity.y <0)
    //    {
    //        _velocity.y = -2f;
    //    }
    //}
    void Movement()
    {
       _direction = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");

        _playerController.Move(_direction * _speedMove * Time.deltaTime);
        _velocity.y += -Gravity * Time.deltaTime;
        _playerController.Move(_velocity);
    }
    void Jump()
    {
        if(Input.GetButtonDown("Jump") && _playerController.isGrounded)
        {
            //_velocity.y = _jumpFroce;
            _velocity.y = Mathf.Sqrt(_jumpFroce * -.3f * -Gravity);

        }
    }

    


}
