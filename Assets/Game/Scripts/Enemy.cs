using UnityEngine;

namespace FG
{
    public class Enemy : MonoBehaviour
    {
        public float enemySpeedMultiplier;

        private void Awake()
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up * enemySpeedMultiplier, ForceMode2D.Impulse);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            GameObject.Destroy(this.gameObject);
            if(collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<PlayerController>().hp -= 1;
            }
        }
    }
}
