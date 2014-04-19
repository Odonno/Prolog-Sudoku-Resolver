using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrologSudoku.Model.Model.Abstract;
using PrologSudoku.Model.Model.Concrete;
using PrologSudoku.Services.Infrastructure;
using PrologSudoku.Services.Services.Concrete;

namespace PrologSudoku.Test
{
    [TestClass]
    public class SudokuUnitTest
    {
        [TestMethod]
        public void Can_Convert_Prolog_Tab_To_Sudoku()
        {
            // arrange
            var sudoku = new Sudoku();

            // act
            sudoku.ConvertPrologTabToSudoku("[1,2,3,4,5,6,7,8,9," +
                                            "1,2,3,4,5,6,7,8,9," +
                                            "1,2,3,4,5,6,7,8,9," +
                                            "1,2,3,4,5,6,7,8,9," +
                                            "1,2,3,4,5,6,7,8,9," +
                                            "1,2,3,4,5,6,7,8,9," +
                                            "1,2,3,4,5,6,7,8,9," +
                                            "1,2,3,4,5,6,7,8,9," +
                                            "1,2,3,4,5,6,7,8,9]");

            // assert
            Assert.AreEqual(sudoku.Squares[0].Value, 1);
            Assert.AreEqual(sudoku.Squares[1].Value, 2);
            Assert.AreEqual(sudoku.Squares[2].Value, 3);
            Assert.AreEqual(sudoku.Squares[3].Value, 4);
            Assert.AreEqual(sudoku.Squares[4].Value, 5);
            Assert.AreEqual(sudoku.Squares[5].Value, 6);
            Assert.AreEqual(sudoku.Squares[6].Value, 7);
            Assert.AreEqual(sudoku.Squares[7].Value, 8);
            Assert.AreEqual(sudoku.Squares[8].Value, 9);
        }

        [TestMethod]
        public void Can_Convert_Sudoku_To_Prolog_Tab()
        {
            // arrange
            var sudoku = new Sudoku();

            for (short i = 0; i < 9; i++)
                for (short j = 0; j < 9; j++)
                    sudoku.Squares[i * 9 + j].Value = (short)(j + 1);

            // act
            string prologTab = sudoku.ConvertSudokuToPrologTab();

            // assert
            Assert.AreEqual(prologTab, "[1,2,3,4,5,6,7,8,9," +
                                       "1,2,3,4,5,6,7,8,9," +
                                       "1,2,3,4,5,6,7,8,9," +
                                       "1,2,3,4,5,6,7,8,9," +
                                       "1,2,3,4,5,6,7,8,9," +
                                       "1,2,3,4,5,6,7,8,9," +
                                       "1,2,3,4,5,6,7,8,9," +
                                       "1,2,3,4,5,6,7,8,9," +
                                       "1,2,3,4,5,6,7,8,9]");
        }

        [TestMethod]
        public void Is_Nine_Squares_Correct_Return_True()
        {
            // arrange
            var squares = new List<ISquare>
            {
                new Square {Value = 1},
                new Square {Value = 2},
                new Square {Value = 3},
                new Square {Value = 4},
                new Square {Value = 5},
                new Square {Value = 6},
                new Square {Value = 7},
                new Square {Value = 8},
                new Square {Value = 9},
            };

            // act
            bool isCorrect = squares.IsNineSquaresCorrect();

            // assert
            Assert.IsTrue(isCorrect);
        }

        [TestMethod]
        public void Is_Nine_Squares_Incorrect_Return_False()
        {
            // arrange
            var squares = new List<ISquare>
            {
                new Square {Value = 1},
                new Square {Value = 2},
                new Square {Value = 2},
                new Square {Value = 4},
                new Square {Value = 5},
                new Square {Value = 3},
                new Square {Value = 7},
                new Square {Value = 9},
                new Square {Value = 9},
            };

            // act
            bool isCorrect = squares.IsNineSquaresCorrect();

            // assert
            Assert.IsFalse(isCorrect);
        }

        [TestMethod]
        public void Is_Nine_Squares_Incorrect_With_Zeros_Return_False()
        {
            // arrange
            var squares = new List<ISquare>
            {
                new Square {Value = 1},
                new Square {Value = 2},
                new Square {Value = 2},
                new Square {Value = 0},
                new Square {Value = 0},
                new Square {Value = 3},
                new Square {Value = 7},
                new Square {Value = 9},
                new Square {Value = 0},
            };

            // act
            bool isCorrect = squares.IsNineSquaresCorrect();

            // assert
            Assert.IsFalse(isCorrect);
        }

        [TestMethod]
        public void Is_Nine_Squares_Correct_With_Only_Zeros_Return_True()
        {
            // arrange
            var squares = new List<ISquare>
            {
                new Square {Value = 0},
                new Square {Value = 0},
                new Square {Value = 0},
                new Square {Value = 0},
                new Square {Value = 0},
                new Square {Value = 0},
                new Square {Value = 0},
                new Square {Value = 0},
                new Square {Value = 0},
            };

            // act
            bool isCorrect = squares.IsNineSquaresCorrect();

            // assert
            Assert.IsTrue(isCorrect);
        }

        [TestMethod]
        public void Can_Instantiate_A_Sudoku_Copy()
        {
            // arrange
            var sudoku = new Sudoku();

            // act
            var sudokuCopy = new Sudoku(sudoku);

            // assert
            Assert.AreNotSame(sudoku, sudokuCopy);
            Assert.AreNotSame(sudoku.Squares, sudokuCopy.Squares);
        }

        [TestMethod]
        public void Can_Instantiate_A_Square_Copy()
        {
            // arrange
            var sudoku = new Sudoku();

            // act
            var sudokuCopy = new Sudoku(sudoku);

            // assert
            Assert.AreNotSame(sudoku.Squares, sudokuCopy.Squares);
            Assert.AreNotSame(sudoku.Squares[0], sudokuCopy.Squares[0]);
            Assert.AreEqual(sudoku.Squares[0].Value, sudokuCopy.Squares[0].Value);
        }

        [TestMethod]
        public void Is_Rows_Correct_Select_Rows_Correctly()
        {
            // arrange
            var values = new short[]
            {
                3, 5, 4,    6, 1, 8,    2, 7, 9,
                8, 7, 6,    4, 2, 9,    1, 5, 3,
                1, 9, 2,    7, 5, 3,    8, 6, 4,

                4, 2, 5,    3, 6, 1,    9, 8, 7,
                6, 3, 8,    5, 9, 7,    4, 1, 2,
                7, 1, 9,    8, 4, 2,    6, 3, 5,

                5, 6, 7,    2, 8, 4,    3, 9, 1,
                2, 8, 1,    9, 3, 5,    7, 4, 6,
                9, 4, 3,    1, 7, 6,    5, 2, 8
            };
            var sudoku = new Sudoku(values);

            // act
            var result = sudoku.IsRowsCorrect();

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Is_Rows_Correct_Select_Rows_With_Nine_Elements()
        {
            // arrange
            var values = new short[]
            {
                3, 5, 4,    6, 1, 8,    2, 7, 9,
                8, 7, 6,    4, 2, 9,    1, 5, 3,
                1, 9, 2,    7, 5, 3,    8, 6, 4,

                4, 2, 5,    3, 6, 1,    9, 8, 7,
                6, 3, 8,    5, 9, 7,    4, 1, 2,
                7, 1, 9,    8, 4, 2,    6, 3, 5,

                5, 6, 7,    2, 8, 4,    3, 9, 1,
                2, 8, 1,    9, 3, 5,    7, 4, 6,
                9, 4, 3,    1, 7, 6,    5, 2, 8
            };
            var sudoku = new Sudoku(values);

            // act
            var nine = sudoku.Squares.Skip(3 * 9).Take(9).ToArray();

            // assert
            Assert.AreEqual(nine.Length, 9);
            Assert.AreEqual(nine[0].Value, 4);
            Assert.AreEqual(nine[1].Value, 2);
            Assert.AreEqual(nine[2].Value, 5);
            Assert.AreEqual(nine[3].Value, 3);
            Assert.AreEqual(nine[4].Value, 6);
            Assert.AreEqual(nine[5].Value, 1);
            Assert.AreEqual(nine[6].Value, 9);
            Assert.AreEqual(nine[7].Value, 8);
            Assert.AreEqual(nine[8].Value, 7);
        }

        [TestMethod]
        public void Is_Columns_Correct_Select_Columns_Correctly()
        {
            // arrange
            var values = new short[]
            {
                3, 5, 4,    6, 1, 8,    2, 7, 9,
                8, 7, 6,    4, 2, 9,    1, 5, 3,
                1, 9, 2,    7, 5, 3,    8, 6, 4,

                4, 2, 5,    3, 6, 1,    9, 8, 7,
                6, 3, 8,    5, 9, 7,    4, 1, 2,
                7, 1, 9,    8, 4, 2,    6, 3, 5,

                5, 6, 7,    2, 8, 4,    3, 9, 1,
                2, 8, 1,    9, 3, 5,    7, 4, 6,
                9, 4, 3,    1, 7, 6,    5, 2, 8
            };
            var sudoku = new Sudoku(values);

            // act
            var result = sudoku.IsColumnsCorrect();

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Is_Columns_Correct_Select_Columns_With_Nine_Elements()
        {
            // arrange
            var values = new short[]
            {
                3, 5, 4,    6, 1, 8,    2, 7, 9,
                8, 7, 6,    4, 2, 9,    1, 5, 3,
                1, 9, 2,    7, 5, 3,    8, 6, 4,

                4, 2, 5,    3, 6, 1,    9, 8, 7,
                6, 3, 8,    5, 9, 7,    4, 1, 2,
                7, 1, 9,    8, 4, 2,    6, 3, 5,

                5, 6, 7,    2, 8, 4,    3, 9, 1,
                2, 8, 1,    9, 3, 5,    7, 4, 6,
                9, 4, 3,    1, 7, 6,    5, 2, 8
            };
            var sudoku = new Sudoku(values);

            // act
            var nine = sudoku.Squares.Where((s, index) => index % 9 == 1).ToArray();

            // assert
            Assert.AreEqual(nine.Length, 9);
            Assert.AreEqual(nine[0].Value, 5);
            Assert.AreEqual(nine[1].Value, 7);
            Assert.AreEqual(nine[2].Value, 9);
            Assert.AreEqual(nine[3].Value, 2);
            Assert.AreEqual(nine[4].Value, 3);
            Assert.AreEqual(nine[5].Value, 1);
            Assert.AreEqual(nine[6].Value, 6);
            Assert.AreEqual(nine[7].Value, 8);
            Assert.AreEqual(nine[8].Value, 4);
        }

        [TestMethod]
        public void Is_InternSquares_Correct_Select_InternSquares_Correctly()
        {
            // arrange
            var values = new short[]
            {
                3, 5, 4,    6, 1, 8,    2, 7, 9,
                8, 7, 6,    4, 2, 9,    1, 5, 3,
                1, 9, 2,    7, 5, 3,    8, 6, 4,

                4, 2, 5,    3, 6, 1,    9, 8, 7,
                6, 3, 8,    5, 9, 7,    4, 1, 2,
                7, 1, 9,    8, 4, 2,    6, 3, 5,

                5, 6, 7,    2, 8, 4,    3, 9, 1,
                2, 8, 1,    9, 3, 5,    7, 4, 6,
                9, 4, 3,    1, 7, 6,    5, 2, 8
            };
            var sudoku = new Sudoku(values);

            // act
            var result = sudoku.IsInternSquaresCorrect();

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Is_InternSquares_Correct_With_Nine_Elements()
        {
            // arrange
            var values = new short[]
            {
                3, 5, 4,    6, 1, 8,    2, 7, 9,
                8, 7, 6,    4, 2, 9,    1, 5, 3,
                1, 9, 2,    7, 5, 3,    8, 6, 4,

                4, 2, 5,    3, 6, 1,    9, 8, 7,
                6, 3, 8,    5, 9, 7,    4, 1, 2,
                7, 1, 9,    8, 4, 2,    6, 3, 5,

                5, 6, 7,    2, 8, 4,    3, 9, 1,
                2, 8, 1,    9, 3, 5,    7, 4, 6,
                9, 4, 3,    1, 7, 6,    5, 2, 8
            };
            var sudoku = new Sudoku(values);

            // act
            var nine = sudoku.Squares.Skip(3).Take(27).Where((s, index) => (index % 9) < 3).ToArray();

            // assert
            Assert.AreEqual(nine.Length, 9);
            Assert.AreEqual(nine[0].Value, 6);
            Assert.AreEqual(nine[1].Value, 1);
            Assert.AreEqual(nine[2].Value, 8);
            Assert.AreEqual(nine[3].Value, 4);
            Assert.AreEqual(nine[4].Value, 2);
            Assert.AreEqual(nine[5].Value, 9);
            Assert.AreEqual(nine[6].Value, 7);
            Assert.AreEqual(nine[7].Value, 5);
            Assert.AreEqual(nine[8].Value, 3);
        }

        [TestMethod]
        public void Can_Resolve_Sudoku()
        {
            // arrange
            var recursiveResolver = new RecursiveResolverService();
            var values = new short[]
            {
                0, 5, 0,    0, 0, 0,    0, 7, 0,
                8, 7, 6,    0, 0, 0,    1, 0, 0,
                0, 0, 0,    0, 5, 3,    8, 0, 4,

                4, 2, 0,    0, 6, 0,    9, 0, 0,
                0, 0, 0,    0, 0, 0,    0, 0, 0,
                0, 0, 9,    0, 4, 0,    0, 3, 5,

                5, 0, 7,    2, 8, 0,    0, 0, 0,
                0, 0, 1,    0, 0, 0,    7, 4, 6,
                0, 4, 0,    0, 0, 0,    0, 2, 0
            };
            ISudoku sudokuResult;
            var sudoku = new Sudoku(values);

            // act
            recursiveResolver.Resolution(sudoku, out sudokuResult);

            var result = new short[81];
            for (short i = 0; i < sudokuResult.Squares.Length; i++)
                result[i] = sudokuResult.Squares[i].Value;

            // assert
            Assert.AreEqual(result[0], 3);
            Assert.AreEqual(result[2], 4);
            Assert.AreEqual(result[3], 6);
            Assert.AreEqual(result[4], 1);
            Assert.AreEqual(result[5], 8);
            Assert.AreEqual(result[6], 2);
            Assert.AreEqual(result[8], 9);
        }
    }
}
