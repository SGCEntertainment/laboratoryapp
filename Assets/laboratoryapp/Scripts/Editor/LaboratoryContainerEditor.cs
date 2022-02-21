using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Laboratory_container))]
public class LaboratoryContainerEditor : Editor
{
    SerializedProperty laboratory_name;
    SerializedProperty target_work;
    SerializedProperty devices_materials;
    SerializedProperty instructions_work;
    SerializedProperty speech;

    SerializedProperty phrase;

    private void OnEnable()
    {
        laboratory_name = serializedObject.FindProperty("laboratory_name");
        target_work = serializedObject.FindProperty("target_work");
        devices_materials = serializedObject.FindProperty("devices_materials");
        instructions_work = serializedObject.FindProperty("instructions_work");
        speech = serializedObject.FindProperty("speech");

        phrase = serializedObject.FindProperty("phrase");
    }

    string TextField(string text, string placeholder)
    {
        var newText = EditorGUILayout.TextField(text);
        if (string.IsNullOrEmpty(text))
        {
            var guiColor = GUI.color;
            GUI.color = Color.grey;
            EditorGUI.LabelField(GUILayoutUtility.GetLastRect(), placeholder);
            GUI.color = guiColor;
        }
        return newText;
    }

    string TextArea(string text, string placeholder)
    {
        return TextInput(text, placeholder, area: true);
    }

    private string TextInput(string text, string placeholder, bool area = false)
    {
        var newText = area ? EditorGUILayout.TextArea(text) : EditorGUILayout.TextField(text);
        if (string.IsNullOrEmpty(text.Trim()))
        {
            const int textMargin = 2;
            var guiColor = GUI.color;
            GUI.color = Color.gray;
            var textRect = GUILayoutUtility.GetLastRect();
            var position = new Rect(textRect.x + textMargin, textRect.y, textRect.width, textRect.height);
            EditorGUI.LabelField(position, placeholder);
            GUI.color = guiColor;
        }
        return newText;
    }

    void DrawHeadInfo()
    {
        GUIStyle style = new GUIStyle
        {
            fontStyle = FontStyle.Bold
        };

        EditorGUILayout.LabelField("Информация о лабораторной работе", style, GUILayout.Height(20));

        EditorGUILayout.Space(10);

        EditorGUILayout.BeginVertical(new GUIStyle(EditorStyles.helpBox));

        GUILayout.Label("Название лабораторной работы", style);
        laboratory_name.stringValue = TextArea(laboratory_name.stringValue, "");

        EditorStyles.textField.wordWrap = true;

        GUILayout.Label("Цель работы", style);
        target_work.stringValue = TextArea(target_work.stringValue, "");
        GUILayout.Space(6);

        GUILayout.Label("Приборы и материалы", style);
        devices_materials.stringValue = TextArea(devices_materials.stringValue, "");
        GUILayout.Space(6);

        GUILayout.Label("Указания к работе", style);
        instructions_work.stringValue = TextArea(instructions_work.stringValue, "");
        GUILayout.Space(6);

        EditorGUILayout.ObjectField(speech, new GUIContent("Текущая речь"), GUILayout.Height(20));

        EditorGUILayout.EndVertical();
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        DrawHeadInfo();

        serializedObject.ApplyModifiedProperties();
    }
}
