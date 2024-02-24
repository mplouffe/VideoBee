using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace lvl_0
{
    public class WindController : MonoBehaviour
    {
        [SerializeField]
        private Vector3 m_wind;

        private bool m_isBlowing;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!m_isBlowing && collision.CompareTag("Player"))
            {
                var beeController = collision.GetComponent<BeeController>();
                beeController.ChangeWind(m_wind);
                m_isBlowing = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (m_isBlowing && collision.CompareTag("Player"))
            {
                var beeController = collision.GetComponent<BeeController>();
                beeController.ChangeWind(Vector3.zero);
                m_isBlowing = false;
            }
        }
    }
}
