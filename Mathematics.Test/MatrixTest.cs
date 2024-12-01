namespace Mathematics.Test;

public class MatrixTest
{
    [Fact]
    public void MatrixConstructor_Test()
    {
        var a = new Matrix(2, 3);

        Assert.Equal(2, a.Lines);
        Assert.Equal(3, a.Columns);
        Assert.Equal(6, a.TheMatrix.Length);
    }

    [Fact]
    public void MatrixMultiplication_Test()
    {
        var a = new Matrix(2, 3);
        var b = new Matrix(3, 2);

        a.TheMatrix[0, 0] = 1;
        a.TheMatrix[0, 1] = 2;
        a.TheMatrix[0, 2] = 3;
        a.TheMatrix[1, 0] = 4;
        a.TheMatrix[1, 1] = 5;
        a.TheMatrix[1, 2] = 6;

        b.TheMatrix[0, 0] = 7;
        b.TheMatrix[0, 1] = 8;
        b.TheMatrix[1, 0] = 9;
        b.TheMatrix[1, 1] = 10;
        b.TheMatrix[2, 0] = 11;
        b.TheMatrix[2, 1] = 12;

        var c = a * b;
        var d = 2 * a;
        var e = a * 2;

        Assert.Equal(58, c.TheMatrix[0, 0]);
        Assert.Equal(64, c.TheMatrix[0, 1]);
        Assert.Equal(139, c.TheMatrix[1, 0]);
        Assert.Equal(154, c.TheMatrix[1, 1]);

        Assert.Equal(2, d.TheMatrix[0, 0]);
        Assert.Equal(4, d.TheMatrix[0, 1]);
        Assert.Equal(6, d.TheMatrix[0, 2]);
        Assert.Equal(8, d.TheMatrix[1, 0]);
        Assert.Equal(10, d.TheMatrix[1, 1]);
        Assert.Equal(12, d.TheMatrix[1, 2]);

        Assert.Equal(2, e.TheMatrix[0, 0]);
        Assert.Equal(4, e.TheMatrix[0, 1]);
        Assert.Equal(6, e.TheMatrix[0, 2]);
        Assert.Equal(8, e.TheMatrix[1, 0]);
        Assert.Equal(10, e.TheMatrix[1, 1]);
        Assert.Equal(12, e.TheMatrix[1, 2]);
    }

    [Fact]
    public void MatrixAddition_Test()
    {
        var a = new Matrix(2, 2);
        var b = new Matrix(2, 2);

        a.TheMatrix[0, 0] = 1;
        a.TheMatrix[0, 1] = 2;
        a.TheMatrix[1, 0] = 3;
        a.TheMatrix[1, 1] = 4;

        b.TheMatrix[0, 0] = 5;
        b.TheMatrix[0, 1] = 6;
        b.TheMatrix[1, 0] = 7;
        b.TheMatrix[1, 1] = 8;

        var c = a + b;
        var d = 3 + a;
        var e = a + 3;

        Assert.Equal(6, c.TheMatrix[0, 0]);
        Assert.Equal(8, c.TheMatrix[0, 1]);
        Assert.Equal(10, c.TheMatrix[1, 0]);
        Assert.Equal(12, c.TheMatrix[1, 1]);

        Assert.Equal(4, d.TheMatrix[0, 0]);
        Assert.Equal(5, d.TheMatrix[0, 1]);
        Assert.Equal(6, d.TheMatrix[1, 0]);
        Assert.Equal(7, d.TheMatrix[1, 1]);

        Assert.Equal(4, e.TheMatrix[0, 0]);
        Assert.Equal(5, e.TheMatrix[0, 1]);
        Assert.Equal(6, e.TheMatrix[1, 0]);
        Assert.Equal(7, e.TheMatrix[1, 1]);
    }

    [Fact]
    public void MatrixSubtraction_Test()
    {
        var a = new Matrix(2, 2);
        var b = new Matrix(2, 2);

        a.TheMatrix[0, 0] = 1;
        a.TheMatrix[0, 1] = 2;
        a.TheMatrix[1, 0] = 3;
        a.TheMatrix[1, 1] = 4;

        b.TheMatrix[0, 0] = 5;
        b.TheMatrix[0, 1] = 6;
        b.TheMatrix[1, 0] = 7;
        b.TheMatrix[1, 1] = 8;

        var c = a - b;
        var d = 3 - a;
        var e = a - 3;

        Assert.Equal(-4, c.TheMatrix[0, 0]);
        Assert.Equal(-4, c.TheMatrix[0, 1]);
        Assert.Equal(-4, c.TheMatrix[1, 0]);
        Assert.Equal(-4, c.TheMatrix[1, 1]);

        Assert.Equal(2, d.TheMatrix[0, 0]);
        Assert.Equal(1, d.TheMatrix[0, 1]);
        Assert.Equal(0, d.TheMatrix[1, 0]);
        Assert.Equal(-1, d.TheMatrix[1, 1]);

        Assert.Equal(-2, e.TheMatrix[0, 0]);
        Assert.Equal(-1, e.TheMatrix[0, 1]);
        Assert.Equal(0, e.TheMatrix[1, 0]);
        Assert.Equal(1, e.TheMatrix[1, 1]);
    }

    [Fact]
    public void MatrixTranspose_Test()
    {
        var a = new Matrix(2, 3)
        {
            TheMatrix =
            {
                [0, 0] = 1,
                [0, 1] = 2,
                [0, 2] = 3,
                [1, 0] = 4,
                [1, 1] = 5,
                [1, 2] = 6
            }
        };

        var b = a.Transpose();

        Assert.Equal(1, b.TheMatrix[0, 0]);
        Assert.Equal(4, b.TheMatrix[0, 1]);
        Assert.Equal(2, b.TheMatrix[1, 0]);
        Assert.Equal(5, b.TheMatrix[1, 1]);
        Assert.Equal(3, b.TheMatrix[2, 0]);
        Assert.Equal(6, b.TheMatrix[2, 1]);
    }

    [Fact]
    public void GetMaxValueIndex_Test()
    {
        var a = new Matrix(6, 1)
        {
            TheMatrix =
            {
                [0, 0] = 1,
                [1, 0] = 2,
                [2, 0] = 30,
                [3, 0] = 4,
                [4, 0] = 5,
                [5, 0] = 6
            }
        };

        Assert.Equal(2, a.GetMaxValueIndex());
    }

    [Fact]
    public void GenerateRandomValuesBetween_Test()
    {
        var a = new Matrix(2, 3);
        var random = new Random(0);

        a.TheMatrix[0, 0] = 0;
        a.TheMatrix[0, 1] = 0;
        a.TheMatrix[0, 2] = 0;
        a.TheMatrix[1, 0] = 0;
        a.TheMatrix[1, 1] = 0;
        a.TheMatrix[1, 2] = 0;
        a.GenerateRandomValuesBetween(0.2f, 1.0f, random);

        Assert.NotEqual(0, a.TheMatrix[0, 0]);
        Assert.NotEqual(0, a.TheMatrix[0, 1]);
        Assert.NotEqual(0, a.TheMatrix[0, 2]);
        Assert.NotEqual(0, a.TheMatrix[1, 0]);
        Assert.NotEqual(0, a.TheMatrix[1, 1]);
        Assert.NotEqual(0, a.TheMatrix[1, 2]);
    }

    [Fact]
    public void CheckIfTestClassWorks_Test()
    {
        Assert.Equal(3, 3);
    }
}