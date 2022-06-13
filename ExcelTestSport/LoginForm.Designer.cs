
namespace ExcelTestSport
{
    partial class LoginForm
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
            this.EnterVariant = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.codeVariant = new System.Windows.Forms.TextBox();
            this.exitBottom = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // EnterVariant
            // 
            this.EnterVariant.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EnterVariant.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.EnterVariant.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EnterVariant.Font = new System.Drawing.Font("Comic Sans MS", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnterVariant.Location = new System.Drawing.Point(138, 342);
            this.EnterVariant.Name = "EnterVariant";
            this.EnterVariant.Size = new System.Drawing.Size(180, 65);
            this.EnterVariant.TabIndex = 0;
            this.EnterVariant.Text = "ВВОД";
            this.EnterVariant.UseVisualStyleBackColor = true;
            this.EnterVariant.Click += new System.EventHandler(this.EnterVariant_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(93, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 48);
            this.label1.TabIndex = 1;
            this.label1.Text = "ВВЕДИТЕ КОД";
            // 
            // codeVariant
            // 
            this.codeVariant.BackColor = System.Drawing.SystemColors.Info;
            this.codeVariant.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.codeVariant.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.codeVariant.Location = new System.Drawing.Point(107, 235);
            this.codeVariant.Name = "codeVariant";
            this.codeVariant.Size = new System.Drawing.Size(232, 63);
            this.codeVariant.TabIndex = 2;
            this.codeVariant.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // exitBottom
            // 
            this.exitBottom.AutoSize = true;
            this.exitBottom.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.exitBottom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitBottom.Font = new System.Drawing.Font("Comic Sans MS", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exitBottom.Location = new System.Drawing.Point(426, -6);
            this.exitBottom.Name = "exitBottom";
            this.exitBottom.Size = new System.Drawing.Size(34, 39);
            this.exitBottom.TabIndex = 3;
            this.exitBottom.Text = "x";
            this.exitBottom.Click += new System.EventHandler(this.exitBottom_Click);
            this.exitBottom.MouseEnter += new System.EventHandler(this.exitBottom_MouseEnter);
            this.exitBottom.MouseLeave += new System.EventHandler(this.exitBottom_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(463, 115);
            this.panel1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(32, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(386, 60);
            this.label2.TabIndex = 5;
            this.label2.Text = "ТЕСТИРОВАНИЕ";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 450);
            this.Controls.Add(this.exitBottom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.codeVariant);
            this.Controls.Add(this.EnterVariant);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Activated += new System.EventHandler(this.LoginForm_Activated);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button EnterVariant;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox codeVariant;
        private System.Windows.Forms.Label exitBottom;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
    }
}