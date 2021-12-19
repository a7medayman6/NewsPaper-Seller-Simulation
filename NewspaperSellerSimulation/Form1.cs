using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewspaperSellerModels;
using NewspaperSellerTesting;

namespace NewspaperSellerSimulation
{
    public partial class Form1 : Form
    {
        SimulationSystem simulationSystem;
        Random ran = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void simulate_b_Click(object sender, EventArgs e)
        {
            string[] data = File.ReadAllLines(Constants.FileNames.TestCase1);
            simulationSystem =  readInput(data);
            Simulate(simulationSystem);
            Display(simulationSystem);

            // TEST 
            string testingResult = TestingManager.Test(simulationSystem, Constants.FileNames.TestCase1);
            MessageBox.Show(testingResult);

        }
        private void Display(SimulationSystem simulationSystem)
        {
            simulationSystem.PerformanceMeasures.TotalSalesProfit = 0;
            simulationSystem.PerformanceMeasures.TotalCost = 0;
            simulationSystem.PerformanceMeasures.TotalLostProfit = 0;
            simulationSystem.PerformanceMeasures.TotalScrapProfit = 0;
            simulationSystem.PerformanceMeasures.TotalNetProfit = 0;
            simulationSystem.PerformanceMeasures.DaysWithMoreDemand = 0;
            simulationSystem.PerformanceMeasures.DaysWithUnsoldPapers = 0;
            for (int i = 0; i < simulationSystem.SimulationTable.Count; i++)
            {
                table_dgv.Rows.Add
                    (
                       simulationSystem.SimulationTable[i].DayNo, 
                       simulationSystem.SimulationTable[i].NewsDayType,
                       simulationSystem.SimulationTable[i].RandomNewsDayType, 
                       simulationSystem.SimulationTable[i].RandomDemand,
                       simulationSystem.SimulationTable[i].Demand, 
                       simulationSystem.SimulationTable[i].DailyCost, 
                       simulationSystem.SimulationTable[i].SalesProfit, 
                       simulationSystem.SimulationTable[i].LostProfit,
                       simulationSystem.SimulationTable[i].ScrapProfit, 
                       simulationSystem.SimulationTable[i].DailyNetProfit
                    );

                simulationSystem.PerformanceMeasures.TotalSalesProfit += simulationSystem.SimulationTable[i].SalesProfit;
                simulationSystem.PerformanceMeasures.TotalCost += simulationSystem.SimulationTable[i].DailyCost;
                simulationSystem.PerformanceMeasures.TotalLostProfit += simulationSystem.SimulationTable[i].LostProfit;
                simulationSystem.PerformanceMeasures.TotalScrapProfit += simulationSystem.SimulationTable[i].ScrapProfit;
                simulationSystem.PerformanceMeasures.TotalNetProfit += simulationSystem.SimulationTable[i].DailyNetProfit;
                
                if (simulationSystem.SimulationTable[i].Demand > simulationSystem.NumOfNewspapers)
                    simulationSystem.PerformanceMeasures.DaysWithMoreDemand++;
                if (simulationSystem.SimulationTable[i].Demand < simulationSystem.NumOfNewspapers)
                    simulationSystem.PerformanceMeasures.DaysWithUnsoldPapers++;
            }
        }
        private void Simulate(SimulationSystem simulationSystem)
        {
            for (int Record = 0; Record < simulationSystem.NumOfRecords; Record++)
                simulationSystem.SimulationTable.Add(SimulateAcase(simulationSystem, Record));
        }
        private SimulationCase SimulateAcase(SimulationSystem simulationSystem, int Record)
        {
            SimulationCase simulationCase = new SimulationCase();
            
            int RandomDayType = GenerateRandomInt();
            int RandomDemand = GenerateRandomInt();

            int DayType = -1, Demand = -1;

            if (RandomDayType <= simulationSystem.DayTypeDistributions[0].MaxRange)
            {
                DayType = 0;
                simulationCase.NewsDayType = Enums.DayType.Good;
            }
            else if (RandomDayType <= simulationSystem.DayTypeDistributions[1].MaxRange)
            {
                DayType = 1;
                simulationCase.NewsDayType = Enums.DayType.Fair;
            }
            else
            {
                DayType = 2;
                simulationCase.NewsDayType = Enums.DayType.Poor;
            }

            for (int i = 0; i < simulationSystem.DemandDistributions.Count; i++)
                if (RandomDemand >= simulationSystem.DemandDistributions[i].DayTypeDistributions[DayType].MinRange &&
                    RandomDemand <= simulationSystem.DemandDistributions[i].DayTypeDistributions[DayType].MaxRange)
                {
                    
                    Demand = simulationSystem.DemandDistributions[i].Demand;
                    break;
                }

            simulationCase.DailyCost = CalcNewspapersCost(simulationSystem.PurchasePrice, simulationSystem.NumOfNewspapers);
            simulationCase.SalesProfit = CalcSalesRevnue(Demand, simulationSystem.SellingPrice, simulationSystem.NumOfNewspapers);
            simulationCase.LostProfit = CalcLostProfit(Demand, simulationSystem.SellingPrice, simulationSystem.PurchasePrice, simulationSystem.NumOfNewspapers);
            simulationCase.ScrapProfit = CalcScrapProfit(Demand, simulationSystem.ScrapPrice, simulationSystem.NumOfNewspapers);
            simulationCase.DailyNetProfit = CalcTotalProfit(Demand, simulationSystem.SellingPrice, simulationSystem.PurchasePrice, simulationSystem.ScrapPrice, simulationSystem.NumOfNewspapers);
            simulationCase.DayNo = Record + 1;
            simulationCase.RandomNewsDayType = RandomDayType;
            simulationCase.RandomDemand = RandomDemand;
            simulationCase.Demand = Demand;

            return simulationCase;
        }
        private decimal CalcSalesRevnue(int Demand, decimal SellingPrice, int N)
        {
            if (N > Demand)
                return (decimal) Demand * SellingPrice;
            return (decimal) N * SellingPrice;
        }
        decimal CalcLostProfit(int Demand, decimal SellingPrice, decimal PurchasePrice, int N)
        {
            if (Demand > N)
                return ((Demand * SellingPrice) - (Demand * PurchasePrice)) - ((N * SellingPrice) - (N * PurchasePrice));
            return 0;
        }
        private decimal CalcScrapProfit(int Demand, decimal ScrapPrice, int N)
        {
            if (Demand < N)
                return (N - Demand) * ScrapPrice;
            return 0;
        }
        private decimal CalcNewspapersCost(decimal PurchasePrice, int N)
        {
            return N * PurchasePrice;
        }
        private decimal CalcTotalProfit(int Demand, decimal SellingPrice, decimal PurchasePrice, decimal ScrapPrice, int N)
        {
            return CalcSalesRevnue(Demand, SellingPrice, N) - CalcNewspapersCost(PurchasePrice, N) - CalcLostProfit(Demand, SellingPrice, PurchasePrice, N) + CalcScrapProfit(Demand, ScrapPrice, N);
        }
        private SimulationSystem readInput(string[] data)
        {
            simulationSystem = new SimulationSystem();
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == "NumOfNewspapers")
                {
                    newspaper_t.Text = data[i + 1];
                    simulationSystem.NumOfNewspapers = int.Parse(data[i + 1]);
                }
                else if (data[i] == "NumOfRecords")
                {
                    records_t.Text = data[i + 1];
                    simulationSystem.NumOfRecords = int.Parse(data[i + 1]);
                }
                else if (data[i] == "PurchasePrice")
                {
                    purchace_t.Text = data[i + 1];
                    simulationSystem.PurchasePrice = decimal.Parse(data[i + 1]);
                }
                else if (data[i] == "SellingPrice")
                {
                    selling_t.Text = data[i + 1];
                    simulationSystem.SellingPrice = decimal.Parse(data[i + 1]);
                }
                else if (data[i] == "ScrapPrice")
                {
                    scrap_t.Text = data[i + 1];
                    simulationSystem.ScrapPrice = decimal.Parse(data[i + 1]);
                }
                else if (data[i] == "DayTypeDistributions")
                {
                    // advance to the next line
                    i++;
                        
                    // get the next line values
                    string[] DayTypeDists = data[i].Split(',');

                    // get the day type dists
                    simulationSystem.DayTypeDistributions = CalcDayTypeDistribution(DayTypeDists);
                    
                }
                else if (data[i] == "DemandDistributions")
                {
                    i++;
                    while (i < data.Length && data[i] != "")
                    {
                        DemandDistribution DemandDistribution = new DemandDistribution();
                        string[] DemandDists = data[i].Split(',');

                        DemandDistribution.Demand = int.Parse(DemandDists[0]);

                        List<DayTypeDistribution> DayTypeDistribution = new List<DayTypeDistribution>();
                        DayTypeDistribution DayTypeDistSpec;

                        for (int j = 1; j <= 3; j++)
                        {
                            DayTypeDistSpec = new DayTypeDistribution();
                            DayTypeDistSpec.Probability = decimal.Parse(DemandDists[j]);
                            if (j == 1)
                                DayTypeDistSpec.DayType = Enums.DayType.Good;
                            else if (j == 2)
                                DayTypeDistSpec.DayType = Enums.DayType.Fair;
                            else
                                DayTypeDistSpec.DayType = Enums.DayType.Poor;

                            DayTypeDistribution.Add(DayTypeDistSpec);
                        }
                        DemandDistribution.DayTypeDistributions = DayTypeDistribution;
                        simulationSystem.DemandDistributions.Add(DemandDistribution);
                        i++;

                    }
                    for (int DemCounter = 0; DemCounter < simulationSystem.DemandDistributions.Count; DemCounter++)
                    {
                        for (int DayTypeCounter = 0; DayTypeCounter < 3; DayTypeCounter++)
                        {
                            if (DemCounter == 0)
                            {
                                simulationSystem.DemandDistributions[DemCounter].DayTypeDistributions[DayTypeCounter].CummProbability = simulationSystem.DemandDistributions[DemCounter].DayTypeDistributions[DayTypeCounter].Probability;
                                simulationSystem.DemandDistributions[DemCounter].DayTypeDistributions[DayTypeCounter].MinRange = 0;
                                simulationSystem.DemandDistributions[DemCounter].DayTypeDistributions[DayTypeCounter].MaxRange = (int)(simulationSystem.DemandDistributions[DemCounter].DayTypeDistributions[DayTypeCounter].CummProbability * 100);
                            }
                            else
                            {
                                simulationSystem.DemandDistributions[DemCounter].DayTypeDistributions[DayTypeCounter].MinRange = simulationSystem.DemandDistributions[DemCounter - 1].DayTypeDistributions[DayTypeCounter].MaxRange + 1;
                                simulationSystem.DemandDistributions[DemCounter].DayTypeDistributions[DayTypeCounter].CummProbability = simulationSystem.DemandDistributions[DemCounter].DayTypeDistributions[DayTypeCounter].Probability + simulationSystem.DemandDistributions[DemCounter - 1].DayTypeDistributions[DayTypeCounter].CummProbability;
                                simulationSystem.DemandDistributions[DemCounter].DayTypeDistributions[DayTypeCounter].MaxRange = (int)(simulationSystem.DemandDistributions[DemCounter].DayTypeDistributions[DayTypeCounter].CummProbability * 100); 
                            }
                        }
                    }
                }
            }

            return simulationSystem;
            
        }
        private List<DayTypeDistribution> CalcDayTypeDistribution(string[] DayTypeDists)
        {
            DayTypeDistribution DT;
            List<DayTypeDistribution> DTList = new List<DayTypeDistribution>();

            for (int j = 0; j < DayTypeDists.Length; j++)
            {
                string typeDist = DayTypeDists[j];

                DT = new DayTypeDistribution();

                // read the probability of type j
                DT.Probability = decimal.Parse(typeDist);

                // calc the cumm prob
                DT.CummProbability = DT.Probability;

                if(j != 0)
                    DT.CummProbability += DTList[DTList.Count - 1].CummProbability;

                // (if not first type) calc the min range -> prev type max range
                DT.MinRange = j == 0 ? 1 : DTList[DTList.Count - 1].MaxRange + 1;

                // (if not last type) calc the max range -> prob * 100
                DT.MaxRange = j == DayTypeDists.Length - 1 ? 100 : Decimal.ToInt32(DT.CummProbability * 100);

                if (j == 0)
                    DT.DayType = Enums.DayType.Good;
                else if (j == 1)
                    DT.DayType = Enums.DayType.Fair;
                else
                    DT.DayType = Enums.DayType.Poor;

                DTList.Add(DT);
            }

            return DTList;
        }

        public int GenerateRandomInt()
        {
            int number = ran.Next(1, 101);
            return number;
        }
    }
}
