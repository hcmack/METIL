using System;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    private static EventManager instance;

    private Dictionary<string, Action> eventDictionary;

    public static EventManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<EventManager>();
                if (instance == null)
                {
                    GameObject singleton = new GameObject("EventManager");
                    instance = singleton.AddComponent<EventManager>();
                    DontDestroyOnLoad(singleton);
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            eventDictionary = new Dictionary<string, Action>();
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public static void StartListening(string eventName, Action listener)
    {
        if (Instance.eventDictionary.TryGetValue(eventName, out Action thisEvent))
        {
            thisEvent += listener;
            Instance.eventDictionary[eventName] = thisEvent;
        }
        else
        {
            Instance.eventDictionary[eventName] = listener;
        }
    }

    public static void StopListening(string eventName, Action listener)
    {
        if (instance == null) return;

        if (Instance.eventDictionary.TryGetValue(eventName, out Action thisEvent))
        {
            thisEvent -= listener;
            if (thisEvent == null)
            {
                Instance.eventDictionary.Remove(eventName);
            }
            else
            {
                Instance.eventDictionary[eventName] = thisEvent;
            }
        }
    }

    public static void TriggerEvent(string eventName)
    {
        if (Instance.eventDictionary.TryGetValue(eventName, out Action thisEvent))
        {
            thisEvent?.Invoke();
        }
        else
        {
            Debug.LogWarning($"Event '{eventName}' has no listeners!");
        }
    }

    public static void TriggerAction(Action customAction)
    {
        customAction?.Invoke();
        Debug.Log("Custom action triggered.");
    }
}
