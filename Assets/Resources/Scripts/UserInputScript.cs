using UnityEngine;
using TMPro;

public class UserInputScript : MonoBehaviour
{
    [SerializeField] TMP_InputField sizeInput;
    void Start()
    {

    }

    void Update()
    {

    }

    public void ReadStringInput()
    {
        string input = sizeInput.text;

        if (int.TryParse(input, out int value) && input.Length == 1 && value <= 6)
        {

        }
    }
}
