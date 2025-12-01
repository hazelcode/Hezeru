using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace KeplerEngine.Input;

public class KeyboardInputHandler
{
    private KeyboardState _prevKbState;
    private KeyboardState _actualKbState;
    private Action _inputs;
    private Dictionary<string, int> _timeCounters;

    public KeyboardInputHandler()
    {
        _inputs = () => { };
        _timeCounters = [];
    }

    public void OnKeyPressedOnce(Keys key, Action action)
    {
        _inputs += () =>
        {
            if (_actualKbState.IsKeyDown(key) && !_prevKbState.IsKeyDown(key))
            {
                action();
            }
        };
    }

    public void RegisterTimeCounter(string counterName)
    {
        _timeCounters.Add(counterName, 0);
    }

    public void OnKeyHolded(Keys key, string counterName, int requiredTime, Action action)
    {
        if (!_timeCounters.ContainsKey(counterName))
            throw new IndexOutOfRangeException($"\"{counterName}\" is not registered in the time counters of this keyboard input handler.");

        _inputs += () =>
        {
            if (!_actualKbState.IsKeyDown(key))
            {
                _timeCounters[counterName] = 0;
            }
            else
            {
                _timeCounters[counterName] += 1;
                if (_timeCounters[counterName] == requiredTime)
                {
                    action();
                    _timeCounters[counterName] = 0;
                }
            }
        };
    }

    public void Update()
    {
        _actualKbState = Keyboard.GetState();

        _inputs(); // Attend inputs here.

        _inputs = () => { }; // Clear inputs which will return on the next Update() call.

        _prevKbState = _actualKbState;
    }
}