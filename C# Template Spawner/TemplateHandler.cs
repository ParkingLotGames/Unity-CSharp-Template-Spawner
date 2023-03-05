using System.IO;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

public static class TemplateHandler
{
    #region MonoBehaviour
    [MenuItem("Assets/Create/C#/MonoBehaviour", priority = 60)]
    static void CreateMonoBehaviour()
    {
        string newFileName = "NewMonoBehaviour";
        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(@"Packages/com.parkinglotgames.csharp-templatespawner/C# Template Spawner/Templates/DefaultMonoBehaviour.txt", newFileName + ".cs");
    }
    #endregion

    #region EditorWindow
    [MenuItem("Assets/Create/C#/Editor Window", priority = 61)]
    static void CreateEditorWindow()
    {
        string newFileName = "NewEditorWindow";
        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(@"Packages/com.parkinglotgames.csharp-templatespawner/C# Template Spawner/Templates/DefaultEditorWindow.txt", newFileName + ".cs");
    }
    #endregion

    #region Enum
    [MenuItem("Assets/Create/C#/Enum", priority = 62)]
    static void CreateEnum()
    {
        string newFileName = "NewEnum";
        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(@"Packages/com.parkinglotgames.csharp-templatespawner/C# Template Spawner/Templates/DefaultEnum.txt", newFileName + ".cs");
    }
    #endregion

    #region ScriptableObject
    [MenuItem("Assets/Create/C#/Scriptable Object", priority = 63)]
    static void CreateScriptableObject()
    {
        string newFileName = "NewScriptableObject";
        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(@"Packages/com.parkinglotgames.csharp-templatespawner/C# Template Spawner/Templates/DefaultScriptableObject.txt", newFileName + ".cs");
    }
    #endregion

    #region Inspector
    [MenuItem("Assets/Create/C#/Custom Inspector", priority = 64)]
    static void CreateInspector()
    {
        string newFileName = "NewCustomInspector";
        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(@"Packages/com.parkinglotgames.csharp-templatespawner/C# Template Spawner/Templates/DefaultCustomInspector.txt", newFileName + ".cs");
    }
    #endregion

    #region Struct
    [MenuItem("Assets/Create/C#/Struct", priority = 65)]
    static void CreateStruct()
    {
        string newFileName = "NewStruct";
        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(@"Packages/com.parkinglotgames.csharp-templatespawner/C# Template Spawner/Templates/DefaultStruct.txt", newFileName + ".cs");
    }
    #endregion

    #region Interface
    [MenuItem("Assets/Create/C#/Interface", priority = 66)]
    static void CreateInterface()
    {
        string newFileName = "NewInterface";
        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(@"Packages/com.parkinglotgames.csharp-templatespawner/C# Template Spawner/Templates/DefaultInterface.txt", newFileName + ".cs");
    }
    #endregion

    #region StaticClass
    [MenuItem("Assets/Create/C#/Static Class", priority = 67)]
    static void CreateStaticClass()
    {
        string newFileName = "NewStaticClass";
        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(@"Packages/com.parkinglotgames.csharp-templatespawner/C# Template Spawner/Templates/DefaultStaticClass.txt", newFileName + ".cs");
    }
    #endregion
}// final