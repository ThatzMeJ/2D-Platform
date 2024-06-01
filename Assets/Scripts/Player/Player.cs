using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStateMachine stateMachine { get; private set; }

    [SerializeField] private float speed;
    [SerializeField] private float xFloat;
    [SerializeField] private float jumpingPower;
    [SerializeField] private bool isFacingRight;

    [Header("Ground Check Info")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] public float groundCheckDistance;
    
    #region Components

    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public Animator anim;
    [SerializeField] public SpriteRenderer sr;
    [SerializeField] public BoxCollider2D col;
    
    #endregion

    #region States
    public IState idleState { get; private set; }
    public IState walkState { get; private set; }
    #endregion
    
    private void Awake()
    {
        stateMachine = new PlayerStateMachine();
        
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        sr = GetComponentInChildren<SpriteRenderer>();
        
        //States
        idleState = new PlayerIdleState(this, stateMachine);
        walkState = new PlayerWalkState(this, stateMachine);
    }


    private void Start()
    {
        stateMachine.Initialize(idleState);
        
    }

    private void Update()
    {   
        stateMachine.Update();
    }

    public bool isGrounded()
    {
        return Physics2D.Linecast(groundCheck.position, groundCheck.position + Vector3.down * groundCheckDistance, whatIsGround);
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        
        //Draw a line downward from the GroundCheck position
        Gizmos.DrawLine(groundCheck.position, groundCheck.position + Vector3.down * groundCheckDistance); 
    }

    
}
