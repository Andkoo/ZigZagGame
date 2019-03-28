using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject particles;

    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!GameManager.instance.started)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameManager.instance.GameStart();
                SwitchDirection();
            }
        }
        else
        {
            if (!GameManager.instance.gameOver && Input.GetMouseButtonDown(0))
            {
                SwitchDirection();
            }
        }

        if (!Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            GameManager.instance.GameOver();
            rb.velocity = new Vector3(0, -15f, 0);
        }

        //Infinite falling prevention
        if (gameObject.transform.position.y < -40) rb.velocity = new Vector3(0, 0, 0);
    }

    void SwitchDirection()
    {
        if (rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed);
        } else
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Point")
        {
            GameObject part = Instantiate(
                particles,
                collider.gameObject.transform.position,
                Quaternion.identity
            ) as GameObject;
            Destroy(part, 1f);

            Destroy(collider.gameObject);
            ScoreManager.instance.IncrementScore(10);
        }
    }
}
