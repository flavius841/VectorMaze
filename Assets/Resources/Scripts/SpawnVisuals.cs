using UnityEngine;

public class SpawnVisuals : MonoBehaviour
{
    public TapAway3DMatrixGenerator matrixGenerator;
    [SerializeField] GameObject arrowPrefab;
    [SerializeField] float spacing;
    [SerializeField] int width;
    [SerializeField] int height;
    [SerializeField] bool GenerateLayer0;
    [SerializeField] bool GenerateLayer1;
    [SerializeField] bool GenerateLayer2;
    [SerializeField] bool GenerateLayer3;

    void Start()
    {
        width = matrixGenerator.size;
        height = matrixGenerator.size;

        if (GenerateLayer0) SpawnLayer(0, matrixGenerator.layer0);
        if (GenerateLayer1) SpawnLayer(1, matrixGenerator.layer1);
        if (matrixGenerator.size > 2 && GenerateLayer2) SpawnLayer(2, matrixGenerator.layer2);
        if (matrixGenerator.size > 3 && GenerateLayer3) SpawnLayer(3, matrixGenerator.layer3);
    }

    void Update()
    {

    }

    void SpawnLayer(int layer, int[,] layerData)
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = height - 1; y >= 0; y--)
            {
                int direction = layerData[y, x];

                Vector3 localPos = new Vector3(x * spacing, 0, -y * spacing);

                GameObject arrow = Instantiate(arrowPrefab, transform);
                arrow.transform.localPosition = localPos;

                if (direction < 4)
                {
                    Quaternion localRot = Quaternion.Euler(0, direction * 90f, 0);
                    arrow.transform.localRotation = localRot;
                }

                else if (direction == 4)
                {
                    Quaternion localRot = Quaternion.Euler(0, 0, 90f);
                    arrow.transform.localRotation = localRot;
                }

                else if (direction == 5)
                {
                    Quaternion localRot = Quaternion.Euler(0, 0, -90f);
                    arrow.transform.localRotation = localRot;
                }

                arrow.name = $"Arrow [{y},{x}]";
            }
        }
    }
}
