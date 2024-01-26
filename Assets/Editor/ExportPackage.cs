using System.Collections;
using UnityEngine;
using UnityEditor;
using System;

public static class ExportPackage
{
    [MenuItem("Export/Export with tags and layers, Input settings")]
    public static void Export()
    {
        string[] projectContent = new string[] { "Assets", "ProjectSettings/TagManager.asset", "ProjectSettings/InputManager.asset", "ProjectSettings/ProjectSettings.asset" };
        AssetDatabase.ExportPackage(projectContent, $"2DShootingGame_{DateTime.Now.ToString("yyMMdd")}.unitypackage", ExportPackageOptions.Interactive | ExportPackageOptions.Recurse | ExportPackageOptions.IncludeDependencies);
        Debug.Log("Project Exported");
    }
}
