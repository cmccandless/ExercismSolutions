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
}

public static class Ledger
{
	public static LedgerEntry CreateEntry(string date, string desc, int chng)
	{
		return new LedgerEntry(DateTime.Parse(date, CultureInfo.InvariantCulture), desc, chng / 100.0f);
	}

	private static CultureInfo CreateCulture(string cur, string loc)
	{
		var curSymb = new Dictionary<string, string> { { "USD", "$" }, { "EUR", "€" } };
		var datPat = new Dictionary<string, string> { { "en-US", "MM/dd/yyyy" }, { "nl-NL", "dd/MM/yyyy" } };
		var culture = new CultureInfo(loc);
		try { culture.NumberFormat.CurrencySymbol = curSymb[cur]; }
		catch (KeyNotFoundException) { throw new ArgumentException("Invalid currency"); }
		try { culture.DateTimeFormat.ShortDatePattern = datPat[loc]; }
		catch (KeyNotFoundException) { throw new ArgumentException("Invalid locale"); }
		return culture;
	}

	private static string PrintHead(string loc)
	{
		var pad = new[] { 10, 25, 13 };
		var label = new Dictionary<string, string[]> {
			{"en-US",new[]{"Date","Description","Change"}},
			{"nl-NL",new[]{"Datum","Omschrijving","Verandering"}}
		};
		try { return string.Join(" | ", label[loc].Zip(pad, (l, s) => l.PadRight(s))); }
		catch (KeyNotFoundException) { throw new ArgumentException("Invalid locale"); }
	}

	private static string Date(IFormatProvider culture, DateTime date) { return date.ToString("d", culture); }

	private static string Truncate(this string desc, int length)
	{
		return desc.Length > length ? desc.Substring(0, length - 3) + "..." : desc;
	}

	private static string Change(IFormatProvider culture, float cgh)
	{
		return cgh < 0.0 ? cgh.ToString("C", culture) : cgh.ToString("C", culture) + " ";
	}

	private static string PrintEntry(IFormatProvider culture, LedgerEntry entry)
	{
		return string.Join(" | ", new[] {
			Date(culture, entry.Date),
			string.Format("{0,-25}", entry.Desc.Truncate(25)),
			string.Format("{0,13}", Change(culture, entry.Chg)) 
		});
	}


	private static IEnumerable<LedgerEntry> sort(LedgerEntry[] entries)
	{
		return entries.OrderBy(e => e.Chg >= 0).ThenBy(x => x.Date + "@" + x.Desc + "@" + x.Chg);
	}

	public static string Format(string currency, string locale, LedgerEntry[] entries)
	{
		var culture = CreateCulture(currency, locale);
		return string.Join("\n", new[] { PrintHead(locale) }.Concat(from entry in sort(entries) select PrintEntry(culture, entry)));
	}
}
