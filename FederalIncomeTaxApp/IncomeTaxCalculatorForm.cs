/*
 * File: IncomeTaxCalculatorForm.cs
 * Author: Miguel Duran 841-17-1372
 * Course: COTI 4150-KJ1 Prof. Antonio F. Huertas
 * Date: 02/18/2021
 * Purpose: This form calculates and displays the income tax owed for the given
 *          taxable income and tax percent.
 */

using System;
using System.Windows.Forms;

namespace FederalIncomeTaxApp
{
    public partial class IncomeTaxCalculatorForm : Form
    {
        // Creates a new form.
        public IncomeTaxCalculatorForm()
        {
            InitializeComponent();
        }

        // Closes this form when the Exit button is clicked.
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Calculates the income tax owed based on the value entered when the 
        // Calculate button is clicked.
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                decimal taxIncome = Convert.ToInt32(txtTaxableIncome.Text);
                decimal taxPercent = 0.0M;
                decimal taxOwed = FederalTaxIncome(taxIncome, taxPercent);
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid number. Value must be an integer.", "Entry Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (OverflowException)
            {
                MessageBox.Show("Overflow error. Enter smaller values.", "Entry Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message, "Processing Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.GetType().ToString() +
                    "\n" + ex.StackTrace, "Exception Caught",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // Calculates the income tax owed based on the given taxable income, tax percent
        private decimal FederalTaxIncome(decimal taxIncome, decimal taxPercent)
        {
            decimal taxOwed = 0.0M;
            if (taxIncome >= 413200.0M)
            {
                taxPercent = .396M;
                taxOwed = (Decimal.ToInt32((taxIncome - 413200.0M) * taxPercent) + 119996.25M);
                txtIncomeTaxOwed.Text = taxOwed.ToString("c");
            }
            else if (taxIncome >= 411500.0M)
            {
                taxPercent = .35M;
                taxOwed = (Decimal.ToInt32((taxIncome - 411500.0M) * taxPercent) + 119401.25M);
                txtIncomeTaxOwed.Text = taxOwed.ToString("c");
            }
            else if (taxIncome >= 189300.0M)
            {
                taxPercent = .33M;
                taxOwed = (Decimal.ToInt32((taxIncome - 189300.0M) * taxPercent) + 46675.25M);
                txtIncomeTaxOwed.Text = taxOwed.ToString("c");
            }
            else if (taxIncome >= 90750.0M)
            {
                taxPercent = .28M;
                taxOwed = (Decimal.ToInt32((taxIncome - 90750.0M) * taxPercent) + 18481.25M);
                txtIncomeTaxOwed.Text = taxOwed.ToString("c");
            }
            else if (taxIncome >= 37450.0M)
            {
                taxPercent = .25M;
                taxOwed = (Decimal.ToInt32((taxIncome - 37450.0M) * taxPercent) + 5156.25M);
                txtIncomeTaxOwed.Text = taxOwed.ToString("c");
            }
            else if (taxIncome >= 9225.0M)
            {
                taxPercent = .15M;
                taxOwed = (Decimal.ToInt32((taxIncome - 9225.0M) * taxPercent) + 922.50M);
                txtIncomeTaxOwed.Text = taxOwed.ToString("c");
            }
            else if (taxIncome >= 0.0M)
            {
                taxPercent = .10M;
                taxOwed = (Decimal.ToInt32((taxIncome - 0.0M) * taxPercent) + 0M);
                txtIncomeTaxOwed.Text = taxOwed.ToString("c");
            }
            else if (taxIncome < 0.0M)
            {
                throw new ArgumentOutOfRangeException(
                    "Taxable Income", "Taxable Income Must Be Positive");
            }
            return taxOwed;
        }

        // Clears the tax owed textbox when the input text changes.
        private void input_TextChanged(object sender, EventArgs e)
        {
            txtIncomeTaxOwed.Clear();
        }
    }
}
