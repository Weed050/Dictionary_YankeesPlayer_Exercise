namespace GoFishing
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
            textProgress = new TextBox();
            listHand = new ListBox();
            requestCardButton = new Button();
            textBooks = new TextBox();
            label1 = new Label();
            label2 = new Label();
            textName = new TextBox();
            startGameBtn = new Button();
            SuspendLayout();
            // 
            // textProgress
            // 
            textProgress.Location = new Point(12, 43);
            textProgress.Multiline = true;
            textProgress.Name = "textProgress";
            textProgress.Size = new Size(345, 218);
            textProgress.TabIndex = 0;
            // 
            // listHand
            // 
            listHand.FormattingEnabled = true;
            listHand.ItemHeight = 20;
            listHand.Location = new Point(401, 214);
            listHand.Name = "listHand";
            listHand.Size = new Size(150, 184);
            listHand.TabIndex = 1;
            // 
            // requestCardButton
            // 
            requestCardButton.Enabled = false;
            requestCardButton.Location = new Point(401, 413);
            requestCardButton.Name = "requestCardButton";
            requestCardButton.Size = new Size(150, 29);
            requestCardButton.TabIndex = 2;
            requestCardButton.Text = "Zarządaj karty";
            requestCardButton.UseVisualStyleBackColor = true;
            requestCardButton.Click += requestCardButton_Click;
            // 
            // textBooks
            // 
            textBooks.Location = new Point(12, 288);
            textBooks.Multiline = true;
            textBooks.Name = "textBooks";
            textBooks.Size = new Size(345, 137);
            textBooks.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(401, 191);
            label1.Name = "label1";
            label1.Size = new Size(90, 20);
            label1.TabIndex = 4;
            label1.Text = "Karty w ręce";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(401, 43);
            label2.Name = "label2";
            label2.Size = new Size(38, 20);
            label2.TabIndex = 5;
            label2.Text = "Imię";
            // 
            // textName
            // 
            textName.Location = new Point(401, 66);
            textName.Name = "textName";
            textName.Size = new Size(125, 27);
            textName.TabIndex = 6;
            // 
            // startGameBtn
            // 
            startGameBtn.Location = new Point(432, 108);
            startGameBtn.Name = "startGameBtn";
            startGameBtn.Size = new Size(94, 29);
            startGameBtn.TabIndex = 7;
            startGameBtn.Text = "Zacznij grę";
            startGameBtn.UseVisualStyleBackColor = true;
            startGameBtn.Click += startGame_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(startGameBtn);
            Controls.Add(textName);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBooks);
            Controls.Add(requestCardButton);
            Controls.Add(listHand);
            Controls.Add(textProgress);
            Name = "Form1";
            Text = "Go Fishing!";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textProgress;
        private ListBox listHand;
        private Button requestCardButton;
        private TextBox textBooks;
        private Label label1;
        private Label label2;
        private TextBox textName;
        private Button startGameBtn;
    }
}