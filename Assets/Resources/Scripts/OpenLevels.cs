using UnityEngine;

public class OpenLevels : MonoBehaviour
{
    public Click click;
    bool stop = false;
    void Start()
    {

    }

    void Update()
    {
        if (click.releasedOnButton && !stop)
        {
            transform.Translate(Vector3.down * Time.deltaTime * 20f);
        }

        if (transform.localPosition.y < 7.6f)
        {
            stop = true;
        }



    }
}
