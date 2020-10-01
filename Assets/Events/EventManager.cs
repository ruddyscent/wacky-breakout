﻿using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    static FreezerBlock freezeInvoker;
    static UnityAction<float> freezeListener;
    static SpeedupBlock speedupInvoker;
    static UnityAction<float, float> speedupListener;
    static Block addPointsInvoker;
    static UnityAction<int> addPointsListener;

    public static void AddFreezerInvoker(FreezerBlock script)
    {
        freezeInvoker = script;
        if (freezeListener != null)
        {
            freezeInvoker.AddFreezerEffectListener(freezeListener);
        }
    }

    public static void AddFreezerEffectListener(UnityAction<float> handler)
    {
        freezeListener = handler;
        if (freezeInvoker != null)
        {
            freezeInvoker.AddFreezerEffectListener(freezeListener);         
        }
    }

    public static void AddSpeedupInvoker(SpeedupBlock script)
    {
        speedupInvoker = script;
        if (speedupListener != null)
        {
            speedupInvoker.AddSpeedupEffectListener(speedupListener);
        }
    }

    public static void AddSpeedupListener(UnityAction<float, float> handler)
    {
        speedupListener = handler;
        if (speedupInvoker != null)
        {
            speedupInvoker.AddSpeedupEffectListener(speedupListener);         
        }
    }

    public static void AddPointsInvoker(Block script)
    {
        addPointsInvoker = script;
        if (addPointsListener != null)
        {
            addPointsInvoker.AddPointsListener(addPointsListener);
        }
    }

    public static void AddPointsListener(UnityAction<int> handler)
    {
        addPointsListener = handler;
        if (addPointsInvoker != null)
        {
            addPointsInvoker.AddPointsListener(addPointsListener);
        }
    }
}
