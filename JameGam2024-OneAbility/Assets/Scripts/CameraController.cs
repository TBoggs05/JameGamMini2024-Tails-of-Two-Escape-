using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private Transform target;
    public GameObject player;
    public float smoothSpeed = 10f;
    public Vector3 offset;
    // Update is called once per frame
    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.fixedDeltaTime);
            transform.position = desiredPosition;

            transform.LookAt(target);
        }
        else
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    public void ChangeTarget(GameObject p)
    {
        player = p;
        target = p.transform;
    }
}
