using UnityEngine;

public class Click : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] bool StartButtons;
    [SerializeField] float ColorBrightness;
    [SerializeField] float MinBrightness;


    float MaxBrightness = 255f;
    float minY = -2.4f;
    float maxY = -2f;
    public bool releasedOnButton = false;

    bool isHolding = false;

    void OnMouseDown()
    {
        isHolding = true;
        releasedOnButton = false;
    }

    void OnMouseUpAsButton()
    {
        releasedOnButton = true;
    }

    void OnMouseUp()
    {
        isHolding = false;
    }


    void Update()
    {
        if (StartButtons)
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

        else
        {
            if (isHolding)
            {
                ColorBrightness = Mathf.Lerp(ColorBrightness, MinBrightness, Time.deltaTime * speed);
            }
            else
            {
                ColorBrightness = Mathf.Lerp(ColorBrightness, MaxBrightness, Time.deltaTime * speed);
            }

            byte b = (byte)ColorBrightness;

            GetComponent<Renderer>().material.color = new Color32(b, b, b, 255);


        }
    }
}