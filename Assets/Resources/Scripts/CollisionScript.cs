using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionScript : MonoBehaviour
{
    public bool Collided;

    public void BackButton()
    {
        Invoke("BackToMenu", 1f);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(1);
    }
    public void RestartButton()
    {
        Invoke("RestartScene", 1f);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
