using UnityEngine;

public class MainGameCode : MonoBehaviour
{
    public Tutorial tutorial;
    private bool isHolding = false;
    [SerializeField] bool releasedOnButton = false;

    void OnMouseDown()
    {
        if (tutorial.TutorialDone)
        {
            isHolding = true;
            releasedOnButton = false;
        }
    }

    void OnMouseUpAsButton()
    {
        if (tutorial.TutorialDone)
        {
            releasedOnButton = true;
        }
    }

    void OnMouseUp()
    {
        if (tutorial.TutorialDone)
        {
            isHolding = false;
        }
    }

    void Start()
    {

    }

    void Update()
    {
        if (releasedOnButton)
        {
            transform.Translate(Vector3.right * Time.deltaTime * 80f);
        }
    }
}
