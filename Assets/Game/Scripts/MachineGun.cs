using UnityEngine;

public class MachineGun : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject.Destroy(this.gameObject);
    }
}
