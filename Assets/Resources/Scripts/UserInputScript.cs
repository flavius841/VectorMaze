using UnityEngine;
using TMPro;
using System.Collections;

public class UserInputScript : MonoBehaviour
{
    [SerializeField] TMP_InputField sizeInput;
    public GameDataScript gameData;
    [SerializeField] float Timer;
    void Start()
    {

    }

    void Update()
    {

    }

    public void ReadStringInput()
    {
        string input = sizeInput.text;

        if (int.TryParse(input, out int value) && input.Trim().Length == 1 && value <= 6 && value >= 2)
        {
            gameData.MazeSize2D = value;
        }

        else
        {
            sizeInput.text = "";
            StartCoroutine(FlashPlaceholderError());

        }
    }

    IEnumerator FlashPlaceholderError()
    {
        TextMeshProUGUI placeholder = sizeInput.placeholder.GetComponent<TextMeshProUGUI>();

        placeholder.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        placeholder.color = Color.black;
        yield return new WaitForSeconds(0.2f);
    }

}
