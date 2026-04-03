using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public int Score;
    public bool StartFinalTutorial;
    public TapAwayMatrixGenerator tapAwayMatrixGenerator;
    [SerializeField] bool Cheked;
    [SerializeField] GameObject LoseText;
    [SerializeField] GameObject TutorialPanel;
    [SerializeField] bool NormalLevel;

    void Update()
    {
        if (NormalLevel)
        {
            if (Score == tapAwayMatrixGenerator.width * tapAwayMatrixGenerator.height - 1 && !Cheked)
            {
                Invoke("FinalTutorial", 1f);
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
        if (!LoseText.activeInHierarchy)
        {
            StartFinalTutorial = true;
            TutorialPanel.SetActive(true);
        }
    }

}
