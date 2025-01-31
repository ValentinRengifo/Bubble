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
    public GameManagerA GameManagerA;
    
        
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = bulleManager.bullesParSeconde * 2.5f * 5;
        _lifeTime = 100 /speed ;
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
        if (other.gameObject.CompareTag("poisson"))
        {
            GameManagerA.ClickAction();
            Destroy(gameObject);
            //}
        }
        //throw new NotImplementedException();
    }
    
    private void OnMouseDown()
    {
        GameManagerA.ClickAction();
        Destroy(gameObject); // Détruit la bulle quand on clique dessus
    }
}