using UnityEngine;
using System;
public class GrenadeHit: MonoBehaviour
{
    private Boolean isActivated = false;
    private float elapsedTime = 0f;
    private float detonationTime = 2;
    public ParticleSystem grenadeExplosion;

    private void Update()
    {
        if (isActivated)
        {
            if (elapsedTime > detonationTime)
            {
                Detonate();
                elapsedTime = 0;
                Destroy(gameObject);
            }
            else
            {
                elapsedTime += Time.deltaTime;
            }
        }
    }
    
    // private void OnParticleCollision(GameObject other)
    // {
    //     if (other.name.Contains("Enemy"))
    //     {
    //         Destroy(other); 
    //     }
    // }

    public void ActivateGrenade()
    {
        isActivated = true;
    }

    private void Detonate()
    {
        ParticleSystem explosion = Instantiate(grenadeExplosion);

        explosion.transform.position = transform.position;
        explosion.loop = false;
        explosion.Play(true);
        Destroy(explosion, explosion.duration);
    }
}

