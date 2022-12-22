namespace CalculatorTest
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.customCalculator1 = new CustomCalculator.CustomCalculator();
            this.SuspendLayout();
            // 
            // customCalculator1
            // 
            this.customCalculator1.BackColor = System.Drawing.Color.White;
            this.customCalculator1.Location = new System.Drawing.Point(82, 39);
            this.customCalculator1.Margin = new System.Windows.Forms.Padding(2);
            this.customCalculator1.Name = "customCalculator1";
            this.customCalculator1.Size = new System.Drawing.Size(439, 353);
            this.customCalculator1.TabIndex = 0;
            this.customCalculator1.Load += new System.EventHandler(this.customCalculator1_Load_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 424);
            this.Controls.Add(this.customCalculator1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Calculator";
            this.ResumeLayout(false);

        }

        #endregion

        private CustomCalculator.CustomCalculator customCalculator1;
    }
}

