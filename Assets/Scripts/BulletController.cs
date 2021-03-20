using UnityEngine;

public class BulletController : MonoBehaviour {

    private float bulletSpeed = 50f;

    // Start is called before the first frame update
    void Start() {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * bulletSpeed;
    }

}
