using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BarFill : MonoBehaviour
{
    public ScoreScript scoreScript;
    [SerializeField] Image fillImage;
    public float progress;
    [SerializeField] float Speed;
    [SerializeField] int Score;
    [SerializeField] TextMeshProUGUI LoseWinText;
    public CollisionScript collisionScript;
    void Start()
    {

    }

    void Update()
    {
        progress = Mathf.MoveTowards(progress, 0, Time.deltaTime * Speed);

        if (scoreScript.Cheked)
        {
            progress = progress + 0.25f;
            progress = Mathf.Clamp01(progress);
            scoreScript.Cheked = false;
            Score++;
        }

        fillImage.fillAmount = progress;

        if (progress == 0)
        {
            LoseWinText.text = "    Score: " + Score.ToString();
            collisionScript.Collided = true;
        }
    }
}
