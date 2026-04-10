using UnityEngine;

public class ExitScript : MonoBehaviour
{
    public Click ExitButton;
    void Start()
    {

    }

    void Update()
    {
        if (ExitButton.releasedOnButton)
        {
            Debug.Log("Exiting Game...");

            Application.Quit();

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }

    }
}
