using UnityEngine;

public class OpenLevels : MonoBehaviour
{
    public Click StartButton;
    public Click BackButton;
    bool stop = false;
    void Start()
    {

    }

    void Update()
    {
        if (StartButton.releasedOnButton)
        {
            if (transform.localPosition.y < 2.5f)
            {
                stop = true;
            }

            else
            {
                stop = false;
            }

            if (!stop)
            {
                BackButton.releasedOnButton = false;
                transform.Translate(Vector3.down * Time.deltaTime * 20f);
            }
        }



        if (BackButton.releasedOnButton)
        {
            if (transform.localPosition.y > 53f)
            {
                stop = true;
            }

            else
            {
                stop = false;
            }

            if (!stop)
            {
                StartButton.releasedOnButton = false;
                transform.Translate(Vector3.up * Time.deltaTime * 20f);
            }
        }



    }
}
