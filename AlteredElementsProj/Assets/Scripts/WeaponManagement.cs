using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManagement : MonoBehaviour
{
    [SerializeField] private List<WeaponScript> equipedWeapons = new List<WeaponScript>();
    [SerializeField] public WeaponScript activeWeapon;
    // Start is called before the first frame update
    void Start()
    {
        activeWeapon = equipedWeapons[0];
        activeWeapon.gameObject.SetActive(true);
        activeWeapon.imAlive();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.LeftShift)) {
            //selectWeapon(equipedWeapons[1]);
            changeWeapon(equipedWeapons[1]);
        }

        if(Input.GetKeyUp(KeyCode.J))
        {
            activeWeapon.imAlive();
        }
    }

    private void changeWeapon(WeaponScript targetWeapon)
    {
        activeWeapon.gameObject.SetActive(false);
        activeWeapon = targetWeapon;
        activeWeapon.gameObject.SetActive(true);
        activeWeapon.imAlive();


    }
}
