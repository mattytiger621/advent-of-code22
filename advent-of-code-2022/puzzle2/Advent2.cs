namespace advent_of_code_2022.puzzle2;

public class Advent2
{
    const string FILE_NAME = "puzzle2/input.txt";
    private static int WIN_SCORE = 6;
    private static int DRAW_SCORE = 3;

    private static Dictionary<char, HandShape> _charShapeMap = new Dictionary<char, HandShape>
    {
        { 'A', HandShape.Rock },
        { 'X', HandShape.Rock },
        { 'B', HandShape.Paper },
        { 'Y', HandShape.Paper },
        { 'C', HandShape.Scissors },
        { 'Z', HandShape.Scissors }
    };
    
    private static Dictionary<HandShape, HandShape> _winConditions = new Dictionary<HandShape, HandShape>
    {
        { HandShape.Rock, HandShape.Scissors},
        { HandShape.Paper, HandShape.Rock},
        { HandShape.Scissors, HandShape.Paper}
    };


    internal static int FindTotalScoreAssumedPlan()
    {
        int totalScore = 0;
        TextReader reader = File.OpenText(FILE_NAME);
        string? line = reader.ReadLine();
        while (line != null)
        {
            HandShape opponentHandShape = _charShapeMap[line[0]];
            HandShape ourHandShape = _charShapeMap[line[2]];
            if (opponentHandShape.Equals(ourHandShape))
            {
                totalScore += (ourHandShape.GetHashCode() + 1) + DRAW_SCORE;
            } else if (_winConditions[ourHandShape].Equals(opponentHandShape))
            {
                totalScore += (ourHandShape.GetHashCode() + 1) + WIN_SCORE;
            }
            else
            {
                totalScore += (ourHandShape.GetHashCode() + 1);
            }
            line = reader.ReadLine();
        }
        return totalScore;
    } 
    
    internal static int FindTotalScoreActualPlan()
    {
        // Find shape for desired outcome.
        // Add up desired outcome points and shape points. 
        int totalScore = 0;
        TextReader reader = File.OpenText(FILE_NAME);
        string? line = reader.ReadLine();
        HandShape ourHandShape;
        while (line != null)
        {
            HandShape opponentHandShape = _charShapeMap[line[0]];
            if (line[2].Equals('X')) // You need to lose
            {
                ourHandShape = _winConditions[opponentHandShape];
                totalScore += ourHandShape.GetHashCode() + 1;
            } else if (line[2].Equals('Y')) // You need a draw.
            {
                ourHandShape = opponentHandShape;
                totalScore += DRAW_SCORE + ourHandShape.GetHashCode() + 1;
            }
            else
            {
                ourHandShape = _winConditions.Values.Where(g => _winConditions[g].Equals(opponentHandShape)).First();
                totalScore += WIN_SCORE + ourHandShape.GetHashCode() + 1;
            }
            line = reader.ReadLine();
        }
        return totalScore;
    } 
}