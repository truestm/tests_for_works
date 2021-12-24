using System;
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
            
            textError.Text = String.Empty;

            string resultText = null;
            try
            {
                var result = await evaluator.EvalAsync(expression);
                resultText = result.ToString();

            }
            catch (Tokenizer.TokenException ex)
            {
                textError.Text = ex.Message;
                return;
            }
            catch (Exception ex)
            {
                resultText = ex.Message;
            }
            var resultItem = new ListViewItem(new[] { expression, resultText });
            listResults.Items.Add(resultItem);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            listResults.Items.Clear();
        }

        private void listResults_ItemActivate(object sender, EventArgs e)
        {
            if (listResults.SelectedItems.Count > 0)
                textExpression.Text = listResults.SelectedItems[0].Text;
        }
    }
}
