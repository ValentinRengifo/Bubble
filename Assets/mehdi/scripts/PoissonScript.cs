using UnityEngine;


public class PoissonScript : MonoBehaviour
{
    public bool state; // false = idle, true = popping a bubble
        public float cooldown;
        private float _timer;
        private GameObject _target;
        private Collider _collider;
        [SerializeField] private Transform idlePosition;
        public float speed = 5;

        
        private void Start()
        {
            _collider = GetComponent<Collider>();
        }
        private void Update()
        {
            if (state) // En train d'éclater une bulle
            {
                if (_collider.enabled == false)
                {
                    _collider.enabled = true; // Réactive le collider pour permettre au poisson de chasser à nouveau
                }
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
                        speed * 1.5f * Time.deltaTime
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
                speed * Time.deltaTime
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
                // Retour en Idle
                state = false;
                _timer = 0f;
                _target = null;
                _collider.enabled = false; // Désactive le collider pour éviter de toucher plusieurs bulles

            }
        }
}
