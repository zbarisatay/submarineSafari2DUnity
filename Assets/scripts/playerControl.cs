using System.Collections;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float forwardSpeed = 5f;
    public float verticalSpeed = 5f;
    public float rotationSpeed = 10f;
    public float maxRotationAngle = 30f;

    public float minY = -4.5f; // Oyuncunun inebileceği en düşük Y pozisyonu
    public float maxY = 4.5f;  // Oyuncunun çıkabileceği en yüksek Y pozisyonu

    public GameObject bubblePrefab;  // Baloncuk prefab'ını burada tanımlayın
    public int bubbleCount = 5;  // Aynı anda çıkacak baloncuk sayısı
    public float bubbleInterval = 2f;  // Baloncukların çıkma aralığı (saniye)
    public Vector3 bubbleOffset = new Vector3(-1f, 0f, 0f);  // Baloncukların çıkacağı konum (denizaltının arkasında)
    public float bubbleSpreadForce = 2f;  // Baloncukların yayılma gücü (rastgele yönler)

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.interpolation = RigidbodyInterpolation2D.None;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Discrete;

        // Baloncukları başlat
        StartCoroutine(SpawnBubbles());
    }

    void FixedUpdate()
    {
        float moveVertical = Input.GetAxis("Vertical");

        // Yeni hareket vektörü oluştur
        Vector2 movement = new Vector2(forwardSpeed, moveVertical * verticalSpeed);
        rb.velocity = movement;

        // Rotasyonu ayarla
        float targetAngle = moveVertical * maxRotationAngle;
        rb.rotation = Mathf.LerpAngle(rb.rotation, targetAngle, rotationSpeed * Time.fixedDeltaTime);

        // Oyuncunun min ve max sınırlarını kontrol et
        ClampPosition();
    }

    void ClampPosition()
    {
        Vector3 clampedPosition = transform.position;

        // Y pozisyonunu min ve max arasında sınırla
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, minY, maxY);

        // Pozisyonu uygula
        transform.position = clampedPosition;
    }

    private IEnumerator SpawnBubbles()
    {
        while (true)
        {
            // Aynı anda birden fazla baloncuk oluştur
            for (int i = 0; i < bubbleCount; i++)
            {
                // Baloncuk oluştur
                GameObject bubble = Instantiate(bubblePrefab, transform.position + bubbleOffset, Quaternion.identity);

                // Baloncuğa rastgele bir kuvvet ekle (yayılma etkisi)
                Vector2 randomDirection = Random.insideUnitCircle.normalized;  // Rastgele bir yön
                bubble.GetComponent<Rigidbody2D>().AddForce(randomDirection * bubbleSpreadForce, ForceMode2D.Impulse);

                // Baloncuk 2 saniye sonra kaybolacak
                Destroy(bubble, 2f);
            }

            // Belirtilen aralıkla baloncukları oluştur
            yield return new WaitForSeconds(bubbleInterval);
        }
    }
}
