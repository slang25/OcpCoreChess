using OcpCore.Engine.Exceptions;
using OcpCore.Engine.Extensions;
using OcpCore.Engine.General;
using OcpCore.Engine.General.StaticData;
using OcpCore.Engine.Pieces;

namespace OcpCore.Engine.Bitboards;

public class Game
{
    private readonly ulong[] _planes;

    public ulong this[Plane plane]
    {
        get => _planes[(int) plane];
        private set => _planes[(int) plane] = value;
    }
    
    public Game()
    {
        _planes = new ulong[Enum.GetValues<Plane>().Length];
    }

    public Game(Game game)
    {
        var planeCount = Enum.GetValues<Plane>().Length;
        
        _planes = new ulong[planeCount];
        
        Buffer.BlockCopy(game._planes, 0, _planes, 0, planeCount * sizeof(ulong));
    }

    public void MakeMove(Kind kind, Colour colour, int from, int to)
    {
        UpdateBitboards(kind, colour, from, to);
    }

    public void ParseFen(string fen)
    {
        var parts = fen.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length < 6)
        {
            throw new FenParseException($"Invalid number of parts to FEN string: {parts.Length}.");
        }

        var ranks = parts[0].Split('/');

        if (ranks.Length != Constants.Ranks)
        {
            throw new FenParseException($"Incorrect number of ranks in FEN string: {ranks.Length}.");
        }

        for (var rank = 0; rank < Constants.Ranks; rank++)
        {
            var files = ranks[Constants.MaxRank - rank];

            var file = 0;

            var index = 0;

            while (index < files.Length)
            {
                var cell = files[index];

                index++;
                
                if (char.IsNumber(cell))
                {
                    file += cell - '0';

                    if (file > Constants.Files)
                    {
                        throw new FenParseException($"Too many files in rank {rank + 1}: {files}.");
                    }

                    continue;
                }

                var colourPlane = char.IsUpper(cell) ? Plane.White : Plane.Black;
                
                var plane = char.ToUpper(cell) switch
                {
                    'P' => Plane.Pawn,
                    'R' => Plane.Rook,
                    'N' => Plane.Knight,
                    'B' => Plane.Bishop,
                    'Q' => Plane.Queen,
                    'K' => Plane.King,
                    _ => throw new FenParseException($"Invalid piece token in rank {rank + 1}: {cell}.")
                };

                var cellIndex = Cell.GetCell(rank, file);

                if (cellIndex < 0)
                {
                    throw new FenParseException($"Too many files in rank {rank + 1}: {files}.");
                }

                this[colourPlane] |= 1ul << cellIndex;

                this[plane] |= 1ul << cellIndex;

                file++;
            }
            
            if (file != Constants.Files)
            {
                throw new FenParseException($"Not enough files in rank {rank + 1}: {files}.");
            }
        }
    }
    
    private void UpdateBitboards(Kind kind, Colour colour, int from, int to)
    {
        var fromBit = 1ul << from;

        var toBit = 1ul << to;
        
        // ReSharper disable once SwitchStatementHandlesSomeKnownEnumValuesWithDefault
        switch (colour)
        {
            case Colour.White:
                if ((this[Plane.White] & fromBit) == 0)
                {
                    throw new InvalidMoveException($"No {colour} {kind} at {from.ToStandardNotation()}.");
                }

                this[Plane.White] &= ~fromBit;
                this[Plane.White] |= toBit;
                break;

            case Colour.Black:
                if ((this[Plane.Black] & fromBit) == 0)
                {
                    throw new InvalidMoveException($"No {colour} {kind} at {from.ToStandardNotation()}.");
                }

                this[Plane.Black] &= ~fromBit;
                this[Plane.Black] |= toBit;
                break;
        }
        
        // ReSharper disable once SwitchStatementHandlesSomeKnownEnumValuesWithDefault
        switch (kind)
        {
            case Kind.Pawn:
                if ((this[Plane.Pawn] & fromBit) == 0)
                {
                    throw new InvalidMoveException($"No {colour} {kind} at {from.ToStandardNotation()}.");
                }

                this[Plane.Pawn] &= ~fromBit;
                this[Plane.Pawn] |= toBit;
                break;

            case Kind.Rook:
                if ((this[Plane.Rook] & fromBit) == 0)
                {
                    throw new InvalidMoveException($"No {colour} {kind} at {from.ToStandardNotation()}.");
                }

                this[Plane.Rook] &= ~fromBit;
                this[Plane.Rook] |= toBit;
                break;

            case Kind.Knight:
                if ((this[Plane.Knight] & fromBit) == 0)
                {
                    throw new InvalidMoveException($"No {colour} {kind} at {from.ToStandardNotation()}.");
                }

                this[Plane.Knight] &= ~fromBit;
                this[Plane.Knight] |= toBit;
                break;

            case Kind.Bishop:
                if ((this[Plane.Bishop] & fromBit) == 0)
                {
                    throw new InvalidMoveException($"No {colour} {kind} at {from.ToStandardNotation()}.");
                }

                this[Plane.Bishop] &= ~fromBit;
                this[Plane.Bishop] |= toBit;
                break;

            case Kind.Queen:
                if ((this[Plane.Queen] & fromBit) == 0)
                {
                    throw new InvalidMoveException($"No {colour} {kind} at {from.ToStandardNotation()}.");
                }

                this[Plane.Queen] &= ~fromBit;
                this[Plane.Queen] |= toBit;
                break;

            case Kind.King:
                if ((this[Plane.King] & fromBit) == 0)
                {
                    throw new InvalidMoveException($"No {colour} {kind} at {from.ToStandardNotation()}.");
                }

                this[Plane.King] &= ~fromBit;
                this[Plane.King] |= toBit;
                break;
        }
    }
}