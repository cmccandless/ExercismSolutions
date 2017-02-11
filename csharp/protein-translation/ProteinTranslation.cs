using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ProteinTranslation
{
//	Codon                 | Protein
//:---                  | :---
//AUG                   | Methionine
//UUU, UUC              | Phenylalanine
//UUA, UUG              | Leucine
//UCU, UCC, UCA, UCG    | Serine
//UAU, UAC              | Tyrosine
//UGU, UGC              | Cysteine
//UGG                   | Tryptophan
//UAA, UAG, UGA         | STOP
	private static Dictionary<string, string> proteins = new Dictionary<string, string>()
	{
		{"AUG","Methionine"},
		{"UUU","Phenylalanine"},
		{"UUC","Phenylalanine"},
		{"UUA","Leucine"},
		{"UUG","Leucine"},
		{"UCU","Serine"},
		{"UCC","Serine"},
		{"UCA","Serine"},
		{"UCG","Serine"},
		{"UAU","Tyrosine"},
		{"UAC","Tyrosine"},
		{"UGU","Cysteine"},
		{"UGC","Cysteine"},
		{"UGG","Tryptophan"},
		{"UAA","STOP"},
		{"UAG","STOP"},
		{"UGA","STOP"},
	};
	public static string[] Translate(string codon)
	{
		return Enumerable.Range(0, codon.Length / 3)
			.Select(i => proteins[codon.Substring(i*3, 3)])
			.TakeWhile(x=> x != "STOP").ToArray();
	}
}
