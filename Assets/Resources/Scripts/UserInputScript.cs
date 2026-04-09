using UnityEngine;
using TMPro;
using System.Collections;

public class UserInputScript : MonoBehaviour
{
    [SerializeField] TMP_InputField sizeInput2D;
    [SerializeField] TMP_InputField sizeInput3D;
    public GameDataScript gameData;

    public bool TookInputFor2D;
    public bool TookInputFor3D;

    public void ReadStringInput2D()
    {
        VerifyInput(sizeInput2D, 6, ref TookInputFor2D, true);
    }

    public void ReadStringInput3D()
    {
        VerifyInput(sizeInput3D, 4, ref TookInputFor3D, false);
    }

    public IEnumerator FlashPlaceholderError(TMP_InputField inputField)
    {
        TextMeshProUGUI placeholder = inputField.placeholder.GetComponent<TextMeshProUGUI>();

        for (int i = 0; i < 3; i++)
        {
            placeholder.color = Color.red;
            yield return new WaitForSeconds(0.2f);
            placeholder.color = Color.black;
            yield return new WaitForSeconds(0.2f);
        }
    }

    void VerifyInput(TMP_InputField inputField, int maxValue, ref bool tookInputFlag, bool is2D)
    {
        string input = inputField.text;

        if (int.TryParse(input, out int value) && input.Trim().Length == 1 && value <= maxValue && value >= 2)
        {
            gameData.MazeSize2D = value;
            tookInputFlag = true;
        }
        else
        {
            inputField.text = "";
            StartCoroutine(FlashPlaceholderError(inputField));
        }
    }
}