using System;
using System.Collections.Generic;
using System.Linq;

namespace Day4
{
    public static class SecondPart
    { 
        public static int GetResult(string[] fileLines)
        {
            var allExtractedNumbers = fileLines.First().Split(',');

            var winningBoard = new List<string>();
            var lastNumberExtracted = 0;

            var boards = new List<List<string>>();

            for (var i = 0; i < fileLines.Length - 5; i+=6)
            {
                var board = fileLines.Skip(i + 2).Take(5).ToList();
                boards.Add(board);
            }

            var extractedTillNow = allExtractedNumbers.Take(5).ToList();

            var boardsLeft = boards.Select(x => x).ToList();
            
            for (var i = 5; i < allExtractedNumbers.Length; i++)
            {
                foreach (var board in boards)
                {
                    var hasWinningRow = CheckIfRowWins(board, extractedTillNow);

                    var hasWinningColumn = CheckIfColumnWins(board, extractedTillNow);

                    if (hasWinningRow == false && hasWinningColumn == false) continue;

                    if (boards.Count > 1)
                    {
                        boardsLeft.Remove(board); 
                        continue;
                    }
                    
                    winningBoard = board
                        .SelectMany(w => w.Split(' '))
                        .Where(w => string.IsNullOrEmpty(w) == false)
                        .ToList();
                    
                    lastNumberExtracted =  Convert.ToInt32(extractedTillNow.Last());
                    break;
                }

                if (winningBoard.Count > 0) break;

                boards = boardsLeft.Select(x => x).ToList();
                
                extractedTillNow.Add(allExtractedNumbers[i]);
            }

            var sumOfUnmarked = winningBoard
                .Where(w => extractedTillNow.Contains(w) == false)
                .Select(w => Convert.ToInt32(w))
                .Sum();

            var result = sumOfUnmarked * lastNumberExtracted;

            return result;
        }

        private static bool CheckIfRowWins(List<string> board, List<string> extracted)
        {
            return board
                .Select(b => b.Split(' ')
                    .Count(extracted.Contains))
                .Any(x => x.Equals(5));
        }
        
        private static bool CheckIfColumnWins(List<string> board, List<string> extracted)
        {
            for (var i = 0; i < board.Count; i++)
            {
                var column = board
                    .Select(b => b.Split(' ')
                        .Where(s => string.IsNullOrEmpty(s) == false)
                        .ToArray()[i]);

                var columnWon = column.Count(extracted.Contains) == 5;

                if (columnWon) return true;
            }

            return false;
        }
    }
}