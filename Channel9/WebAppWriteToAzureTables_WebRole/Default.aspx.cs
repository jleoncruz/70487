using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.Storage.Queue;

namespace WebAppWriteToAzureTables_WebRole
{
    public partial class _Default : Page
    {
        CloudStorageAccount account = new CloudStorageAccount(
            new StorageCredentials("70487favouritequotes",
                "EiPFb3yN7/pUfn98bAWUyKuS+v7fDtPkXjelkA9mXO3fUftcZQ1I4nyy0YFl/UABsxoClabPcxgPCHKqGrrN/w=="), true);

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cmdAddQuote_Click(object sender, EventArgs e)
        {
            string quote = txtQuote.Text;
            string author = txtAuthor.Text;
            string submitter = txtSubmitter.Text;
            AddNewQuote(quote, author, submitter);
        }

        public void AddNewQuote(string quote, string author, string submitter)
        {
            // You could use local development storage
            //   account = CloudStorageAccount.DevelopmentStorageAccount;
            // Create the table client.
            CloudTableClient tableClient = account.CreateCloudTableClient();

            // Create the table if it doesn’t exist.
            CloudTable table = tableClient.GetTableReference("quotes");
            table.CreateIfNotExistsAsync();
            QuoteEntity quoteEntity = new QuoteEntity(quote, author);
            quoteEntity.Submitter = submitter;

            // Create the TableOperation that inserts the customer entity.
            TableOperation insertOperation = TableOperation.Insert(quoteEntity);

            // Execute the insert operation.
            table.Execute(insertOperation);

            lblMessage.Text = "Done with one row insert";
        }

        protected void cmdAddBatch_Click(object sender, EventArgs e)
        {
            // Create the table client.
            CloudTableClient tableClient = account.CreateCloudTableClient();

            // Create the CloudTable object that represents the "quotes" table.
            CloudTable table = tableClient.GetTableReference("quotes");
            table.CreateIfNotExistsAsync();
            // Create the batch operation.
            TableBatchOperation batchOperation = new TableBatchOperation();

            // Create a quote entity and add it to the table.
            QuoteEntity quote1 = new QuoteEntity("The critic has to educate the public. The artist has to educate the critic.", "Oscar Wilde");
            quote1.Submitter = "Bruno";

            //// Create a quote entity and add it to the table.
            QuoteEntity quote2 = new QuoteEntity("I have the simplest tastes. I am always satisfied with the best", "Oscar Wilde");
            quote2.Submitter = "Bruno";

            // Add both customer entities to the batch insert operation.
            batchOperation.Insert(quote1);
            batchOperation.Insert(quote2);

            // Execute the batch operation.
            table.ExecuteBatch(batchOperation);
            lblMessage.Text = "Done with batch";
        }

        protected void cmdGetOscarWildeQuotes_Click(object sender, EventArgs e)
        {
            lbQuotes.Visible = true;
            // Create the table client.
            CloudTableClient tableClient = account.CreateCloudTableClient();

            // Create the CloudTable object that represents the "quotes" table.
            CloudTable table = tableClient.GetTableReference("quotes");
            // Construct the query operation for all customer entities where PartitionKey="Oscar Wilde".
            TableQuery<QuoteEntity> query = new TableQuery<QuoteEntity>()
                .Where(TableQuery.GenerateFilterCondition("PartitionKey",
                QueryComparisons.Equal,
                "Oscar Wilde"));

            // Print the fields for each customer.
            foreach (QuoteEntity entity in table.ExecuteQuery(query))
            {
                lbQuotes.Items.Add(new ListItem { Text = entity.RowKey });
            }

            lblMessage.Text = "Done with select";
        }
    }

    public class QuoteEntity : TableEntity
    {
        public QuoteEntity(string quote, string author)
        {
            this.PartitionKey = author;
            this.RowKey = quote;
        }
        public QuoteEntity() { }
        public string Submitter { get; set; }
    }
}