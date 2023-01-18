using System.IO;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

public static class TemplateHandler
{
    #region MonoBehaviour
    [MenuItem("Assets/Create/MonoBehaviour", priority = 60)]
    static void CreateMonoBehaviour()
    {
        string newFileName = "NewMonoBehaviour";
        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(@"Assets/Templates\DefaultMonoBehaviour.txt", newFileName + ".cs");
    }
    #endregion

    #region EditorWindow
    [MenuItem("Assets/Create/Editor Window", priority=61)]
    static void CreateEditorWindow()
    {
        string newFileName = "NewEditorWindow";
        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(@"Assets/Templates\DefaultEditorWindow.txt", newFileName +".cs");
    }
    #endregion
 
    #region Enum
    [MenuItem("Assets/Create/Enum", priority=62)]
    static void CreateEnum()
    {
        string newFileName = "NewEnum";
        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(@"Assets/Templates\DefaultEnum.txt", newFileName +".cs");
    }
    #endregion
 
    #region ScriptableObject
    [MenuItem("Assets/Create/ScriptableObject", priority=63)]
    static void CreateScriptableObject()
    {
        string newFileName = "NewScriptableObject";
        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(@"Assets/Templates\DefaultScriptableObject.txt", newFileName +".cs");
    }
    #endregion
 
    #region Inspector
    [MenuItem("Assets/Create/Custom Inspector", priority=64)]
    static void CreateInspector()
    {
        string newFileName = "NewCustomInspector";
        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(@"Assets/Templates\DefaultCustomInspector.txt", newFileName +".cs");
    }
    #endregion
 
    #region Struct
    [MenuItem("Assets/Create/Struct", priority=65)]
    static void CreateStruct()
    {
        string newFileName = "NewStruct";
        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(@"Assets/Templates\DefaultStruct.txt", newFileName +".cs");
    }
    #endregion
 
    #region Interface
    [MenuItem("Assets/Create/Interface", priority=66)]
    static void CreateInterface()
    {
        string newFileName = "NewInterface";
        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(@"Assets/Templates\DefaultInterface.txt", newFileName +".cs");
    }
    #endregion
 
    #region StaticClass
    [MenuItem("Assets/Create/Static Class", priority=67)]
    static void CreateStaticClass()
    {
        string newFileName = "NewStaticClass";
        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(@"Assets/Templates\DefaultStaticClass.txt", newFileName +".cs");
    }
    #endregion
}// final