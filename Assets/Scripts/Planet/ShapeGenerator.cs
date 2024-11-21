using UnityEngine;

public class ShapeGenerator
{
    private ShapeSettings settings;
    public MinMax minMax;
    NoiseFilter noiseFilter;

    public ShapeGenerator(ShapeSettings settings)
    {
        this.settings = settings;
        this.noiseFilter = new NoiseFilter(settings.noiseSettings);
        this.minMax = new MinMax();
    }

    public Vector3 Calculate(Vector3 point)
    {
        float elevation = noiseFilter.Evaluate(point);

        elevation = settings.radius * (elevation + 1);
        minMax.AddValue(elevation);

        return point * elevation;
    }
}
