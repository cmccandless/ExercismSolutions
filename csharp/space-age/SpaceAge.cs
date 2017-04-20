using System;

public class SpaceAge
{
	public Int64 Seconds { get; private set; }
    private double OnEarthExact => Seconds / 31557600.0;
    public SpaceAge(Int64 seconds)
	{
		Seconds = seconds;
	}

	public double OnMercury() => Math.Round(OnEarthExact / 0.2408467, 2);

	public double OnVenus() => Math.Round(OnEarthExact / 0.61519726, 2);

    public double OnEarth() => Math.Round(OnEarthExact, 2);

	public double OnMars() => Math.Round(OnEarthExact / 1.8808158, 2);

	public double OnJupiter() => Math.Round(OnEarthExact / 11.862615, 2);

	public double OnSaturn() => Math.Round(OnEarthExact / 29.447498, 2);

	public double OnUranus() => Math.Round(OnEarthExact / 84.016846, 2);

	public double OnNeptune() => Math.Round(OnEarthExact / 164.79132, 2);
}
