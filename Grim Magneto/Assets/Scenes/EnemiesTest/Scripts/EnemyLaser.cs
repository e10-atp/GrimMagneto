using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    public float shootRate = 3f;
    private float m_shootRateTimeStamp;
    public GameObject player;

    public GameObject m_shotPrefab;
    public ParticleSystem colliderExplosion;
    public AudioSource explosionSound;
    public ParticleSystem hitEffect;
    
    float range = 1000.0f;
    
    public int health = 1;

    private void Start()
    {
        m_shootRateTimeStamp = Time.time + 3f;
    }

    void Update()
    {

        if (Time.time > m_shootRateTimeStamp)
        {
            ShootRay();
            m_shootRateTimeStamp = Time.time + shootRate;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Laser"))
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

    void ShootRay()
    {
        GameObject laser = GameObject.Instantiate(m_shotPrefab, transform.position, transform.rotation) as GameObject;
        laser.GetComponent<EnemyShotBehavior>().setTarget(player.transform.position);

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
