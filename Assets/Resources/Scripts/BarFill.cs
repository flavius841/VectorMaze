using UnityEngine;
using UnityEngine.UI;

public class BarFill : MonoBehaviour
{
    public ScoreScript scoreScript;
    [SerializeField] Image fillImage;
    public float progress;
    [SerializeField] float Speed;
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
        }

        fillImage.fillAmount = progress;
    }
}
