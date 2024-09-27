using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
    public float speed;
    private float distance;

    private void Start() 
    {
        // player = FindAnyObjectByType<PlayerController>().gameObject;
        player = GameObject.FindWithTag("Player");
    }

    private void Update() {

        if(player != null)
        {
            distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - transform.position;
            direction.Normalize();

            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if(collision.tag != "Lightning")
        // {
        //     gameObject.transform.parent = collision.gameObject.transform;
        //     Destroy(GetComponent<Rigidbody>());
        //     GetComponent<BoxCollider2D>().enabled = false;
        // }
        if(collision.tag == "Player")
        {
            var healthComponent = collision.GetComponent<Health>();
            if(healthComponent != null)
            {
                healthComponent.TakeDamage(1);
            }

            Destroy(gameObject);
        }
    }
}
