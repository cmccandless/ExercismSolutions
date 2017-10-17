using System;
using System.Collections.Generic;
using System.Linq;

public class Allergies
{
	public enum Allergy
	{
		eggs=0x1,
		peanuts=0x2,
		shellfish=0x4,
		strawberries=0x8,
		tomatoes=0x10,
		chocolate=0x20,
		pollen=0x40,
		cats=0x80,
	}

	public List<string> List() =>
		(from Allergy allergy in Enum.GetValues(typeof(Allergy))
		 where AllergyScore.HasFlag(allergy)
		 select allergy.ToString()).ToList();

	public Allergy AllergyScore { get; set; }

	public Allergies(int allergyScore)
	{
		AllergyScore = (Allergy)allergyScore;
	}

	public bool IsAllergicTo(string allergies) =>
		 AllergyScore.HasFlag((Allergy)Enum.Parse(typeof(Allergy), allergies));
}
