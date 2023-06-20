using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class WallBehavior : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("wall collision with: " + other.gameObject.name);
        if (other.gameObject.name.Contains("shot_prefab") || other.gameObject.name.Contains("Laser"))
        {
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("wall trigger collision with: " + other.gameObject.name);
        if (other.gameObject.name.Contains("shot_prefab") || other.gameObject.name.Contains("Laser"))
        {
            Destroy(other.gameObject);
        }
    }
}
