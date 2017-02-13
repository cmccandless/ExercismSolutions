﻿using NUnit.Framework;
using Exercism.zebra_puzzle;

public class ZebraPuzzleTest
{
    [Test]
    public void Who_drinks_water()
    {
        Assert.That(ZebraPuzzle.WhoDrinks(Drink.Water), Is.EqualTo(Nationality.Norwegian));
    }

    [Test]
    public void Who_owns_the_zebra()
    {
        Assert.That(ZebraPuzzle.WhoOwns(Pet.Zebra), Is.EqualTo(Nationality.Japanese));
    }
}