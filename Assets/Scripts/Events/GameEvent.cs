using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GameEvent class, handles event logic for the entire game. <br/>
/// Unless absolutely necessary, DO NOT touch this code. 
/// </summary>
[CreateAssetMenu(menuName ="Game Event")]
public class GameEvent : ScriptableObject
{
    private List<GameEventListener> listeners = new List<GameEventListener>();

    /// <summary>
    /// Triggers the game event, broadcasting it to all listeners. 
    /// </summary>
    public void TriggerEvent()
    {
        for (int i = listeners.Count -1; i >= 0; i--)
        {
            listeners[i].OnEventTriggered();
        }
    }

    /// <summary>
    /// Adds a listener to the event notifier list. 
    /// </summary>
    /// <param name="listener">The GameEventListener script to add.</param>
    public void AddListener(GameEventListener listener)
    {
        listeners.Add(listener);
    }
    
    /// <summary>
    /// Removes a listener from the event notifier list. 
    /// </summary>
    /// <param name="listener">The GameEventListener script to remove.</param>
    public void RemoveListener(GameEventListener listener)
    {
        listeners.Remove(listener);
    }
}