using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Rigidbody2D rb;
    private Vector3 direction;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * 20, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject.Destroy(this.gameObject);
    }
}
