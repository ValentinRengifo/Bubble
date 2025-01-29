using System;
using UnityEngine;

namespace mehdi.scripts
{
    public class PoissonScript : MonoBehaviour
    {
        public bool state; // false = idle, true = popping a bubble
        public float cooldown;
        private float _timer;
        private GameObject _target;
        [SerializeField] private Transform idlePosition;

        private void Update()
        {
            if (state) // En train d'éclater une bulle
            {
                if (_target == null) 
                {
                    FindBubble(); // Trouve une autre bulle si l'actuelle disparaît
                }

                if (_target != null)
                {
                    // Déplacement vers la bulle
                    transform.position = Vector3.MoveTowards(
                        transform.position, 
                        _target.transform.position, 
                        7f * Time.deltaTime
                    );
                }
            }
            else // Idle state
            {
                _timer += Time.deltaTime;
                if (_timer >= cooldown)
                {
                    FindBubble(); // Trouver une bulle et passer à l'état "popping"
                }
                else
                {
                    Idle();
                }
            }
        }

        private void Idle()
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                idlePosition.position,
                5f * Time.deltaTime
            );
        }

        private void FindBubble()
        {
            _target = GameObject.FindWithTag("bulle");
            if (_target != null)
            {
                state = true;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("bulle") && state)
            {
                Destroy(other.gameObject); // Détruit la bulle
                
                // Retour en Idle
                state = false;
                _timer = 0f;
                _target = null;
            }
        }
    }
}
