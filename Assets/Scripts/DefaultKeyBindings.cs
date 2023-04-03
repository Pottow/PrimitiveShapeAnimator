using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultKeyBindings : MonoBehaviour
{
    KeyCode up = KeyCode.E; 
    KeyCode down = KeyCode.Q; 
    KeyCode forward = KeyCode.W; 
    KeyCode left = KeyCode.A; 
    KeyCode back = KeyCode.S; 
    KeyCode right = KeyCode.D; 
    KeyCode deselect = KeyCode.Space; 
    KeyCode delete = KeyCode.Delete; 
    KeyCode rotateMode = KeyCode.R; 
    KeyCode moveMode = KeyCode.F; 
    KeyCode scaleMode = KeyCode.X; 
    KeyCode cameraMode = KeyCode.C; 
    KeyCode quit = KeyCode.Escape;
    KeyCode comboKey = KeyCode.LeftControl;
    KeyCode duplicate = KeyCode.D; 

    public KeyCode Up { get => up; set => up = value; }
    public KeyCode Down { get => down; set => down = value; }
    public KeyCode Forward { get => forward; set => forward = value; }
    public KeyCode Left { get => left; set => left = value; }
    public KeyCode Back { get => back; set => back = value; }
    public KeyCode Right { get => right; set => right = value; }
    public KeyCode Deselect { get => deselect; set => deselect = value; }
    public KeyCode Delete { get => delete; set => delete = value; }
    public KeyCode RotateMode { get => rotateMode; set => rotateMode = value; }
    public KeyCode MoveMode { get => moveMode; set => moveMode = value; }
    public KeyCode ScaleMode { get => scaleMode; set => scaleMode = value; }
    public KeyCode CameraMode { get => cameraMode; set => cameraMode = value; }
    public KeyCode Quit { get => quit; set => quit = value; }
    public KeyCode ComboKey { get => comboKey; set => comboKey = value; }
    public KeyCode Duplicate { get => duplicate; set => duplicate = value; }
}
