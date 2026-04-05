using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] bool StartMoving;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float MaxX;
    [SerializeField] Transform SizePanel;

    void Start()
    {

    }


    void Update()
    {
        if (StartMoving)
        {
            SizePanel.localPosition += Vector3.right * moveSpeed * Time.deltaTime;

            if (SizePanel.localPosition.x > MaxX)
            {
                StartMoving = false;
            }
        }

    }

    public void LoadTutorial()
    {
        SceneManager.LoadScene(0);
    }

    public void TutorialBool()
    {
        Invoke("LoadTutorial", 0.5f);
    }

    public void AskSize()
    {
        StartMoving = true;
    }


}
