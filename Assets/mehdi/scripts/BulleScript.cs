using System;
using UnityEngine;
using UnityEngine.Serialization;

public class BulleScript : MonoBehaviour
{
    [SerializeField] public BulleManagerScript bulleManager; 
    public Transform finalPosition;
    //private float _timer;
    public float speed = 2f;
    public int valeur = 1;
    public GameManagerA GameManagerA;
    
        
    

    // Update is called once per frame
    void FixedUpdate()
    {
        var actualSpeed = bulleManager.bullesParSeconde * speed;
        transform.position = Vector3.MoveTowards(
            transform.position, 
            finalPosition.position, 
            actualSpeed * Time.fixedDeltaTime
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
        if (other.gameObject.CompareTag("endZone"))
        {
            Destroy(gameObject);
            //}
        }
    }
    
    private void OnMouseDown()
    {
        GameManagerA.ClickAction();
        Destroy(gameObject); // Détruit la bulle quand on clique dessus
    }
}