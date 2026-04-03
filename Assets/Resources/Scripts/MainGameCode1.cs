using UnityEngine;
using TMPro;

public class MainGameCode : MonoBehaviour
{
    public CollisionScript collisionScript;
    public Tutorial tutorial;
    public ScoreScript scoreScript;
    private bool isHolding = false;
    [SerializeField] bool releasedOnButton = false;
    [SerializeField] bool NormalLevel;
    [SerializeField] TextMeshProUGUI LoseText;
    [SerializeField] GameObject RestartButton;
    [SerializeField] GameObject BackButton;
    [SerializeField] float ColorAlpha = 0f;
    [SerializeField] float MaxAlpha = 255f;

    void OnMouseDown()
    {
        if (NormalLevel)
        {
            if (!collisionScript.Collided)
            {
                isHolding = true;
                releasedOnButton = false;
            }

        }

        else if (tutorial != null && tutorial.TutorialDone && !collisionScript.Collided)
        {
            isHolding = true;
            releasedOnButton = false;
        }
    }

    void OnMouseUpAsButton()
    {
        if (NormalLevel)
        {
            if (!collisionScript.Collided)
            {
                releasedOnButton = true;
                scoreScript.Score++;
            }
        }

        else if (tutorial != null && tutorial.TutorialDone && !collisionScript.Collided)
        {
            releasedOnButton = true;
            scoreScript.Score++;
        }
    }

    void OnMouseUp()
    {
        if (NormalLevel)
        {
            if (!collisionScript.Collided)
            {
                isHolding = false;
            }
        }

        else if (tutorial != null && tutorial.TutorialDone && !collisionScript.Collided)
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

        if (collisionScript.Collided)
        {
            LoseText.gameObject.SetActive(true);
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
            collisionScript.Collided = true;
        }
    }
}
