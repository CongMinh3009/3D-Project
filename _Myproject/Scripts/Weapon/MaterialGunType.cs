using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialGunType : MonoBehaviour
{
    public MaterialTypeEnum TypeOfMaterial;

    [System.Serializable]
    public enum MaterialTypeEnum 
    {
        Plaster,
        Metall,
        Folliage,
        Rock,
        Wood,
        Brick,
        Concrete,
        Dirt,
        Glass,
        Water
    }
}
