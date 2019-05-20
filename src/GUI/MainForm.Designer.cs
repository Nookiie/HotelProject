namespace Draw
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.currentStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.buttonImport = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.textFile = new System.Windows.Forms.TextBox();
            this.radioOptimal = new System.Windows.Forms.RadioButton();
            this.radioExcept = new System.Windows.Forms.RadioButton();
            this.radioSpecial = new System.Windows.Forms.RadioButton();
            this.radioExceptElevator = new System.Windows.Forms.RadioButton();
            this.radioExceptClimb = new System.Windows.Forms.RadioButton();
            this.labelOperation = new System.Windows.Forms.Label();
            this.radioExceptWalk = new System.Windows.Forms.RadioButton();
            this.textFrom = new System.Windows.Forms.TextBox();
            this.labelFrom = new System.Windows.Forms.Label();
            this.labelTo = new System.Windows.Forms.Label();
            this.textTo = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.viewPort = new Draw.DoubleBufferedPanel();
            this.statusBar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusBar
            // 
            this.statusBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentStatusLabel});
            this.statusBar.Location = new System.Drawing.Point(0, 499);
            this.statusBar.Name = "statusBar";
            this.statusBar.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusBar.Size = new System.Drawing.Size(982, 22);
            this.statusBar.TabIndex = 2;
            this.statusBar.Text = "statusStrip1";
            // 
            // currentStatusLabel
            // 
            this.currentStatusLabel.Name = "currentStatusLabel";
            this.currentStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 499);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(3, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 499);
            this.splitter2.TabIndex = 7;
            this.splitter2.TabStop = false;
            // 
            // buttonImport
            // 
            this.buttonImport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonImport.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonImport.Location = new System.Drawing.Point(6, 0);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(152, 499);
            this.buttonImport.TabIndex = 8;
            this.buttonImport.Text = "Import";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonStart.Location = new System.Drawing.Point(818, 0);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(164, 499);
            this.buttonStart.TabIndex = 9;
            this.buttonStart.Tag = "Data";
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // textFile
            // 
            this.textFile.Dock = System.Windows.Forms.DockStyle.Top;
            this.textFile.Location = new System.Drawing.Point(158, 0);
            this.textFile.Multiline = true;
            this.textFile.Name = "textFile";
            this.textFile.Size = new System.Drawing.Size(660, 170);
            this.textFile.TabIndex = 11;
            // 
            // radioOptimal
            // 
            this.radioOptimal.AutoSize = true;
            this.radioOptimal.Location = new System.Drawing.Point(164, 176);
            this.radioOptimal.Name = "radioOptimal";
            this.radioOptimal.Size = new System.Drawing.Size(122, 21);
            this.radioOptimal.TabIndex = 12;
            this.radioOptimal.TabStop = true;
            this.radioOptimal.Text = "OptimalSearch";
            this.radioOptimal.UseVisualStyleBackColor = true;
            // 
            // radioExcept
            // 
            this.radioExcept.AutoSize = true;
            this.radioExcept.Location = new System.Drawing.Point(292, 176);
            this.radioExcept.Name = "radioExcept";
            this.radioExcept.Size = new System.Drawing.Size(116, 21);
            this.radioExcept.TabIndex = 13;
            this.radioExcept.TabStop = true;
            this.radioExcept.Text = "SearchExcept";
            this.radioExcept.UseVisualStyleBackColor = true;
            this.radioExcept.CheckedChanged += new System.EventHandler(this.radioExcept_CheckedChanged);
            // 
            // radioSpecial
            // 
            this.radioSpecial.AutoSize = true;
            this.radioSpecial.Location = new System.Drawing.Point(414, 176);
            this.radioSpecial.Name = "radioSpecial";
            this.radioSpecial.Size = new System.Drawing.Size(189, 21);
            this.radioSpecial.TabIndex = 14;
            this.radioSpecial.TabStop = true;
            this.radioSpecial.Text = "SearchLiftOrClimbSpecial";
            this.radioSpecial.UseVisualStyleBackColor = true;
            // 
            // radioExceptElevator
            // 
            this.radioExceptElevator.AutoSize = true;
            this.radioExceptElevator.Location = new System.Drawing.Point(327, 203);
            this.radioExceptElevator.Name = "radioExceptElevator";
            this.radioExceptElevator.Size = new System.Drawing.Size(81, 21);
            this.radioExceptElevator.TabIndex = 15;
            this.radioExceptElevator.TabStop = true;
            this.radioExceptElevator.Text = "Elevator";
            this.radioExceptElevator.UseVisualStyleBackColor = true;
            this.radioExceptElevator.Visible = false;
            this.radioExceptElevator.CheckedChanged += new System.EventHandler(this.radioExceptElevator_CheckedChanged);
            // 
            // radioExceptClimb
            // 
            this.radioExceptClimb.AutoSize = true;
            this.radioExceptClimb.Location = new System.Drawing.Point(414, 203);
            this.radioExceptClimb.Name = "radioExceptClimb";
            this.radioExceptClimb.Size = new System.Drawing.Size(63, 21);
            this.radioExceptClimb.TabIndex = 16;
            this.radioExceptClimb.TabStop = true;
            this.radioExceptClimb.Text = "Climb";
            this.radioExceptClimb.UseVisualStyleBackColor = true;
            this.radioExceptClimb.Visible = false;
            this.radioExceptClimb.CheckedChanged += new System.EventHandler(this.radioExceptClimb_CheckedChanged);
            // 
            // labelOperation
            // 
            this.labelOperation.AutoSize = true;
            this.labelOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOperation.Location = new System.Drawing.Point(164, 456);
            this.labelOperation.Name = "labelOperation";
            this.labelOperation.Size = new System.Drawing.Size(178, 32);
            this.labelOperation.TabIndex = 17;
            this.labelOperation.Text = "Bottom Text";
            // 
            // radioExceptWalk
            // 
            this.radioExceptWalk.AutoSize = true;
            this.radioExceptWalk.Location = new System.Drawing.Point(261, 203);
            this.radioExceptWalk.Name = "radioExceptWalk";
            this.radioExceptWalk.Size = new System.Drawing.Size(60, 21);
            this.radioExceptWalk.TabIndex = 18;
            this.radioExceptWalk.TabStop = true;
            this.radioExceptWalk.Text = "Walk";
            this.radioExceptWalk.UseVisualStyleBackColor = true;
            this.radioExceptWalk.Visible = false;
            this.radioExceptWalk.CheckedChanged += new System.EventHandler(this.radioExceptWalk_CheckedChanged);
            // 
            // textFrom
            // 
            this.textFrom.Location = new System.Drawing.Point(49, 5);
            this.textFrom.Name = "textFrom";
            this.textFrom.Size = new System.Drawing.Size(40, 22);
            this.textFrom.TabIndex = 19;
            // 
            // labelFrom
            // 
            this.labelFrom.AutoSize = true;
            this.labelFrom.Location = new System.Drawing.Point(3, 8);
            this.labelFrom.Name = "labelFrom";
            this.labelFrom.Size = new System.Drawing.Size(40, 17);
            this.labelFrom.TabIndex = 21;
            this.labelFrom.Text = "From";
            // 
            // labelTo
            // 
            this.labelTo.AutoSize = true;
            this.labelTo.Location = new System.Drawing.Point(95, 8);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(25, 17);
            this.labelTo.TabIndex = 22;
            this.labelTo.Text = "To";
            this.labelTo.Click += new System.EventHandler(this.labelTo_Click);
            // 
            // textTo
            // 
            this.textTo.Location = new System.Drawing.Point(126, 5);
            this.textTo.Name = "textTo";
            this.textTo.Size = new System.Drawing.Size(40, 22);
            this.textTo.TabIndex = 23;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelFrom);
            this.panel1.Controls.Add(this.textTo);
            this.panel1.Controls.Add(this.textFrom);
            this.panel1.Controls.Add(this.labelTo);
            this.panel1.Location = new System.Drawing.Point(609, 176);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 24;
            // 
            // viewPort
            // 
            this.viewPort.AutoSize = true;
            this.viewPort.Location = new System.Drawing.Point(381, 23);
            this.viewPort.Margin = new System.Windows.Forms.Padding(5);
            this.viewPort.Name = "viewPort";
            this.viewPort.Size = new System.Drawing.Size(556, 720);
            this.viewPort.TabIndex = 4;
            this.viewPort.Load += new System.EventHandler(this.viewPort_Load_1);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 521);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.radioExceptWalk);
            this.Controls.Add(this.labelOperation);
            this.Controls.Add(this.radioExceptClimb);
            this.Controls.Add(this.radioExceptElevator);
            this.Controls.Add(this.radioSpecial);
            this.Controls.Add(this.radioExcept);
            this.Controls.Add(this.radioOptimal);
            this.Controls.Add(this.textFile);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonImport);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.viewPort);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Hotel";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		
		private System.Windows.Forms.ToolStripStatusLabel currentStatusLabel;
		private Draw.DoubleBufferedPanel viewPort;
		private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.TextBox textFile;
        private System.Windows.Forms.RadioButton radioOptimal;
        private System.Windows.Forms.RadioButton radioExcept;
        private System.Windows.Forms.RadioButton radioSpecial;
        private System.Windows.Forms.RadioButton radioExceptElevator;
        private System.Windows.Forms.RadioButton radioExceptClimb;
        private System.Windows.Forms.Label labelOperation;
        private System.Windows.Forms.RadioButton radioExceptWalk;
        private System.Windows.Forms.TextBox textFrom;
        private System.Windows.Forms.Label labelFrom;
        private System.Windows.Forms.Label labelTo;
        private System.Windows.Forms.TextBox textTo;
        private System.Windows.Forms.Panel panel1;
    }
}
