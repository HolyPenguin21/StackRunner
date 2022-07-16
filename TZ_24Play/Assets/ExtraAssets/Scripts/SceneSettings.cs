using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSettings
{
    public enum InputType { pc, mobile};

    public void Set_Framerate(int fps)
    {
        Application.targetFrameRate = fps;
    }

    public InputType Get_InputType()
    {
        if (SystemInfo.deviceType == DeviceType.Handheld)
            return InputType.mobile;
        else
            return InputType.pc;
    }
}
