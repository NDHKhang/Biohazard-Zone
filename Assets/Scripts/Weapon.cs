using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Camera FPCamera;
    [SerializeField] private float range = 50f;
    [SerializeField] private InputActionReference fire;

    void Update()
    {
        //if (fire.action.ReadValue<float>() == 1)
        //{
            //Fire();
        //}
        if (fire.action.triggered)
        {
            Fire();
        }
    }

    void Fire()
    {
        RaycastHit hit;
        Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range);
        print($"{hit.collider.name} was hit");
        
    }
}
