using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

public class LedgerEntry
{
    public LedgerEntry(DateTime date, string desc, float chg)
    {
        Date = date;
        Desc = desc;
        Chg = chg;
    }

    public readonly DateTime Date;
    public readonly string Desc;
    public readonly float Chg;
    public override string ToString() => $"{Date}@{Desc}@{Chg}";
}

public static class Ledger
{
    internal static T Assert<T>(this T obj, Func<T, bool> c, string msg = "")
    {
        if (c(obj)) return obj;
        throw new ArgumentException(msg);
    }

    public static LedgerEntry CreateEntry(string date, string desc, int chng) =>
        new LedgerEntry(DateTime.Parse(date, CultureInfo.InvariantCulture), desc, chng / 100.0f);

    private static Dictionary<string, string> curSymb = new Dictionary<string, string>
    { ["USD"] = "$", ["EUR"] = "€" };

    private static Dictionary<string, string> datPat = new Dictionary<string, string>
    { ["en-US"] = "MM/dd/yyyy", ["nl-NL"] = "dd/MM/yyyy" };

    private static CultureInfo CreateCulture(string cur, string loc)
    {
        var culture = new CultureInfo(loc);
        culture.NumberFormat.CurrencySymbol = curSymb[cur.Assert(curSymb.ContainsKey, "Invalid currency")];
        culture.DateTimeFormat.ShortDatePattern = datPat[loc.Assert(datPat.ContainsKey, "Invalid Locale")];
        return culture;
    }

    private static string[] GetPrintLabels(string loc)
    {
        switch (loc)
        {
            case "en-US": return new[] { "Date", "Description", "Change" };
            case "nl-NL": return new[] { "Datum", "Omschrijving", "Verandering" };
        }
        throw new ArgumentException("Invalid locale");
    }

    private static string PrintHead(string loc) =>
        string.Join(" | ", GetPrintLabels(loc).Zip(new[] { 10, 25, 13 }, (l, s) => l.PadRight(s)));

    private static string Date(IFormatProvider culture, DateTime date) => date.ToString("d", culture);

    private static string Truncate(this string desc, int length) =>
        desc.Length > length ? desc.Substring(0, length - 3) + "..." : desc;

    private static string Change(IFormatProvider culture, float cgh) =>
        $"{cgh.ToString("C", culture)}{(cgh < 0.0 ? "" : " ")}";

    private static string PrintEntry(this IFormatProvider culture, LedgerEntry entry) =>
        $"{Date(culture, entry.Date)} | {entry.Desc.Truncate(25),-25} | {Change(culture, entry.Chg),13}";

    private static IEnumerable<LedgerEntry> Sorted(LedgerEntry[] entries) =>
        entries.OrderBy(e => e.Chg >= 0).ThenBy(x => x.ToString());

    public static string Format(string currency, string locale, LedgerEntry[] entries) =>
        Format(PrintHead(locale), entries, CreateCulture(currency, locale));
    public static string Format(string head, LedgerEntry[] entries, IFormatProvider culture) =>
        $"{head}{(entries.Any() ? "\n" : "")}{string.Join("\n", Sorted(entries).Select(culture.PrintEntry))}";
}
