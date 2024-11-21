using UnityEngine;

[CreateAssetMenu(fileName = "ShapeSettings", menuName = "Planet settings/Shape Settings")]
public class ShapeSettings : ScriptableObject
{
    public float radius;
    public NoiseSettings noiseSettings;
}
