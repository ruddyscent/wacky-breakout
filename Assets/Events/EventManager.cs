using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    static FreezerBlock invoker;
    static UnityAction<float> listener;

    public static void AddInvoker(FreezerBlock script)
    {
        invoker = script;
        if (listener != null)
        {
            invoker.AddFreezerEffectListener(listener);
        }
    }

    public static void AddListener(UnityAction<float> handler)
    {
        listener = handler;
        if (invoker != null)
        {
            invoker.AddFreezerEffectListener(listener);         
        }
    }
}
