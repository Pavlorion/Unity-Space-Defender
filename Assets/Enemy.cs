
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 1f;
    [SerializeField] float maxTimeBetweenShots = 2f;
    [SerializeField] GameObject enemyLaser;
    // Start is called before the first frame update
    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        CountAndShoot();
    }

    private void CountAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if(shotCounter <= 0)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire()
    {
        GameObject laserProjectile = Instantiate(enemyLaser, transform.position, Quaternion.identity) as GameObject;
        laserProjectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -20f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damage = collision.gameObject.GetComponent<DamageDealer>();
        ProcessHit(damage);
    }

    private void ProcessHit(DamageDealer damage)
    {
        health -= damage.GetDamage();
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
