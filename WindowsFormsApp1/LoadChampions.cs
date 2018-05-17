using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using Newtonsoft.Json;



namespace WindowsFormsApp1
{
    partial class Window
    {
        private void LoadChampions()
        {
            // Constants
            const string    DATA    = "data\\data.json";
            const string    PATH    = "data\\{0}";
            const string    IMAGE   = "data\\{0}\\{0}.png";
            const string    IMAGE_S = "data\\{0}\\{0}Selected.png";
            const string    TXT     = "champions.txt";
            const string    FONT    = "BeaufortforLOL-Bold";
            const char      DELIM   = ',';
            const int       ROW     = 16;
            const int       SIZE    = 50;
            const int       BWIDTH  = 62;
            const int       BHEIGHT = 60;

            // DataRead
            Dictionary<string, dynamic> data = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(File.ReadAllText(DATA));
            StreamReader file   = new StreamReader(String.Format(PATH, TXT));
            this.champions = new Dictionary<string, int>();
            int elements = Int32.Parse(file.ReadLine());

            // ImageList
            this.ImageList.ImageSize            = new Size(SIZE, SIZE);
            this.ImageListSelected.ImageSize    = new Size(SIZE, SIZE);

            // Arrays
            this.buttons            = new System.Windows.Forms.Button[elements]     ;

            this.ChampPanels        = new System.Windows.Forms.Panel[elements]      ;
            this.DataPanels         = new System.Windows.Forms.Panel[elements]      ;
            this.LeftPanels         = new System.Windows.Forms.Panel[elements]      ;
            this.MiddlePanels       = new System.Windows.Forms.Panel[elements]      ;
            this.RightPanels        = new System.Windows.Forms.Panel[elements]      ;
            this.BuildPanels        = new System.Windows.Forms.Panel[elements]      ;
            this.RunesPanels        = new System.Windows.Forms.Panel[elements]      ;
            this.WinratePanels      = new System.Windows.Forms.Panel[elements]      ;
            this.GraphPanels        = new System.Windows.Forms.Panel[elements]      ;
            this.CountersPanels     = new System.Windows.Forms.Panel[elements]      ;

            this.separators         = new System.Windows.Forms.Panel[elements]      ;
            this.ChampNameLabels    = new System.Windows.Forms.Label[elements]      ;
            this.CountersLabel1     = new System.Windows.Forms.Label[elements]      ;
            this.CountersLabel2     = new System.Windows.Forms.Label[elements]      ;
            this.CounterButtons     = new System.Windows.Forms.Button[elements, 10] ;

            // Button Creation
            for (int i = 0; i < elements; i++)
            {
                // ImageList
                string[] champion = file.ReadLine().Split(DELIM);
                this.ImageList.Images.Add(Image.FromFile(String.Format(IMAGE, champion)));
                this.ImageListSelected.Images.Add(Image.FromFile(String.Format(IMAGE_S, champion)));
                this.champions.Add(champion[1], i);

                // Button Position
                int x = i % ROW * BWIDTH;
                int y = i / ROW * BHEIGHT;

                // Creation
                this.ChampPanels[i]         = new System.Windows.Forms.Panel()  ;
                this.DataPanels[i]          = new System.Windows.Forms.Panel()  ;
                this.LeftPanels[i]          = new System.Windows.Forms.Panel()  ;
                this.MiddlePanels[i]        = new System.Windows.Forms.Panel()  ;
                this.RightPanels[i]         = new System.Windows.Forms.Panel()  ;
                this.BuildPanels[i]         = new System.Windows.Forms.Panel()  ;
                this.RunesPanels[i]         = new System.Windows.Forms.Panel()  ;
                this.WinratePanels[i]       = new System.Windows.Forms.Panel()  ;
                this.GraphPanels[i]         = new System.Windows.Forms.Panel()  ;
                this.CountersPanels[i]      = new System.Windows.Forms.Panel()  ;
                this.separators[i]          = new System.Windows.Forms.Panel()  ;
                this.ChampNameLabels[i]     = new System.Windows.Forms.Label()  ;
                this.CountersLabel1[i]      = new System.Windows.Forms.Label()  ;
                this.CountersLabel2[i]      = new System.Windows.Forms.Label()  ;
                this.buttons[i]             = new System.Windows.Forms.Button() ;

                // Location
                this.ChampionsButtonPanel.Controls.Add( this.buttons[i]             );

                this.MainPanel.Controls.Add(            this.ChampPanels[i]         );
                this.ChampPanels[i].Controls.Add(       this.ChampNameLabels[i]     );
                this.ChampPanels[i].Controls.Add(       this.separators[i]          );
                this.ChampPanels[i].Controls.Add(       this.DataPanels[i]          );

                this.DataPanels[i].Controls.Add(        this.LeftPanels[i]          );
                this.DataPanels[i].Controls.Add(        this.MiddlePanels[i]        );
                this.DataPanels[i].Controls.Add(        this.RightPanels[i]         );

                this.MiddlePanels[i].Controls.Add(      this.BuildPanels[i]         );
                this.MiddlePanels[i].Controls.Add(      this.RunesPanels[i]         );
                this.MiddlePanels[i].Controls.Add(      this.WinratePanels[i]       );

                this.RightPanels[i].Controls.Add(       this.CountersPanels[i]      );
                this.RightPanels[i].Controls.Add(       this.GraphPanels[i]         );

                this.CountersPanels[i].Controls.Add(    this.CountersLabel1[i]      );
                this.CountersPanels[i].Controls.Add(    this.CountersLabel2[i]      );

                //Panels
                this.ChampPanels[i].BackColor = Color.Transparent;
                this.ChampPanels[i].Dock = System.Windows.Forms.DockStyle.Fill;
                this.ChampPanels[i].Location = new Point(0, 78);
                this.ChampPanels[i].Name = champion[0] + "MainPanel";
                this.ChampPanels[i].Size = new Size(1056, 638);

                this.DataPanels[i].BackColor = Color.Transparent;
                this.DataPanels[i].Location = new Point(39, 73);
                this.DataPanels[i].Name = champion[0] + "DataPanel";
                this.DataPanels[i].Size = new Size(992, 540);

                this.separators[i].BackColor = Color.FromArgb(93, 71, 29);
                this.separators[i].Location = new Point(40, 66);
                this.separators[i].Name = champion[0] + "Separator";
                this.separators[i].Size = new Size(990, 1);

                this.LeftPanels[i].Location = new Point(0, 0);
                this.LeftPanels[i].Name = champion[0] + "LeftPanel";
                this.LeftPanels[i].Size = new Size(324, 540);

                this.MiddlePanels[i].Location = new Point(334, 0);
                this.MiddlePanels[i].Name = champion[0] + "MiddlePanel";
                this.MiddlePanels[i].Size = new Size(324, 540);

                this.RightPanels[i].Location = new Point(668, 0);
                this.RightPanels[i].Name = champion[0] + "RightPanel";
                this.RightPanels[i].Size = new Size(324, 540);

                this.BuildPanels[i].BackColor = Color.Wheat;
                this.BuildPanels[i].Location = new Point(0, 0);
                this.BuildPanels[i].Name = champion[0] + "BuildPanel";
                this.BuildPanels[i].Size = new Size(324, 170);
                this.RunesPanels[i].BackColor = Color.Salmon;
                this.RunesPanels[i].Location = new Point(0, 185);
                this.RunesPanels[i].Name = champion[0] + "RunesPanel";
                this.RunesPanels[i].Size = new Size(324, 170);
                this.WinratePanels[i].BackColor = Color.Yellow;
                this.WinratePanels[i].Location = new Point(0, 370);
                this.WinratePanels[i].Name = champion[0] + "WinratePanel";
                this.WinratePanels[i].Size = new Size(324, 170);

                this.GraphPanels[i].Location = new Point(0, 0);
                this.GraphPanels[i].Name = champion[0] + "GraphPanel";
                this.GraphPanels[i].Size = new Size(324, 260);

                this.CountersPanels[i].Location = new Point(0, 280);
                this.CountersPanels[i].Name = champion[0] + "CountersPanel";
                this.CountersPanels[i].Size = new Size(324, 260);

                // Buttons
                this.buttons[i].FlatAppearance.BorderSize = 0;
                this.buttons[i].Cursor = System.Windows.Forms.Cursors.Hand;
                this.buttons[i].FlatAppearance.MouseDownBackColor = Color.Transparent;
                this.buttons[i].FlatAppearance.MouseOverBackColor = Color.Transparent;
                this.buttons[i].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.buttons[i].ImageIndex = i;
                this.buttons[i].ImageList = this.ImageList;
                this.buttons[i].Location = new Point(x, y);
                this.buttons[i].Margin = new System.Windows.Forms.Padding(0);
                this.buttons[i].Name = champion[0];
                this.buttons[i].Size = new Size(BWIDTH, BHEIGHT);
                this.buttons[i].UseVisualStyleBackColor = true;
                this.buttons[i].MouseEnter += new EventHandler(this.Highlight);
                this.buttons[i].MouseLeave += new EventHandler(this.DeHighlight);
                this.buttons[i].Click += new EventHandler(this.Open);

                //Labels
                this.ChampNameLabels[i].Font = new Font(FONT, 26.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                this.ChampNameLabels[i].ForeColor = Color.FromArgb(201, 170, 113);
                this.ChampNameLabels[i].Location = new Point(0, 19);
                this.ChampNameLabels[i].Name = champion[0] + "Label";
                this.ChampNameLabels[i].Size = new Size(1056, 44);
                this.ChampNameLabels[i].Text = champion[1];
                this.ChampNameLabels[i].TextAlign = ContentAlignment.MiddleCenter;

                this.CountersLabel1[i].Font = new Font(FONT, 18, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                this.CountersLabel1[i].ForeColor = Color.FromArgb(201, 170, 113);
                this.CountersLabel1[i].Location = new Point(0, 20);
                this.CountersLabel1[i].Name = champion[0] + "CounterLabel1";
                this.CountersLabel1[i].Size = new Size(324, 45);
                this.CountersLabel1[i].Text = champion[1] + " is strong against";
                this.CountersLabel1[i].TextAlign = ContentAlignment.MiddleCenter;

                this.CountersLabel2[i].Font = new Font(FONT, 18, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                this.CountersLabel2[i].ForeColor = Color.FromArgb(201, 170, 113);
                this.CountersLabel2[i].Location = new Point(0, 150);
                this.CountersLabel2[i].Name = champion[0] + "CounterLabel2";
                this.CountersLabel2[i].Size = new Size(324, 45);
                this.CountersLabel2[i].Text = champion[1] + " is weak against";
                this.CountersLabel2[i].TextAlign = ContentAlignment.MiddleCenter;
            }

            file.Close();
            file = new StreamReader(String.Format(PATH, TXT));
            file.ReadLine();

            for (int i = 0; i < elements; i++)
            {
                string[] Counter = new string[2] { "goodwith", "counterd" };
                string[] champion = file.ReadLine().Split(DELIM);
                var s = data[champion[0]]["coreitem"];//.Take(5);

                //Builds
                for (int n = 0; n < 1; n++)
                {
                    continue;
                }
                //Counters
                for (int n = 0; n < 10; n++)
                {
                    //Variables
                    string      ChampName   = data[champion[0]][Counter[n / 5]][n % 5][0];
                    int         ChampIndex  = champions[ChampName];
                    int         x = 1   + (n % 5) * 64;
                    int         y = 68  + (n / 5) * 130;

                    //Creation
                    this.CounterButtons[i, n] = new System.Windows.Forms.Button();
                    this.CountersPanels[i].Controls.Add(this.CounterButtons[i, n]);

                    //Button
                    this.CounterButtons[i, n].FlatAppearance.BorderSize = 0;
                    this.CounterButtons[i, n].Cursor = System.Windows.Forms.Cursors.Hand;
                    this.CounterButtons[i, n].FlatAppearance.MouseDownBackColor = Color.Transparent;
                    this.CounterButtons[i, n].FlatAppearance.MouseOverBackColor = Color.Transparent;
                    this.CounterButtons[i, n].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    this.CounterButtons[i, n].ImageIndex = ChampIndex;
                    this.CounterButtons[i, n].ImageList = this.ImageList;
                    this.CounterButtons[i, n].Location = new Point(x, y);
                    this.CounterButtons[i, n].Margin = new System.Windows.Forms.Padding(0);
                    this.CounterButtons[i, n].Name = champion[0] + "Counter" + n.ToString();
                    this.CounterButtons[i, n].Size = new Size(BWIDTH, BHEIGHT);
                    this.CounterButtons[i, n].UseVisualStyleBackColor = true;
                    this.CounterButtons[i, n].MouseEnter += new EventHandler(this.Highlight);
                    this.CounterButtons[i, n].MouseLeave += new EventHandler(this.DeHighlight);
                    this.CounterButtons[i, n].Click += new EventHandler(this.Open);
                }
            }
        }

    private System.Windows.Forms.Button[] buttons;
    private System.Windows.Forms.Panel[] DataPanels;
    private System.Windows.Forms.Label[] ChampNameLabels;
    private System.Windows.Forms.Label[] CountersLabel1;
    private System.Windows.Forms.Label[] CountersLabel2;
    private System.Windows.Forms.Panel[] separators;
    private System.Windows.Forms.Panel[] LeftPanels;
    private System.Windows.Forms.Panel[] MiddlePanels;
    private System.Windows.Forms.Panel[] RightPanels;
    private System.Windows.Forms.Panel[] BuildPanels;
    private System.Windows.Forms.Panel[] RunesPanels;
    private System.Windows.Forms.Panel[] WinratePanels;
    private System.Windows.Forms.Panel[] GraphPanels;
    private System.Windows.Forms.Panel[] CountersPanels;
    private System.Windows.Forms.Panel[] ChampPanels;
    private System.Windows.Forms.Button[,] CounterButtons;
    private Dictionary<string, int> champions;


    }
}