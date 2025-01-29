using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace mehdi.scripts
{
    public class PoissonScript : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        [FormerlySerializedAs("_state")] public bool state; // false = en attente    /    true = entrain d'eclater une bulle
        public float cooldown = 3f;
        private float _timer;
        private bool _poped;
        private GameObject _target;

        private void Start()
        {
            throw new NotImplementedException();
        }

        // Update is called once per frame
        private void Update()
        {
            if (_timer >= cooldown)
            {
                state = true;
            }
            else
            {
                _timer += Time.deltaTime;
            }

            if (state)
            {
                Pop();
                state = false;
            }
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private void Pop()
        {
            _target = GameObject.FindWithTag("bulle");
            do
            {
                if (_target == null)
                {
                    _target = GameObject.FindWithTag("bulle");
                }
                
                // TODO
                // aller tout droit sur la bulle
                // revenir a sa place quand on a eclater une bulle
                // 
                // faire en sorte que la fonction ne call que une fois à la fois                 !!!!!!!!!!!!!!!!!!!!!!!
            } while (_poped!);
            _poped = false;

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("bulle"))
            {
                if (state)
                {
                    _poped = true; 
                }
            }
        }
    }
}
