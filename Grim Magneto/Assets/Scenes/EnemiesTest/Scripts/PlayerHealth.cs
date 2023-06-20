using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerHealth : MonoBehaviour
{
    public GameObject m_health;
    
    private TextMeshProUGUI health;
    private CapsuleCollider playerCollider;

    private int totalHealth = 10000;
    private int damageBase = 10;
    private int hits = 0;

    private String healthText;

    private int isHit = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        health = m_health.GetComponent<TextMeshProUGUI>();
        playerCollider = gameObject.GetComponent<CapsuleCollider>();
        
        healthText = health.text;
        
        health.text = healthText + " " + totalHealth;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("shot_prefab"))
        {
            if (isHit == 0)
            {
                Debug.Log("player trigger collision with: " + other.gameObject.name);
                int randomDmg = Random.Range(-5, 5);
                totalHealth -= (damageBase + randomDmg);
                hits += 1;
                
                if (totalHealth >= 0)
                {
                    health.text = healthText + " " + totalHealth;
                }
                else
                {
                    health.text = healthText + " " + 0;
                }

                isHit += 1;
            }
            else
            {
                isHit = 0;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
