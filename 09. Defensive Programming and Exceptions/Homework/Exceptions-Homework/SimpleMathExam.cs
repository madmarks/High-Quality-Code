using System;

public class SimpleMathExam : Exam
{
    private const int MinSolvedProblems = 0;
    private const int MaxSolvedProblems = 10;

    private int problemsSolved;

    public SimpleMathExam(int problemsSolved)
    {
        this.ProblemsSolved = problemsSolved;
    }

    public int ProblemsSolved
    {
        get
        {
            return this.problemsSolved;
        }

        private set
        {
            if (value < MinSolvedProblems)
            {
                throw new ArgumentOutOfRangeException("problems solved must be higher than 0");
            }

            if (value > MaxSolvedProblems)
            {
                throw new ArgumentOutOfRangeException("problems solved must be smaller than 10");
            }

            this.problemsSolved = value;
        }
    }

    public override ExamResult Check()
    {
        if (this.ProblemsSolved == 0)
        {
            return new ExamResult(2, 2, 6, "Bad result: nothing done.");
        }
        else if (this.ProblemsSolved == 1)
        {
            return new ExamResult(4, 2, 6, "Average result: nothing done.");
        }
        else if (this.ProblemsSolved == 2)
        {
            return new ExamResult(6, 2, 6, "Average result: nothing done.");
        }
        else
        {
            throw new InvalidOperationException("Can not process with more than 2 problems solved");
        }
    }
}
