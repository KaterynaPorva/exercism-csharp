public class RemoteControlCar
{
    public string CurrentSponsor { get; private set; }
    private Speed currentSpeed;

    public TelemetrySystem Telemetry { get; }

    public RemoteControlCar()
    {
        Telemetry = new TelemetrySystem(this);
    }

    public string GetSpeed()
    {
        return currentSpeed.ToString();
    }

    private void SetSponsor(string sponsorName)
    {
        CurrentSponsor = sponsorName;
    }

    private void SetSpeed(Speed speed)
    {
        currentSpeed = speed;
    }

    public class TelemetrySystem
    {
        private readonly RemoteControlCar car;

        internal TelemetrySystem(RemoteControlCar car)
        {
            this.car = car;
        }

        public void Calibrate()
        {
        }

        public bool SelfTest()
        {
            return true;
        }

        public void ShowSponsor(string sponsorName)
        {
            car.SetSponsor(sponsorName);
        }

        public void SetSpeed(decimal amount, string unitsString)
        {
            SpeedUnits units = SpeedUnits.MetersPerSecond;
            if (unitsString == "cps")
            {
                units = SpeedUnits.CentimetersPerSecond;
            }

            car.SetSpeed(new Speed(amount, units));
        }
    }

    private enum SpeedUnits
    {
        MetersPerSecond,
        CentimetersPerSecond
    }

    private struct Speed
    {
        public decimal Amount { get; }
        public SpeedUnits Units { get; }

        public Speed(decimal amount, SpeedUnits units)
        {
            Amount = amount;
            Units = units;
        }

        public override string ToString()
        {
            string unitsString = Units == SpeedUnits.CentimetersPerSecond
                ? "centimeters per second"
                : "meters per second";
            return $"{Amount} {unitsString}";
        }
    }
}
