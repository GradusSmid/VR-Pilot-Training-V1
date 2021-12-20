﻿using Android.BLE.Extension;
using System;
namespace Android.BLE.Commands
{
    public class SubscribeToCharacteristic : BleCommand
    {
        public readonly string DeviceAddress;

        public readonly string Service;
        public readonly string Characteristic;

        public readonly CharacteristicChanged OnCharacteristicChanged;

        private readonly bool _customGatt = false;

        public SubscribeToCharacteristic(string deviceAddress, string service, string characteristic) : base(true, true)
        {
            DeviceAddress = deviceAddress;

            Service = service;
            Characteristic = characteristic;
        }

        public SubscribeToCharacteristic(string deviceAddress, string service, string characteristic, Action<byte[]> onDataFound) : base(true, true)
        {
            DeviceAddress = deviceAddress;

            Service = service;
            Characteristic = characteristic;
            
            OnCharacteristicChanged += new CharacteristicChanged(onDataFound);
        }

        public override void Start()
        {
            string command = _customGatt ? "subscribeToCustomGattCharacteristic" : "subscribeToGattCharacteristic";
            BleManager.SendCommand(command, DeviceAddress, Service, Characteristic);
        }

        public override void End()
        {
            string command = _customGatt ? "unsubscribeFromCustomGattCharacteristic" : "unsubscribeFromGattCharacteristic";
            BleManager.SendCommand(command, DeviceAddress, Service, Characteristic);
        }

        public void Unsubscribe() => End();

        public override bool CommandReceived(BleObject obj)
        {
            if (string.Equals(obj.Command, "CharacteristicValueChanged"))
            {
                if (obj.Characteristic.Length > 4)
                {
                    if (string.Equals(obj.Device, DeviceAddress) &&
                        string.Equals(obj.Service, DeviceAddress) &&
                        string.Equals(obj.Characteristic, Characteristic))
                    {
                        OnCharacteristicChanged?.Invoke(obj.GetByteMessage());
                    }
                }
                else
                {
                    if (string.Equals(obj.Device, DeviceAddress) &&
                        string.Equals(obj.Service, DeviceAddress) &&
                        string.Equals(obj.Characteristic, Characteristic.Get16BitUuid()))
                    {
                        OnCharacteristicChanged?.Invoke(obj.GetByteMessage());
                    }
                }
            }

            return false;
        }

        public delegate void CharacteristicChanged(byte[] value);

    }
}