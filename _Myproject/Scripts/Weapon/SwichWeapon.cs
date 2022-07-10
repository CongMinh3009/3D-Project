using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwichWeapon : MonoBehaviour
{
    [SerializeField] int selectWeapon = 0;


    private void Start()
    {
        SelectWeapon();
    }
    private void Update()
    {
        PreviousSelectWeapon();
    }
    void PreviousSelectWeapon()
    {
        int  previousSeletctedWeapon = selectWeapon;
        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectWeapon >= transform.childCount - 1)
            {
                selectWeapon = 0;
            }
            else { selectWeapon--; }
        }
    }
    void KeyAlpha()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            selectWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            selectWeapon = 2;
        }
       
    }
    void SelectWeapon()
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if(i == selectWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);

            }
            i++;
        }
    }
}
