using UnityEditor;
using UnityEngine;
using System.IO;
using System.Linq;

public class TemplateScanner : MonoBehaviour
{
    public static string TEMPLATE_FOLDER = "Packages/com.parkinglotgames.csharp-templatespawner/C# Template Spawner/Templates";
    const string HANDLER_SCRIPT_PATH = "Packages/com.parkinglotgames.csharp-templatespawner/C# Template Spawner/TemplateHandler.cs";
    static int priority = 60;

    static string menuItemTemplate =
    @"    #region {0}
    [MenuItem(""Assets/Create/{0}"", priority={4})]
    static void {1}()
    {{
        string templatePath = @""{3}"";
        string fileName = ""New{0}.cs"";
        CreateScriptFromTemplate(templatePath, fileName);
    }}
    #endregion
}}// final";

    [InitializeOnLoadMethod]
    static void AddMenuItems()
    {
        // Get all files in the template folder
        string[] templatePaths = Directory.GetFiles(TEMPLATE_FOLDER, "*.txt", SearchOption.AllDirectories);
        // Read the handler script content
        string scriptContent = File.ReadAllText(HANDLER_SCRIPT_PATH);
        // Add a menu item for each template file
        for (int i = 0; i < templatePaths.Length; i++)
        {
            string templatePath = templatePaths[i];
            string defaultName = Path.GetFileNameWithoutExtension(templatePath);
            string templateName = defaultName.Remove(0, 7);
            string methodName = "Create" + templateName;
            string priorityString = priority.ToString();
            // Check if the method already exists in the handler script
            if (!scriptContent.Contains(templateName))
            {
                // Add the new method to the handler script
                string newMethod = string.Format(menuItemTemplate, templateName, methodName, defaultName, templatePath, priorityString);
                scriptContent = scriptContent.Replace("}// final", " ");
                scriptContent += "\n" + newMethod;
                scriptContent = scriptContent.Replace(" Default", " ");

                File.WriteAllText(HANDLER_SCRIPT_PATH, scriptContent);
            }
            priority++;
        }
    }
}
