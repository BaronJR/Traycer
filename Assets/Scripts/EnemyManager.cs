using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

    public float spawnTime;
    public float spawnRange;

    private GameObject Player;
    private GameObject prefabEnemy;
	// Use this for initialization
	void Start () {
        prefabEnemy = Resources.Load("Enemy") as GameObject;

        Player = GameObject.Find("Player");

        InvokeRepeating ("Spawn", spawnTime, spawnTime);
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void Spawn ()
    {
        Vector3 spawnPoint = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), 0);

        //while ((spawnPoint - Player.transform.position).magnitude <= spawnRange)
        //{
        //    spawnPoint = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), 0);
        //}

        Instantiate(prefabEnemy, spawnPoint, Quaternion.identity);
    }
}
