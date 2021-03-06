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
    static Ball looseBallInvoker;
    static UnityAction looseBallListener;
    static Ball spawnBallInvoker;
    static UnityAction spawnBallListener;
    static Ball gameOverInvoker;
    static UnityAction gameOverListener;
    static Block blockDestroyedInvoker;
    static UnityAction blockDestroyedListener;

    public static void AddBlockDestroyedInvoker(Block script)
    {
        blockDestroyedInvoker = script;
        if (blockDestroyedListener != null)
        {
            blockDestroyedInvoker.AddBlockDestroyedListener(blockDestroyedListener);
        }
    }

    public static void AddBlockDestroyedListener(UnityAction handler)
    {
        blockDestroyedListener = handler;
        if (blockDestroyedInvoker != null)
        {
            blockDestroyedInvoker.AddBlockDestroyedListener(blockDestroyedListener);         
        }
    }

    public static void AddGameOverInvoker(Ball script)
    {
        gameOverInvoker = script;
        if (gameOverListener != null)
        {
            gameOverInvoker.AddGameOverListener(gameOverListener);
        }
    }

    public static void AddGameOverListener(UnityAction handler)
    {
        gameOverListener = handler;
        if (gameOverInvoker != null)
        {
            gameOverInvoker.AddGameOverListener(gameOverListener);         
        }
    }

    public static void AddSpawnBallInvoker(Ball script)
    {
        spawnBallInvoker = script;
        if (spawnBallListener != null)
        {
            spawnBallInvoker.AddSpawnBallListener(spawnBallListener);
        }
    }

    public static void AddSpawnBallListener(UnityAction handler)
    {
        spawnBallListener = handler;
        if (spawnBallInvoker != null)
        {
            spawnBallInvoker.AddSpawnBallListener(spawnBallListener);         
        }
    }

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

    public static void AddAddPointsInvoker(Block script)
    {
        addPointsInvoker = script;
        if (addPointsListener != null)
        {
            addPointsInvoker.AddPointsListener(addPointsListener);
        }
    }

    public static void AddAddPointsListener(UnityAction<int> handler)
    {
        addPointsListener = handler;
        if (addPointsInvoker != null)
        {
            addPointsInvoker.AddPointsListener(addPointsListener);
        }
    }

    public static void AddLooseBallInvoker(Ball script)
    {
        looseBallInvoker = script;
        if (looseBallListener != null)
        {
            looseBallInvoker.AddLooseBallListener(looseBallListener);
        }
    }

    public static void AddLooseBallListener(UnityAction handler)
    {
        looseBallListener = handler;
        if (looseBallInvoker != null)
        {
            looseBallInvoker.AddLooseBallListener(looseBallListener);
        }
    }
}
