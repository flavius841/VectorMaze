using UnityEngine;


[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
[ExecuteAlways]
public class TriangleGenerator : MonoBehaviour
{
    [SerializeField] Material Mat;

    void OnValidate()
    {
        Generate3DTriangle();
    }

    public void Generate3DTriangle()
    {
        if (!gameObject.activeInHierarchy) return;
        if (Mat == null) return;

        Vector3 A = new Vector3(3, 0, 5);
        Vector3 B = new Vector3(6, 0, 0);
        Vector3 C = new Vector3(0, 0, 0);

        TriangleMesh mesh = new TriangleMesh();
        mesh.Vertices.Add(A);
        mesh.Vertices.Add(B);
        mesh.Vertices.Add(C);

        mesh.Indices.Add(0);
        mesh.Indices.Add(1);
        mesh.Indices.Add(2);

        var mf = GetComponent<MeshFilter>();
        var mr = GetComponent<MeshRenderer>();

        if (mf.sharedMesh == null)
            mf.sharedMesh = new Mesh();

        mf.sharedMesh.Clear();


        mf.sharedMesh.SetVertices(mesh.Vertices);
        mf.sharedMesh.SetIndices(mesh.Indices, MeshTopology.Triangles, 0);

        mr.sharedMaterial = Mat;
    }
}