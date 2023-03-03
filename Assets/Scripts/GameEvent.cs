using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameEvent : ScriptableObject
{
	[SerializeField] private bool debugLog = true;
	private List<GameEventListener> listeners = new List<GameEventListener>();

	public void Raise()
	{
		if(debugLog ) Debug.Log(name + " event raised"); // logging - could be disabled 

		for (int i = listeners.Count - 1; i >= 0; i--) // count backwards to avoid range errors
			listeners[i].OnEventRaised();
	}

	public void RegisterListener(GameEventListener listener)
	{ listeners.Add(listener); }

	public void UnregisterListener(GameEventListener listener)
	{ listeners.Remove(listener); }
}