using UnityEngine;

namespace SEGFramework.InputSystem
{
    /// <summary>
    /// Configuration class for input settings in the SEG Framework.
    /// This class defines the key bindings for primary, secondary, and tertiary actions.
    /// </summary>
    [System.Serializable]
    public static class InputConfig
    {
        public static KeyCode PrimaryKey = KeyCode.Mouse0;
        public static KeyCode SecondaryKey = KeyCode.Mouse1;
        public static KeyCode TertiaryKey = KeyCode.Mouse2;
    }
}
