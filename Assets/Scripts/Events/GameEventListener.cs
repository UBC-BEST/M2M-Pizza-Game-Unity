using UnityEngine;
using UnityEngine.Events;

/// <summary>
///     GameEventListener class, handles event logic for the entire game. Enables the listening for an event when added to
///     a GameObject.<br />
///     Unless absolutely necessary, DO NOT touch this code.
/// </summary>
public class GameEventListener : MonoBehaviour
{
    public GameEvent gameEvent;
    public UnityEvent onEventTriggered;

    /// <summary>
    ///     When the GameObject is enabled, add this listener to the specified event notifier list.
    /// </summary>
    private void OnEnable()
    {
        gameEvent.AddListener(this);
    }

    /// <summary>
    ///     When the GameObject is disabled, remove this listener from the specified event notifier list.
    /// </summary>
    private void OnDisable()
    {
        gameEvent.RemoveListener(this);
    }

    /// <summary>
    ///     When the event to be listened to is broadcasted, run the function tied to the event.
    /// </summary>
    public void OnEventTriggered()
    {
        onEventTriggered.Invoke();
    }
}