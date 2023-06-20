using System;
using UnityEngine;

namespace Scenes.EnemiesTest.Scripts
{
    public class EnemyLinearPath: MonoBehaviour
    {
        public GameObject startObj;
        public GameObject endObj;
        private Vector3 endPos;
        private Vector3 startPos;
        public float lerpTime = 3f;
        private float elapsedTime = 0f;
        public GameObject player;
        private Boolean forward;

        public void Start()
        {
            endPos = endObj.transform.position;
            startPos = startObj.transform.position;
            forward = true;
        }

        public void Update()
        {
            if (elapsedTime > lerpTime)
            {
                forward = !forward;
                elapsedTime = 0;
            }
            elapsedTime += Time.deltaTime;
            Vector3 newPos;
            if (forward)
            {
                newPos = Vector3.Lerp(startPos, endPos, elapsedTime / lerpTime);
            }
            else
            {
                newPos = Vector3.Lerp(endPos, startPos, elapsedTime / lerpTime);
            }
            
            gameObject.transform.SetPositionAndRotation(newPos, gameObject.transform.rotation);
            transform.LookAt(player.transform.position);
            Debug.Log("newPos: " + newPos);
            

        }
    }
}