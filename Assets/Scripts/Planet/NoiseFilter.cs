using UnityEngine;

public class NoiseFilter
{
    private Noise noise = new Noise();
    private NoiseSettings settings;

    public NoiseFilter(NoiseSettings settings)
    {
        this.settings = settings;
    }

    public float Evaluate(Vector3 point)
    {
        float noiseValue = 0;
        float frequency = settings.baseRoughness;
        float amplitude = 1;

        for (int i = 0; i < settings.numOfLayers; i++)
        {
            float val = noise.Evaluate(point * frequency + settings.center);
            noiseValue += (val + 1) *0.5f * amplitude;  // Apply noise value to the accumulated noise value.

            frequency *= settings.roughness;
            amplitude *= settings.persistence;
        }
        noiseValue = Mathf.Max(0, noiseValue - settings.minValue);
        return noiseValue * settings.strength;
    }
}
