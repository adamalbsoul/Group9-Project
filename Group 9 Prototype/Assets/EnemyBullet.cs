using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    float speed; //bullet speed


    //default values:



    // Use this for initialization
    void Start()
    {
        speed = 10f;
    }



    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position; //bullet's current pos

        position = new Vector2(position.x - speed * Time.deltaTime, position.y); //calculate bullet's new pos

        transform.position = position; //update bullet's position

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));



        if (transform.position.x < min.x)
        {
            Destroy(gameObject); //destroy if it's out of bounds
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {   // destroys the bullet when it hits the player
        if (col.tag == "PlayerShipTag")
        {
            Destroy(gameObject);
        }
    }
}
