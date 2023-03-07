using UnityEditor;
using UnityEngine;

#if (UNITY_EDITOR)
[CustomEditor(typeof (Hand), true)]
public class HandEditor : Editor
{
    Hand hand;

    private int index;
    private Card card;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        hand = (Hand) target; // get reference to Deck instance

        GUILayout.Label("Debugger", EditorStyles.boldLabel); // bold header
        
        if (GUILayout.Button("Clear")) hand.ClearHand(); 
        if (GUILayout.Button("Add Card"))
        {
            hand.AddCard(hand.cardGen.GenerateCard()); 
        }
    }
}
#endif