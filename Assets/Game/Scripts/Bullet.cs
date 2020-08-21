using UnityEngine;

namespace FG
{
    public class Bullet : MonoBehaviour
    {
        public float damage;

        private Rigidbody2D rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            rb.AddForce(transform.up * 20, ForceMode2D.Impulse);
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.CompareTag("Enemy"))
            {
                collider.gameObject.GetComponent<Enemy>().TakeDamage(damage);
                Destroy(gameObject);
            }
            else if(collider.CompareTag("Wall"))
            {
                Destroy(gameObject);
            }
        }
    }
}