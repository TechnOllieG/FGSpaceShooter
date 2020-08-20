using UnityEngine;

namespace FG
{
    public class Gun : MonoBehaviour
    {
        public float machineGunCooldown;
        public GameObject MachineGunAmmo;
        public Transform LeftGunTransform;
        public Transform RightGunTransform;
        public float ShootCooldown;

        private float currentMachineGunCooldown = 0;

        private Quaternion dirQuaternion;

        void Update()
        {
            currentMachineGunCooldown -= Time.deltaTime;
            if (Input.GetMouseButton(0) && currentMachineGunCooldown <= 0)
            {
                dirQuaternion = transform.rotation;
                Instantiate(MachineGunAmmo, LeftGunTransform.position, dirQuaternion);
                Instantiate(MachineGunAmmo, RightGunTransform.position, dirQuaternion);

                currentMachineGunCooldown = ShootCooldown;
            }
        }
    }
}