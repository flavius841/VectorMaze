using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public int Score;
    public bool StartFinalTutorial;
    public GameDataScript gamedataScript;
    public CollisionScript collisionScript;
    [SerializeField] bool Cheked;
    [SerializeField] GameObject LoseWinText;
    [SerializeField] GameObject TutorialPanel;
    [SerializeField] bool NormalLevel;
    [SerializeField] bool level3D;

    void Update()
    {
        if (NormalLevel)
        {
            if (Score == gamedataScript.MazeSize2D * gamedataScript.MazeSize2D && !Cheked)
            {
                Invoke("WinFunction", 1f);
                Cheked = true;
            }
        }

        else if (level3D)
        {
            if (Score == gamedataScript.MazeSize2D * gamedataScript.MazeSize2D * gamedataScript.MazeSize2D && !Cheked)
            {
                Invoke("WinFunction", 1f);
                Cheked = true;
            }
        }

        else if (Score == 5 && !Cheked)
        {
            Invoke("FinalTutorial", 1f);
            Cheked = true;
        }
    }

    void FinalTutorial()
    {
        if (!LoseWinText.activeInHierarchy)
        {
            StartFinalTutorial = true;
            TutorialPanel.SetActive(true);
        }
    }

    void WinFunction()
    {
        if (!LoseWinText.activeInHierarchy)
        {
            LoseWinText.GetComponent<TextMeshProUGUI>().text = "    You Win!";
            collisionScript.Collided = true;
        }

    }

}
