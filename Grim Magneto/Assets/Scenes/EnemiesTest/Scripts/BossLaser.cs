using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = System.Random;

public class BossLaser : MonoBehaviour
{
    public float shootRate = 3f;
    private float m_shootRateTimeStamp;
    public GameObject player;

    public GameObject m_shotPrefab;
    public ParticleSystem colliderExplosion;
    public AudioSource explosionSound;
    public GameObject sourceObject;
    public GameObject leftArm;
    public GameObject rightArm;
    public Boolean isMain;
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
            
            if (isMain)
            {
                if (leftArm != null || rightArm != null)
                {
                    return;
                }
            }
            
            if (health == 0)
            {
                Explode();
                Destroy(sourceObject);
            }
            else
            {
                health--;
            }

        }
    }
    
    // private void OnCollisionEnter(Collision other)
    // {
    //     if (other.gameObject.name.Contains("Laser"))
    //     {
    //         Spark();
    //         
    //         if (isMain)
    //         {
    //             if (leftArm != null || rightArm != null)
    //             {
    //                 return;
    //             }
    //         }
    //     
    //         if (health == 0)
    //         {
    //             Explode();
    //             Destroy(sourceObject);
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
        Spark();
        if (isMain)
        {
            if (leftArm != null || rightArm != null)
            {
                return;
            }
        }
        
        if (other.name.Contains("Grenade") || other.name.Contains("Lightning"))
        {
            Explode();
            Destroy(sourceObject);
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
