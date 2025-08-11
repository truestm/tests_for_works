
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
            this.textError = new System.Windows.Forms.TextBox();
            this.buttonClear = new System.Windows.Forms.Button();
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
            this.textExpression.Size = new System.Drawing.Size(414, 161);
            this.textExpression.TabIndex = 0;
            this.textExpression.Text = "1+2*2+1";
            // 
            // listResults
            // 
            this.listResults.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.listResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderExpression,
            this.columnHeaderResult});
            this.listResults.FullRowSelect = true;
            this.listResults.HideSelection = false;
            this.listResults.Location = new System.Drawing.Point(3, 3);
            this.listResults.MultiSelect = false;
            this.listResults.Name = "listResults";
            this.listResults.Size = new System.Drawing.Size(414, 235);
            this.listResults.TabIndex = 1;
            this.listResults.UseCompatibleStateImageBehavior = false;
            this.listResults.View = System.Windows.Forms.View.Details;
            this.listResults.ItemActivate += new System.EventHandler(this.listResults_ItemActivate);
            // 
            // columnHeaderExpression
            // 
            this.columnHeaderExpression.Text = "Expression";
            this.columnHeaderExpression.Width = 261;
            // 
            // columnHeaderResult
            // 
            this.columnHeaderResult.Text = "Result";
            this.columnHeaderResult.Width = 145;
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
            this.splitContainer.Panel1.Controls.Add(this.buttonClear);
            this.splitContainer.Panel1.Controls.Add(this.listResults);
            this.splitContainer.Panel1MinSize = 100;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.textError);
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
            this.buttonCalculate.Location = new System.Drawing.Point(313, 227);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(95, 29);
            this.buttonCalculate.TabIndex = 1;
            this.buttonCalculate.Text = "Calculate";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click);
            // 
            // textError
            // 
            this.textError.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textError.BackColor = System.Drawing.SystemColors.Control;
            this.textError.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textError.Location = new System.Drawing.Point(3, 170);
            this.textError.Multiline = true;
            this.textError.Name = "textError";
            this.textError.Size = new System.Drawing.Size(414, 51);
            this.textError.TabIndex = 2;
            // 
            // buttonClear
            // 
            this.buttonClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClear.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonClear.Location = new System.Drawing.Point(313, 244);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(95, 29);
            this.buttonClear.TabIndex = 2;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
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
        private System.Windows.Forms.TextBox textError;
        private System.Windows.Forms.Button buttonClear;
    }
}

