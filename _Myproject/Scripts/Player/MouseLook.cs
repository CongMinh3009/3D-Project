
using UnityEngine;


public class MouseLook : MonoBehaviour
{
    [Range(0f, 200f)]
    [SerializeField] float MouseSentivity = 100f;

    [SerializeField] Transform PlayerBody;
    [SerializeField] float xRotation = 0f;
    private 
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
    }
    void Rotation()
    {
        float MouseXSenvitity = Input.GetAxis("Mouse X") * MouseSentivity *Time.deltaTime;
        float MouseYSenvitity = Input.GetAxis("Mouse Y") * MouseSentivity * Time.deltaTime;

        xRotation -= MouseYSenvitity;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        PlayerBody.Rotate(Vector3.up * MouseXSenvitity);
       
    }
   

}
