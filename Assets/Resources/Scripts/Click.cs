using UnityEngine;

public class Click : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] bool StartButtons;
    [SerializeField] float ColorBrightness;
    [SerializeField] float MinBrightness;
    public OpeningMaze openingMaze;


    float MaxBrightness = 255f;
    float minY = -2.4f;
    float maxY = -2f;
    public bool releasedOnButton = false;

    bool isHolding = false;

    void OnMouseDown()
    {
        if (openingMaze.Done)
        {
            isHolding = true;
            releasedOnButton = false;
        }
    }

    void OnMouseUpAsButton()
    {
        if (openingMaze.Done)
        {
            releasedOnButton = true;
        }
    }

    void OnMouseUp()
    {
        if (openingMaze.Done)
        {
            isHolding = false;
        }
    }


    void Update()
    {
        if (!openingMaze.Done)
        {
            return;
        }

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