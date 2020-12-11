using UnityEngine;
using RosJoy = RosMessageTypes.RosSharpTCP.Joy;
using RosSharp.RosBridgeClient;

public class JoySubscriberExample : MonoBehaviour
{
  public ROSConnection ros;
  public JoyButtonWriter[] joyButtonWriters;
  public JoyAxisWriter[] joyAxisWriters;

  void Start()
  {
    ros.Subscribe<RosJoy>("joy", driveWheels);
  }

  void driveWheels(RosJoy joyMessage)
  {
    int I = joyButtonWriters.Length < joyMessage.buttons.Length ? joyButtonWriters.Length : joyMessage.buttons.Length;
    for (int i = 0; i < I; i++)
        if (joyButtonWriters[i] != null)
            joyButtonWriters[i].Write(joyMessage.buttons[i]);

    I = joyAxisWriters.Length < joyMessage.axes.Length ? joyAxisWriters.Length : joyMessage.axes.Length;
    for (int i = 0; i < I; i++)
        if (joyAxisWriters[i] != null)
            joyAxisWriters[i].Write(joyMessage.axes[i]);
  }
}
