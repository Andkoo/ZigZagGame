using UnityEngine;

public class TriggerChecker : MonoBehaviour
{
    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player") Invoke("FallDown", 0.5f);
    }

    void FallDown()
    {
        GetComponent<Rigidbody>().useGravity = true;
        Destroy(gameObject, 3f);
    }
}
