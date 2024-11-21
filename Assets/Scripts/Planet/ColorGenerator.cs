using UnityEngine;

public class ColorGenerator
{
    private ColorSettings settings;
    const int textureResolution = 50;
    private Texture2D texture;

    public ColorGenerator(ColorSettings settings)
    {
        this.settings = settings;
    }

    public void updateElevation(MinMax minMax)
    {
        settings.material.SetVector("_elevationMinMax", new Vector4(minMax.Min, minMax.Max, 0.0f, 0.0f));

    }

    public void updateColors()
    {
        Color[] colors = new Color[textureResolution];
        if (texture == null)
        {
            texture = new Texture2D(textureResolution, 1);
        }

        for (int i = 0; i < textureResolution; i++)
        {
            colors[i] = settings.gradient.Evaluate(i / (textureResolution - 1f));
        }
        texture.SetPixels(colors);
        texture.Apply();

        settings.material.SetTexture("_surfaceColor", texture);
    }
}
