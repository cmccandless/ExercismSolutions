using System.Collections.Generic;

static class SecretHandshake
{
	public static string[] Commands(int n)
	{
		var actions = new List<string>();
		if ((n & 1) > 0) actions.Add("wink");
		if ((n & 1 << 1) > 0) actions.Add("double blink");
		if ((n & 1 << 2) > 0) actions.Add("close your eyes");
		if ((n & 1 << 3) > 0) actions.Add("jump");
		if ((n & 1 << 4) > 0) actions.Reverse();

		return actions.ToArray();
	}
}
