using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
Class to keep track of all gameObject names and tags. Any constants go in here.
 */
public class Constants
{
    // Sound source names
    public const string SOUND_MARCO = "sound_marco";
    public const string SOUND_POLO = "sound_polo";
    public const string SOUND_VICTORY = "sound_victory";

    // Scene names
    public const string SCENE_NAME = "SampleScene";

    // Tags
    public const string TAG_POLO = "polo";
    public const string TAG_OBSTACLE = "obstacle";
    public const string TAG_CANVAS = "canvas";

    // Numbers
    public const int MAX_RANGE = 5;
    public const int MIN_RANGE = 1;
    public const int SPEED_POLO = 1000;

    // Time
    public const int WAVE_LIFE_TIME = 10;
}