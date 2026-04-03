using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public int Score;
    public bool StartFinalTutorial;
    public TapAwayMatrixGenerator tapAwayMatrixGenerator;
    public CollisionScript collisionScript;
    [SerializeField] bool Cheked;
    [SerializeField] GameObject LoseWinText;
    [SerializeField] GameObject TutorialPanel;
    [SerializeField] bool NormalLevel;

    void Update()
    {
        if (NormalLevel)
        {
            if (Score == tapAwayMatrixGenerator.width * tapAwayMatrixGenerator.height && !Cheked)
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
