using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public float bulletSpeed;
    public float shotTime;

    private GameObject prefab;
    private GameObject Player;

	// Use this for initialization
	void Start () {
        prefab = Resources.Load("EnemyBullet") as GameObject;
        Player = GameObject.Find("Player");

        InvokeRepeating("EnemyGun", shotTime, shotTime);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void EnemyGun()
    {
        Vector3 enemyAim = Player.transform.position - transform.position;
        enemyAim.Normalize();

        GameObject bullet = Instantiate(prefab) as GameObject;

        bullet.transform.position = transform.position + enemyAim;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = enemyAim * bulletSpeed;
    }
}
