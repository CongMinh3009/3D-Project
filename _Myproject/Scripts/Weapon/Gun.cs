using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Damged")]
    [SerializeField] int _damged = 10;


    public int Dameged()
    {
        return _damged;
    }    
}
