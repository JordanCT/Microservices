use db_transactions;
db.transactions.insertOne(
    {
        "id_invoice": 2,
        "amount": {
            "$numberDecimal": "100.0"
        },
        "date": {
            "$date": "2023-10-18T01:10:56.355Z"
        }
    });