using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    [SerializeField] float _playerDamage;
    [SerializeField] HeathPlayer _playerHeath;

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _playerHeath.CurrentPlayerHeath -= _playerDamage;
            _playerHeath.TakeDamage();
            //gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

}
