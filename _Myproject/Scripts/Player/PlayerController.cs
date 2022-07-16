
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("For Player")]
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
    [SerializeField] Animator _animGunAka;
    [SerializeField] Animator _animArmsAKa;
    [SerializeField] Animator _animGunM119;
    [SerializeField] Animator _animArmsM119;

    [Header("Shotting")]
    [Range(0f, Mathf.Infinity)]
    [SerializeField] float _range;
    [SerializeField] Camera _fpsCam;





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
            Shot();
            _animArmsAKa.SetTrigger("isFire");
            _animGunAka.SetTrigger("isFire");
            _animArmsM119.SetTrigger("isFire");
            _animGunM119.SetTrigger("isFire");
           
        }
    }

     void Shot()
    {
        RaycastHit hit;
        if (Physics.Raycast(_fpsCam.transform.position, transform.forward, out hit, _range))
        {
            Debug.Log(hit.transform.name);
        }
        var _damged = GetComponent<Gun>();
        var _target = hit.transform.GetComponent<Target>();

        if(_target != null)
        {
            _target.TakeDamge(_damged.Dameged());
        }    

        Debug.DrawRay(_fpsCam.transform.position, _fpsCam.transform.forward * _range, Color.red);
    }


}
