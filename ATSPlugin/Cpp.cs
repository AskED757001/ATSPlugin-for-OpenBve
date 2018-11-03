using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATSPlugin
{
    public class Cpp
    {
        //ここからatsplugin.h
        public struct ATS_VEHICLESPEC
        {
            public int BrakeNotches;
            public int PowerNotches;
            public int AtsNotch;
            public int B67Notch;
            public int Cars;
        };
        public struct ATS_VEHICLESTATE
        {
            public double Location;
            public float Speed;
            public int Time;
            public float BcPressure;
            public float MrPressure;
            public float ErPressure;
            public float BpPressure;
            public float SapPressure;
            public float Current;
        };
        public struct ATS_BEACONDATA
        {
            public int Type;
            public int Signal;
            public float Distance;
            public int Optional;
        };
        public struct ATS_HANDLES
        {
            public int Brake;
            public int Power;
            public int Reverser;
            public int ConstantSpeed;
        };
        const int ATS_CONSTANTSPEED_CONTINUE = 0;
        const int ATS_CONSTANTSPEED_ENABLE = 1;
        const int ATS_CONSTANTSPEED_DISABLE = 2;

        const int ATS_KEY_S = 0;
        const int ATS_KEY_A1 = 1;
        const int ATS_KEY_A2 = 2;
        const int ATS_KEY_B1 = 3;
        const int ATS_KEY_B2 = 4;
        const int ATS_KEY_C1 = 5;
        const int ATS_KEY_C2 = 6;
        const int ATS_KEY_D = 7;
        const int ATS_KEY_E = 8;
        const int ATS_KEY_F = 9;
        const int ATS_KEY_G = 10;
        const int ATS_KEY_H = 11;
        const int ATS_KEY_I = 12;
        const int ATS_KEY_J = 13;
        const int ATS_KEY_K = 14;
        const int ATS_KEY_L = 15;

        const int ATS_INIT_REMOVED = 2;
        const int ATS_INIT_EMG = 1;
        const int ATS_INIT_SVC = 0;

        const int ATS_SOUND_STOP = -10000;
        const int ATS_SOUND_PLAY = 1;
        const int ATS_SOUND_PLAYLOOPING = 0;
        const int ATS_SOUND_CONTINUE = 2;

        const int ATS_HORN_PRIMARY = 0;
        const int ATS_HORN_SECONDARY = 1;
        const int ATS_HORN_MUSIC = 2;
        
        public static ATS_HANDLES output;
        //ここまで変更注意
        static int powerNotch;
        static int brakeNotch;
        static int reverser;
        public static void Load()
        {

        }
        public static void Dispose()
        {

        }
        public static void GetPluginVersion()
        {

        }
        public static void SetVehicleSpec(ATS_VEHICLESPEC vehicleSpec)
        {

        }
        public static void Initialize(int brake)
        {

        }
        public static ATS_HANDLES Elapse(ATS_VEHICLESTATE vehicleState, int[] panel, int[] sound)
        {
            output.Brake = brakeNotch;
            output.Power = powerNotch;
            output.Reverser = reverser;
            return output;
        }
        public static void SetPower(int notch)
        {
            powerNotch = notch;
        }
        public static void SetBrake(int notch)
        {
            brakeNotch = notch;
        }
        public static void SetReverser(int pos)
        {
            reverser = pos;
        }
        public static void KeyDown(int atsKeyCode)
        {

        }
        public static void KeyUp(int atsKeyCode)
        {

        }
        public static void HornBlow(int hornType)
        {

        }
        public static void DoorOpen()
        {

        }
        public static void DoorClose()
        {

        }
        public static void SetSignal(int signal)
        {

        }
        public static void SetBeaconData(ATS_BEACONDATA beaconData)
        {

        }
    }
}
