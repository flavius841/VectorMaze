using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public UserInputScript userInput;
    [SerializeField] bool StartMoving;
    [SerializeField] bool Goback;
    [SerializeField] float moveSpeed;
    [SerializeField] float MaxX;
    [SerializeField] float finalX;
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
                Goback = true;
                StartMoving = false;
            }
        }

        if (Goback)
        {
            moveSpeed = 40f;

            SizePanel.localPosition += Vector3.left * moveSpeed * Time.deltaTime;

            if (SizePanel.localPosition.x < finalX)
            {
                Goback = false;
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

    public void LoadRLevel()
    {
        SceneManager.LoadScene(2);
    }

    public void RLevelButton()
    {
        if (userInput.TookInput)
        {
            Invoke("LoadRLevel", 0.5f);
        }

        else
        {
            StartCoroutine(userInput.FlashPlaceholderError());
        }

    }


}
