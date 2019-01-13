using UnityEngine;
using UnityEngine.AI;

public class MoveController : MonoBehaviour
{
    private NavMeshAgent agent;
    private float yaw = 0f;
    private float pitch = 0f;

    public float speedH = 2f;
    public float speedV = 2f;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        yaw += Input.GetAxis("Mouse X");
        pitch -= Input.GetAxis("Mouse Y");
        agent.transform.eulerAngles = new Vector3(pitch, yaw, 0f);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 100))
            {
                agent.destination = hit.point;
            }
        }
    }
}