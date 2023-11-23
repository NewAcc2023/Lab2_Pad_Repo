using Lab2.Service;
using Microsoft.AspNetCore.Mvc;

namespace Lab2.Controllers
{
    public class BookController : ControllerBase
    {
        private readonly CurrencyConvertService _currencyConvertService;

        public BookController(CurrencyConvertService currencyConvertService)
        {
            _currencyConvertService = currencyConvertService;
        }


        public static List<KeyValuePair<int, string>> Books = new List<KeyValuePair<int, string>>
        {
            new KeyValuePair<int, string>(1,"Harry Potter"),
             new KeyValuePair<int, string>(2,"Will"),
              new KeyValuePair<int, string>(3,"The Great Gatsby"),
        };

        // Use SOAP to convert currency
        [HttpGet]
        [Route("/currency/")]
        public ActionResult<double> Convert(string from, string to, double amount)
        {
            try
            {
                // Call the SOAP service to perform currency conversion
                double convertedAmount = _currencyConvertService.CurrencyConvert(from, to, amount);

                // Return the result
                return Ok(convertedAmount);
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately
                return BadRequest($"Error converting currency: {ex.Message}");
            }
        }




        [HttpGet]
        [Route("/books/{id}")]
        public KeyValuePair<int, string> GeBookById(int id)
        {
            return Books.FirstOrDefault(x=>x.Key == id);
        }

        [HttpGet]
        [Route("/books")]
        public List<KeyValuePair<int, string>> GetAllBooks()
        {
            return Books;
        }

        [HttpPost]
        [Route("/books/post/{bookName}")]
        public KeyValuePair<int, string> GetAllBooks(string bookName)
        {
            Books.Add(new KeyValuePair<int, string>(Books.Count + 1, bookName));
            return Books.FirstOrDefault(x=>x.Key == Books.Count);
        }

        [HttpPut]
        [Route("/books/update/{id}/{newName}")]
        public KeyValuePair<int, string> Rename(int id,string newName)
        {
            var result = Books.FirstOrDefault(x => x.Key == id);
            if (result.Key!=0)
            {
                Books.Remove(result);
                Books.Add(new KeyValuePair<int, string>(result.Key, newName));
            }
            return Books.FirstOrDefault(x => x.Key == id);
        }

        [HttpDelete]
        [Route("/books/delete/{id}/")]
        public KeyValuePair<int, string> Delete(int id)
        {
            var result = Books.FirstOrDefault(x => x.Key == id);
            if (result.Key != 0)
            {
                Books.Remove(result);  
            }
            return result;
        }
    }
}
