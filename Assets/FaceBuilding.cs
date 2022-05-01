using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class FaceBuilding : MonoBehaviour
{
    [Header("Input Fields Entry")]
    [SerializeField] private InputField[] inputX = new InputField[3];
    [SerializeField] private InputField[] inputY = new InputField[3];
    [SerializeField] private InputField[] connections = new InputField[3];

    [Header("Polygon Material")]
    [SerializeField] private Material material;

    private Vector3[] vertices = new Vector3[3];
    private Mesh mesh;

    private void Start()
    {
        mesh = new Mesh();

        MeshFilter filter = GetComponent<MeshFilter>();
        filter.mesh = mesh;

        MeshRenderer render = GetComponent<MeshRenderer>();
        render.material = material;
    }

    private void LateUpdate()
    {
        vertices[0] = SetVertexCoord(inputX[0], inputY[0]);
        vertices[1] = SetVertexCoord(inputX[1], inputY[1]);
        vertices[2] = SetVertexCoord(inputX[2], inputY[2]);

        if (vertices.Length >= 3)
        {
            InstantiateFace();
        }
    }

    private void OnDrawGizmos()
    {
        if(vertices == null)
        {
            return;
        }
        else
        {
            Gizmos.color = Color.red;
            for (int i=0; i < vertices.Length; i++)
            {
                Gizmos.DrawSphere(vertices[i], 0.05f);
            }
        }
    }

    public Vector3 SetVertexCoord(InputField inputX, InputField inputY)
    {
        int valueX, valueY;

        int.TryParse(inputX.text, out valueX);
        int.TryParse(inputY.text, out valueY);

        return new Vector3(valueX, valueY, 0);
    }

    public int[] ConnectVertices(InputField[] sequence)
    {
        int[] triangles = new int[vertices.Length];

        for (int i=0; i < triangles.Length; i++)
        {
            int.TryParse(sequence[i].text, out triangles[i]);

            if(triangles[i] >= triangles.Length)
            {
                triangles[i] = triangles.Length-1;
                connections[i].text = triangles[i].ToString();
            }
        }

        return triangles;
    }

    public void InstantiateFace()
    {
        Vector2[] test = {
            new Vector3(0, 0),
            new Vector3(1, 1),
            new Vector3(1, 0),

    };

        mesh.vertices = vertices;
        mesh.triangles = ConnectVertices(connections);
        mesh.uv = test;
    }
}

