using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour
{
    public float bulletDuration;

    private PlayerController playerControl;
    private float bulletTimer;
    // Use this for initialization
    void Start()
    {
        bulletTimer = bulletDuration;

        GameObject Player = GameObject.Find("Player");
        playerControl = Player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bulletTimer > 0)
        {
            bulletTimer -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.CompareTag("EnemyBullet")) 
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
        else
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                Destroy(other.gameObject);
                playerControl.count += 5;
                playerControl.SetCountText();
                Destroy(gameObject);
            }
        }
    }
}