using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    float speed; //bullet speed
    Vector2 _direction; //the direction of the bullet
    bool isReady; //to know when the bullet direction is set

    //default values:
    private void Awake()
    {
        speed = 5f;
        isReady = false;
    }

    // Use this for initialization
    void Start()
    {

    }

    //bullet's direction:
    public void SetDirection(Vector2 direction)
    {
        _direction = direction.normalized;

        isReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isReady)
        {
            Vector2 position = transform.position; //bullet's current pos

            position += _direction * speed * Time.deltaTime; //calculate bullet's new pos

            transform.position = position; //update bullet's position

            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

            if ((transform.position.x < min.x) || (transform.position.x > max.x) ||
                    (transform.position.x < min.y) || (transform.position.x > max.y))
            {
                Destroy(gameObject); //destroy if it's out of bounds
            }
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
