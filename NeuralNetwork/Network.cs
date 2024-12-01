﻿using Mathematics;
using System.Drawing;

#pragma warning disable CA1416

namespace NeuralNetwork;

public class Network
{
    public int InputNodes { get; set; }
    public int HiddenNodes { get; set; }
    public int OutputNodes { get; set; }
    public float LearningRate { get; set; }

    private Layer InputLayer { get; set; }
    private Layer HiddenLayer { get; set; }
    private Layer OutputLayer { get; set; }

    Matrix _lastInput;

    private int _neuronRadiusDraw;
    private int _distanceBetweenLayersDraw;
    private int _distanceBetweenNeuronsDraw;
    private int _startXDraw;
    private int _startYDraw;
    private int _maxNrNeuronsOnLevel;

    public void InitializeNetwork(int inputNodes, int hiddenNodes, int outputNodes, float learningRate, Random rand)
    {
        InputNodes = inputNodes;
        HiddenNodes = hiddenNodes;
        OutputNodes = outputNodes;
        LearningRate = learningRate;
        InputLayer = new Layer();
        HiddenLayer = new Layer();
        OutputLayer = new Layer();

        InputLayer.Weights = new Matrix(HiddenNodes, InputNodes);
        InputLayer.Weights.GenerateRandomValuesBetween(-Math.Pow(HiddenNodes, -0.5), Math.Pow(HiddenNodes, -0.5), rand);
        HiddenLayer.Weights = new Matrix(OutputNodes, HiddenNodes);
        HiddenLayer.Weights.GenerateRandomValuesBetween(-Math.Pow(OutputNodes, -0.5), Math.Pow(OutputNodes, -0.5), rand);
        OutputLayer.Output = new Matrix(OutputNodes, 1);

        _neuronRadiusDraw = 6;
        _distanceBetweenLayersDraw = 100;
        _distanceBetweenNeuronsDraw = 5;
        _startXDraw = 40;
        _startYDraw = 10;
        int[] array =
        [
            inputNodes, hiddenNodes, outputNodes
        ];

        _maxNrNeuronsOnLevel = array.Max(a => a);
    }

    public Matrix TrainNetwork(Matrix inputs, Matrix target)
    {
        OutputLayer.Output = QueryNetwork(inputs);
        OutputLayer.Errors = target - OutputLayer.Output;
        HiddenLayer.Errors = HiddenLayer.Weights.Transpose() * OutputLayer.Errors;
        var hiddenLayerOutputTranspose = InputLayer.Output.Transpose();
        var inputsTranspose = inputs.Transpose();

        for (var i = 0; i < OutputLayer.Errors.Lines; i++)
        {
            var change = (OutputLayer.Errors.TheMatrix[i, 0] * OutputLayer.Output.TheMatrix[i, 0] * (1.0 - OutputLayer.Output.TheMatrix[i, 0]));
            HiddenLayer.Weights.AddToLine(LearningRate * (change * hiddenLayerOutputTranspose), i);
        }

        for (var i = 0; i < HiddenLayer.Errors.Lines; i++)
        {
            var change = (HiddenLayer.Errors.TheMatrix[i, 0] * InputLayer.Output.TheMatrix[i, 0] * (1.0 - InputLayer.Output.TheMatrix[i, 0]));
            InputLayer.Weights.AddToLine(LearningRate * (change * inputsTranspose), i);
        }

        return OutputLayer.Output;
    }

    public Matrix QueryNetwork(Matrix inputs)
    {
        _lastInput = inputs;
        InputLayer.Output = InputLayer.Weights * inputs;

        for (var i = 0; i < HiddenNodes; i++)
        {
            InputLayer.Output.TheMatrix[i, 0] = ActivationFunction(InputLayer.Output.TheMatrix[i, 0]);
        }

        HiddenLayer.Output = HiddenLayer.Weights * InputLayer.Output;
        OutputLayer.Output = new Matrix(OutputNodes, 1);

        for (var i = 0; i < OutputNodes; i++)
        {
            OutputLayer.Output.TheMatrix[i, 0] = ActivationFunction(HiddenLayer.Output.TheMatrix[i, 0]);
        }

        return OutputLayer.Output;
    }

    public void Draw(Graphics graphics, Bitmap bitmap)
    {
        var brush = new SolidBrush(Color.Yellow);
        var pen = new Pen(Color.Black);

        var diameter = _neuronRadiusDraw * 2;
        var ySpacePerNeuron = (_neuronRadiusDraw * 2 + _distanceBetweenNeuronsDraw);
        var yOffset0 = _startYDraw + _neuronRadiusDraw + (_maxNrNeuronsOnLevel - InputNodes) / 2 * ySpacePerNeuron;
        var yOffset1 = _startYDraw + _neuronRadiusDraw + (_maxNrNeuronsOnLevel - HiddenNodes) / 2 * ySpacePerNeuron;
        var xOffset0 = _startXDraw + _neuronRadiusDraw;
        var xOffset1 = _startXDraw + _distanceBetweenLayersDraw + _neuronRadiusDraw;
        for (var i = 0; i < InputLayer.Weights.Columns; i++)
        {
            for (var j = 0; j < InputLayer.Weights.Lines; j++)
            {
                pen.Width = (int) (Math.Abs(InputLayer.Weights.TheMatrix[j, i]) * 5);
                pen.Color = InputLayer.Weights.TheMatrix[j, i] < 0 ? Color.Red : Color.Blue;
                graphics.DrawLine(pen,
                                  xOffset0,
                                  yOffset0 + i * ySpacePerNeuron,
                                  xOffset1,
                                  yOffset1 + j * ySpacePerNeuron);
            }
        }

        ySpacePerNeuron = (_neuronRadiusDraw * 2 + _distanceBetweenNeuronsDraw);
        yOffset0 = _startYDraw + _neuronRadiusDraw + (_maxNrNeuronsOnLevel - HiddenNodes) / 2 * ySpacePerNeuron;
        yOffset1 = _startYDraw + _neuronRadiusDraw + (_maxNrNeuronsOnLevel - OutputNodes) / 2 * ySpacePerNeuron;
        xOffset0 = _startXDraw + _distanceBetweenLayersDraw + _neuronRadiusDraw;
        xOffset1 = _startXDraw + _distanceBetweenLayersDraw * 2 + _neuronRadiusDraw;
        for (var i = 0; i < HiddenLayer.Weights.Columns; i++)
        {
            for (var j = 0; j < HiddenLayer.Weights.Lines; j++)
            {
                pen.Width = (int) (Math.Abs(HiddenLayer.Weights.TheMatrix[j, i]) * 5);
                pen.Color = HiddenLayer.Weights.TheMatrix[j, i] < 0 ? Color.Red : Color.Blue;
                graphics.DrawLine(pen,
                                  xOffset0,
                                  yOffset0 + i * ySpacePerNeuron,
                                  xOffset1,
                                  yOffset1 + j * ySpacePerNeuron);
            }
        }

        ySpacePerNeuron = (_neuronRadiusDraw * 2 + _distanceBetweenNeuronsDraw);
        yOffset0 = _startYDraw + (_maxNrNeuronsOnLevel - InputNodes) / 2 * ySpacePerNeuron;
        xOffset0 = _startXDraw;
        for (var i = 0; i < InputNodes; i++)
        {
            brush.Color = Color.Yellow;
            graphics.FillEllipse(brush, new Rectangle(xOffset0, yOffset0 + i * ySpacePerNeuron, diameter, diameter));

            var text = $"{_lastInput.TheMatrix[i, 0]:N3}";
            brush.Color = Color.Black;
            graphics.DrawString(text, new Font("Consolas", 8), brush, xOffset0 - 30, yOffset0 + i * ySpacePerNeuron);
        }

        ySpacePerNeuron = (_neuronRadiusDraw * 2 + _distanceBetweenNeuronsDraw);
        yOffset0 = _startYDraw + (_maxNrNeuronsOnLevel - HiddenNodes) / 2 * ySpacePerNeuron;
        xOffset0 = _startXDraw + _distanceBetweenLayersDraw;
        for (var i = 0; i < HiddenNodes; i++)
        {
            brush.Color = Color.Yellow;
            graphics.FillEllipse(brush, new Rectangle(xOffset0, yOffset0 + i * ySpacePerNeuron, diameter, diameter));
        }

        ySpacePerNeuron = (_neuronRadiusDraw * 2 + _distanceBetweenNeuronsDraw);
        yOffset0 = _startYDraw + (_maxNrNeuronsOnLevel - OutputNodes) / 2 * ySpacePerNeuron;
        xOffset0 = _startXDraw + _distanceBetweenLayersDraw * 2;
        for (var i = 0; i < OutputNodes; i++)
        {
            brush.Color = Color.Yellow;
            graphics.FillEllipse(brush, new Rectangle(xOffset0, yOffset0 + i * ySpacePerNeuron, diameter, diameter));

            var text = $"{OutputLayer.Output.TheMatrix[i, 0]:N3}";
            brush.Color = Color.Black;
            graphics.DrawString(text, new Font("Consolas", 8), brush, xOffset0 + _neuronRadiusDraw * 2, yOffset0 + i * ySpacePerNeuron);
        }
    }

    public string ConvertNetworkToBitString()
    {
        var bits = string.Empty;

        for (var i = 0; i < InputLayer.Weights.Columns; i++)
        {
            for (var j = 0; j < InputLayer.Weights.Lines; j++)
            {
                var value = (int) (((InputLayer.Weights.TheMatrix[j, i] + 1) / 2) * 1000);
                var scaledDownTo256Bit = (int) (value * 255.0 / 999.0);
                bits += Functions.ToBin(scaledDownTo256Bit, 8);
            }
        }

        for (var i = 0; i < HiddenLayer.Weights.Columns; i++)
        {
            for (var j = 0; j < HiddenLayer.Weights.Lines; j++)
            {
                var value = (int) (((HiddenLayer.Weights.TheMatrix[j, i] + 1) / 2) * 1000);
                var scaledDownTo256Bit = (int) (value * 255.0 / 999.0);
                bits += Functions.ToBin(scaledDownTo256Bit, 8);
            }
        }

        return bits;
    }

    public void ConvertBitStringToNetwork(string bits)
    {
        var index = 0;
        for (var i = 0; i < InputLayer.Weights.Columns; i++)
        {
            for (var j = 0; j < InputLayer.Weights.Lines; j++)
            {
                var scaledDownTo256Bit = Convert.ToInt32(bits.Substring(index, 8), 2);
                var value = (scaledDownTo256Bit * 999 / 255.0 / 1000.0 * 2 - 1);
                InputLayer.Weights.TheMatrix[j, i] = value;
                index += 8;
            }
        }

        for (var i = 0; i < HiddenLayer.Weights.Columns; i++)
        {
            for (var j = 0; j < HiddenLayer.Weights.Lines; j++)
            {
                var scaledDownTo256Bit = Convert.ToInt32(bits.Substring(index, 8), 2);
                var value = (scaledDownTo256Bit * 999 / 255.0 / 1000.0 * 2 - 1);
                HiddenLayer.Weights.TheMatrix[j, i] = value;
                index += 8;
            }
        }
    }

    public string ConvertNetworkToBitStringHiddenLayerOrder()
    {
        var bits = string.Empty;

        for (var j = 0; j < InputLayer.Weights.Lines; j++)
        {
            for (var i = 0; i < InputLayer.Weights.Columns; i++)
            {
                var value = (int) (((InputLayer.Weights.TheMatrix[j, i] + 1) / 2) * 1000);
                var scaledDownTo256Bit = (int) (value * 255.0 / 999.0);
                bits += Functions.ToBin(scaledDownTo256Bit, 8);
            }

            for (var l = 0; l < HiddenLayer.Weights.Lines; l++)
            {
                var value = (int) (((HiddenLayer.Weights.TheMatrix[l, j] + 1) / 2) * 1000);
                var scaledDownTo256Bit = (int) (value * 255.0 / 999.0);
                bits += Functions.ToBin(scaledDownTo256Bit, 8);
            }
        }

        return bits;
    }

    public void ConvertBitStringToNetworkHiddenLayerOrder(string bits)
    {
        var index = 0;
        for (var j = 0; j < InputLayer.Weights.Lines; j++)
        {
            for (var i = 0; i < InputLayer.Weights.Columns; i++)
            {
                var scaledDownTo256Bit = index < bits.Length ? Convert.ToInt32(bits.Substring(index, 8), 2) : 0;
                var value = (scaledDownTo256Bit * 999 / 255.0 / 1000.0 * 2 - 1);
                InputLayer.Weights.TheMatrix[j, i] = value;
                index += 8;
            }

            for (var l = 0; l < HiddenLayer.Weights.Lines; l++)
            {
                var scaledDownTo256Bit = index < bits.Length ? Convert.ToInt32(bits.Substring(index, 8), 2) : 0;
                var value = (scaledDownTo256Bit * 999 / 255.0 / 1000.0 * 2 - 1);
                HiddenLayer.Weights.TheMatrix[l, j] = value;
                index += 8;
            }
        }
    }

    private static double ActivationFunction(double x)
    {
        return Functions.Sigmoid(x);
    }
}