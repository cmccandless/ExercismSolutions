using System.Linq;

public class PhoneNumber
{
    public readonly string Number;

    public string AreaCode => Number.Substring(0, 3);

    private string Prefix => Number.Substring(3, 3);

    private string Suffix => Number.Substring(6);

    public PhoneNumber(string number)
    {
        Number = string.Join("", number.Where(char.IsDigit));
        if (Number.Length == 11 && Number[0] == '1') Number = Number.Substring(1);
        else if (Number.Length != 10) Number = new string('0', 10);
    }

    public override string ToString() => $"({AreaCode}) {Prefix}-{Suffix}";
}
