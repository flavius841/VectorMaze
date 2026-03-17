using UnityEngine;
using System.Collections.Generic;

public class TriangleMesh
{
    public List<Vector3> Vertices = new List<Vector3>();
    public List<int> Indices = new List<int>();
}

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]

public class TriangleGenerator : MonoBehaviour
{
    void Start()
    {
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

    }


}
