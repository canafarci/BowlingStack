using UnityEngine;

public enum RaycastState
{
    Inactive,
    Click,
    Drag,
    Swipe
}

public enum RepairStage
{
    Wall,
    Floor,
    Window,
    Paint,
    Mopping,
    Reset
}
public static class CameraStrings
{
    public static string FirstCamera = "FirstCamera";
    public static string LeftSideCamera = "LeftSideCamera";
    public static string RightSideCamera = "RightSideCamera";
}
public static class PrefKeys
{
    public static string Money = "Money";
    public static string GameplayLoop = "GameplayLoop";
}

public static class AnimationHashes
{
    
}