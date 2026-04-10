using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public int Score;
    public bool StartFinalTutorial;
    public GameDataScript gamedataScript;
    public CollisionScript collisionScript;
    public TapAwayMatrixGenerator MatrixGenerator;
    [SerializeField] bool Cheked;
    [SerializeField] GameObject LoseWinText;
    [SerializeField] GameObject TutorialPanel;
    [SerializeField] bool NormalLevel;
    [SerializeField] bool level3D;
    [SerializeField] bool SpeedRunLevel;

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

        else if (SpeedRunLevel)
        {
            if (Score == gamedataScript.MazeSize2D * gamedataScript.MazeSize2D)
            {
                gamedataScript.MazeSize2D = Random.Range(2, 7);
                Invoke("NewStage", 0.5f);
                Score = 0;
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

    void NewStage()
    {
        int width = gamedataScript.MazeSize2D;
        int height = gamedataScript.MazeSize2D;

        int[,] resultMatrix = MatrixGenerator.GenerateMatrix(width, height);
        MatrixGenerator.SpawnVisuals(resultMatrix);
    }

}
