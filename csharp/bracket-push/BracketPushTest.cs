// This file was auto-generated based on version 1.1.0 of the canonical data.

using Xunit;

public class BracketPushTest
{
    [Fact]
    public void Paired_square_brackets()
    {
        var input = "[]";
        Assert.True(BracketPush.IsPaired(input));
    }

    [Fact]
    public void Empty_string()
    {
        var input = "";
        Assert.True(BracketPush.IsPaired(input));
    }

    [Fact]
    public void Unpaired_brackets()
    {
        var input = "[[";
        Assert.False(BracketPush.IsPaired(input));
    }

    [Fact]
    public void Wrong_ordered_brackets()
    {
        var input = "}{";
        Assert.False(BracketPush.IsPaired(input));
    }

    [Fact]
    public void Wrong_closing_bracket()
    {
        var input = "{]";
        Assert.False(BracketPush.IsPaired(input));
    }

    [Fact]
    public void Paired_with_whitespace()
    {
        var input = "{ }";
        Assert.True(BracketPush.IsPaired(input));
    }

    [Fact]
    public void Simple_nested_brackets()
    {
        var input = "{[]}";
        Assert.True(BracketPush.IsPaired(input));
    }

    [Fact]
    public void Several_paired_brackets()
    {
        var input = "{}[]";
        Assert.True(BracketPush.IsPaired(input));
    }

    [Fact]
    public void Paired_and_nested_brackets()
    {
        var input = "([{}({}[])])";
        Assert.True(BracketPush.IsPaired(input));
    }

    [Fact]
    public void Unopened_closing_brackets()
    {
        var input = "{[)][]}";
        Assert.False(BracketPush.IsPaired(input));
    }

    [Fact]
    public void Unpaired_and_nested_brackets()
    {
        var input = "([{])";
        Assert.False(BracketPush.IsPaired(input));
    }

    [Fact]
    public void Paired_and_wrong_nested_brackets()
    {
        var input = "[({]})";
        Assert.False(BracketPush.IsPaired(input));
    }

    [Fact]
    public void Math_expression()
    {
        var input = "(((185 + 223.85) * 15) - 543)/2";
        Assert.True(BracketPush.IsPaired(input));
    }

    [Fact]
    public void Complex_latex_expression()
    {
        var input = "\\left(\\begin{array}{cc} \\frac{1}{3} & x\\\\ \\mathrm{e}^{x} &... x^2 \\end{array}\\right)";
        Assert.True(BracketPush.IsPaired(input));
    }
}