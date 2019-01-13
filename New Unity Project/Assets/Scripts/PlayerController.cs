using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private NavMeshAgent agent;
    private float yaw = 0f;
    private float pitch = 0f;

    public float speedH = 2f;
    public float speedV = 2f;

    private void RotateCamera()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");
        agent.transform.eulerAngles = new Vector3(pitch, yaw, 0f);
    }

    private void MoveToPoint()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 100))
        {
            agent.destination = hit.point;
        }
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    { 
        RotateCamera();

        if (Input.GetMouseButtonDown(0))
        {
            MoveToPoint();
        }
    }
}