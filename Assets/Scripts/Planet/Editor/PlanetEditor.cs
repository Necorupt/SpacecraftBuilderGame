using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Planet))]
public class PlanetEditor : Editor
{
    Planet planet;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        DrawSettingsEditor(planet.shapeSettings, planet.OnShapeSettingsUpdated, ref planet.onShapeSettingsVisible);
        DrawSettingsEditor(planet.colorSettings, planet.OnColorSettingsUpdated, ref planet.onColorSettingsVisible);
    }

    public void DrawSettingsEditor(Object settings, System.Action onUpdateSettings,ref bool foldout)
    {
        using (var check = new EditorGUI.ChangeCheckScope())
        {
            foldout = EditorGUILayout.InspectorTitlebar(foldout, settings);
            if (foldout)
            {
                Editor editor = CreateEditor(settings);
                editor.OnInspectorGUI();

                if (check.changed)
                {
                    onUpdateSettings();
                }
            }
        }

    }

    private void OnEnable()
    {
        planet = (Planet)target;
    }
}
