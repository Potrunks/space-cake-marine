using Assets.Scripts.GameEvents.ScriptableObjects;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class DevicesManager : MonoBehaviour
{
    [field: Header("--- Game Events ---")]
    [field: SerializeField]
    public GameEvent OnGamepadConnectedDetected { get; private set; }

    [field: SerializeField]
    public GameEvent OnNoGamepadConnectedDetected { get; private set; }

    private List<InputDevice> _gamepadDevices;

    private void Awake()
    {
        InputSystem.onDeviceChange += OnDeviceChange;
        _gamepadDevices = InputSystem.devices.Where(dev => dev is Gamepad).ToList();
        CheckGamepadConnected();
    }

    private void OnDeviceChange(InputDevice concernedDevice, InputDeviceChange changeType)
    {
        if (changeType == InputDeviceChange.Added && concernedDevice is Gamepad && !_gamepadDevices.Contains(concernedDevice))
        {
            _gamepadDevices.Add(concernedDevice);
        }

        if (changeType == InputDeviceChange.Removed)
        {
            _gamepadDevices.Remove(concernedDevice);
        }

        CheckGamepadConnected();
    }

    private void CheckGamepadConnected()
    {
        if (_gamepadDevices.Any())
        {
            OnGamepadConnectedDetected.Raise();
        }
        else
        {
            OnNoGamepadConnectedDetected.Raise();
        }
    }
}
