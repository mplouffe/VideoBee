using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace lvl_0
{
    public class BeeController : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D m_rigidBody;

        [SerializeField]
        private Vector3 m_direction = Vector3.up;

        [SerializeField]
        private Vector3 m_currentWind = Vector3.zero;

        [SerializeField]
        private float m_minimumSpeed;

        [SerializeField]
        private float m_boostSpeed;

        [SerializeField]
        private float m_turningRadius;

        [SerializeField]
        private float m_maxVelocityChange;

        [SerializeField]
        private float m_struggleTime;

        [SerializeField]
        private float m_struggleRange;

        [SerializeField]
        private GameObject m_graphicsGameObject;

        [SerializeField]
        private ParticleSystem m_deathExplosionSystem;

        [SerializeField]
        private Collider2D m_collider;

        private int m_struggleMultiplier = 1;


        private Controls m_controls;

        private BeeState m_beeState;

        public Action<CollisionObject> OnBeeCollison;

        private Duration m_struggleDuration;

        // Start is called before the first frame update
        void Awake()
        {
            m_controls = new Controls();
            m_controls.Level.Enable();
            m_struggleDuration = new Duration(m_struggleTime);
        }

        private void OnEnable()
        {
            m_controls.Level.Escape.performed += OnEscapePressed;
            m_controls.Level.Pause.performed += OnPausePressed;
        }

        private void OnDisable()
        {
            m_controls.Level.Escape.performed -= OnEscapePressed;
            m_controls.Level.Pause.performed -= OnPausePressed;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            switch (m_beeState)
            {
                case BeeState.Alive:
                    UpdateDirection();
                    UpdateVelocity();
                    UpdateRotation();
                    break;
                case BeeState.Trapped:
                    m_struggleDuration.Update(Time.deltaTime);
                    if (m_struggleDuration.Elapsed())
                    {
                        m_struggleDuration.Reset();
                        transform.eulerAngles = new Vector3(0, 0, transform.localEulerAngles.z + m_struggleRange * m_struggleMultiplier);
                        m_struggleMultiplier *= -1;
                    }
                    break;

            }
        }

        public void ChangeState(BeeState newState)
        {
            switch (newState)
            {
                case BeeState.Resting:
                    m_rigidBody.velocity = Vector3.zero;
                    m_rigidBody.freezeRotation = true;
                    break;
                case BeeState.Dead:
                    m_rigidBody.velocity = Vector3.zero;
                    m_rigidBody.freezeRotation = true;
                    m_graphicsGameObject.SetActive(false);
                    m_collider.enabled = false;
                    m_deathExplosionSystem.Play();
                    break;
                case BeeState.Alive:
                    m_rigidBody.freezeRotation = false;
                    m_collider.enabled = true;
                    m_graphicsGameObject.SetActive(true);
                    break;
                case BeeState.Trapped:
                    m_rigidBody.velocity = Vector3.zero;
                    m_rigidBody.freezeRotation = true;
                    m_struggleDuration.Reset();
                    transform.eulerAngles = new Vector3(0, 0, transform.localEulerAngles.z + m_struggleRange * m_struggleMultiplier / 2);
                    break;
                case BeeState.Drown:
                    m_rigidBody.velocity = Vector3.zero;
                    m_rigidBody.freezeRotation = true;
                    m_graphicsGameObject.SetActive(false);
                    m_collider.enabled = false;
                    break;
            }
            m_beeState = newState;
        }

        public void ResetPlayer(Vector3 startingPosition)
        {
            transform.eulerAngles = Vector3.zero;
            transform.position = startingPosition;
            gameObject.SetActive(true);
        }

        public void Eaten()
        {
            ChangeState(BeeState.Dead);
            OnBeeCollison?.Invoke(CollisionObject.Enemy);
        }

        public void Zapped()
        {

            ChangeState(BeeState.Dead);
            OnBeeCollison?.Invoke(CollisionObject.Enemy);
        }

        public void Drowned()
        {
            ChangeState(BeeState.Drown);
            OnBeeCollison?.Invoke(CollisionObject.Enemy);
        }

        public void ChangeWind(Vector3 newWind)
        {
            m_currentWind = newWind;
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
            desiredVelocity += m_currentWind;
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
                if (collision.collider.CompareTag("Flower"))
                {
                    OnBeeCollison?.Invoke(CollisionObject.Flower);
                }
                else if (collision.collider.CompareTag("Beehive"))
                {
                    OnBeeCollison?.Invoke(CollisionObject.Beehive);
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (m_beeState == BeeState.Alive)
            {
                if (collision.CompareTag("SpiderWeb"))
                {
                    ChangeState(BeeState.Trapped);
                }
                else if (collision.CompareTag("UnsafeWall"))
                {
                    ChangeState(BeeState.Trapped);
                }
                else if (collision.CompareTag("WaterDroplet"))
                {
                    ChangeState(BeeState.Trapped);
                }
            }
        }

        private void OnEscapePressed(CallbackContext context)
        {
            if (m_beeState == BeeState.Alive)
            {
                LevelController.Instance.Escape();
            }
        }

        private void OnPausePressed(CallbackContext context)
        {
            if (m_beeState == BeeState.Alive)
            {
                LevelController.Instance.Pause();
            }
        }
    }

    public enum BeeState
    {
        Alive,
        Dead,
        Drown,
        Resting,
        Trapped
    }
}