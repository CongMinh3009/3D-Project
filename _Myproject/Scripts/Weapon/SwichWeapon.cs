using UnityEngine;

public class SwichWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] _gameObjectsWeapon;

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
       if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            _gameObjectsWeapon[1].SetActive(true);
            _gameObjectsWeapon[0].SetActive(false);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            _gameObjectsWeapon[0].SetActive(true);
            _gameObjectsWeapon[1].SetActive(false);
        }   
    }
    void InputKeyPad()
    {
        
        if( Input.GetKeyDown(KeyCode.Alpha1))
        {
            _gameObjectsWeapon[0].SetActive(true);
            _gameObjectsWeapon[1].SetActive(false);

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _gameObjectsWeapon[1].SetActive(true);
            _gameObjectsWeapon[0].SetActive(false);

        }
    }
    void startWeapon()
    {
        _gameObjectsWeapon[0].SetActive(true);
        _gameObjectsWeapon[1].SetActive(false);
    }

}
