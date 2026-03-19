using UnityEngine;

public class OpeningMaze : MonoBehaviour
{
    [SerializeField] float Timer;
    [SerializeField] int i = 1;
    void Start()
    {

    }

    void Update()
    {
        if (i <= transform.childCount)
        {

            if (Timer > 0)
            {
                Timer -= Time.deltaTime;
                transform.GetChild(i).Translate(Vector3.right * Time.deltaTime * 40f);
            }
            else
            {
                Timer = 3;
                i++;
            }

        }

    }
}
