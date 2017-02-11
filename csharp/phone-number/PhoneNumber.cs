using System.Text.RegularExpressions;

public class PhoneNumber
{
	public string AreaCode { get { return Number.Substring(0, 3); } }

	public string Number { get; set; }

	public PhoneNumber(string number)
	{
			Number = Regex.Replace(number, @"[()-.]|\s", string.Empty);
		if ((Number.Length > 10 && Number[0]!='1') ||
			Number.Length < 10)
			Number = "0000000000";
		else
			Number = Number.Substring(Number.Length - 10);
	}

	public override string ToString()
	{
		return string.Format(
			"({0}) {1}-{2}",
			AreaCode,
			Number.Substring(3,3),
			Number.Substring(6));
	}
}
