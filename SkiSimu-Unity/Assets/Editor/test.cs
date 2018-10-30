using UnityEditor;

/// <summary>
/// Unity エディタのメニューのコマンドを実行する関数を管理するクラス
/// </summary>
public static class Shortcut
{
    /// <summary>
    /// InputManager を Inspector ビューに表示します
    /// Alt + 1 キーでも実行できます
    /// </summary>
    [MenuItem("Shortcut/Input &1")]
    public static void OpenInputManager()
    {
        EditorApplication.ExecuteMenuItem("Edit/Project Settings/Input");
    }

    /// <summary>
    /// Tags & Layers を Inspector ビューに表示します
    /// Alt + 2 キーでも実行できます
    /// </summary>
    [MenuItem("Shortcut/Tags and Layers &2")]
    public static void OpenTagsAndLayers()
    {
        EditorApplication.ExecuteMenuItem("Edit/Project Settings/Tags and Layers");
    }

    /// <summary>
    /// PhysicsManager を Inspector ビューに表示します
    /// Alt + 3 キーでも実行できます
    /// </summary>
    [MenuItem("Shortcut/Physics Manager &3")]
    public static void OpenPhysicsManager()
    {
        EditorApplication.ExecuteMenuItem("Edit/Project Settings/Physics");
    }
}