# Zoho-Invoice-creation-via-CSV
A simple application for creating ZOHO invoices via a CSV file. It wil group the invoices based on the customername (or WorkOrderNumber if specified in the CustomerNamesWhichShouldBeGroupedByWorkOrderNumber property).

# To run this application

1. Fill in the properties in the appsettings.json
    - AccessToken: The accesstoken (see: Getting an accesstoken)
    - CustomerId: the zoho customerId for which the payments should be created
    - TransactionsFile: The path to the knab banking transactions file
    - OutputFile: The path used for creating a output file (so you can see the log)
    - OrganisationId: Your Zoho OrganisationId
    - TotalAmountOfHours: Is used to check if the sum of the orderlines quantity matches the total amount of hours
    - TaxId: Your Zoho tax id
    - InvoiceContactPersons: Your Zoho contactperson id's
    - CustomerNamesWhichShouldBeGroupedByWorkOrderNumber: The names of the customers of which the invoices should be created based on the workordernumber
    - InvoiceTemplateId: Your Zoho InvoiceTemplateId

Zoho specific id's (TaxId, InvoiceTemplateId, etc) can be found in the response of a existing invoice (you can use the GetInvoice test for getting a existing invoice).

# Limitations
- The format for the invoice ReferenceNumber is fixed

## Getting an accesstoken

1. Go to: https://api-console.zoho.com/
2. Create a "Self client"
3. Go to "Generate code" and use te following scope's to create a code

```
ZohoInvoice.fullaccess.all
```

4. Make a post:

```
curl --location --request POST 'https://accounts.zoho.com/oauth/v2/token' \
--form 'client_id="XXXXXXX"' \
--form 'client_secret="XXXXXXX"' \
--form 'grant_type="authorization_code"' \
--form 'code="XXXXXX"' \
--form 'expiry_time="1614935642077"'
```

5. This will give a response like this:

```
{
    "access_token": "XXXXXXXXXXX",
    "refresh_token": "XXXXXXXXXX",
    "api_domain": "https://www.zohoapis.com",
    "token_type": "Bearer",
    "expires_in": 3600
}
```

6. Use the access_token for subsequent requests:

```
curl --location --request GET 'https://invoice.zoho.com/api/v3/invoices' \
--header 'Authorization: Zoho-oauthtoken XXXXXXXXXXX' \
```