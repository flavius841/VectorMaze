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
    [SerializeField] Vector3 center;

    float x;
    float y;
    float scroll;
    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        center = GetCombinedCenter(target.gameObject);


    }


    void LateUpdate()
    {
        center = GetCombinedCenter(target.gameObject);

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
        Vector3 position = center - (rotation * Vector3.forward * distance);

        transform.rotation = rotation;
        transform.position = position;


    }
    public Vector3 GetCombinedCenter(GameObject parent)
    {
        Renderer[] renderers = parent.GetComponentsInChildren<Renderer>();
        if (renderers.Length == 0) return parent.transform.position;

        // Create a box starting at the first renderer
        Bounds bounds = renderers[0].bounds;

        // Expand the box to include all other children
        for (int i = 1; i < renderers.Length; i++)
        {
            bounds.Encapsulate(renderers[i].bounds);
        }

        // This is the "Center" coordinate you see in the Scene View
        return bounds.center;
    }
}
