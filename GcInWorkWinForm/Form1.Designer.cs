namespace GcInWorkWinForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnGc = new System.Windows.Forms.Button();
            this.btnThreads = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current total memory";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 30);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(150, 20);
            this.textBox1.TabIndex = 1;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(13, 66);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 2;
            this.btnTest.Text = "test";
            this.btnTest.UseVisualStyleBackColor = true;
            // 
            // btnGc
            // 
            this.btnGc.Location = new System.Drawing.Point(278, 32);
            this.btnGc.Name = "btnGc";
            this.btnGc.Size = new System.Drawing.Size(75, 23);
            this.btnGc.TabIndex = 3;
            this.btnGc.Text = "GC";
            this.btnGc.UseVisualStyleBackColor = true;
            // 
            // btnThreads
            // 
            this.btnThreads.Location = new System.Drawing.Point(424, 32);
            this.btnThreads.Name = "btnThreads";
            this.btnThreads.Size = new System.Drawing.Size(75, 23);
            this.btnThreads.TabIndex = 4;
            this.btnThreads.Text = "button2";
            this.btnThreads.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 158);
            this.Controls.Add(this.btnThreads);
            this.Controls.Add(this.btnGc);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnGc;
        private System.Windows.Forms.Button btnThreads;
    }
}

