using UnityEngine;

namespace FG
{
    public class Enemy : MonoBehaviour
    {
        [Tooltip("The multiplier for which to multiply the enemies initial force added (as they enter the scene)")]
        public float enemySpeedMultiplier;
        [Tooltip("The minimum velocity the enemy should bounce of the walls at")]
        public float minVelocity;
        [Tooltip("The hitpoints of the enemy, 1 will kill it in one machine gun shot")]
        public float hp = 1;
        [Tooltip("The explosion to be played when enemy has died")]
        public ParticleSystem deathVFX;

        private Rigidbody2D rb;
        private Vector3 lastVelocity;
        private float speed;
        private Vector3 direction;
        private GameObject player;
        private PlayerController playerController;
        private bool pointGiven = false;

        private void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player"); // Expensive, but the only way I thought of to add a points system
            playerController = player.GetComponent<PlayerController>();

            Physics2D.IgnoreLayerCollision(10, 10);
            rb = GetComponent<Rigidbody2D>();
            rb.AddForce(transform.up * enemySpeedMultiplier, ForceMode2D.Impulse);
        }

        public void TakeDamage(float damage)
        {
            hp -= damage;
            if (hp <= 0)
            {
                if(!pointGiven)
                {
                    playerController.points++;
                    pointGiven = true;
                }
                Death();
            }
        }

        private void Update()
        {
            lastVelocity = rb.velocity;
        }

        private void Death()
        {
            ParticleSystem particleSystem= Instantiate(deathVFX, transform.position, Quaternion.identity);
            Invoke("Destroy(particleSystem)", 1f);

            Destroy(gameObject);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                Death();
                collision.gameObject.GetComponent<PlayerController>().hp -= 1;
            }
            else if (collision.gameObject.tag == "Wall")
            {
                speed = lastVelocity.magnitude;
                direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

                rb.velocity = direction * Mathf.Max(speed, minVelocity);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            GetComponent<CircleCollider2D>().isTrigger = false;
        }
    }
}
