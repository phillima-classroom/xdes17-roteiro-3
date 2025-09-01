using System;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{

    Rigidbody2D _rb;
    Animator _animator;

    [SerializeField] float speedY;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        
        _rb.AddForceY(-speedY, ForceMode2D.Impulse);

        _animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        _animator.enabled = true;
        Destroy(gameObject,0.5f);
    }
}