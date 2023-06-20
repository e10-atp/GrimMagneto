using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class EnemyPathFollower : MonoBehaviour
{
    public PathCreator pathCreator;
    public float speed = 5;
    public GameObject lookAt;
    float distanceTravelled;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distanceTravelled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
        transform.LookAt(lookAt.transform);
    }
}
