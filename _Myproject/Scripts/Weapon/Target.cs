using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [Header("Heath")]
    [SerializeField] int _heath = 50;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamge(int Amount)
    {
        _heath -= Amount;
        if(_heath <= 0f)
        {
            Die();
        }    
    }
    void Die()
    {
        Destroy(gameObject);
    }    
}
