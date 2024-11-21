using UnityEngine;

[CreateAssetMenu(fileName = "ColorSettings", menuName = "Planet settings/Color Settings")]
public class ColorSettings : ScriptableObject
{
    public Color planetColor;
    public Material material;
    public Gradient gradient;
}
