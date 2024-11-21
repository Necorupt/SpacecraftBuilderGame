using System;
using UnityEngine;

public class TerrainFace
{
    private Mesh mesh;
    private ShapeGenerator shapeGenerator;
    int resolution;
    Vector3 localUp;
    Vector3 axisA;
    Vector3 axisB;

    public TerrainFace(ShapeGenerator shapeGenerator,Mesh mesh, int resolution, Vector3 localUp)
    {
        this.mesh = mesh;
        this.resolution = resolution;
        this.localUp = localUp;
        this.shapeGenerator = shapeGenerator;

        this.axisA = new Vector3(localUp.y, localUp.z, localUp.x);
        this.axisB = Vector3.Cross(localUp, axisA);
    }

    public void Generate()
    {
        Vector3[] vertices = new Vector3[this.resolution * resolution];
        int[] indices = new int[(this.resolution - 1) * (resolution - 1) * 6];
        int indicesCounter = 0;
        int i = 0;

        for (int x = 0; x < resolution; x++)
        {
            for (int y = 0; y < resolution; y++)
            {
                Vector2 percent = new Vector2(x, y) / (resolution - 1);

                Vector3 point = localUp + (percent.x - 0.5f) * 2 * axisA + (percent.y - 0.5f) * 2 * axisB;
                point = point.normalized;

                vertices[i] = shapeGenerator.Calculate(point);

                if (x != resolution - 1 && y != resolution - 1)
                {
                    indices[indicesCounter] = i + resolution;
                    indices[indicesCounter + 1] = i + resolution + 1;
                    indices[indicesCounter + 2] = i;

                    indices[indicesCounter + 3] = i + resolution + 1;
                    indices[indicesCounter + 4] = i + 1;
                    indices[indicesCounter + 5] = i;

                    indicesCounter += 6;
                }
                i++;
            }
        }

        this.mesh.Clear();
        this.mesh.vertices = vertices;
        this.mesh.triangles = indices;
        this.mesh.RecalculateNormals();
    }
}
