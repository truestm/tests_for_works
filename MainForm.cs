using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calc
{
    public partial class MainForm : Form
    {
        IEvaluator evaluator;

        public MainForm()
        {
            InitializeComponent();
        }
        public MainForm(IEvaluator evaluator):this()
        {
            this.evaluator = evaluator;
        }

        private async void buttonCalculate_Click(object sender, EventArgs e)
        {
            var expression = textExpression.Text;
            string resultText = null;
            try
            {
                var result = await evaluator.EvalAsync(expression);
                resultText = result.ToString();

            }
            catch (Exception ex)
            {
                resultText = ex.Message;
            }
            var resultItem = new ListViewItem(new[] { expression, resultText });
            listResults.Items.Add(resultItem);
        }
    }
}
