using UnityEngine;

public class GetPosScript : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] bool GetY;
    void Start()
    {

    }

    void Update()
    {
        if (GetY)
        {
            transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
        }

        else
        {
            transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
        }

    }
}
