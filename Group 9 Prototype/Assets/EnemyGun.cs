using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{

    public GameObject EnemyBullet;

    // Use this for initialization
    void Start()
    {
        //fire enemy bullet after 1 second
        Invoke("FireEnemyBullet", 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FireEnemyBullet()
    {
        GameObject playerChar = GameObject.Find("Player"); //refrence to player

        // if player isn't dead
        if (playerChar != null)
        {
            //instantiate an enemy bullet
            GameObject bullet = (GameObject)Instantiate(EnemyBullet);

            //set bullet's initial pos
            bullet.transform.position = transform.position;




        }
    }
}
