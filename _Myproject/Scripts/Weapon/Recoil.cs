
using UnityEngine;


public class Recoil : MonoBehaviour
{
    Vector3 currentPosition, targetRotation, currentRotation, initGunPosition;
    [SerializeField] Transform _camera;
    [SerializeField] float _recoilX;
    [SerializeField] float _recoilY;
    [SerializeField] float _recoilZ;

    [SerializeField] float _kichBackZ;

    [SerializeField] float snappiness, returnAmount;




    private void Start()
    {
        initGunPosition = transform.localPosition;
    }
    private void Update()
    {
        caculateRotation();
        back();
    }
    public void caculateRotation()
    {
        targetRotation = Vector3.Lerp(targetRotation, Vector3.zero, Time.deltaTime * returnAmount);
        currentRotation = Vector3.Slerp(currentRotation, targetRotation, Time.fixedDeltaTime * snappiness);
        transform.localRotation = Quaternion.Euler(currentRotation);

    }
    public void recoil()
    {
        targetRotation -= new Vector3(0, 0, _kichBackZ);
        targetRotation += new Vector3(Random.Range(0,-_recoilX), Random.Range(-_recoilY, _recoilY), _recoilZ);
    }
    public void back()
    {
        targetRotation = Vector3.Lerp(targetRotation, initGunPosition, Time.deltaTime * returnAmount);
        currentPosition = Vector3.Lerp(currentPosition, targetRotation, Time.deltaTime * snappiness);
    }
}
