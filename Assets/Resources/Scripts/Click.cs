using UnityEngine;

public class Click : MonoBehaviour
{
    [SerializeField] float speed = 5f;

    float minY = -2.4f;
    float maxY = -2f;

    bool isHolding = false;

    void OnMouseDown()
    {
        isHolding = true;
    }

    void OnMouseUp()
    {
        isHolding = false;
    }

    void Update()
    {
        if (isHolding)
        {
            if (transform.localPosition.y > minY)
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else
        {
            if (transform.localPosition.y < maxY)
                transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
    }
}