using System.Collections;
using UnityEngine;

public class AsteroidController : MonoBehaviour {
    private bool canMove = true;
    public int points = 0;
    public GameController gameController;
    public Collider2D spawnZone;

    private float speed = 0.01f;
    void Start() {
        StartCoroutine(this.Respawn());
    }

    // Update is called once per frame
    void Update() {
        if (this.transform.position.x > 20) {
            StartCoroutine(this.Respawn());
        }
    }

    void FixedUpdate() {
        this.Move();
    }

    void OnTriggerEnter2D(Collider2D c) {
        if (c.gameObject.tag == "Projectile") {
            gameController.IncreaseScore(this.points);
            Destroy(c.gameObject);

            StartCoroutine(this.Respawn());
        }
    }
    
    private IEnumerator Respawn() {
        this.canMove = false;

        this.newPosition();

        yield return new WaitForSeconds(1);
        this.speed = Random.Range(0.01f, 0.04f);
        this.canMove = true;
    }

    private void newPosition() {
        int size = Random.Range(0, 10);
        transform.localScale = new Vector3 (size, size, 1);

        this.transform.position = new Vector2(
            Random.Range(spawnZone.bounds.min.x, spawnZone.bounds.max.x),
            Random.Range(spawnZone.bounds.min.y, spawnZone.bounds.max.y)
        );
    }

    private void Move() {
        if (canMove) {
            Vector2 position = this.transform.position;

            this.transform.position = new Vector2(position.x + this.speed, position.y);
        }
    }

}
