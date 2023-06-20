using System;
using UnityEngine;

namespace Scenes.EnemiesTest.Scripts
{
    public class BossBehavior: MonoBehaviour
    {
        public GameObject player;
        private Transform bossTransform;
        private GameObject leftArm;
        private GameObject rightArm;
        private GameObject leftWeapon;
        private GameObject rightWeapon;
        private GameObject upDome;
        private GameObject downDome;
        private GameObject boneMain;

        private float rightArmHealth = 100;
        private float leftArmHealth = 100;
        private float downHealth = 100;
        private float upHealth = 100;
        private float boneHealth = 100;

        void Start()
        {
            bossTransform = gameObject.transform;
            leftArm = bossTransform.Find("Left_Arm").gameObject;
            rightArm = bossTransform.Find("Right_Arm").gameObject;
            leftWeapon = bossTransform.Find("Left_Weapons").gameObject;
            rightWeapon = bossTransform.Find("Right_Weapon").gameObject;
            upDome = bossTransform.Find("Up").gameObject;
            downDome = bossTransform.Find("Down").gameObject;
            boneMain = bossTransform.Find("Bone_Main").gameObject;
        }

        private void Update()
        {
            gameObject.transform.LookAt(player.transform.position);
            // Destroy(downDome);
            // Destroy(leftArm);
        }

        private void Shoot(GameObject origin)
        {
            
        }
    }
}