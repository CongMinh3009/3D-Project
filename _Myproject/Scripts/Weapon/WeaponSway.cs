
using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    [SerializeField] float _swayMouse;
    [SerializeField] float _smooth;
    private void Update()
    {
        InPutMouse();
    }
    void InPutMouse()
    {
        //Input mouse
        float MouseX = Input.GetAxisRaw("MouseX") * _swayMouse;
        float MouseY = Input.GetAxisRaw("MouseY" )* _swayMouse;

        // tinh toan target rotation
        Quaternion rotationX = Quaternion.AngleAxis(-MouseY, Vector3.right);
        Quaternion rotationY = Quaternion.AngleAxis(MouseX, Vector3.up);

        Quaternion targetRotation = rotationX * rotationY;


        //rotate
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, _smooth * Time.deltaTime);


    }


}
