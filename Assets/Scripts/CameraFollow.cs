using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] float lerpRate;

    Vector3 offset;

    void Start()
    {
        offset = target.transform.position - transform.position;
    }
    
    void Update()
    {
        if (!GameManager.instance.gameOver) Follow();
    }

    void Follow()
    {
        Vector3 pos = transform.position;
        Vector3 targetPos = target.transform.position - offset;
        pos = Vector3.Lerp(pos, targetPos, lerpRate * Time.deltaTime);
        transform.position = pos;
    }
}
