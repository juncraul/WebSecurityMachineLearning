﻿namespace Mathematics.Test;

public class FunctionsTest
{
    [Fact]
    public void Sigmoid_Test()
    {
        for (double x = -10; x < 10; x++)
        {
            var result = Functions.Sigmoid(x);

            Assert.True(result >= -1 && result <= 1);
        }
    }

    [Fact]
    public void CirclesCollisionThrowsNullReferenceException596()
    {
        Assert.Throws<NullReferenceException>(() => Functions.CirclesCollision(null, 0, null, 0));
    }

    [Fact]
    public void CirclesCollisionThrowsNullReferenceException295()
    {
        var s0 = new Vector2(0, 0);
        Assert.Throws<NullReferenceException>(() => Functions.CirclesCollision(s0, 0, null, 0));
    }

    [Fact]
    public void CirclesCollision442()
    {
        bool b;
        var s0 = new Vector2(2, 2);
        var s1 = new Vector2(4, 2);
        var s2 = new Vector2(4, 3);
        b = Functions.CirclesCollision(s0, 1, s1, 1);
        Assert.True(b);
        b = Functions.CirclesCollision(s1, 1, s2, 1);
        Assert.True(b);
        b = Functions.CirclesCollision(s0, 1, s2, 1);
        Assert.False(b);
    }

    [Fact]
    public void CollisionPointCircleThrowsNullReferenceException804()
    {
        bool b;
        Assert.Throws<NullReferenceException>(() => Functions.CollisionPointCircle(null, null, 0));
    }

    [Fact]
    public void CollisionPointCircleThrowsNullReferenceException466()
    {
        bool b;
        var s0 = new Vector2(0, 0);
        Assert.Throws<NullReferenceException>(() => Functions.CollisionPointCircle(s0, null, 0));
    }

    [Fact]
    public void CollisionPointCircle186()
    {
        var p0 = new Vector2(0, 0);
        var p1 = new Vector2(2, 2);
        var p2 = new Vector2(1, 2);
        var s0 = new Vector2(2, 2);
        var b = Functions.CollisionPointCircle(p0, s0, 1);
        Assert.False(b);
        b = Functions.CollisionPointCircle(p1, s0, 1);
        Assert.True(b);
        b = Functions.CollisionPointCircle(p2, s0, 1);
        Assert.True(b);
    }

    [Fact]
    public void AngleBetweenTwoPoints()
    {
        var p0 = new Vector2(0, 0);
        var p1 = new Vector2(1, 0);
        var p2 = new Vector2(1, 1);
        var p3 = new Vector2(0, 1);
        var p4 = new Vector2(-1, 1);
        var p5 = new Vector2(-1, 0);
        var p6 = new Vector2(-1, -1);
        var p7 = new Vector2(0, -1);
        var p8 = new Vector2(1, -1);

        var x = Functions.AngleBetweenTwoPoints(p0, p1);
        Assert.True(Math.Abs(x - (2 * Math.PI / 8 * 8)) < 0.001);
        x = Functions.AngleBetweenTwoPoints(p0, p2);
        Assert.True(Math.Abs(x - (2 * Math.PI / 8 * 1)) < 0.001);
        x = Functions.AngleBetweenTwoPoints(p0, p3);
        Assert.True(Math.Abs(x - (2 * Math.PI / 8 * 2)) < 0.001);
        x = Functions.AngleBetweenTwoPoints(p0, p4);
        Assert.True(Math.Abs(x - (2 * Math.PI / 8 * 3)) < 0.001);
        x = Functions.AngleBetweenTwoPoints(p0, p5);
        Assert.True(Math.Abs(x - (2 * Math.PI / 8 * 4)) < 0.001);
        x = Functions.AngleBetweenTwoPoints(p0, p6);
        Assert.True(Math.Abs(x - (2 * Math.PI / 8 * 5)) < 0.001);
        x = Functions.AngleBetweenTwoPoints(p0, p7);
        Assert.True(Math.Abs(x - (2 * Math.PI / 8 * 6)) < 0.001);
        x = Functions.AngleBetweenTwoPoints(p0, p8);
        Assert.True(Math.Abs(x - (2 * Math.PI / 8 * 7)) < 0.001);
    }
}