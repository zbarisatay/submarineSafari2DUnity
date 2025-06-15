using UnityEngine;

public class Mine : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float rotationSpeed = 10f;

    private float initialRotation;
    private float targetRotation = -360f;
    private bool isRotating = false;
    private GameOver gameOverScript; // GameOver script referansı

    void Start()
    {
        initialRotation = transform.rotation.eulerAngles.z;
        gameOverScript = FindObjectOfType<GameOver>(); // GameOver script'ini bul
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("border"))
        {
            Destroy(this.gameObject); // Mayını yok et
        }
        else if (collision.CompareTag("Player"))
        {
            Debug.Log("Player mayına çarptı!");
            // Oyuncuyu yok etme yerine Game Over panelini aktif et
            gameOverScript.gameOverPanel.SetActive(true);
            Time.timeScale = 0f; // Oyun durur
        }
    }

    void Update()
    {
        // X ekseninde sola hareket
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        // Z rotasyonu yavaşça azalsın
        if (isRotating)
        {
            float currentRotation = Mathf.LerpAngle(initialRotation, targetRotation, Time.time * rotationSpeed * 0.1f);
            transform.rotation = Quaternion.Euler(0, 0, currentRotation);
        }
    }

    public void StartRotating()
    {
        isRotating = true;
    }
}
