
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
            this.SuspendLayout();
            // 
            // EnterVariant
            // 
            this.EnterVariant.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnterVariant.Location = new System.Drawing.Point(143, 255);
            this.EnterVariant.Name = "EnterVariant";
            this.EnterVariant.Size = new System.Drawing.Size(179, 64);
            this.EnterVariant.TabIndex = 0;
            this.EnterVariant.Text = "ВВОД";
            this.EnterVariant.UseVisualStyleBackColor = true;
            this.EnterVariant.Click += new System.EventHandler(this.EnterVariant_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(82, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(317, 46);
            this.label1.TabIndex = 1;
            this.label1.Text = "ВВЕДИТЕ КОД";
            // 
            // codeVariant
            // 
            this.codeVariant.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.codeVariant.Location = new System.Drawing.Point(117, 159);
            this.codeVariant.Name = "codeVariant";
            this.codeVariant.Size = new System.Drawing.Size(232, 53);
            this.codeVariant.TabIndex = 2;
            this.codeVariant.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 369);
            this.Controls.Add(this.codeVariant);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EnterVariant);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Activated += new System.EventHandler(this.LoginForm_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button EnterVariant;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox codeVariant;
    }
}