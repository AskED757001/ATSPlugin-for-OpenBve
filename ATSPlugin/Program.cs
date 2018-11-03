using OpenBveApi.Runtime;
namespace Plugin
{
    
    public class Plugin : IRuntime
    {
        int brakeNotch;
        int powerNotch;
        int reverser;
        int[] panel = new int[256];
        int[] sound = new int[256];
        PlaySoundDelegate SoundDelegate;
        SoundHandle[] Handle = new SoundHandle[256];

        public bool Load(LoadProperties properties)
        {
            properties.Panel = new int[256];
            panel = properties.Panel;
            SoundDelegate = properties.PlaySound;
            ATSPlugin.Cpp.Load();
            ATSPlugin.Cpp.GetPluginVersion();
            return true;
        }
        
        public void Unload()
        {
            ATSPlugin.Cpp.Dispose();
        }

        public void SetVehicleSpecs(VehicleSpecs specs)
        {
            ATSPlugin.Cpp.ATS_VEHICLESPEC vehicleSpec;
            vehicleSpec.AtsNotch = specs.AtsNotch;
            vehicleSpec.B67Notch = specs.B67Notch;
            vehicleSpec.BrakeNotches = specs.BrakeNotches;
            vehicleSpec.Cars = specs.Cars;
            vehicleSpec.PowerNotches = specs.PowerNotches;
            ATSPlugin.Cpp.SetVehicleSpec(vehicleSpec);

        }
        
        public void Initialize(InitializationModes mode)
        {
            ATSPlugin.Cpp.Initialize(0);
        }
        
        public void Elapse(ElapseData data)
        {
            ATSPlugin.Cpp.ATS_VEHICLESTATE vehicleState = new ATSPlugin.Cpp.ATS_VEHICLESTATE();
            ATSPlugin.Cpp.ATS_HANDLES Output;
            vehicleState.BcPressure = (float)data.Vehicle.BcPressure;
            vehicleState.BpPressure = (float)data.Vehicle.BpPressure;
            vehicleState.ErPressure = (float)data.Vehicle.ErPressure;
            vehicleState.Location = data.Vehicle.Location;
            vehicleState.MrPressure = (float)data.Vehicle.MrPressure;
            vehicleState.SapPressure = (float)data.Vehicle.SapPressure;
            vehicleState.Speed = (float)data.Vehicle.Speed.KilometersPerHour;
            vehicleState.Time = (int)data.ElapsedTime.Milliseconds;
            Output = ATSPlugin.Cpp.Elapse(vehicleState, panel, sound);
            int i = 0;
            while (i++ < 256)
            {
                if (sound[i] == 0)
                    Handle[i] = SoundDelegate(i, 1, 1, true);
                else if (sound[i] == 1)
                    SoundDelegate(i, 1, 1, false);
                else if (sound[i] == -10000)
                    Handle[i].Stop();
                else if (sound[i] > -10000 && sound[i] < 0)
                    Handle[i] = SoundDelegate(i, 1 - (double)sound[i] / 10000, 1, true);
            }
            data.Handles.BrakeNotch = Output.Brake;
            data.Handles.PowerNotch = Output.Power;
            data.Handles.Reverser = Output.Reverser;
            if (Output.ConstantSpeed == 1)
                data.Handles.ConstSpeed = true;
            if (Output.ConstantSpeed == 2)
                data.Handles.ConstSpeed = false;

        }
        
        public void SetReverser(int reverser)
        {
            ATSPlugin.Cpp.SetReverser(reverser);
            this.reverser = reverser;
        }
        
        public void SetPower(int powerNotch)
        {
            ATSPlugin.Cpp.SetPower(powerNotch);
            this.powerNotch = powerNotch;
        }
        
        public void SetBrake(int brakeNotch)
        {
            ATSPlugin.Cpp.SetBrake(brakeNotch);
            this.brakeNotch = brakeNotch;
        }
        
        public void KeyDown(VirtualKeys key)
        {
            if (key == VirtualKeys.S)
                ATSPlugin.Cpp.KeyDown(0);
            if (key == VirtualKeys.A1)
                ATSPlugin.Cpp.KeyDown(1);
            if (key == VirtualKeys.A2)
                ATSPlugin.Cpp.KeyDown(2);
            if (key == VirtualKeys.B1)
                ATSPlugin.Cpp.KeyDown(3);
            if (key == VirtualKeys.B2)
                ATSPlugin.Cpp.KeyDown(4);
            if (key == VirtualKeys.C1)
                ATSPlugin.Cpp.KeyDown(5);
            if (key == VirtualKeys.C2)
                ATSPlugin.Cpp.KeyDown(6);
            if (key == VirtualKeys.D)
                ATSPlugin.Cpp.KeyDown(7);
            if (key == VirtualKeys.E)
                ATSPlugin.Cpp.KeyDown(8);
            if (key == VirtualKeys.F)
                ATSPlugin.Cpp.KeyDown(9);
            if (key == VirtualKeys.G)
                ATSPlugin.Cpp.KeyDown(10);
            if (key == VirtualKeys.H)
                ATSPlugin.Cpp.KeyDown(11);
            if (key == VirtualKeys.I)
                ATSPlugin.Cpp.KeyDown(12);
            if (key == VirtualKeys.J)
                ATSPlugin.Cpp.KeyDown(13);
            if (key == VirtualKeys.K)
                ATSPlugin.Cpp.KeyDown(14);
            if (key == VirtualKeys.L)
                ATSPlugin.Cpp.KeyDown(15);
        }
        
        public void KeyUp(VirtualKeys key)
        {
            if (key == VirtualKeys.S)
                ATSPlugin.Cpp.KeyUp(0);
            if (key == VirtualKeys.A1)
                ATSPlugin.Cpp.KeyUp(1);
            if (key == VirtualKeys.A2)
                ATSPlugin.Cpp.KeyUp(2);
            if (key == VirtualKeys.B1)
                ATSPlugin.Cpp.KeyUp(3);
            if (key == VirtualKeys.B2)
                ATSPlugin.Cpp.KeyUp(4);
            if (key == VirtualKeys.C1)
                ATSPlugin.Cpp.KeyUp(5);
            if (key == VirtualKeys.C2)
                ATSPlugin.Cpp.KeyUp(6);
            if (key == VirtualKeys.D)
                ATSPlugin.Cpp.KeyUp(7);
            if (key == VirtualKeys.E)
                ATSPlugin.Cpp.KeyUp(8);
            if (key == VirtualKeys.F)
                ATSPlugin.Cpp.KeyUp(9);
            if (key == VirtualKeys.G)
                ATSPlugin.Cpp.KeyUp(10);
            if (key == VirtualKeys.H)
                ATSPlugin.Cpp.KeyUp(11);
            if (key == VirtualKeys.I)
                ATSPlugin.Cpp.KeyUp(12);
            if (key == VirtualKeys.J)
                ATSPlugin.Cpp.KeyUp(13);
            if (key == VirtualKeys.K)
                ATSPlugin.Cpp.KeyUp(14);
            if (key == VirtualKeys.L)
                ATSPlugin.Cpp.KeyUp(15);
        }
        
        public void HornBlow(HornTypes type)
        {
            if(type == HornTypes.Primary)
                ATSPlugin.Cpp.HornBlow(0);
            if (type == HornTypes.Secondary)
                ATSPlugin.Cpp.HornBlow(1);
            if (type == HornTypes.Music)
                ATSPlugin.Cpp.HornBlow(2);
        }
        
        public void DoorChange(DoorStates oldState, DoorStates newState)
        {
            if(oldState == DoorStates.None && (newState == DoorStates.Right || newState == DoorStates.Left))
                ATSPlugin.Cpp.DoorOpen();
            if (newState == DoorStates.None && (oldState == DoorStates.Right || oldState == DoorStates.Left))
                ATSPlugin.Cpp.DoorClose();
        }
        
        public void SetSignal(SignalData[] signal)
        {
            ATSPlugin.Cpp.SetSignal(signal[0].Aspect);
        }
        
        public void SetBeacon(BeaconData beacon)
        {
            ATSPlugin.Cpp.ATS_BEACONDATA beaconData = new ATSPlugin.Cpp.ATS_BEACONDATA();
            beaconData.Signal = beacon.Signal.Aspect;
            beaconData.Type = beacon.Type;
            beaconData.Distance = (float)beacon.Signal.Distance;
            beaconData.Optional = beacon.Optional;

            ATSPlugin.Cpp.SetBeaconData(beaconData);
        }
        
        public void PerformAI(AIData data)
        {
        }

    }
}