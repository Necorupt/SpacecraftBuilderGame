using UnityEngine;
using UnityEngine.TextCore;

public class Planet : MonoBehaviour
{
    [Range(3, 256)]
    public int resolution = 10;
    [SerializeField, HideInInspector]
    MeshFilter[] meshFilters;
    [HideInInspector]
    public bool onColorSettingsVisible = true;
    public ColorSettings colorSettings;
    [HideInInspector]
    public bool onShapeSettingsVisible = true;
    public ShapeSettings shapeSettings;
    private TerrainFace[] terrainFaces;
    private ShapeGenerator shapeGenerator;
    private ColorGenerator colorGenerator;

    private void OnValidate()
    {
        this.Initialize();
        this.Generate();
        this.UpdateColors();
    }

    public void OnColorSettingsUpdated()
    {
        this.Initialize();
        this.Generate();
        this.UpdateColors();
    }

    public void OnShapeSettingsUpdated()
    {
        this.Initialize();
        this.Generate();
    }

    void Initialize()
    {
        shapeGenerator = new ShapeGenerator(shapeSettings);
        colorGenerator = new ColorGenerator(colorSettings);

        Vector3[] directions = { Vector3.up, Vector3.down, Vector3.left, Vector3.right, Vector3.forward, Vector3.back };

        if (this.meshFilters == null || this.meshFilters.Length == 0)
        {
            this.meshFilters = new MeshFilter[directions.Length];
        }

        this.terrainFaces = new TerrainFace[6];

        for (int i = 0; i < 6; i++)
        {
            if (meshFilters[i] == null)
            {
                GameObject meshObj = new GameObject("mesh");
                meshObj.transform.parent = transform;

                meshObj.AddComponent<MeshRenderer>();
                meshFilters[i] = meshObj.AddComponent<MeshFilter>();
                meshFilters[i].sharedMesh = new Mesh();
            }
            meshFilters[i].GetComponent<MeshRenderer>().sharedMaterial = colorSettings.material;

            terrainFaces[i] = new TerrainFace(shapeGenerator, meshFilters[i].sharedMesh, resolution, directions[i]);
        }
    }

    void Generate()
    {
        foreach (TerrainFace face in terrainFaces)
        {
            face.Generate();
        }

        colorGenerator.updateElevation(shapeGenerator.minMax);
    }

    void UpdateColors()
    {
        colorGenerator.updateColors();
    }
}
