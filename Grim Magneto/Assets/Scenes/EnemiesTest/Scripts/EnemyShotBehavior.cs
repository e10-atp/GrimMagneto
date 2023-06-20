using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotBehavior : MonoBehaviour
{
    public Vector3 m_target;
    public GameObject collisionExplosion;
    public float speed;
    public GameObject enemy;


    // Update is called once per frame
    void Update()
    {
        // transform.position += transform.forward * Time.deltaTime * 300f;// The step size is equal to speed times frame time.
        float step = speed * Time.deltaTime;

        if (m_target != null)
        {
            if (transform.position == m_target)
            {
                Destroy(gameObject);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, m_target, step);
            }
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("destroyed. " + other.gameObject.name);
        Destroy(gameObject);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("laser collide with: " + other.gameObject.name);
        if (other.gameObject.name.Contains("PlayerSet") || other.gameObject.name.Contains("Cube") || other.gameObject.name.Contains("Wall"))
        {
            Debug.Log("destroyed trigger. " + other.gameObject.name);
            Destroy(gameObject);
        }

    }

    public void setTarget(Vector3 target)
    {
        m_target = target;
    }

    void explode()
    {
        if (collisionExplosion  != null) {
            GameObject explosion = (GameObject)Instantiate(
                collisionExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(explosion, 0.02f);
        }

    }
}
