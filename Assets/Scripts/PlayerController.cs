using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    float rotationSpeed = 200f;
    float thrustForce = 30f;
 
    //public AudioClip crash;
    //public AudioClip shoot;
 
    public GameObject bullet;

    public GameController gameController;

    public Rigidbody2D initialState;

    void Start() {
        initialState = GetComponent<Rigidbody2D>();
    }
 
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            ShootBullet();
        }

        GetComponent<Animator>().SetBool("IsMoving", this.IsMoving());
    }

    private void FixedUpdate() {
        if (gameController.isRunning()) {
            transform.Rotate(0, 0, -Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime);
        }
 
        GetComponent<Rigidbody2D>().AddForce(transform.up * thrustForce * Input.GetAxis("Vertical"));
    }
 
    void OnTriggerEnter2D(Collider2D c) {
        if (c.gameObject.tag == "Asteroid") {
            this.EndGame();
        }
    }

    public void EndGame() {
        SceneManager.LoadScene("Menu");
    }
 
    private bool IsMoving() {
        return (GetComponent<Rigidbody2D>().velocity.magnitude > 1);
    }

    void ShootBullet() {
        if (gameController.isRunning()) {
            Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
        }

        // Play a shoot sound
        //AudioSource.PlayClipAtPoint (shoot, Camera.main.transform.position);
    }

}
