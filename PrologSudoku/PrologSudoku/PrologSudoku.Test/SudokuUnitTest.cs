using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrologSudoku.Model.Model.Abstract;
using PrologSudoku.Model.Model.Concrete;
using PrologSudoku.Services.Infrastructure;

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
    }
}
