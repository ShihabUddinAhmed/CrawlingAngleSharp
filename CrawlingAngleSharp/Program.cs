using AngleSharp;
using AngleSharp.Dom;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CrawlingAngleSharp
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);

            var url = "https://medicalalley.org/partner-directory/partner/?member_id=60661";

            var doc = await context.OpenAsync(url);
            // var title = doc.QuerySelector("title").InnerHtml;
            var title = doc.Title;

            Console.WriteLine(title);

            var aboutText = doc.GetElementsByClassName("member-description body").FirstOrDefault();
            Console.WriteLine(aboutText.Text().Trim());
            doc.Close();

            var url1 = "https://www.crunchbase.com/organization/allina-health-a9e5";

            var doc1 = await context.OpenAsync(url1);
            // var title = doc.QuerySelector("title").InnerHtml;
            var title1 = doc1.Title;

            Console.WriteLine(title1);

            var address = doc1.GetElementsByClassName("field-type-identifier-multi").FirstOrDefault();
            var employeeNumber = doc1.GetElementsByClassName("component--field-formatter field-type-enum accent highlight-color-contrast-light ng-star-inserted").FirstOrDefault();
            var LastFundingType = doc1.GetElementsByClassName("component--field-formatter field-type-enum accent highlight-color-contrast-light ng-star-inserted").Skip(1).FirstOrDefault();
            var moneyRaised = doc1.GetElementsByClassName("component--field-formatter field-type-money ng-star-inserted").FirstOrDefault();
            var phoneNumber = doc1.GetElementsByTagName("fields-card").Skip(3).FirstOrDefault();
            Console.WriteLine(address.Text().Trim());
            Console.WriteLine(employeeNumber.Text().Trim());
            Console.WriteLine(moneyRaised.Text().Trim());
            Console.WriteLine(LastFundingType.Text().Trim());
            Console.WriteLine(phoneNumber.Text().Trim("Phone Number ".ToCharArray()));

            //foreach (var par in phoneNumber)
            //{
            //    Console.WriteLine("For Phone Number \n\n\n" + par.Text().Trim());
            //}
            doc1.Close();

            //Console.Read();
            //var pars = doc.QuerySelectorAll("p");

            //foreach (var par in pars)
            //{
            //    Console.WriteLine(par.Text().Trim());
            //}

            //From LinkedIn Pages
            Console.WriteLine("\n\nLinkedIn Parsing:\n\n");
            var url2 = "https://www.linkedin.com/company/zurich-medical-inc-/";

            var doc2 = await context.OpenAsync(url2);
            // var title = doc.QuerySelector("title").InnerHtml;
            var title2 = doc2.Title;

            Console.WriteLine(title2);

            var website = doc2.QuerySelector("[data-test-id='about-us__website']")?.QuerySelector("dd")?.QuerySelector("a");
            var industries = doc2.QuerySelector("[data-test-id='about-us__industries']")?.QuerySelector("dd");
            var employeeSize = doc2.QuerySelector("[data-test-id='about-us__size']")?.QuerySelector("dd");
            var headquaters = doc2.QuerySelector("[data-test-id='about-us__headquarters']")?.QuerySelector("dd");
            var organizationType = doc2.QuerySelector("[data-test-id='about-us__organizationType']")?.QuerySelector("dd");
            var foundDate = doc2.QuerySelector("[data-test-id='about-us__foundedOn']")?.QuerySelector("dd");
            var funding = doc2.QuerySelector("[data-test-id='funding']")?.QuerySelector("[id='external-link-last-round']");
            Console.WriteLine(website.Text().Trim());
            Console.WriteLine(industries.Text().Trim());
            Console.WriteLine(employeeSize.Text().Trim());
            Console.WriteLine(headquaters.Text().Trim());
            Console.WriteLine(organizationType.Text().Trim());
            Console.WriteLine(foundDate.Text().Trim());
            Console.WriteLine(funding.Text().Trim());
            
            //foreach (var par in phoneNumber)
            //{
            //    Console.WriteLine("For Phone Number \n\n\n" + par.Text().Trim());
            //}
            doc2.Close();

            Console.Read();
        }
    }
}
