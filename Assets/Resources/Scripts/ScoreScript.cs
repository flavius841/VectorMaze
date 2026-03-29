using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public int Score;
    public bool StartFinalTutorial;
    [SerializeField] bool Cheked;
    [SerializeField] GameObject LoseText;
    [SerializeField] GameObject TutorialPanel;

    void Update()
    {
        if (Score == 5 && !Cheked)
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
