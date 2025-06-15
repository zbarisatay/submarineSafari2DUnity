using UnityEngine;

public class BoxColliderFollow : MonoBehaviour
{
    public Transform submarine;       
    public float followSpeed = 2f;    

    private float initialDistance;    

    void Start()
    {
        
        initialDistance = transform.position.x - submarine.position.x;
    }

    void Update()
    {
        
        

        float targetX = submarine.position.x + initialDistance; 

        
        Vector3 newPosition = new Vector3(targetX, transform.position.y, transform.position.z);

        
        transform.position = Vector3.MoveTowards(transform.position, newPosition, followSpeed * Time.deltaTime);
    }
}
