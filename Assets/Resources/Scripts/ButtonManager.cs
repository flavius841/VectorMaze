using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    void Start()
    {

    }


    void Update()
    {

    }

    public void LoadTutorial()
    {
        SceneManager.LoadScene(0);
    }

    public void TutorialBool()
    {
        Invoke("LoadTutorial", 0.5f);
    }
}
