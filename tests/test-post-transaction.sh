curl -X POST http://localhost:5275/api/transactions \
-H "Content-Type: application/json" \
-d '{
  "TransactionCurrencyCode": "USD",
  "LocalHour": "12:00",
  "TransactionScenario": "Online",
  "TransactionType": "Purchase",
  "TransactionIPaddress": "127.0.0.1",
  "IpState": "CA",
  "IpPostalCode": "90001",
  "IpCountry": "US",
  "BrowserLanguage": "en-US",
  "PaymentInstrumentType": "CreditCard",
  "CardType": "Visa",
  "PaymentBillingPostalCode": "90001",
  "PaymentBillingState": "CA",
  "PaymentBillingCountryCode": "US",
  "ShippingPostalCode": "90001",
  "ShippingState": "CA",
  "ShippingCountry": "US",
  "CvvVerifyResult": "Match"
}'
