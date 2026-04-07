using UnityEngine;

public class RotateCameraScript : MonoBehaviour
{
    public OpeningMaze openingMaze;
    public GameDataScript gameData;
    [SerializeField] Transform target;
    [SerializeField] Transform AdditionalTarget;
    [SerializeField] bool GotTheCenter;
    [SerializeField] float distance;
    [SerializeField] float sensitivity;
    [SerializeField] bool NoScrolling;
    [SerializeField] bool NoRotating;
    [SerializeField] bool Menu;
    [SerializeField] bool Tutorial;
    [SerializeField] bool is3dMaze;
    [SerializeField] Vector3 center;
    [SerializeField] float MaxDistance;

    float x;
    float y;
    float scroll;
    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        if (is3dMaze)
        {
            if (gameData.MazeSize2D == 2)
            {
                target = AdditionalTarget;
            }
        }

        MaxDistance = CameraDistance();
        distance = MaxDistance;
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

        else if (!GotTheCenter)
        {
            center = GetCombinedCenter(target.gameObject);
            GotTheCenter = true;
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
            distance = Mathf.Clamp(distance, 2f, MaxDistance);
        }

        Quaternion rotation = Quaternion.Euler(y, x, 0);

        if (Menu)
        {
            Vector3 position = target.position - (rotation * Vector3.forward * distance);

            transform.rotation = rotation;
            transform.position = position;
        }

        else
        {
            Vector3 position = center - (rotation * Vector3.forward * distance);

            transform.rotation = rotation;
            transform.position = position;
        }


    }
    public Vector3 GetCombinedCenter(GameObject parent)
    {
        Renderer[] renderers = parent.GetComponentsInChildren<Renderer>();
        if (renderers.Length == 0) return parent.transform.position;

        Bounds bounds = renderers[0].bounds;

        for (int i = 1; i < renderers.Length; i++)
        {
            bounds.Encapsulate(renderers[i].bounds);
        }

        return bounds.center;
    }

    float CameraDistance()
    {
        if (Menu || Tutorial) return 15f;
        else if (gameData.MazeSize2D == 6) return 25f;
        else if (gameData.MazeSize2D == 5) return 20f;
        else if (gameData.MazeSize2D == 4) return 17f;
        else if (gameData.MazeSize2D == 3) return 14f;
        else return 9f;
    }
}
