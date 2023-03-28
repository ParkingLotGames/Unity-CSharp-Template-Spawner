using System;
using System.IO;
using UnityEditor;
using UnityEngine;

public static class TemplateHandler
{

    #region Helpers
    private class NewScriptNamePopup : PopupWindowContent
    {
        private string templatePath;
        private string directoryPath;
        private Action<string, string> onComplete;

        private string scriptName = "";
        private bool invalidName = false;

        public NewScriptNamePopup(string templatePath, string directoryPath, Action<string, string> onCompleteCallback)
        {
            this.templatePath = templatePath;
            this.directoryPath = directoryPath;
            onComplete = onCompleteCallback;
        }

        public override void OnGUI(Rect rect)
        {
            GUILayout.BeginVertical();

            GUILayout.Label("Enter script name:", EditorStyles.boldLabel);

            scriptName = GUILayout.TextField(scriptName);

            if (scriptName.Contains(" "))
            {
                invalidName = true;
                GUILayout.Label("Please do not use spaces in the script name.");
            }
            else
            {
                invalidName = false;
            }

            GUI.enabled = !invalidName;

            if (GUILayout.Button("Create"))
            {
                string templateContent = File.ReadAllText(templatePath);
                string modifiedContent = templateContent.Replace("#SCRIPTNAME#", scriptName);
                string fullPath = Path.Combine(directoryPath, scriptName + ".cs");

                onComplete(modifiedContent, fullPath);
                editorWindow.Close();
            }

            GUI.enabled = true;

            if (GUILayout.Button("Cancel"))
            {
                editorWindow.Close();
            }

            GUILayout.EndVertical();
        }

        public override void OnOpen() { }
        public override void OnClose() { }
    }
    #endregion

    #region MonoBehaviour
    [MenuItem("Assets/Create/C#/MonoBehaviour", priority = 60)]
    static void CreateMonoBehaviour()
    {
        string newFileName = "NewMonoBehaviour";
        CreateScriptFromTemplate(@"Packages/com.parkinglotgames.csharp-templatespawner/C# Template Spawner/Templates/DefaultMonoBehaviour.txt", newFileName + ".cs");
   ;
    }
    #endregion

    #region EditorWindow
    [MenuItem("Assets/Create/C#/Editor Window", priority = 61)]
    static void CreateEditorWindow()
    {
        string newFileName = "NewEditorWindow";
        CreateScriptFromTemplate(@"Packages/com.parkinglotgames.csharp-templatespawner/C# Template Spawner/Templates/DefaultEditorWindow.txt", newFileName + ".cs");
    }
    #endregion

    #region Enum
    [MenuItem("Assets/Create/C#/Enum", priority = 62)]
    static void CreateEnum()
    {
        string newFileName = "NewEnum";
        CreateScriptFromTemplate(@"Packages/com.parkinglotgames.csharp-templatespawner/C# Template Spawner/Templates/DefaultEnum.txt", newFileName + ".cs");
    }
    #endregion

    #region ScriptableObject
    [MenuItem("Assets/Create/C#/Scriptable Object", priority = 63)]
    static void CreateScriptableObject()
    {
        string newFileName = "NewScriptableObject";
        CreateScriptFromTemplate(@"Packages/com.parkinglotgames.csharp-templatespawner/C# Template Spawner/Templates/DefaultScriptableObject.txt", newFileName + ".cs");
    }
    #endregion

    #region Inspector
    [MenuItem("Assets/Create/C#/Custom Inspector", priority = 64)]
    static void CreateInspector()
    {
        string newFileName = "NewCustomInspector";
        CreateScriptFromTemplate(@"Packages/com.parkinglotgames.csharp-templatespawner/C# Template Spawner/Templates/DefaultInspector.txt", newFileName + ".cs");
    }
    #endregion

    #region Struct
    [MenuItem("Assets/Create/C#/Struct", priority = 65)]
    static void CreateStruct()
    {
        string newFileName = "NewStruct";
        CreateScriptFromTemplate(@"Packages/com.parkinglotgames.csharp-templatespawner/C# Template Spawner/Templates/DefaultStruct.txt", newFileName + ".cs");
       }
    #endregion

    #region Interface
    [MenuItem("Assets/Create/C#/Interface", priority = 66)]
    static void CreateInterface()
    {
        string newFileName = "NewInterface";
        CreateScriptFromTemplate(@"Packages/com.parkinglotgames.csharp-templatespawner/C# Template Spawner/Templates/DefaultInterface.txt", newFileName + ".cs");
    }
    #endregion

    #region StaticClass
    [MenuItem("Assets/Create/C#/Static Class", priority = 67)]
    static void CreateStaticClass()
    {
        string newFileName = "NewStaticClass";
        CreateScriptFromTemplate(@"Packages/com.parkinglotgames.csharp-templatespawner/C# Template Spawner/Templates/DefaultStaticClass.txt", newFileName + ".cs");
    }
    #endregion

    private static void CreateScriptFromTemplate(string templatePath, string fileName)
    {    
        string assetPath = AssetDatabase.GetAssetPath(Selection.activeObject);
        if (string.IsNullOrEmpty(assetPath)) assetPath = "Assets";
        string fullPath = Path.Combine(assetPath, fileName);

        if (!File.Exists(fullPath))
        {
#if UNITY_2019_OR_NEWER
            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(templatePath, fileName);
#else
            TempEditorWindow.ShowWindow(templatePath, assetPath);
#endif
        }
        else
        {
            Debug.LogError("File with the same name already exists.");
        }
    }
    private class TempEditorWindow : EditorWindow
    {
        private string templatePath;
        private string fullPath;

        public static void ShowWindow(string templatePath, string fullPath)
        {
            TempEditorWindow window = GetWindow<TempEditorWindow>();
            window.titleContent = new GUIContent("Temp Window");
            window.Show();
            window.templatePath = templatePath;
            window.fullPath = fullPath;
            window.ShowPopup();
        }

        private void OnGUI()
        {
            if (Event.current.type == EventType.Layout)
            {
                NewScriptNamePopup scriptNamePopup = new NewScriptNamePopup(templatePath, fullPath, (string scriptContent, string fullPath) =>
                {
                    File.WriteAllText(fullPath, scriptContent);
                    AssetDatabase.Refresh();
                    Close();
                });
                PopupWindow.Show(new Rect(Event.current.mousePosition, Vector2.zero), scriptNamePopup);
            }
        }
    }
}// final