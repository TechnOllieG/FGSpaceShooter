using UnityEngine;

public class MachineGun : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(this);
        Debug.Log("Trigger has been entered");
    }
}
