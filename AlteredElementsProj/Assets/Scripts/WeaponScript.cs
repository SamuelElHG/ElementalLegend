using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] private string mensaje;
 
    public void imAlive()
    {
        Debug.Log(mensaje);
    }
}
