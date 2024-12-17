using System;
using System.Windows.Forms;
using System.Drawing;

public class QuadraticForm : Form
{
    private TextBox textBoxA, textBoxB, textBoxC;
    private Button plotButton;
    private Panel graphPanel;

    public QuadraticForm()
    {
        this.Text = "Gráfico de Função Quadrática";
        this.Size = new Size(800, 600);

        Label labelA = new Label() { Text = "Coeficiente a:", Location = new Point(20, 20) };
        textBoxA = new TextBox() { Location = new Point(120, 20) };

        Label labelB = new Label() { Text = "Coeficiente b:", Location = new Point(20, 60) };
        textBoxB = new TextBox() { Location = new Point(120, 60) };

        Label labelC = new Label() { Text = "Coeficiente c:", Location = new Point(20, 100) };
        textBoxC = new TextBox() { Location = new Point(120, 100) };

        plotButton = new Button() { Text = "Plotar Gráfico", Location = new Point(20, 140) };
        plotButton.Click += new EventHandler(PlotButton_Click);

        graphPanel = new Panel() { Location = new Point(20, 180), Size = new Size(740, 360), BorderStyle = BorderStyle.FixedSingle };

        this.Controls.Add(labelA);
        this.Controls.Add(textBoxA);
        this.Controls.Add(labelB);
        this.Controls.Add(textBoxB);
        this.Controls.Add(labelC);
        this.Controls.Add(textBoxC);
        this.Controls.Add(plotButton);
        this.Controls.Add(graphPanel);
    }

    private void PlotButton_Click(object sender, EventArgs e)
    {
        double a = double.Parse(textBoxA.Text);
        double b = double.Parse(textBoxB.Text);
        double c = double.Parse(textBoxC.Text);

        using (Graphics g = graphPanel.CreateGraphics())
        {
            g.Clear(Color.White);
            Pen pen = new Pen(Color.Blue, 2);
            
            for (int x = -graphPanel.Width / 2; x < graphPanel.Width / 2; x++)
            {
                double y = a * x * x + b * x + c;
                Point point = new Point(x + graphPanel.Width / 2, graphPanel.Height / 2 - (int)y);
                g.DrawEllipse(pen, point.X, point.Y, 1, 1);
            }
        }

        // Cálculos avançados
        double vertexX = -b / (2 * a);
        double vertexY = a * vertexX * vertexX + b * vertexX + c;
        MessageBox.Show($"Vértice: ({vertexX}, {vertexY})");

        double delta = b * b - 4 * a * c;
        if (delta >= 0)
        {
            double root1 = (-b + Math.Sqrt(delta)) / (2 * a);
            double root2 = (-b - Math.Sqrt(delta)) / (2 * a);
            MessageBox.Show($"Raízes: {root1} e {root2}");
        }
        else
        {
            MessageBox.Show("A função não possui raízes reais.");
        }
    }

    [STAThread]
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new QuadraticForm());
    }
}
