using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] CharacterController _playerController;
    [Range(0f, 20f)]
    [SerializeField] float _speedMove = 12f;
    [SerializeField] float Gravity = -9.81f;
    [SerializeField] Transform groundCheck;
    [Range(0f, 1f)]
    [SerializeField] float groundDistance = 0.4f;
    [SerializeField] LayerMask groundMask;

    [Header("For Animation")]
    [SerializeField] bool isFire;
    

    [Header("Animator")]
    [SerializeField] Animator _animGun;
    [SerializeField] Animator _animArms;
  
    Vector3 velocity;
    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        CheckMap();
        SetBoolAnimation();
    }
    void Movement()
    {
        Vector3 Movement = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");

        _playerController.Move(Movement * _speedMove * Time.deltaTime);

        velocity.y = Gravity * Time.deltaTime;

        _playerController.Move(velocity * Time.deltaTime);


    }
    void CheckMap()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }
    }
    void SetBoolAnimation()
    {
       if(Input.GetMouseButton(0))
        {
            _animArms.SetTrigger("isFire");
            _animGun.SetTrigger("isFire");
        }    
    }

}
