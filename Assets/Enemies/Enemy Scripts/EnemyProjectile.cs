using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody rb;
    private GameObject player;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag(Tags.PLAYER_TAG);
    }

    private void Start()
    {
        Vector3 dir = player.transform.position - transform.position;
        dir.y += 1;
        dir.Normalize();

        rb.velocity = dir * speed;

        transform.LookAt(player.transform);
        transform.Rotate(80, transform.rotation.y, transform.rotation.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals(Tags.PLAYER_TAG))
        {
            other.gameObject.GetComponent<HealthScript>().ApplyDamage(5, false);
        }

        if(!other.gameObject.tag.Equals(Tags.ENEMY_TAG))
            Destroy(gameObject);
    }
}
