
namespace Calc
{
    partial class MainForm
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
            this.textExpression = new System.Windows.Forms.TextBox();
            this.listResults = new System.Windows.Forms.ListView();
            this.columnHeaderExpression = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderResult = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.buttonCalculate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // textExpression
            // 
            this.textExpression.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textExpression.Location = new System.Drawing.Point(3, 3);
            this.textExpression.Multiline = true;
            this.textExpression.Name = "textExpression";
            this.textExpression.Size = new System.Drawing.Size(414, 214);
            this.textExpression.TabIndex = 0;
            // 
            // listResults
            // 
            this.listResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderExpression,
            this.columnHeaderResult});
            this.listResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listResults.HideSelection = false;
            this.listResults.Location = new System.Drawing.Point(0, 0);
            this.listResults.Name = "listResults";
            this.listResults.Size = new System.Drawing.Size(420, 276);
            this.listResults.TabIndex = 1;
            this.listResults.UseCompatibleStateImageBehavior = false;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.listResults);
            this.splitContainer.Panel1MinSize = 100;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.buttonCalculate);
            this.splitContainer.Panel2.Controls.Add(this.textExpression);
            this.splitContainer.Panel2MinSize = 100;
            this.splitContainer.Size = new System.Drawing.Size(420, 552);
            this.splitContainer.SplitterDistance = 276;
            this.splitContainer.SplitterWidth = 8;
            this.splitContainer.TabIndex = 2;
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCalculate.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonCalculate.Location = new System.Drawing.Point(313, 223);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(95, 29);
            this.buttonCalculate.TabIndex = 1;
            this.buttonCalculate.Text = "Calculate";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 552);
            this.Controls.Add(this.splitContainer);
            this.MinimumSize = new System.Drawing.Size(100, 300);
            this.Name = "MainForm";
            this.Text = "Calc";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textExpression;
        private System.Windows.Forms.ListView listResults;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Button buttonCalculate;
        private System.Windows.Forms.ColumnHeader columnHeaderExpression;
        private System.Windows.Forms.ColumnHeader columnHeaderResult;
    }
}

