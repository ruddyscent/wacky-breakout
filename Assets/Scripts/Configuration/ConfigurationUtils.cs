using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    #region Fields
    static ConfigurationData configurationData;
    #endregion

    #region Properties
    
    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public static float PaddleMoveUnitsPerSecond
    {
        get { return configurationData.PaddleMoveUnitsPerSecond; }
    }

    public static float BallImpulseForce
    {
        get { return configurationData.BallImpulseForce; }
    }

    public static float BallPauseTime
    {
        get { return configurationData.BallPauseTime; }
    }

    public static int GivenNumberOfBalls
    {
        get { return configurationData.GivenNumberOfBalls; }
    }

    public static int StandardBlockPoint
    {
        get { return configurationData.StandardBlockPiont; }
    }

    #endregion

    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
        configurationData = new ConfigurationData();
    }
}
