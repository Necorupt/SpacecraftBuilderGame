using System;
using UnityEngine;

[Serializable]
public class NoiseSettings
{
    public float roughness = 1.0f;
    public float strength = 1.0f;
    public float baseRoughness = 1.0f;
    public float persistence = 0.2f;
    public float minValue = 0.0f;
    public Vector3 center;
    [Range(1, 32)]
    public int numOfLayers = 2;
}
