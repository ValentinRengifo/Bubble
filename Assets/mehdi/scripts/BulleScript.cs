using System;
using UnityEngine;
using UnityEngine.Serialization;

public class BulleScript : MonoBehaviour
{
    [SerializeField] public BulleManagerScript bulleManager; 
    public Transform finalPosition;
    private float _timer;
        
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 3.5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position, 
            finalPosition.position, 
            5f * Time.deltaTime
        );
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("detects collision");
        if (other.gameObject.CompareTag("poisson"))
        {
            //if (other.gameObject.GetComponent<PoissonScript>().state)
            //{
            Debug.Log("is poisson");
            bulleManager.GetComponent<BulleManagerScript>().bulleScore += 1;
            Destroy(gameObject);
            //}
        }
        //throw new NotImplementedException();
    }
    
    private void OnMouseDown()
    {
        Debug.Log("une bulle à été clické !");
        bulleManager.GetComponent<BulleManagerScript>().bulleScore += 1;
        Destroy(gameObject); // Détruit la bulle quand on clique dessus
    }
}