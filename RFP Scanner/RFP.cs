using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.ML;
using System.Linq.Expressions;
using Org.BouncyCastle.Asn1.Cmp;
using Org.BouncyCastle.Pqc.Crypto.Lms;
using Org.BouncyCastle.Utilities;
using static iTextSharp.text.pdf.events.IndexEvents;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace RFP_Scanner
{
    public partial class RFP : Form
    {
        string pdfText = string.Empty;
        public RFP()
        {
            InitializeComponent();
            ApplyCustomStyling();
            customProgressBar.Visible = false; // Initially hide the progress bar
            lblScanInProgress.Visible = false;
            lblStatus.Visible = false;
            //lstProducts.Visible = false;
        }

        private void ApplyCustomStyling()
        {
            this.BackColor = Color.FromArgb(240, 240, 240);

            var modernFont = new Font("Segoe UI", 10);

            uploadbtn.Font = modernFont;
            uploadbtn.FlatStyle = FlatStyle.Flat;
            uploadbtn.BackColor = Color.FromArgb(0, 120, 215);
            uploadbtn.ForeColor = Color.White;
            uploadbtn.FlatAppearance.BorderSize = 0;
            uploadbtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 150, 245);

            btnFindProducts.Font = modernFont;
            btnFindProducts.FlatStyle = FlatStyle.Flat;
            btnFindProducts.BackColor = Color.FromArgb(0, 120, 215);
            btnFindProducts.ForeColor = Color.White;
            btnFindProducts.FlatAppearance.BorderSize = 0;
            btnFindProducts.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 150, 245);
            btnFindProducts.AutoSize = true;

            flowLayoutPanel1.BackColor = Color.FromArgb(230, 230, 230); // Light gray background
            flowLayoutPanel1.Padding = new Padding(5);  // Padding around the panel
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.AutoScroll = true;



        }

        private  async void btnUploadPDF_Click(object sender, EventArgs e)
        {
            lblStatus.Visible = false;
            // Create OpenFileDialog to upload a PDF
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "PDF Files (*.pdf)|*.pdf",
                Title = "Select a PDF File"
            };

            // Show dialog and check if the user selected a file
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                // Reset and show progress bar
                customProgressBar.Value = 0;
                customProgressBar.Visible = true;
                lblScanInProgress.Visible = true;
                // Read PDF contents with progress
                pdfText = await ReadPdfFileWithProgressAsync(filePath);

                // Hide progress bar after completion
                customProgressBar.Visible = false;
                lblScanInProgress.Visible = false;
                // Display PDF content in the TextBox
                
            }
        }

        private int ScanContent(string pdfText)
        {
            int count = 0;
            // Initialize MLContext
            var mlContext = new MLContext();
            string rfpText = pdfText;
            // Define product-related keywords
            var products = new List<Product>
            {
                new Product
                {
                    Name = "OpenSCADA",
                    Keywords = new List<string> { "supervisory control", "control center", "Scada", "alarms", "status points", "analog points", "tags", "limits", "quality", "point dialog", "data acquisition", "master station", "remote stations", "central monitoring system", "energy management system", "Displays", "notes SLD" }
                },
                new Product
                {
                    Name = "OpenFEP",
                    Keywords = new List<string> { "Front end processor", "Communications server", "DNP 3.0", "IEC 60870-5-101", "IEC 60870-5-104",
                    "Modbus", "CDC Type I and II, Conitel", "Harris, SC1801", "L&G 8979", "PG&E", "Valmet Series V protocols", "RTU", "FRTU", "IEDs", "controls"}
                },
                new Product
                {
                    Name = "OpenHIS",
                    Keywords = new List<string> { "Archival", "SQL", "historical", "RDBMS", "storage", "retrieval rows", "columns", "tables", "MS SQL", "Oracle", "Postgres", "mysql" }

                },
                new Product
                {
                    Name = "Webplatform",
                    Keywords = new List<string> { "Web SCADA", "web application", "lite users", "web/mobiles based applications", "light weight client", "web browser client", "REST data services", "replica site", "CORP" }
                },
                new Product
                {
                    Name = "Advanced Tabulars",
                    Keywords = new List<string> { "Tabular displays", "tables", "data grid", "filters" }
                },
                new Product
                {
                    Name = "System Explorer",
                    Keywords = new List<string> { "Displays", "SLDs", "symbols", "color codes", "pages", "navigation" }
                },
                new Product
                {
                    Name = "OpenODBC",
                    Keywords = new List<string> { "ODBC", "Open Database Connectivity interface", "ODBC driver" }
                },
                new Product
                {
                    Name = "DataExplorer",
                    Keywords = new List<string> { "Data maintenance", "data validation", "data commit", "modify database", "new records", "rollout", "data grouping", "exporting data", "importing data", "rollback data changes" }
                }
            };
            // Use ML.NET to featurize the text and find matches
            var foundProducts = FindMatchingProducts(mlContext, rfpText, products);
            if (foundProducts.Count > 0)
            {
                count = foundProducts.Count;
                //lstProducts.Visible = true;
                // Output the found products and their matching keywords
                foreach (var product in foundProducts)
                {
                    ProductInfo productInfo = new ProductInfo();
                    productInfo.ProductName = product.Name;
                    flowLayoutPanel1.Controls.Add(productInfo);
                    //lstProducts.Items.Add(productInfo);
                    //lstProducts.Items.Add($"Product: {product.Name}");
                    //Console.WriteLine($"Product: {product.Name}");
                    //Console.WriteLine("Matched Keywords:");
                    //product.Keywords.ForEach(kw => Console.WriteLine($"- {kw}"));
                    //Console.WriteLine();
                }
                
            }
            else
            {
                //lstProducts.Visible = false;
            }
            return count;
        }
        private void btnFindProducts_Click(object sender, EventArgs e)
        {
            //txtPDFContent.Text
            if (!string.IsNullOrWhiteSpace(pdfText))
            {
                var numProd = ScanContent(pdfText);
                lblStatus.Text = "Scan in Progress!";
                lblStatus.Visible = true;

                if (numProd > 0)
                {
                    lblStatus.Text = $"Found {numProd} Products";
                }
                else
                {
                    lblStatus.Text = $"No Products Found";
                }
            }
            else
                MessageBox.Show("Content is Empty or Error reading the file");
        }
        // Helper method to update the progress bar safely from any thread
        private void UpdateProgress(int progress)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    customProgressBar.Value = progress;
                }));
            }
            else
            {
                customProgressBar.Value = progress;
            }
        }
        // Async function to read PDF content and report progress
        private async Task<string> ReadPdfFileWithProgressAsync(string filePath)
        {
            string result = string.Empty;

            // Run the file reading task in a separate thread to keep UI responsive
            await Task.Run(() =>
            {
                try
                {
                    using (PdfReader reader = new PdfReader(filePath))
                    {
                        int totalPages = reader.NumberOfPages;

                        // Loop through each page of the PDF
                        for (int i = 1; i <= totalPages; i++)
                        {
                            try
                            {
                                // Extract text from each page, handle potential null or empty pages
                                string pageText = PdfTextExtractor.GetTextFromPage(reader, i);

                                // Check if text extraction returned something
                                if (string.IsNullOrEmpty(pageText))
                                {
                                    // Log the issue for further investigation
                                    Console.WriteLine($"Warning: No text extracted from page {i}. Skipping...");
                                }
                                else
                                {
                                    result += pageText;
                                }
                            }
                            catch (Exception ex)
                            {
                                // Log or show the error for individual page extraction
                                MessageBox.Show($"Error extracting text from page {i}: {ex.Message}");
                            }

                            // Report progress to the UI thread
                            int progress = (i * 100) / totalPages;
                            UpdateProgress(progress);
                        }
                    }
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Error reading the PDF file: " + ex.Message);
                }
            });

            return result;
        }

        // Function to read PDF content
        private string ReadPdfFile(string filePath)
        {
            string result = string.Empty;

            try
            {
                using (PdfReader reader = new PdfReader(filePath))
                {
                    for (int i = 1; i <= reader.NumberOfPages; i++)
                    {
                        result += PdfTextExtractor.GetTextFromPage(reader, i);
                    }
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error reading the PDF file: " + ex.Message);
            }

            return result;
        }

        static List<Product> FindMatchingProducts(MLContext mlContext, string rfpText, List<Product> products)
        {
            // Create data for RFP input
            var rfpData = new List<RfpInput> { new RfpInput { Text = rfpText } };

            // Load RFP data into IDataView
            IDataView dataView = mlContext.Data.LoadFromEnumerable(rfpData);

            // Build the text featurization pipeline
            var textPipeline = mlContext.Transforms.Text.FeaturizeText("Features", nameof(RfpInput.Text))
                .Append(mlContext.Transforms.NormalizeMinMax("Features"));

            // Apply text featurization pipeline
            var transformedData = textPipeline.Fit(dataView).Transform(dataView);

            // Get the feature vector for the RFP document
            var featurePreview = mlContext.Data.CreateEnumerable<RfpInput>(transformedData, reuseRowObject: false).First();

            // Convert RFP text to lowercase for case-insensitive matching
            string lowerCaseRfp = rfpText.ToLower();

            // List to store products found in the document
            var foundProducts = new List<Product>();

            foreach (var product in products)
            {
                // Find keywords that are present in the RFP document
                var matchedKeywords = product.Keywords
                    .Where(keyword => lowerCaseRfp.Contains(keyword.ToLower()))
                    .ToList();

                // If any keywords match, add the product to the found list
                if (matchedKeywords.Any())
                {
                    foundProducts.Add(new Product
                    {
                        Name = product.Name,
                        Keywords = matchedKeywords
                    });
                }
            }

            return foundProducts;
        }

        private void  lblStatus_TextChanged(object sender, EventArgs e)
        {
            //lblStatus.Text = "There are no products that matches the RFP";

        }
    }
}
