using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D m_rigidBody;

    [SerializeField]
    private Vector3 m_direction = Vector3.up;

    [SerializeField]
    private float m_minimumSpeed;

    [SerializeField]
    private float m_boostSpeed;

    [SerializeField]
    private float m_turningRadius;

    [SerializeField]
    private float m_maxVelocityChange;

    private Controls m_controls;

    private BeeState m_beeState;

    public Action<Collider2D> OnBeeCollison;

    // Start is called before the first frame update
    void Awake()
    {
        m_controls = new Controls();
        m_controls.Level.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        switch (m_beeState)
        {
            case BeeState.Alive:
                UpdateDirection();
                UpdateVelocity();
                UpdateRotation();
                break;

        }
    }

    public void SetState(BeeState newState)
    {
        switch (newState)
        {
            case BeeState.Resting:
            case BeeState.Dead:
                m_rigidBody.velocity = Vector3.zero;
                m_rigidBody.freezeRotation = true;
                break;
            case BeeState.Alive:
                m_rigidBody.freezeRotation = false;
                break;
        }
        m_beeState = newState;
    }

    private void UpdateDirection()
    {
        m_direction.Normalize();
        m_direction = Vector3.MoveTowards(m_direction, m_controls.Level.Move.ReadValue<Vector2>(), m_turningRadius);
    }

    private void UpdateVelocity()
    {
        var desiredSpeed = m_controls.Level.Boost.IsPressed() ? m_boostSpeed : m_minimumSpeed;
        var desiredVelocity = m_direction * desiredSpeed;
        m_rigidBody.velocity = Vector3.MoveTowards(m_rigidBody.velocity, desiredVelocity, m_maxVelocityChange);
    }

    private void UpdateRotation()
    {
        var zRotation = Mathf.Atan2(-m_rigidBody.velocity.x, m_rigidBody.velocity.y) * Mathf.Rad2Deg;
        transform.localEulerAngles = new Vector3(0, 0, zRotation);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (m_beeState == BeeState.Alive)
        {
            OnBeeCollison?.Invoke(collision.collider);
        }
    }
}

public enum BeeState
{
    Alive,
    Dead,
    Resting
}
