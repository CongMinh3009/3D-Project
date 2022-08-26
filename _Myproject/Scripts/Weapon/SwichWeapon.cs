using UnityEngine;

public class SwichWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] _gameObjectsWeapon;
    [SerializeField] Gun[] isReloading;
    [SerializeField] Gun[] isFire;



    private void Start()
    {
        startWeapon();
    }
    private void Update()
    {
        InputKeyPad();
        mouseScrollWheel();
    }
    void mouseScrollWheel()
    {
       if(Input.GetAxis("Mouse ScrollWheel") > 0f )
        {
            SetBoolIsReloading();
            SetBoolIsFire();


            _gameObjectsWeapon[1].SetActive(true);
            _gameObjectsWeapon[0].SetActive(false);
          
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            SetBoolIsReloading();
            SetBoolIsFire();


            _gameObjectsWeapon[0].SetActive(true);
            _gameObjectsWeapon[1].SetActive(false);
        }   
      
    }
    void InputKeyPad()
    {
        
        if( Input.GetKeyDown(KeyCode.Alpha1) )
        {
            SetBoolIsReloading();
            SetBoolIsFire();

              _gameObjectsWeapon[0].SetActive(true);
            _gameObjectsWeapon[1].SetActive(false);
           
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) )
        {
            SetBoolIsReloading();
            SetBoolIsFire();

             _gameObjectsWeapon[1].SetActive(true);
            _gameObjectsWeapon[0].SetActive(false);
           
        }
      
    }
    void startWeapon()
    {
        _gameObjectsWeapon[0].SetActive(true);
        _gameObjectsWeapon[1].SetActive(false);
    }
    void SetBoolIsFire()
    {
        foreach (Gun fire in isFire)
        {
            fire.Firing = false;
        }
    }
    void SetBoolIsReloading()
    {   
        foreach(Gun reloading in isReloading)
        {
            reloading._isReloading = false;
        }
    }
}
