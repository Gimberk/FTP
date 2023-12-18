namespace FTPServer
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.portTxt = new Code_Editor.Controls.RoundedEntryBox();
            this.startServerBtn = new Code_Editor.Controls.RoundButton();
            this.SuspendLayout();
            // 
            // portTxt
            // 
            this.portTxt.Animated = false;
            this.portTxt.BackColor = System.Drawing.SystemColors.Window;
            this.portTxt.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.portTxt.BorderFocusColor = System.Drawing.Color.HotPink;
            this.portTxt.BorderRadius = 0;
            this.portTxt.BorderSize = 2;
            this.portTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portTxt.ForeColor = System.Drawing.Color.DimGray;
            this.portTxt.Location = new System.Drawing.Point(52, 26);
            this.portTxt.Margin = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.portTxt.Multiline = false;
            this.portTxt.Name = "portTxt";
            this.portTxt.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.portTxt.PasswordCharacters = false;
            this.portTxt.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.portTxt.PlaceHolderText = "Port...";
            this.portTxt.Size = new System.Drawing.Size(250, 31);
            this.portTxt.TabIndex = 1;
            this.portTxt.Texts = "";
            this.portTxt.UnderlinedStyle = false;
            // 
            // startServerBtn
            // 
            this.startServerBtn.Animated = false;
            this.startServerBtn.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.startServerBtn.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.startServerBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.startServerBtn.BorderRadius = 40;
            this.startServerBtn.BorderSize = 0;
            this.startServerBtn.FlatAppearance.BorderSize = 0;
            this.startServerBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startServerBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startServerBtn.ForeColor = System.Drawing.Color.White;
            this.startServerBtn.Location = new System.Drawing.Point(99, 67);
            this.startServerBtn.Name = "startServerBtn";
            this.startServerBtn.Size = new System.Drawing.Size(143, 57);
            this.startServerBtn.TabIndex = 0;
            this.startServerBtn.Text = "Start";
            this.startServerBtn.TextColor = System.Drawing.Color.White;
            this.startServerBtn.UseVisualStyleBackColor = false;
            this.startServerBtn.Click += new System.EventHandler(this.startServerBtn_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 185);
            this.Controls.Add(this.portTxt);
            this.Controls.Add(this.startServerBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.ResumeLayout(false);

        }

        #endregion

        private Code_Editor.Controls.RoundButton startServerBtn;
        private Code_Editor.Controls.RoundedEntryBox portTxt;
    }
}