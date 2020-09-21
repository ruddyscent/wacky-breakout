using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{ 
    #region Fields

    const string ConfigurationDataFileName = "ConfigurationData.csv";

    // configuration data
    float paddleMoveUnitsPerSecond = 10;
    float ballImpulseForce = 200;
    float ballPauseTime = 1;
    int givenNumberOfBalls = 3;
    int standardBlockPiont = 1;
    int bonusBlockPiont = 1;
    float freezingRatio = -0.5f;
    float freezingTime = 5f;
    
    float speedupRatio = 0.5f;
    float speedupTime = 5f;
    float bonusBlockFrequency = 0.1f;
    float freezerBlockFrequency = 0.1f;
    float speedupBlockFrequency = 0.1f;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public float PaddleMoveUnitsPerSecond
    {
        get { return paddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public float BallImpulseForce
    {
        get { return ballImpulseForce; }    
    }

    public float BallPauseTime
    {
        get { return ballPauseTime; }    
    }

    public int GivenNumberOfBalls
    {
        get { return givenNumberOfBalls; }    
    }

    public int StandardBlockPiont
    {
        get { return standardBlockPiont; }    
    }

    public int BonusBlockPiont
    {
        get { return bonusBlockPiont; }    
    }

    public float FreezingRatio
    {
        get { return freezingRatio; }
    }

    public float FreezingTime
    {
        get { return freezingTime; }
    }

    public float SpeedupRatio
    {
        get { return speedupRatio; }
    }

    public float SpeedupTime
    {
        get { return speedupTime; }
    }

    public float BonusBlockFrequency
    {
        get { return bonusBlockFrequency; }
    }

    public float SpeedupBlockFrequency
    {
        get { return speedupBlockFrequency; }
    }

    public float FreezerBlockFrequency
    {
        get { return freezerBlockFrequency; }
    }
    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData()
    {
        // read and save configuration data from file
        StreamReader input = null;
        try
        {
            // create stream reader object
            input = File.OpenText(Path.Combine(
                Application.streamingAssetsPath, ConfigurationDataFileName));

            // read in names and values
            string names = input.ReadLine();
            string values = input.ReadLine();

            // set configuration data fields
            SetConfigurationDataFields(values);
        }
        catch (Exception)
        {
        }
        finally
        {               
            // always close input file
            if (input != null)
            {
                input.Close();
            }
        }
    }

    /// <summary>
    /// Sets the configuration data fields from the provided
    /// csv string
    /// </summary>
    /// <param name="csvValues">csv string of values</param>
    void SetConfigurationDataFields(string csvValues)
    {
        // the code below assumes we know the order in which the
        // values appear in the string. We could do something more
        // complicated with the names and values, but that's not
        // necessary here
        string[] values = csvValues.Split(','); 
        paddleMoveUnitsPerSecond = float.Parse(values[0]);
        ballImpulseForce = float.Parse(values[1]);
        ballPauseTime = float.Parse(values[2]);
        givenNumberOfBalls = int.Parse(values[3]);
        standardBlockPiont = int.Parse(values[4]);
        bonusBlockPiont = int.Parse(values[5]);
        freezingRatio = float.Parse(values[6]);
        freezingTime = float.Parse(values[7]);
        speedupRatio = float.Parse(values[8]);
        speedupTime = float.Parse(values[9]);
        bonusBlockFrequency = float.Parse(values[10]);
        freezerBlockFrequency = float.Parse(values[11]);
        speedupBlockFrequency = float.Parse(values[12]);
    }

    #endregion
}
