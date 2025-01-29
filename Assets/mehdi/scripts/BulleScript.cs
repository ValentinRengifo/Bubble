using System;
using UnityEngine;

namespace mehdi.scripts
{
    public class BulleScript : MonoBehaviour
    {
        [SerializeField] private BulleManagerScript bulleManager; 
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            throw new NotImplementedException();
            // TODO
            // remonte vers le haut puis disparait au bout de 3 secondes
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("poisson"))
            {
                if (other.gameObject.GetComponent<PoissonScript>().state)
                {
                    Destroy(this);
                    bulleManager.bulleScore += 1;   
                }
            }
            throw new NotImplementedException();
        }
    }
}
