using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject explosion;

    float speed;

    // Use this for initialization
    void Start()
    {
        speed = -2f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position; //get the current position of the enemy

        position = new Vector2(position.x + speed * Time.deltaTime, position.y); //Compute the new position of the enemy

        transform.position = position; //update enemy position

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); // end of screen

        if (transform.position.x < min.x)
        {
            Destroy(gameObject);
        }
    }

    //collision
    void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.tag == "PlayerShipTag") || (col.tag == "PlayerBulletTag"))
        {
            PlayExplosion();
            Destroy(gameObject); //destroy player's ship
        }
    }

    // instantiate explosion
    void PlayExplosion()
    {
        GameObject boom = (GameObject)Instantiate(explosion);

        //set position of explosion
        boom.transform.position = transform.position;
    }
}
