namespace Mathematics.Test;

public class Vector2Test
{
    [Fact]
    public void Vector2Subtraction_Test()
    {
        var a = new Vector2(1, 2);
        var b = new Vector2(3, 4);

        var c = a - b;

        Assert.Equal(-2, c.X);
        Assert.Equal(-2, c.Y);
    }

    [Fact]
    public void Vector2Addition_Test()
    {
        var a = new Vector2(1, 2);
        var b = new Vector2(3, 4);

        var c = a + b;

        Assert.Equal(4, c.X);
        Assert.Equal(6, c.Y);
    }

    [Fact]
    public void Vector2Multiplication1_Test()
    {
        var a = new Vector2(1, 2);
        float b = 3;

        var c = a * b;

        Assert.Equal(3, c.X);
        Assert.Equal(6, c.Y);
    }

    [Fact]
    public void Vector2Multiplication2_Test()
    {
        var a = new Vector2(1, 2);
        float b = 3;

        var c = b * a;

        Assert.Equal(3, c.X);
        Assert.Equal(6, c.Y);
    }

    [Fact]
    public void Vector2Dot_Test()
    {
        var a = new Vector2(1, 2);
        var b = new Vector2(3, 4);

        var c = Vector2.Dot(a, b);

        Assert.Equal(11, c);
    }

    [Fact]
    public void Vector2Magnitude_Test()
    {
        var a = new Vector2(1, 2);

        var c = a.Magnitude();

        Assert.Equal(Math.Sqrt(5), c);
    }

    [Fact]
    public void Vector2Normalize_Test()
    {
        var a = new Vector2(2, 0);

        var c = a.Normalize();

        Assert.Equal(1, c.X);
        Assert.Equal(0, c.Y);
    }

    [Fact]
    public void Vector2Rotate_Test()
    {
        var a = new Vector2(0, 1);

        var b = a.Rotate(Math.PI / 2);
        var c = a.Rotate(Math.PI);
        var d = a.Rotate(3 * Math.PI / 2);
        var e = a.Rotate(2 * Math.PI);
        var f = a.Rotate(0);

        Assert.True(Math.Abs(b.X - -1) <= 0.00001f);
        Assert.True(Math.Abs(b.Y - 0) <= 0.00001f);

        Assert.True(Math.Abs(c.X - 0) <= 0.00001f);
        Assert.True(Math.Abs(c.Y - -1) <= 0.00001f);

        Assert.True(Math.Abs(d.X - 1) <= 0.00001f);
        Assert.True(Math.Abs(d.Y - 0) <= 0.00001f);

        Assert.True(Math.Abs(e.X - 0) <= 0.00001f);
        Assert.True(Math.Abs(e.Y - 1) <= 0.00001f);

        Assert.True(Math.Abs(f.X - 0) <= 0.00001f);
        Assert.True(Math.Abs(f.Y - 1) <= 0.00001f);
    }
}