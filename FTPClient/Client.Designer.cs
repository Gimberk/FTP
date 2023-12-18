namespace FTPClient
{
    partial class Client
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
            this.ipTxt = new Code_Editor.Controls.RoundedEntryBox();
            this.connectBtn = new Code_Editor.Controls.RoundButton();
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
            this.portTxt.Location = new System.Drawing.Point(79, 75);
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
            // ipTxt
            // 
            this.ipTxt.Animated = false;
            this.ipTxt.BackColor = System.Drawing.SystemColors.Window;
            this.ipTxt.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.ipTxt.BorderFocusColor = System.Drawing.Color.HotPink;
            this.ipTxt.BorderRadius = 0;
            this.ipTxt.BorderSize = 2;
            this.ipTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipTxt.ForeColor = System.Drawing.Color.DimGray;
            this.ipTxt.Location = new System.Drawing.Point(79, 30);
            this.ipTxt.Margin = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.ipTxt.Multiline = false;
            this.ipTxt.Name = "ipTxt";
            this.ipTxt.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.ipTxt.PasswordCharacters = false;
            this.ipTxt.PlaceHolderColor = System.Drawing.Color.DarkGray;
            this.ipTxt.PlaceHolderText = "IP...";
            this.ipTxt.Size = new System.Drawing.Size(250, 31);
            this.ipTxt.TabIndex = 1;
            this.ipTxt.Texts = "";
            this.ipTxt.UnderlinedStyle = false;
            // 
            // connectBtn
            // 
            this.connectBtn.Animated = false;
            this.connectBtn.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.connectBtn.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.connectBtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.connectBtn.BorderRadius = 40;
            this.connectBtn.BorderSize = 0;
            this.connectBtn.FlatAppearance.BorderSize = 0;
            this.connectBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connectBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectBtn.ForeColor = System.Drawing.Color.White;
            this.connectBtn.Location = new System.Drawing.Point(133, 116);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(150, 40);
            this.connectBtn.TabIndex = 0;
            this.connectBtn.Text = "Await File";
            this.connectBtn.TextColor = System.Drawing.Color.White;
            this.connectBtn.UseVisualStyleBackColor = false;
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 204);
            this.Controls.Add(this.portTxt);
            this.Controls.Add(this.ipTxt);
            this.Controls.Add(this.connectBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Client";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gabr\'s FTP Client I think";
            this.ResumeLayout(false);

        }

        #endregion

        private Code_Editor.Controls.RoundButton connectBtn;
        private Code_Editor.Controls.RoundedEntryBox ipTxt;
        private Code_Editor.Controls.RoundedEntryBox portTxt;
    }
}