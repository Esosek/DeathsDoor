using UnityEngine;
using UnityEditor;

#if (UNITY_EDITOR)
[CustomEditor(typeof(GameEvent))]
public class GameEventEditor : Editor
{
    // magic for debugging raising events
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GameEvent _event = (GameEvent) target;
        if (GUILayout.Button("Raise"))
        {
            _event.Raise();
        }
    }
}
#endif