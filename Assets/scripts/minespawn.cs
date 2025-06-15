using UnityEngine;

public class MineSpawner : MonoBehaviour
{
    public GameObject minePrefab;   
    public Transform submarine;       
    public float spawnDistance = 10f;  
    public float spawnInterval = 2f;   

    
    public float minY = -3f;    
    public float maxY = 3f;   

    private void Start()
    {
       
        InvokeRepeating("SpawnMine", 0f, spawnInterval);
    }

    void SpawnMine()
    {
        if (submarine == null)
        {
            Debug.LogWarning("Submarine referansı eksik!");
            return;
        }

        
        float spawnX = submarine.position.x + spawnDistance;

        
        float spawnY = Random.Range(minY, maxY);

        
        Vector3 spawnPosition = new Vector3(spawnX, spawnY, submarine.position.z);

        
        GameObject mine = Instantiate(minePrefab, spawnPosition, Quaternion.identity);

        
        Mine mineScript = mine.GetComponent<Mine>();
        if (mineScript != null)
        {
            mineScript.StartRotating();
        }
        else
        {
            Debug.LogWarning("Mayın prefab'ında 'Mine' scripti bulunamadı.");
        }
    }
}
