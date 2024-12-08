using OcpCore.Engine.Bitboards;
using OcpCore.Engine.General.StaticData;
using Xunit;

namespace OcpCore.Engine.Tests.Bitboards;

public class MovesTests
{
    private readonly Moves _moves = Moves.Instance;
    
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
    public void GeneratesHorizontalMovesCorrectly(int cell, string expected)
    {
        var attack = _moves[MoveSet.Horizontal][cell];
        
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
    public void GeneratesVerticalMovesCorrectly(int cell, string expected)
    {
        var attack = _moves[MoveSet.Vertical][cell];
        
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
    [InlineData(36, "10000000" +
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
    public void GeneratesDiagonalMovesCorrectly(int cell, string expected)
    {
        var attack = _moves[MoveSet.Diagonal][cell];

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
    [InlineData(35, "00000001" +
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
    public void GeneratesAntiDiagonalMovesCorrectly(int cell, string expected)
    {
        var attack = _moves[MoveSet.AntiDiagonal][cell];

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
    public void GeneratesKnightMovesCorrectly(int cell, string expected)
    {
        var attack = _moves[MoveSet.Knight][cell];

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
    public void GeneratesKingMovesCorrectly(int cell, string expected)
    {
        var attack = _moves[MoveSet.King][cell];

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
        var attack = _moves[MoveSet.PawnWhiteAttack][cell];

        Assert.Equal(expected, Convert.ToString((long) attack, 2).PadLeft(Constants.Cells, '0'));
    }

    [Theory]
    [InlineData(48, "00000000" +
                    "00000000" +
                    "00000010" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000")]
    [InlineData(49, "00000000" +
                    "00000000" +
                    "00000101" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000")]
    [InlineData(54, "00000000" +
                    "00000000" +
                    "10100000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000")]
    [InlineData(55, "00000000" +
                    "00000000" +
                    "01000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000")]
    [InlineData(41, "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000101" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000")]
    [InlineData(46, "00000000" +
                    "00000000" +
                    "00000000" +
                    "10100000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000")]
    public void GeneratesBlackPawnAttacksCorrectly(int cell, string expected)
    {
        var attack = _moves[MoveSet.PawnBlackAttack][cell];

        Assert.Equal(expected, Convert.ToString((long) attack, 2).PadLeft(Constants.Cells, '0'));
    }

    [Theory]
    [InlineData(8, "00000000" +
                   "00000000" +
                   "00000000" +
                   "00000000" +
                   "00000001" +
                   "00000001" +
                   "00000000" +
                   "00000000")]
    [InlineData(9, "00000000" +
                   "00000000" +
                   "00000000" +
                   "00000000" +
                   "00000010" +
                   "00000010" +
                   "00000000" +
                   "00000000")]
    [InlineData(14, "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "01000000" +
                    "01000000" +
                    "00000000" +
                    "00000000")]
    [InlineData(15, "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "10000000" +
                    "10000000" +
                    "00000000" +
                    "00000000")]
    [InlineData(16, "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000001" +
                    "00000000" +
                    "00000000" +
                    "00000000")]
    [InlineData(17, "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000010" +
                    "00000000" +
                    "00000000" +
                    "00000000")]
    [InlineData(22, "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "01000000" +
                    "00000000" +
                    "00000000" +
                    "00000000")]
    [InlineData(23, "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "10000000" +
                    "00000000" +
                    "00000000" +
                    "00000000")]
    [InlineData(48, "00000001" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000")]
    [InlineData(55, "10000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000")]
    public void GeneratesWhitePawnMovesCorrectly(int cell, string expected)
    {
        var attack = _moves[MoveSet.PawnToBlack][cell];

        Assert.Equal(expected, Convert.ToString((long) attack, 2).PadLeft(Constants.Cells, '0'));
    }

    [Theory]
    [InlineData(48, "00000000" +
                    "00000000" +
                    "00000001" +
                    "00000001" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000")]
    [InlineData(49, "00000000" +
                    "00000000" +
                    "00000010" +
                    "00000010" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000")]
    [InlineData(54, "00000000" +
                    "00000000" +
                    "01000000" +
                    "01000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000")]
    [InlineData(55, "00000000" +
                    "00000000" +
                    "10000000" +
                    "10000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000")]
    [InlineData(40, "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000001" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000")]
    [InlineData(41, "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000010" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000")]
    [InlineData(46, "00000000" +
                    "00000000" +
                    "00000000" +
                    "01000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000")]
    [InlineData(47, "00000000" +
                    "00000000" +
                    "00000000" +
                    "10000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000")]
    [InlineData(8, "00000000" +
                   "00000000" +
                   "00000000" +
                   "00000000" +
                   "00000000" +
                   "00000000" +
                   "00000000" +
                   "00000001")]
    [InlineData(15, "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "00000000" +
                    "10000000")]
    public void GeneratesBlackPawnMovesCorrectly(int cell, string expected)
    {
        var attack = _moves[MoveSet.PawnToWhite][cell];

        Assert.Equal(expected, Convert.ToString((long) attack, 2).PadLeft(Constants.Cells, '0'));
    }
}