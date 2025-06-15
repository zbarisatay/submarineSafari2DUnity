using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public float followSpeed = 1f;  
    public float xOffset = -5f;     
    public Transform target;       
    public float minXPosition = 0f; 

    private Vector3 velocity = Vector3.zero;  

    void Update()
    {
        if (target == null)
            return; 

        
        float targetX = target.position.x + xOffset;

        
        targetX = Mathf.Max(targetX, minXPosition);

        
        Vector3 targetPosition = new Vector3(targetX, transform.position.y, transform.position.z);

        
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }
}
