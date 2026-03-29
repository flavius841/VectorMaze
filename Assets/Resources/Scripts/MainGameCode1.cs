using UnityEngine;
using TMPro;

public class MainGameCode : MonoBehaviour
{
    public Tutorial tutorial;
    public ScoreScript scoreScript;
    private bool isHolding = false;
    [SerializeField] bool releasedOnButton = false;
    [SerializeField] bool Collided;
    [SerializeField] TextMeshProUGUI LoseText;
    [SerializeField] GameObject RestartButton;
    [SerializeField] GameObject BackButton;
    [SerializeField] float ColorAlpha = 0f;
    [SerializeField] float MaxAlpha = 255f;

    void OnMouseDown()
    {
        if (tutorial.TutorialDone && !Collided)
        {
            isHolding = true;
            releasedOnButton = false;
        }
    }

    void OnMouseUpAsButton()
    {
        if (tutorial.TutorialDone && !Collided)
        {
            releasedOnButton = true;
            scoreScript.Score++;
        }
    }

    void OnMouseUp()
    {
        if (tutorial.TutorialDone && !Collided)
        {
            isHolding = false;
        }
    }

    void Start()
    {

    }

    void Update()
    {
        if (releasedOnButton)
        {
            transform.Translate(Vector3.right * Time.deltaTime * 80f);
        }

        if (Collided)
        {
            ColorAlpha = Mathf.Lerp(ColorAlpha, MaxAlpha, Time.deltaTime * 10f);

            byte b = (byte)ColorAlpha;

            LoseText.color = new Color32(79, 3, 0, b);

            if (ColorAlpha > 250f)
            {
                RestartButton.SetActive(true);
                BackButton.SetActive(true);
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Vector"))
        {
            Collided = true;
        }
    }
}
