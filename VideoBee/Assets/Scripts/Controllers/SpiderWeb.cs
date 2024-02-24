using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace lvl_0
{
    public class SpiderWeb : MonoBehaviour
    {
        public Action<Vector3, BeeController> OnBeeContact;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                var beeController = collision.GetComponent<BeeController>();
                OnBeeContact?.Invoke(collision.transform.position, beeController);
            }
        }

        public void Span(Vector3 start, Vector3 end)
        {
            if (!Mathf.Approximately(start.x, end.x) || start.y < end.y)
            {
                return;
            }

            var length = start.y - end.y;
            var yPosition = end.y + length / 2;

            transform.localScale = new Vector3(transform.localScale.x, length, transform.localScale.z);
            transform.position = new Vector3(start.x, yPosition, 0);
        }
    }
}
