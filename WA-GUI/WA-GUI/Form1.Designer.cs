namespace http_winform
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            print = new Button();
            monthComboBox = new ComboBox();
            monthDataFlowLayout = new FlowLayoutPanel();
            peopleFlowLayout = new FlowLayoutPanel();
            send = new Button();
            drinksFlowLayout = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // print
            // 
            print.BackColor = SystemColors.ActiveCaptionText;
            print.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 238);
            print.ForeColor = SystemColors.Control;
            print.Location = new Point(850, 737);
            print.Margin = new Padding(3, 4, 3, 4);
            print.Name = "print";
            print.Size = new Size(182, 105);
            print.TabIndex = 0;
            print.Text = "Print";
            print.UseVisualStyleBackColor = false;
            print.Click += print_Click;
            // 
            // monthComboBox
            // 
            monthComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            monthComboBox.Items.AddRange(new object[] { "leden", "únor", "březen", "duben", "květen", "červen", "červenec", "srpen", "září", "říjen", "listopad", "prosinec" });
            monthComboBox.Location = new Point(734, 699);
            monthComboBox.Margin = new Padding(3, 4, 3, 4);
            monthComboBox.Name = "monthComboBox";
            monthComboBox.Size = new Size(402, 28);
            monthComboBox.TabIndex = 1;
            // 
            // monthDataFlowLayout
            // 
            monthDataFlowLayout.AutoScroll = true;
            monthDataFlowLayout.BackColor = Color.Silver;
            monthDataFlowLayout.FlowDirection = FlowDirection.TopDown;
            monthDataFlowLayout.Location = new Point(734, 335);
            monthDataFlowLayout.Margin = new Padding(3, 4, 3, 4);
            monthDataFlowLayout.Name = "monthDataFlowLayout";
            monthDataFlowLayout.Size = new Size(402, 356);
            monthDataFlowLayout.TabIndex = 7;
            monthDataFlowLayout.WrapContents = false;
            // 
            // peopleFlowLayout
            // 
            peopleFlowLayout.AutoScroll = true;
            peopleFlowLayout.BackColor = Color.Silver;
            peopleFlowLayout.FlowDirection = FlowDirection.TopDown;
            peopleFlowLayout.Location = new Point(17, 15);
            peopleFlowLayout.Margin = new Padding(3, 4, 3, 4);
            peopleFlowLayout.Name = "peopleFlowLayout";
            peopleFlowLayout.Size = new Size(565, 312);
            peopleFlowLayout.TabIndex = 8;
            peopleFlowLayout.WrapContents = false;
            // 
            // send
            // 
            send.BackColor = SystemColors.ActiveCaptionText;
            send.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 238);
            send.ForeColor = SystemColors.ButtonFace;
            send.Location = new Point(194, 335);
            send.Margin = new Padding(3, 4, 3, 4);
            send.Name = "send";
            send.Size = new Size(182, 105);
            send.TabIndex = 10;
            send.Text = "Send";
            send.UseVisualStyleBackColor = false;
            send.Click += send_Click;
            // 
            // drinksFlowLayout
            // 
            drinksFlowLayout.AutoScroll = true;
            drinksFlowLayout.BackColor = Color.Silver;
            drinksFlowLayout.FlowDirection = FlowDirection.TopDown;
            drinksFlowLayout.Location = new Point(588, 15);
            drinksFlowLayout.Margin = new Padding(3, 4, 3, 4);
            drinksFlowLayout.Name = "drinksFlowLayout";
            drinksFlowLayout.Size = new Size(548, 312);
            drinksFlowLayout.TabIndex = 9;
            drinksFlowLayout.WrapContents = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.aveyn348soa81;
            ClientSize = new Size(1150, 877);
            Controls.Add(drinksFlowLayout);
            Controls.Add(send);
            Controls.Add(monthDataFlowLayout);
            Controls.Add(monthComboBox);
            Controls.Add(print);
            Controls.Add(peopleFlowLayout);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button print;
        private ComboBox monthComboBox;
        private TrackBar trackBar2;
        private FlowLayoutPanel monthDataFlowLayout;
        private FlowLayoutPanel peopleFlowLayout;
        private Button send;
        private FlowLayoutPanel drinksFlowLayout;
        private Panel panel1;
        private Label label2;
        private Label label1;
    }
}
