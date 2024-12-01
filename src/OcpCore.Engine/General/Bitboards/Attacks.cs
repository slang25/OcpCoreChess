using OcpCore.Engine.General.StaticData;
using OcpCore.Engine.Pieces;

namespace OcpCore.Engine.General.Bitboards;

public class Attacks
{
    private readonly DirectionalAttacks[] _attacks;
    
    public DirectionalAttacks this[Kind kind] => _attacks[(int) kind];

    public Attacks()
    {
        _attacks = new DirectionalAttacks[Constants.Pieces];

        for (var i = 0; i < Constants.Pieces; i++)
        {
            _attacks[i] = new DirectionalAttacks();
        }

        GenerateQueenAttacks();
    }

    private void GenerateQueenAttacks()
    {
        for (var cell = 0; cell < Constants.Cells; cell++)
        {
            this[Kind.Queen][Direction.Horizontal][cell] = GenerateHorizontalAttacks(Cell.GetRank(cell));

            this[Kind.Queen][Direction.Vertical][cell] = GenerateVerticalAttacks(Cell.GetFile(cell));

            this[Kind.Queen][Direction.Diagonal][cell] = GenerateDiagonalAttacks(cell);

            this[Kind.Queen][Direction.AntiDiagonal][cell] = GenerateAntiDiagonalAttacks(cell);
        }
    }

    private static ulong GenerateHorizontalAttacks(int rank)
    {
        return 0b1111_1111ul << (rank * 8);
    }
    
    private static ulong GenerateVerticalAttacks(int file)
    {
        return 0b0000_0001_0000_0001_0000_0001_0000_0001_0000_0001_0000_0001_0000_0001_0000_0001ul << file;
    }

    private static ulong GenerateDiagonalAttacks(int cell)
    {
        var rank = Cell.GetRank(cell);
        
        var file = Cell.GetFile(cell);
        
        var index = rank - file;

        var mask = 0ul;
        
        for (var r = 0; r < Constants.Ranks; r++)
        {
            for (var f = 0; f < Constants.Files; f++)
            {
                if (r - f == index)
                {
                    mask |= 1ul << (r * 8 + f);
                }
            }
        }
        return mask; 
    }

    private static ulong GenerateAntiDiagonalAttacks(int cell)
    {
        if (cell == 62)
        {
        }

        var rank = Cell.GetRank(cell);
        
        var file = Cell.GetFile(cell);
        
        var index = rank + file;

        var mask = 0ul;
        
        for (var r = 0; r < Constants.Ranks; r++)
        {
            for (var f = 0; f < Constants.Files; f++)
            {
                if (r + f == index)
                {
                    mask |= 1ul << (r * 8 + f);
                }
            }
        }
        return mask;
    }
}