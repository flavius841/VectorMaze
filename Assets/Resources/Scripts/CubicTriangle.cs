using UnityEngine;


[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
[ExecuteAlways]
public class CubicTriangle : MonoBehaviour
{
    [SerializeField] Material Mat;

    void OnValidate()
    {
        GenerateCubicTriangle();
    }


    public void GenerateCubicTriangle()
    {

        Vector3 A = new Vector3(0, 1, 1);
        Vector3 B = new Vector3(1, 1, 1);
        Vector3 C = new Vector3(0.5f, 1, 0);

        Vector3 D = new Vector3(0, 0, 1);
        Vector3 E = new Vector3(1, 0, 1);
        Vector3 F = new Vector3(0.5f, 0, 0);

        TriangleMesh mesh = new TriangleMesh();
        mesh.Vertices.Add(A);
        mesh.Vertices.Add(B);
        mesh.Vertices.Add(C);
        mesh.Vertices.Add(D);
        mesh.Vertices.Add(E);
        mesh.Vertices.Add(F);

        mesh.Indices.Add(0);
        mesh.Indices.Add(1);
        mesh.Indices.Add(2);
        mesh.Indices.Add(3);
        mesh.Indices.Add(4);
        mesh.Indices.Add(5);



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
