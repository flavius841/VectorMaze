using UnityEngine;
using TMPro;
using System.Collections;

public class UserInputScript : MonoBehaviour
{
    [SerializeField] TMP_InputField sizeInput;
    public GameDataScript gameData;
    public bool TookInput;
    public void ReadStringInput()
    {
        string input = sizeInput.text;

        if (int.TryParse(input, out int value) && input.Trim().Length == 1 && value <= 6 && value >= 2)
        {
            gameData.MazeSize2D = value;
            TookInput = true;
        }

        else
        {
            sizeInput.text = "";
            StartCoroutine(FlashPlaceholderError());
        }
    }
    public IEnumerator FlashPlaceholderError()
    {
        TextMeshProUGUI placeholder = sizeInput.placeholder.GetComponent<TextMeshProUGUI>();

        for (int i = 0; i < 3; i++)
        {
            placeholder.color = Color.red;
            yield return new WaitForSeconds(0.2f);
            placeholder.color = Color.black;
            yield return new WaitForSeconds(0.2f);
        }
    }

}
