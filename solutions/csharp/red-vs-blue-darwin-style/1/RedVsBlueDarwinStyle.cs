namespace RedRemoteControlCarTeam
{
    public class RemoteControlCar
    {
        public RemoteControlCar(Motor motor, Chassis chassis, Telemetry telemetry, RunningGear runningGear)
        {
        }
    }

    public class RunningGear { }
    public class Telemetry { }
    public class Chassis { }
    public class Motor { }
}

namespace BlueRemoteControlCarTeam
{
    public class RemoteControlCar
    {
        public RemoteControlCar(Motor motor, Chassis chassis, Telemetry telemetry)
        {
        }
    }

    public class Telemetry { }
    public class Chassis { }
    public class Motor { }
}

namespace Combined
{
    public static class CarBuilder
    {
        public static RedRemoteControlCarTeam.RemoteControlCar BuildRed()
        {
            return new RedRemoteControlCarTeam.RemoteControlCar(
                new RedRemoteControlCarTeam.Motor(),
                new RedRemoteControlCarTeam.Chassis(),
                new RedRemoteControlCarTeam.Telemetry(),
                new RedRemoteControlCarTeam.RunningGear()
            );
        }

        public static BlueRemoteControlCarTeam.RemoteControlCar BuildBlue()
        {
            return new BlueRemoteControlCarTeam.RemoteControlCar(
                new BlueRemoteControlCarTeam.Motor(),
                new BlueRemoteControlCarTeam.Chassis(),
                new BlueRemoteControlCarTeam.Telemetry()
            );
        }
    }
}
