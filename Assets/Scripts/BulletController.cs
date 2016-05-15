using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour
{
    public float bulletDuration;

    private float bulletTimer;
    // Use this for initialization
    void Start()
    {
        bulletTimer = bulletDuration;
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
}