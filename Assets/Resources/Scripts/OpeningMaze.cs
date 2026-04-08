using UnityEngine;

public class OpeningMaze : MonoBehaviour
{
    [SerializeField] float Timer;
    [SerializeField] int i = 0;
    [SerializeField] int j = 0;
    public bool Done = false;
    public GameDataScript gamedataScript;
    void Start()
    {

    }

    void Update()
    {
        Done = gamedataScript.LoadingDone;

        if (Done)
        {
            gameObject.SetActive(false);
        }

        if (i < transform.childCount)
        {

            if (Timer > 0)
            {
                Timer -= Time.deltaTime;
            }
            else
            {
                Timer = 0.5f;
                i++;

                if (i == transform.childCount)
                {
                    gamedataScript.LoadingDone = true;
                }
            }

        }

        for (j = 0; j < i; j++)
        {
            transform.GetChild(j).Translate(Vector3.right * Time.deltaTime * 80f);
        }

    }
}
