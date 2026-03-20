using UnityEngine;

[ExecuteAlways]
public class hierarcyScript : MonoBehaviour
{
    private bool Done = false;
    private int Order;
    void OnValidate()
    {
        while (!Done)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                int.TryParse(transform.GetChild(i).name, out Order);
                transform.GetChild(i).SetSiblingIndex(Order - 1);

                if (i == transform.childCount - 1)
                {
                    Done = true;
                }
                else
                {
                    Done = false;
                }
            }
        }

    }

}
