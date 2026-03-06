using DIS_Semestralka_S1.Classes;
using DIS_Semestralka_S1.Classes.JednotliveCesty;

namespace SimulationGUI
{
    public partial class Form1 : Form
    {
        private VypocetNajkratsejTrasy currentSimulation;
        private Dictionary<string, ScottPlot.WinForms.FormsPlot> routePlots;
        private Dictionary<string, List<double>> routeData;
        private Dictionary<string, List<double>> routeReplicationNumbers;
        private bool isRunning = false;
        private CancellationTokenSource cancellationTokenSource;

        public Form1()
        {
            InitializeComponent();
            InitializeSimulation();
        }

        private void InitializeSimulation()
        {
            routePlots = new Dictionary<string, ScottPlot.WinForms.FormsPlot>
            {
                { "Divinka - Rajec - Strecno", formsPlotDRS },
                { "Divinka - Strecno - Rajec", formsPlotDSR },
                { "Rajec - Divinka - Strecno", formsPlotRDS },
                { "Rajec - Strecno - Divinka", formsPlotRSD },
                { "Strecno - Divinka - Rajec", formsPlotSDR },
                { "Strecno - Rajec - Divinka", formsPlotSRD }
            };

            routeData = new Dictionary<string, List<double>>();
            routeReplicationNumbers = new Dictionary<string, List<double>>();

            foreach (var routeName in routePlots.Keys)
            {
                routeData[routeName] = new List<double>();
                routeReplicationNumbers[routeName] = new List<double>();

                var plot = routePlots[routeName];
                plot.Plot.Title(routeName);
                plot.Plot.XLabel("Replication");
                plot.Plot.YLabel("Average Time");
                plot.Refresh();
            }

            buttonStart.Click += ButtonStart_Click;
            buttonStop.Click += ButtonStop_Click;
            comboBox1.SelectedIndex = 0;
        }

        private async void ButtonStart_Click(object sender, EventArgs e)
        {
            if (isRunning)
                return;

            if (comboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a route!");
                return;
            }

            isRunning = true;
            buttonStart.Enabled = false;
            buttonStop.Enabled = true;
            comboBox1.Enabled = false;

            cancellationTokenSource = new CancellationTokenSource();

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    currentSimulation = new DivinkaRajecStrecno();
                    break;
                case 1:
                    currentSimulation = new DivinkaStrecnoRajec();
                    break;
                case 2:
                    currentSimulation = new RajecDivinkaStrecno();
                    break;
                case 3:
                    currentSimulation = new RajecStrecnoDivinka();
                    break;
                case 4:
                    currentSimulation = new StrecnoDivinkaRajec();
                    break;
                case 5:
                    currentSimulation = new StrecnoRajecDivinka();
                    break;
            }

            currentSimulation.ReplicationCompleted += OnReplicationCompleted;

            await Task.Run(() =>
            {
                try
                {
                    currentSimulation.RunSimulation(10000);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Simulation error: {ex.Message}");
                }
            }, cancellationTokenSource.Token);

            isRunning = false;
            buttonStart.Enabled = true;
            buttonStop.Enabled = false;
            comboBox1.Enabled = true;
        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            if (currentSimulation != null)
            {
                currentSimulation.Run = false;
            }
            cancellationTokenSource?.Cancel();
        }

        private void OnReplicationCompleted(object sender, ReplicationEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<ReplicationEventArgs>(OnReplicationCompleted), sender, e);
                return;
            }

            if (!routeData.ContainsKey(e.Route))
                return;

            routeData[e.Route].Add(e.AverageTime);
            routeReplicationNumbers[e.Route].Add(e.ReplicationNumber);

            UpdateChart(e.Route);
        }

        private void UpdateChart(string routeName)
        {
            if (!routePlots.ContainsKey(routeName))
                return;

            var plot = routePlots[routeName];
            plot.Plot.Clear();

            if (routeData[routeName].Count > 0)
            {
                var scatter = plot.Plot.Add.Scatter(
                    routeReplicationNumbers[routeName].ToArray(),
                    routeData[routeName].ToArray()
                );
                scatter.LineWidth = 2;
                scatter.MarkerSize = 3;

                plot.Plot.Title(routeName);
                plot.Plot.XLabel("Replication");
                plot.Plot.YLabel("Average Time");
                plot.Plot.Axes.AutoScale();
            }

            plot.Refresh();
        }
    }
}
