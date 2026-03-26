using UnityEngine;
using TMPro;

public class LoadingTextScript : MonoBehaviour
{
    public OpeningMaze openingMaze;
    [SerializeField] float Timer;
    [SerializeField] TextMeshPro loadingText;

    void Start()
    {

    }

    void Update()
    {
        if (!openingMaze.Done)
        {
            Timer += Time.deltaTime;

            for (int i = 0; i < 3; i++)
            {
                if (i == (int)Timer)
                {
                    loadingText.text = "Loading" + new string('.', i + 1);
                }
            }

            if (Timer > 3)
            {
                Timer = 0;
            }
        }

        else
        {
            loadingText.text = "";
        }
    }
}
