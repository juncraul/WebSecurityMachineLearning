using Mathematics;
using NeuralNetwork;
using System.Threading;

namespace WebSecurityMachineLearning;

public partial class Form1 : Form
{
    readonly List<string> _trainings = [];
    readonly Network _network;

    private bool _isTraining;
    private bool _isTesting;
    private CancellationTokenSource _cancellationTokenSource = new();

    public Form1()
    {
        InitializeComponent();

        _network = new Network();
        _network.InitializeNetwork(ApplicationSettings.InputNodes, ApplicationSettings.HiddenNodes, ApplicationSettings.OutputNodes, ApplicationSettings.LearningRate, new Random(0));
    }

    private void buttonBrowse_Click(object sender, EventArgs e)
    {
        openFileDialog1.ShowDialog();
        textBoxBrowseTrain.Text = openFileDialog1.FileName;
    }

    private void buttonBrowseTest_Click(object sender, EventArgs e)
    {
        openFileDialog1.ShowDialog();
        textBoxBrowseTest.Text = openFileDialog1.FileName;
    }

    private async void buttonTrain_Click(object sender, EventArgs e)
    {
        if (_isTraining)
        {
            WriteLine("Training Stopped");
            buttonTrain.Text = "Start Training";
            _isTraining = false;
            _cancellationTokenSource.Cancel();
        }
        else
        {
            _cancellationTokenSource = new CancellationTokenSource();
            WriteLine("Training Started");
            buttonTrain.Text = "Stop Training";
            _isTraining = true;
            await TrainNetwork(_cancellationTokenSource.Token);
        }
    }

    private async void buttonTest_Click(object sender, EventArgs e)
    {
        if (_isTesting)
        {
            WriteLine("Testing Stopped");
            buttonTest.Text = "Start Testing";
            _isTesting = false;
            _cancellationTokenSource.Cancel();
        }
        else
        {
            _cancellationTokenSource = new CancellationTokenSource();
            WriteLine("Testing Started");
            buttonTest.Text = "Stop Testing";
            _isTesting = true;
            await TestNetwork(_cancellationTokenSource.Token);
        }
    }

    private async Task TrainNetwork(CancellationToken cancellationToken)
    {
        var stream = new StreamReader(textBoxBrowseTrain.Text);
        while (stream.ReadLine() is { } line)
        {
            _trainings.Add(line);
        }

        var count = 0;
        await Task.Run(() =>
                       {
                           foreach (var t in _trainings)
                           {
                               if (cancellationToken.IsCancellationRequested)
                               {
                                   return;
                               }

                               var inputMatrix = GetMatrix(t);
                               var isOk = t.Split(',')[1] == "good";
                               var targetMatrix = CreateTargetResult(isOk);

                               _network.TrainNetwork(inputMatrix, targetMatrix);
                               count++;

                               if (count % 200 == 0)
                                   WriteLine("Trains conducted so far: " + count);
                           }
                       },
                       cancellationToken);
    }

    private async Task TestNetwork(CancellationToken cancellationToken)
    {
        var total = 0;
        var correct = 0;
        var stream = new StreamReader(textBoxBrowseTrain.Text);
        while (stream.ReadLine() is { } line)
        {
            _trainings.Add(line);
        }

        await Task.Run(() =>
                       {
                           foreach (var t in _trainings)
                           {
                               if (cancellationToken.IsCancellationRequested)
                               {
                                   break;
                               }

                               var inputMatrix = GetMatrix(t);
                               var isOk = t.Split(',').Last() == "good";

                               var mat = _network.QueryNetwork(inputMatrix);
                               var actualValue = mat.GetMaxValueIndex() == 0;
                               total++;
                               if (isOk == actualValue)
                               {
                                   correct++;
                               }
                               else
                               {
                               }

                               if (total % 200 == 0)
                                   WriteLine("Tests conducted so far: " + total);
                           }

                           WriteLine("Total Tests: " + total);
                           WriteLine("Total Correct Results: " + correct);
                           WriteLine(((float)correct / total * 100) + "% match rate");
                       },
                       cancellationToken);
    }

    private Matrix CreateTargetResult(bool isOk)
    {
        var temp = new Matrix(2, 1);

        if (isOk)
        {
            temp.TheMatrix[0, 0] = 0.99;
            temp.TheMatrix[1, 0] = 0.01;
        }
        else
        {
            temp.TheMatrix[0, 0] = 0.01;
            temp.TheMatrix[1, 0] = 0.99;
        }

        return temp;
    }

    private Matrix GetMatrix(string line)
    {
        var temp = new Matrix(300, 1);
        var sample = line.Substring(0, line.LastIndexOf(','));

        var i = 0;
        foreach (var c in sample.TakeWhile(c => i != 300))
        {
            temp.TheMatrix[i, 0] = ScaleInput(c);
            i++;
        }

        return temp;
    }

    private double ScaleInput(char value)
    {
        return value / 255.0 * 0.99 + 0.01;
    }

    private void WriteLine(string line)
    {
        if (richTextBoxConsoleOutput.InvokeRequired)
        {
            richTextBoxConsoleOutput.Invoke(new Action<string>(WriteLine), line);
        }
        else
        {
            richTextBoxConsoleOutput.AppendText(line + Environment.NewLine);
            richTextBoxConsoleOutput.SelectionStart = richTextBoxConsoleOutput.Text.Length;
            richTextBoxConsoleOutput.ScrollToCaret();
        }
    }
}