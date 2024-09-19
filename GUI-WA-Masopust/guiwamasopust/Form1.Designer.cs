namespace http_winform_custom
{
    partial class Form1
    {
        private System.ComponentModel.IContainer resources = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (resources != null))
            {
                resources.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            displayButton = new Button();
            monthSelector = new ComboBox();
            monthDataContainer = new FlowLayoutPanel();
            usersFlowLayout = new FlowLayoutPanel();
            submitButton = new Button();
            drinksContainer = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // displayButton
            // 
            displayButton.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 238);
            displayButton.Location = new Point(760, 580);
            displayButton.Name = "displayButton";
            displayButton.Size = new Size(150, 70);
            displayButton.TabIndex = 1;
            displayButton.Text = "Display";
            displayButton.UseVisualStyleBackColor = true;
            displayButton.Click += new EventHandler(displayButton_Click);
            // 
            // monthSelector
            // 
            monthSelector.DropDownStyle = ComboBoxStyle.DropDownList;
            monthSelector.Items.AddRange(new object[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" });
            monthSelector.Location = new Point(760, 550);
            monthSelector.Name = "monthSelector";
            monthSelector.Size = new Size(150, 25);
            monthSelector.TabIndex = 2;
            // 
            // monthDataContainer
            // 
            monthDataContainer.AutoScroll = true;
            monthDataContainer.BackColor = Color.LightGray;
            monthDataContainer.FlowDirection = FlowDirection.TopDown;
            monthDataContainer.Location = new Point(650, 20);
            monthDataContainer.Name = "monthDataContainer";
            monthDataContainer.Size = new Size(340, 510);
            monthDataContainer.TabIndex = 3;
            monthDataContainer.WrapContents = false;
            // 
            // usersFlowLayout
            // 
            usersFlowLayout.AutoScroll = true;
            usersFlowLayout.BackColor = Color.Gainsboro;
            usersFlowLayout.FlowDirection = FlowDirection.LeftToRight;
            usersFlowLayout.Location = new Point(20, 20);
            usersFlowLayout.Name = "usersFlowLayout";
            usersFlowLayout.Size = new Size(520, 240);
            usersFlowLayout.TabIndex = 4;
            usersFlowLayout.WrapContents = false;
            // 
            // submitButton
            // 
            submitButton.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 238);
            submitButton.Location = new Point(200, 580);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(150, 70);
            submitButton.TabIndex = 5;
            submitButton.Text = "Submit";
            submitButton.UseVisualStyleBackColor = true;
            submitButton.Click += new EventHandler(submitButton_Click);
            // 
            // drinksContainer
            // 
            drinksContainer.AutoScroll = true;
            drinksContainer.BackColor = Color.LightGray;
            drinksContainer.FlowDirection = FlowDirection.LeftToRight;
            drinksContainer.Location = new Point(20, 270);
            drinksContainer.Name = "drinksContainer";
            drinksContainer.Size = new Size(520, 300);
            drinksContainer.TabIndex = 6;
            drinksContainer.WrapContents = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1020, 680);
            Controls.Add(drinksContainer);
            Controls.Add(submitButton);
            Controls.Add(monthDataContainer);
            Controls.Add(monthSelector);
            Controls.Add(displayButton);
            Controls.Add(usersFlowLayout);
            Name = "Form1";
            Text = "Form1 Custom";
            Load += new EventHandler(Form1_Load);
            ResumeLayout(false);
        }

        #endregion

        private Button displayButton;
        private ComboBox monthSelector;
        private FlowLayoutPanel monthDataContainer;
        private FlowLayoutPanel usersFlowLayout;
        private Button submitButton;
        private FlowLayoutPanel drinksContainer;
    }
}
