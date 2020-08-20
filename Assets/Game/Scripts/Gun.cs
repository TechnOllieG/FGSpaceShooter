using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float machineGunCooldown;
    public GameObject MachineGunAmmo;
    public Transform LeftGunTransform;
    public Transform RightGunTransform;
    public float ShootCooldown;
    private GameObject machineGunAmmoClone1;
    private GameObject machineGunAmmoClone2;
    private float currentMachineGunCooldown = 0;
    

    private Quaternion dirQuaternion;

    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        currentMachineGunCooldown -= Time.deltaTime;
        if (Input.GetMouseButton(0) && currentMachineGunCooldown <= 0)
        {

            dirQuaternion = transform.rotation;
            machineGunAmmoClone1 = Instantiate(MachineGunAmmo,LeftGunTransform.position, dirQuaternion);
            machineGunAmmoClone2 = Instantiate(MachineGunAmmo, RightGunTransform.position, dirQuaternion);
            currentMachineGunCooldown = ShootCooldown;
        }



    }
}
