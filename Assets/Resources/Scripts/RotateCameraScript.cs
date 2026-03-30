using UnityEngine;

public class RotateCameraScript : MonoBehaviour
{
    public OpeningMaze openingMaze;
    [SerializeField] Transform target;
    [SerializeField] float distance;
    [SerializeField] float sensitivity;
    [SerializeField] bool NoScrolling;
    [SerializeField] bool NoRotating;
    [SerializeField] bool Menu;

    float x;
    float y;
    float scroll;
    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
    }


    void LateUpdate()
    {
        if (Menu)
        {
            if (openingMaze.Done)
            {
                NoRotating = false;
            }

            else
            {
                NoRotating = true;
            }
        }



        if (Input.GetMouseButton(1) && !NoRotating)
        {
            x += Input.GetAxis("Mouse X") * sensitivity;
            y -= Input.GetAxis("Mouse Y") * sensitivity;

            y = Mathf.Clamp(y, -80f, 80f);
        }

        if (Input.GetAxis("Mouse ScrollWheel") != 0 && !NoScrolling)
        {
            scroll = Input.GetAxis("Mouse ScrollWheel");
            distance -= scroll * sensitivity * 5f;
            distance = Mathf.Clamp(distance, 2f, 15f);
        }

        Quaternion rotation = Quaternion.Euler(y, x, 0);
        Vector3 position = target.position - (rotation * Vector3.forward * distance);

        transform.rotation = rotation;
        transform.position = position;
    }
}
