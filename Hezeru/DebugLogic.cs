using Hezeru.Rendering;
using KeplerEngine;
using Microsoft.Xna.Framework.Input;

namespace Hezeru;

public class DebugLogic
{

    public void Update()
    {
        // Toggle debug layer with F2
        Globals.Keyboard.OnKeyPressedOnce(Keys.F2, () => {
            RenderLayers.DebugLayer.Enabled = !RenderLayers.DebugLayer.Enabled;
        });
        

        // Cycle scaling modes with F3
        Globals.Keyboard.OnKeyPressedOnce(Keys.F3, () => {
            var modes = System.Enum.GetValues(typeof(Globals.ScalingMode));
            int currentIndex = (int)Globals.CurrentScalingMode;
            currentIndex = (currentIndex + 1) % modes.Length;
            Globals.CurrentScalingMode = (Globals.ScalingMode)modes.GetValue(currentIndex);
        });
    }
}
