namespace Test
{
    partial class Form1
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.BFS_button = new System.Windows.Forms.Button();
            this.DFS_button = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.Result_box = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox1.Location = new System.Drawing.Point(12, 41);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(217, 138);
            this.textBox1.TabIndex = 0;
            this.textBox1.WordWrap = false;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(197, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Read File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BFS_button
            // 
            this.BFS_button.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BFS_button.Location = new System.Drawing.Point(51, 12);
            this.BFS_button.Name = "BFS_button";
            this.BFS_button.Size = new System.Drawing.Size(75, 23);
            this.BFS_button.TabIndex = 2;
            this.BFS_button.Text = "BFS";
            this.BFS_button.UseVisualStyleBackColor = true;
            this.BFS_button.Click += new System.EventHandler(this.BFS_button_Click);
            // 
            // DFS_button
            // 
            this.DFS_button.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.DFS_button.Location = new System.Drawing.Point(341, 12);
            this.DFS_button.Name = "DFS_button";
            this.DFS_button.Size = new System.Drawing.Size(75, 23);
            this.DFS_button.TabIndex = 3;
            this.DFS_button.Text = "DFS";
            this.DFS_button.UseVisualStyleBackColor = true;
            this.DFS_button.Click += new System.EventHandler(this.DFS_button_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(380, 187);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "Draw Graph";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Result_box
            // 
            this.Result_box.AccessibleDescription = "";
            this.Result_box.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Result_box.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Result_box.Location = new System.Drawing.Point(237, 41);
            this.Result_box.Multiline = true;
            this.Result_box.Name = "Result_box";
            this.Result_box.ReadOnly = true;
            this.Result_box.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Result_box.Size = new System.Drawing.Size(218, 138);
            this.Result_box.TabIndex = 5;
            this.Result_box.WordWrap = false;
            this.Result_box.TextChanged += new System.EventHandler(this.Result_box_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 218);
            this.Controls.Add(this.Result_box);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.DFS_button);
            this.Controls.Add(this.BFS_button);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "TBD";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button BFS_button;
        private System.Windows.Forms.Button DFS_button;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox Result_box;
    }
}

