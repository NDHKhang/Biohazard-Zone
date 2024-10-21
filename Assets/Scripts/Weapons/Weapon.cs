using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Camera FPCamera;

    [SerializeField] WeaponData weaponData;

    [Tooltip("Determine how far the bullet go")]
    [SerializeField] private float range = 50f;

    [Header("References")]
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private GameObject hitEffect;
    [SerializeField] private GameObject parent;

    private float weaponDamage;
    void Start()
    {
        weaponDamage = weaponData.damage;
    }

    void Update()
    {

    }

    void OnFire(InputValue value)
    {
        if (value.isPressed)
        {
            Fire();
        }
    }

    void Fire()
    {
        muzzleFlash.Play();

        RaycastHit hit; //Variable for storing the information of WHAT WE HIT

        //Firing
        if(Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            Debug.Log("Hit" + hit.transform.name);

            EnemyHealth enemyHealth = hit.transform.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(weaponDamage);
            }

            GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal), parent.transform);
            Destroy(impact, 1f);
        }
    }
}
