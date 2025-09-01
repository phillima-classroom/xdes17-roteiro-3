using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class Nave : MonoBehaviour
{
    Rigidbody2D _rb;

    [SerializeField] GameObject municaoPrefab;
    [SerializeField] Transform armaPosicao;
    [SerializeField] float xSpeed;
    //Taxa de tiro 
    [SerializeField] float fireRate;
    //Ultimo tiro
    float lastFire;
    //Verificar se o botao esta pressionado
    bool attackBtnPressed;
    
    float xDir;
    
    
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        lastFire = Time.time;
    }

    void Update()
    {
        if(attackBtnPressed)
            Atirar();
    }

    //Chamado pelo PlayerInput
    void OnAttack(InputValue inputValue)
    {
        attackBtnPressed = inputValue.isPressed;
    }
    
    void FixedUpdate()
    {
        Movimentar();
    }
    void OnMove(InputValue inputValue)
    {
        //Extraindo apenas a componente X do mapa de ações.
        xDir = inputValue.Get<Vector2>().x;
    }
    void Movimentar()
    {
        //Modificar a velocidade no componente X
        _rb.linearVelocityX = xDir * xSpeed * Time.deltaTime; 
    }
    

    void Atirar()
    {
        if (Time.time > lastFire + fireRate)
        {
            lastFire = Time.time;
            Instantiate(municaoPrefab, armaPosicao.position, Quaternion.identity);
        }
    }
    
}