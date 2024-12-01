using OcpCore.Engine.General;
using OcpCore.Engine.General.Bitboards;
using OcpCore.Engine.General.StaticData;
using OcpCore.Engine.Pieces;
using Xunit;

namespace OcpCore.Engine.Tests.General.Bitboards;

public class AttacksTests
{
    private readonly Attacks _attacks = new();
    
    [Theory]
    [InlineData(0, "00000000" +
                   "00000000" +
                   "00000000" +
                   "00000000" +
                   "00000000" +
                   "00000000" +
                   "00000000" +
                   "11111111")]
    [InlineData(7, "00000000" +
                   "00000000" +
                   "00000000" +
                   "00000000" +
                   "00000000" +
                   "00000000" +
                   "00000000" +
                   "11111111")]
    [InlineData(56, "11111111" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000")]
    [InlineData(63, "11111111" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000")]
    public void GeneratesHorizontalAttacksCorrectly(int cell, string expected)
    {
        var attack = _attacks[Kind.Queen][MoveSet.Horizontal][cell];
        
        Assert.Equal(expected, Convert.ToString((long) attack, 2).PadLeft(Constants.Cells, '0'));
    }
    
    [Theory]
    [InlineData(0, "00000001" +
                   "00000001" +
                   "00000001" +
                   "00000001" +
                   "00000001" +
                   "00000001" +
                   "00000001" +
                   "00000001")]
    [InlineData(7, "10000000" +
                   "10000000" +
                   "10000000" +
                   "10000000" +
                   "10000000" +
                   "10000000" +
                   "10000000" +
                   "10000000")]
    [InlineData(56, "00000001" +
                    "00000001" +
                    "00000001" +
                    "00000001" +
                    "00000001" +
                    "00000001" +
                    "00000001" +
                    "00000001")]
    [InlineData(63, "10000000" +
                    "10000000" +
                    "10000000" +
                    "10000000" +
                    "10000000" +
                    "10000000" +
                    "10000000" +
                    "10000000")]
    public void GeneratesVerticalAttacksCorrectly(int cell, string expected)
    {
        var attack = _attacks[Kind.Queen][MoveSet.Vertical][cell];
        
        Assert.Equal(expected, Convert.ToString((long) attack, 2).PadLeft(Constants.Cells, '0'));
    }
    
    [Theory]
    [InlineData(0, "10000000" +
                   "01000000" +
                   "00100000" +
                   "00010000" +
                   "00001000" +
                   "00000100" +
                   "00000010" +
                   "00000001")]
    [InlineData(1, "00000000" +
                   "10000000" +
                   "01000000" +
                   "00100000" +
                   "00010000" +
                   "00001000" +
                   "00000100" +
                   "00000010")]
    [InlineData(6, "00000000" +
                   "00000000" +
                   "00000000" +
                   "00000000" +
                   "00000000" +
                   "00000000" +
                   "10000000" +
                   "01000000")]
    [InlineData(7, "00000000" +
                   "00000000" +
                   "00000000" +
                   "00000000" +
                   "00000000" +
                   "00000000" +
                   "00000000" +
                   "10000000")]
    [InlineData(8, "01000000" +
                   "00100000" +
                   "00010000" +
                   "00001000" +
                   "00000100" +
                   "00000010" +
                   "00000001" + 
                   "00000000")]
    [InlineData(48, "00000010" +
                    "00000001" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" + 
                    "00000000")]
    [InlineData(57, "00000010" +
                    "00000001" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" + 
                    "00000000")]
    [InlineData(56, "00000001" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" + 
                    "00000000")]
    public void GeneratesDiagonalAttacksCorrectly(int cell, string expected)
    {
        var attack = _attacks[Kind.Queen][MoveSet.Diagonal][cell];
        
        Assert.Equal(expected, Convert.ToString((long) attack, 2).PadLeft(Constants.Cells, '0'));
    }

    [Theory]
    [InlineData(7, "00000001" +
                   "00000010" +
                   "00000100" +
                   "00001000" +
                   "00010000" +
                   "00100000" +
                   "01000000" +
                   "10000000")]
    [InlineData(6, "00000000" +
                   "00000001" +
                   "00000010" +
                   "00000100" +
                   "00001000" +
                   "00010000" +
                   "00100000" +
                   "01000000")]
    [InlineData(1, "00000000" +
                   "00000000" +
                   "00000000" +
                   "00000000" +
                   "00000000" +
                   "00000000" +
                   "00000001" +
                   "00000010")]
    [InlineData(0, "00000000" +
                   "00000000" +
                   "00000000" +
                   "00000000" +
                   "00000000" +
                   "00000000" +
                   "00000000" +
                   "00000001")]
    [InlineData(15, "00000010" +
                    "00000100" +
                    "00001000" +
                    "00010000" +
                    "00100000" +
                    "01000000" +
                    "10000000" +
                    "00000000")]
    [InlineData(55, "01000000" +
                    "10000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000")]
    [InlineData(62, "01000000" +
                    "10000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000")]
    [InlineData(63, "10000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000")]
    public void GeneratesAntiDiagonalAttacksCorrectly(int cell, string expected)
    {
        var attack = _attacks[Kind.Queen][MoveSet.AntiDiagonal][cell];

        Assert.Equal(expected, Convert.ToString((long) attack, 2).PadLeft(Constants.Cells, '0'));
    }

    [Theory]
    [InlineData(0, "00000000" +
                   "00000000" +
                   "00000000" +
                   "00000000" +
                   "00000000" +
                   "00000010" +
                   "00000100" +
                   "00000000")]
    [InlineData(7, "00000000" +
                   "00000000" +
                   "00000000" +
                   "00000000" +
                   "00000000" +
                   "01000000" +
                   "00100000" +
                   "00000000")]
    [InlineData(56, "00000000" +
                    "00000100" +
                    "00000010" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000")]
    [InlineData(63, "00000000" +
                    "00100000" +
                    "01000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000")]
    [InlineData(36, "00000000" +
                    "00101000" +
                    "01000100" +
                    "00000000" +
                    "01000100" +
                    "00101000" +
                    "00000000" +
                    "00000000")]
    public void GeneratesKnightAttacksCorrectly(int cell, string expected)
    {
        var attack = _attacks[Kind.Knight][MoveSet.Specific][cell];

        Assert.Equal(expected, Convert.ToString((long) attack, 2).PadLeft(Constants.Cells, '0'));
    }
    
    [Theory]
    [InlineData(0, "00000000" +
                   "00000000" +
                   "00000000" +
                   "00000000" +
                   "00000000" +
                   "00000000" +
                   "00000011" +
                   "00000010")]
    [InlineData(7, "00000000" +
                   "00000000" +
                   "00000000" +
                   "00000000" +
                   "00000000" +
                   "00000000" +
                   "11000000" +
                   "01000000")]
    [InlineData(56, "00000010" +
                    "00000011" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000")]
    [InlineData(63, "01000000" +
                    "11000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000")]
    [InlineData(36, "00000000" +
                    "00000000" +
                    "00111000" +
                    "00101000" +
                    "00111000" +
                    "00000000" +
                    "00000000" +
                    "00000000")]
    public void GeneratesKingAttacksCorrectly(int cell, string expected)
    {
        var attack = _attacks[Kind.King][MoveSet.Specific][cell];

        Assert.Equal(expected, Convert.ToString((long) attack, 2).PadLeft(Constants.Cells, '0'));
    }

    [Theory]
    [InlineData(8, "00000000" +
                   "00000000" +
                   "00000000" +
                   "00000000" +
                   "00000000" +
                   "00000010" +
                   "00000000" +
                   "00000000")]
    [InlineData(9, "00000000" +
                   "00000000" +
                   "00000000" +
                   "00000000" +
                   "00000000" +
                   "00000101" +
                   "00000000" +
                   "00000000")]
    [InlineData(14, "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "10100000" +
                    "00000000" +
                    "00000000")]
    [InlineData(15, "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "01000000" +
                    "00000000" +
                    "00000000")]
    [InlineData(22, "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "10100000" +
                    "00000000" +
                    "00000000" +
                    "00000000")]
    [InlineData(23, "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "01000000" +
                    "00000000" +
                    "00000000" +
                    "00000000")]
    [InlineData(56, "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000")]
    [InlineData(63, "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000")]
    public void GeneratesWhitePawnAttacksCorrectly(int cell, string expected)
    {
        var attack = _attacks[Kind.Pawn][MoveSet.ToBlack][cell];

        Assert.Equal(expected, Convert.ToString((long) attack, 2).PadLeft(Constants.Cells, '0'));
    }
}