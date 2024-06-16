using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public AudioClip Sound;
    public float Speed; 

    private Rigidbody2D RigidBody2d;
    private Vector2 Direction;
    
    void Start()
    {
        RigidBody2d = GetComponent<Rigidbody2D>();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
    }


    private void FixedUpdate()
    {
        RigidBody2d.velocity = Direction * Speed;
    }

    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        JhonMovment jhon = collision.GetComponent<JhonMovment>();
        GruntScript grunt = collision.GetComponent<GruntScript>();
        if (jhon != null)
        {
            jhon.Hit();
        }
        if (grunt != null)
        {
            grunt.Hit();
        }

        DestroyBullet();
    }


 

}
