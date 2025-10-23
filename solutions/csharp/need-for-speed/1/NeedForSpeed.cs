using System;

class RemoteControlCar
{
    private int distanceDriven;
    private int battery;

    public int Speed { get; }
    public int BatteryDrain { get; }

    public RemoteControlCar(int speed, int batteryDrain)
    {
        Speed = speed;
        BatteryDrain = batteryDrain;
        battery = 100;
        distanceDriven = 0;
    }

    public void Drive()
    {
        if (!BatteryDrained())
        {
            distanceDriven += Speed;
            battery -= BatteryDrain;
        }
    }

    public int DistanceDriven() => distanceDriven;

    public bool BatteryDrained() => battery < BatteryDrain;

    public static RemoteControlCar Nitro() => new RemoteControlCar(50, 4);
}

class RaceTrack
{
    private int distance;

    public RaceTrack(int distance)
    {
        this.distance = distance;
    }

    public bool TryFinishTrack(RemoteControlCar car)
    {
        int maxDistance = (100 / car.BatteryDrain) * car.Speed;
        return maxDistance >= distance;
    }
}
