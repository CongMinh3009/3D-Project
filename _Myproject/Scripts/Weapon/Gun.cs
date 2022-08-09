using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Damged")]
    [SerializeField] int _damged = 10;


    [Header("Animator")]
    [SerializeField] Animator _animGun;
    [SerializeField] Animator _animArms;


    [Header("Shotting")]
    [Range(0f, Mathf.Infinity)]
    [SerializeField] float _range;
    [SerializeField] Camera _fpsCam;
    [SerializeField] float _fireRate;
    [SerializeField] float _nextTimeToFire;
    [SerializeField] LayerMask layerMask;
    
    //[Header("Muzzle Flash")]
    //[SerializeField] GameObject _muzzleFlash;
   

    [Header("Impact&Muzzle")]
    [SerializeField] float _impactForce;
    [SerializeField]public ImpactInfo[] ImpactElements;
    [SerializeField] ParticleSystem[] _muzzleEffect;
    [SerializeField] GameObject _pointLight;

    private void Update()
    {
        InputMouse();
    }
   

    void InputMouse()
    {

        if (Input.GetMouseButton(0) && Time.time >= _nextTimeToFire)
        {
            _nextTimeToFire = Time.time + 1 / _fireRate;
            Shot();
            SetAnimation();
        }
        else
        {
            _pointLight.SetActive(false);
        }


    }
    void SetAnimation()
    {
        _animGun.SetTrigger("isFire");
        _animArms.SetTrigger("isFire");

    }
   
    void Shot() 
    {
        _pointLight.SetActive(true);
        foreach(var muzzle in _muzzleEffect)
        {
            muzzle.Play();
        }
        //_muzzleFlash.SetActive(true);
        RaycastHit hit;
        if (Physics.Raycast(_fpsCam.transform.position, transform.forward, out hit, _range,layerMask))
        {
            Debug.Log(hit.transform.name, hit.transform.gameObject);
        }
        
        var effect = TakeImpactEffect(hit.transform.gameObject);
        //if (effect != null) { }
        
        // không có bắn trúng GameObject nào thì sẽ trả về bỏ qua
        if (effect == null) return;

        //var _impactEffect = Instantiate(effect, hit.point, Quaternion.LookRotation(hit.normal));

        if (hit.rigidbody != null)
        {
            hit.rigidbody.AddForce(-hit.normal * _impactForce);
        }

       var _impactEffect = Instantiate(effect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(_impactEffect, 3f);
        //Object Pool: EZ Pooling


        Debug.Log("Spawn effect");
        //Debug.Log(_impactEffect);
        Debug.DrawRay(_fpsCam.transform.position, _fpsCam.transform.forward * _range, Color.red);
    }
    [System.Serializable]
    public class ImpactInfo
    {
        public MaterialGunType.MaterialTypeEnum materialType;
        public GameObject _impactEffect;
    }
   
    GameObject TakeImpactEffect(GameObject gameObjectImpact)
    {
        var materialType = gameObjectImpact.GetComponent<MaterialGunType>();
        if (materialType == null) return null;
        foreach(var impactInfo in ImpactElements)
        {
            // tìm trong class ImpactInfo so sánh có == kiểu dữ liệu material không sẽ trả về impact của nó trong class MaterialGunType
            if (impactInfo.materialType == materialType.TypeOfMaterial)
            {
                return impactInfo._impactEffect;
            }
        }
        // nếu không thì sẽ trả về là null (không có)
        return null;
    }
    //cách 1
    //IEnumerator wait()
    //{
    //    yield return new WaitForSeconds(0.02f);
    //    _muzzleFlash.SetActive(false);
    //    _somke.Play();
    //}
}
   
