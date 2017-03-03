using System;
using System.Collections.Generic;
using FisherInsuranceApi.Models;

namespace FisherInsuranceApi.Data
{
    public class MemoryStore : IMemoryStore
    {
        // A list that runs in-memory and holds quotes
        private Dictionary<int, Quote> quotes;

        // Constructor. This fills our in memory store with quotes for Auto Insurance
        public MemoryStore()
        {
            quotes = new Dictionary<int, Quote>();

                        new List<Quote>
            {
                new Quote { Product="Auto", ExpireDate=DateTime.Now.AddDays(45), Price=350.00M }, 
                new Quote { Product="Auto", ExpireDate=DateTime.Now.AddDays(45), Price=300.00M },
                new Quote { Product="Auto", ExpireDate=DateTime.Now.AddDays(45), Price=450.00M },
                new Quote { Product="Auto", ExpireDate=DateTime.Now.AddDays(45), Price=250.00M },
            }.ForEach(quote => this.CreateQuote(quote)); 
        }

        // Simulate 'Create' in data store
        public Quote CreateQuote(Quote quote)
        {
            if (quote.Id == 0)
            {
                int key = quotes.Count;

                while (quotes.ContainsKey(key))
                {
                    key++;
                };
                quote.Id = key;
            }
            quotes[quote.Id] = quote;
            return quote;
        }

        // Simulate 'Retrieve All' - a lambda expression for getting all quotes
        public IEnumerable<Quote> RetrieveAllQuotes => quotes.Values;

        // Simulate 'Retrieve'  - lambda expression for getting a specific quote; returns null if not found
        public Quote RetrieveQuote(int id) => quotes.ContainsKey(id) ? quotes[id] : null;

        // Simulate 'Update'  - lambda expression for getting a specific quote; returns null if not found
        public Quote UpdateQuote(Quote quote)
        {
            quotes[quote.Id] = quote;
            return quote;
        }

        // Simulate 'Delete'  
        public void DeleteQuote(int id)
        {
            quotes.Remove(id);
        }


    }
}