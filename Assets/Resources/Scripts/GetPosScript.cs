using UnityEngine;

public class GetPosScript : MonoBehaviour
{
    [SerializeField] Transform target;
    void Start()
    {

    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
    }
}
