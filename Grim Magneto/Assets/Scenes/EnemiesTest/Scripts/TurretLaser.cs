using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class TurretLaser : MonoBehaviour
{
    public float shootRate = 3f;
    private float m_shootRateTimeStamp;
    public GameObject player;

    public GameObject m_shotPrefab;
    public ParticleSystem colliderExplosion;
    public AudioSource explosionSound;
    public GameObject muzzle;
    public ParticleSystem hitEffect;
    
    float range = 1000.0f;
    
    public int health = 1;

    private void Start()
    {
        m_shootRateTimeStamp = Time.time + 3f;
    }

    void Update()
    {
        var lookPos = player.transform.position - transform.position;
        lookPos.y = transform.position.y;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = rotation;
        transform.Rotate(-90, -90, 90);

        if (Time.time > m_shootRateTimeStamp)
        {
            ShootRay(lookPos);
            m_shootRateTimeStamp = Time.time + shootRate;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Laser") || other.gameObject.name.Contains("Lightning"))
        {
            Spark();
            if (health == 0)
            {
                Explode();
                Destroy(gameObject);
            }
            else
            {
                health--;
            }

        }
    }
    
    // private void OnCollisionEnter(Collision other)
    // {
    //     if (other.gameObject.name.Contains("Laser") || other.gameObject.name.Contains("Lightning"))
    //     {
    //         if (health == 0)
    //         {
    //             Explode();
    //             Destroy(gameObject);
    //         }
    //         else
    //         {
    //             health--;
    //         }
    //
    //     }
    // }
    
    private void OnParticleCollision(GameObject other)
    {
        if (other.name.Contains("Grenade") || health == 0)
        {
            Spark();
            Explode();
            Destroy(gameObject);
        } else if (other.name.Contains("Lightning"))
        {
            health--;
        }
    }

    void ShootRay(Vector3 lookPos)
    {
        Vector3 muzzlePos = muzzle.transform.position;
        Vector3 playerPos = player.transform.position;
        Vector3 shootPos = new Vector3(playerPos.x, muzzlePos.y, playerPos.z);
        GameObject laser = GameObject.Instantiate(m_shotPrefab, muzzlePos, player.transform.rotation) as GameObject;
        laser.GetComponent<EnemyShotBehavior>().setTarget(shootPos);

    }

    void Explode()
    {
        ParticleSystem explosion = Instantiate(colliderExplosion);

        explosion.transform.position = transform.position;
        explosion.loop = false;
        explosion.Play(true);
        Destroy(explosion, explosion.duration);
        explosionSound.Play();

    }
    
    void Spark()
    {
        ParticleSystem spark = Instantiate(hitEffect);

        spark.transform.position = transform.position;
        spark.loop = false;
        spark.Play(true);
        Destroy(spark, spark.duration);
    }
}
