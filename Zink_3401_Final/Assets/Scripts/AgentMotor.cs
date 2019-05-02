using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMotor : MonoBehaviour
{
    Vector3 targetPosition;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.position;
    }

    // move forward each frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //GetMouseButton vs. GetMouseButtonDown
        {
            Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(cameraRay, out hit))
            {
                //Debug.Log(hit.point);
                targetPosition = new Vector3(hit.point.x, hit.point.y + .7f, hit.point.z);
                //transform.position = targetPosition; // warps
            }
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed);
    }
}
