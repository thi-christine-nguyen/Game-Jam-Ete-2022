using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{

    private Rigidbody2D m_rigidBody;
    private float m_movementSpeed = 6f;
    private bool m_isGrounded;
    private float m_currentJumpTimecounter;
    private bool m_isJumping;
    private float m_checkRadius = 0.3f;
    private float jumpForce = 9f;
    private float m_maxJumpTime = 0.2f;

    public LayerMask m_groundLayer;
    public Transform m_feet;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horitonalInput = Input.GetAxisRaw("Horizontal");
        Vector2 position = transform.position;
        position.x += + m_movementSpeed * horitonalInput * Time.deltaTime;
        transform.position = position;

        float jumpInput = Input.GetAxisRaw("Jump");

        m_isGrounded = Physics2D.OverlapCircle(m_feet.position, m_checkRadius, m_groundLayer);
        Debug.Log(m_isGrounded);
        if(m_isGrounded == true && jumpInput == 1) 
        {
            m_isJumping = true;
            m_currentJumpTimecounter = m_maxJumpTime;
            m_rigidBody.velocity = Vector2.up * jumpForce;
        }
        if(jumpInput == 1 && m_isJumping)
        {
            if(m_currentJumpTimecounter > 0)
            {
                m_rigidBody.velocity = Vector2.up * jumpForce;
                m_currentJumpTimecounter -= Time.deltaTime;
            }
            else
            {
                m_isJumping = false;
            }
        }
        if (jumpInput == 0)
        {
            m_isJumping = false;
        }
    }
}