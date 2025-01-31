using System;
using UnityEngine;
using UnityEngine.Serialization;

public class BulleScript : MonoBehaviour
{
    [SerializeField] public BulleManagerScript bulleManager; 
    public Transform finalPosition;
    private float _timer;
    public float speed = 5;
    private float _lifeTime;
    public int valeur = 1;
    
        
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = bulleManager.bullesParSeconde * 2.5f;
        _lifeTime = 20/speed ;
        Destroy(gameObject, _lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position, 
            finalPosition.position, 
            speed * Time.deltaTime
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
            bulleManager.GetComponent<BulleManagerScript>().bulleScore += valeur;
            Destroy(gameObject);
            //}
        }
        //throw new NotImplementedException();
    }
    
    private void OnMouseDown()
    {
        Debug.Log("une bulle à été clické !");
        bulleManager.GetComponent<BulleManagerScript>().bulleScore += valeur;
        Destroy(gameObject); // Détruit la bulle quand on clique dessus
    }
}